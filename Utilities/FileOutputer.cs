﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vic3MapMaker
{
    internal class FileOutputer
    {
        public string outputDirectory;

        public FileOutputer(string outputDirectory) {
            this.outputDirectory = outputDirectory;
        }

        //output state_regions files
        public void WriteStateRegions(HashSet<Region> regionSet) {
            //check if the folder exists
            if (!File.Exists(outputDirectory + "\\_output\\map_data\\state_regions\\")) {
                Directory.CreateDirectory(outputDirectory + "\\_output\\map_data\\state_regions\\");
            }

            //group regions by superregion and remove any regions that has no states with provs
            var superRegionGroups = regionSet.GroupBy(r => r.superRegion).Where(g => g.Any(r => r.states.Any(s => s.provDict.Count > 0)));
            
            //for each superregion
            foreach (var superRegionGroup in superRegionGroups) {
                string superRegionName = superRegionGroup.Key;
                if (superRegionName == "") {
                    superRegionName = "default";
                }

                //file path
                string filePath = outputDirectory + "\\_output\\map_data\\state_regions\\" + superRegionName + ".txt";
                //pass the file path and the regions in the superregion to the write function
                WriteStateRegions(superRegionGroup.ToList(), filePath);
            }
            

        }
        private void WriteStateRegions(List<Region> regionList, String path) {
            using (StreamWriter sw = File.CreateText(path)) {
                //region.states hashset to list sorted by state name
                //List<State> stateList = region.states.ToList();

                //sort regionList by region name
                regionList.Sort((x, y) => x.name.CompareTo(y.name));
                foreach (Region region in regionList) {
                    sw.WriteLine("#" + region.name);
                    //sort stateList by state name
                    List<State> stateList = region.states.ToList();
                    foreach (State state in stateList) {
                        //if stae has no provs, skip
                        if (state.provDict.Count == 0) {
                            continue;
                        }

                        sw.WriteLine(state.name + " = {");
                        sw.WriteLine("\tid = " + state.stateID);
                        sw.WriteLine("\tsubsistence_building = \"" + state.subsistenceBuilding + "\"");

                        sw.Write("\tprovinces = { ");
                        //write each prov color in hex for each state.provDict
                        foreach (KeyValuePair<Color, Province> prov in state.provDict) {
                            sw.Write(prov.Value.NameHex() + " ");
                        }
                        sw.WriteLine("}");

                        List<Province> primeLand = state.provDict.Values.Where(x => x.isPrimeLand).ToList();
                        List<Province> impassable = state.provDict.Values.Where(x => x.isImpassible).ToList();
                        if (primeLand.Count > 0) {
                            sw.Write("\tprime_land = { ");
                            foreach (Province prov in primeLand) {
                                sw.Write(prov.NameHex() + " ");
                            }
                            sw.WriteLine("}");
                        }
                        if (impassable.Count > 0) {
                            sw.Write("\timpassable = { ");
                            foreach (Province prov in impassable) {
                                sw.Write(prov.NameHex() + " ");
                            }
                            sw.WriteLine("}");
                        }


                        if (state.traits.Count > 0) {
                            sw.WriteLine("\ttraits = { \"" + string.Join("\" \"", state.traits) + "\" }");
                        }

                        state.GenerateHubList();

                        //for each hub in state.hubList
                        if (state.hubList.Count > 0) {
                            foreach ((string hubName, string provName) in state.hubList) {
                                sw.WriteLine("\t" + hubName + " = " + provName);
                            }
                        }

                        sw.WriteLine("\tarable_land = " + state.arableLand);
                        List<Resource> arableList = state.resources.FindAll(x => x.type == "agriculture");
                        List<Resource> cappedList = state.resources.FindAll(x => x.type == "resource");
                        List<Resource> discoverableList = state.resources.FindAll(x => x.type == "discoverable");

                        if (arableList.Count > 0) {
                            sw.Write("\tarable_resources = {");
                            foreach (Resource res in arableList) {
                                sw.Write(" \"" + res.name + "\"");
                            }
                            sw.WriteLine(" }");
                        }

                        if (cappedList.Count > 0) {
                            sw.WriteLine("\tcapped_resources = {");
                            foreach (Resource res in cappedList) {
                                sw.WriteLine("\t\t" + res.name + " = " + res.knownAmmount);
                            }
                            sw.WriteLine(" }");
                        }

                        if (discoverableList.Count > 0) {
                            foreach (Resource res in discoverableList) {
                                sw.WriteLine("\tresource = {");
                                sw.WriteLine("\t\ttype = \"" + res.name + "\"");
                                if (res.discoverableAmmount > 0)
                                    sw.WriteLine("\t\tundiscovered_amount = " + res.discoverableAmmount);
                                if (res.knownAmmount > 0)
                                    sw.WriteLine("\t\tdiscovered_amount = " + res.knownAmmount);
                                sw.WriteLine("\t}");
                            }
                        }
                        if (state.navalID >= 0) {
                            sw.WriteLine("\tnaval_exit_id = " + state.navalID);
                        }

                        sw.WriteLine("}");

                    }
                }
                sw.Close();
            }
        }
        
        public void WriteRegions(HashSet<Region> regionSet) {
            //check if the folder exists
            if (!File.Exists(outputDirectory + "\\_output\\common\\strategic_regions\\")) {
                Directory.CreateDirectory(outputDirectory + "\\_output\\common\\strategic_regions\\");
            }

            //group regions by region.supperRegion
            Dictionary<string, List<Region>> supperRegionDict = new Dictionary<string, List<Region>>();
            foreach (Region region in regionSet) {
                if (region.superRegion == "") {
                    region.superRegion = "zz_misc_strategic_region";
                }
                if (supperRegionDict.ContainsKey(region.superRegion)) {
                    supperRegionDict[region.superRegion].Add(region);
                }
                else {
                    supperRegionDict.Add(region.superRegion, new List<Region>());
                    supperRegionDict[region.superRegion].Add(region);
                }
            }

            //write each region in supperRegionDict
            foreach (KeyValuePair<string, List<Region>> entry in supperRegionDict) {
                string path = outputDirectory + "\\_output\\common\\strategic_regions\\" + entry.Key + ".txt";
                using (StreamWriter sw = File.CreateText(path)) {
                    foreach (Region region in entry.Value) {
                        //if region has no states, skip
                        if (region.states.Count == 0) {
                            continue;
                        }

                        sw.WriteLine(region.name + " = {");
                        if(region.gfxCulture != "") {
                            sw.WriteLine("\tgraphical_culture = \"" + region.gfxCulture + "\"");
                        }
                        if (region.capital != null) { 
                            sw.WriteLine("\tcapital_province = " + region.capital.NameHex());
                        }
                        else {
                            Console.WriteLine("Region " + region.name + " has no capital set");
                        }
                        sw.WriteLine("\tcolor = { " + region.color.R + " " + region.color.G + " " + region.color.B + " }");
                        sw.WriteLine("\tstates = { " + string.Join(" ", region.states.Select(x => x.name).ToList()) + " }");
                        sw.WriteLine("}");
                    }
                    sw.Close();
                }
            }
        }
        
        //output province_terrains.txt
        public void WriteTerrain(HashSet<Province> provSet) {
            List<Province> provList = provSet.ToList();

            //sort by prov internal ID
            provList.Sort((x, y) => x.internalID.CompareTo(y.internalID));

            //remove any duplicate names from the list
            //provList = provList.GroupBy(x => x.name).Select(x => x.First()).ToList();

            string path = outputDirectory + "\\_output\\map_data\\province_terrains.txt";

            using (StreamWriter sw = File.CreateText(path)) {
                sw.WriteLine("#This is a generated file, do not modify unless you know what you are doing!");
                foreach (Province prov in provList) {
                    if (prov.internalID > 0) {
                        sw.WriteLine(prov.NameHex().Replace("\"","") + "=\"" + prov.terrain + "\"");
                    }
                }
                sw.Close();
            }

        }
    }
}