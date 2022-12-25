using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vic3MapMaker.DataFiles;

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
            if (!File.Exists(outputDirectory + "\\map_data\\state_regions\\")) {
                Directory.CreateDirectory(outputDirectory + "\\map_data\\state_regions\\");
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
                string filePath = outputDirectory + "\\map_data\\state_regions\\" + superRegionName + ".txt";
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
            if (!File.Exists(outputDirectory + "\\common\\strategic_regions\\")) {
                Directory.CreateDirectory(outputDirectory + "\\common\\strategic_regions\\");
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
                string path = outputDirectory + "\\common\\strategic_regions\\" + entry.Key + ".txt";
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
                            Console.WriteLine("region " + region.name + " has no capital set");
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

            string path = outputDirectory + "\\map_data\\province_terrains.txt";

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

        //output country_definitions
        public void WriteCountryDefinitions(HashSet<Nation> nationSet) {
            //if outputDirectory/common/country_definitons doesn't exist, create it
            if (!File.Exists(outputDirectory + "\\common\\country_definitions\\")) {
                Directory.CreateDirectory(outputDirectory + "\\common\\country_definitions\\");
            }

            //sort nations by tag
            List<Nation> nationList = nationSet.ToList();
            nationList.Sort((x, y) => x.tag.CompareTo(y.tag));

            //create a new file 00_countries.txt
            string path = outputDirectory + "\\common\\country_definitions\\00_countries.txt";
            using (StreamWriter sw = File.CreateText(path)) {
                foreach(Nation n in nationList) {
                    sw.WriteLine(n.tag + " = {");
                    sw.WriteLine("\tcolor = { " + n.color.R + " " + n.color.G + " " + n.color.B + " }\n");
                    sw.WriteLine("\tcountry_type = " + n.type + "\n");
                    sw.WriteLine("\ttier = " + n.tier + "\n");
                    //write all culture names in the culture list to the file
                    sw.WriteLine("\tculture = { " + string.Join(" ", n.cultures) + " }");
                    if(n.capital != null)
                        sw.WriteLine("\tcapital = " + n.capital.name);
                    else {
                        Console.WriteLine("Nation " + n.tag + " has a null capital");
                    }
                    if(n.isNamedFromCapital)
                        sw.WriteLine("\tis_named_from_capital = yes");
                    sw.WriteLine("}");

                }
            }
        }

        //output history/states
        public void WriteHistoryStates(HashSet<Nation> NationsSet) {
            //if outputDirectory/history/states doesn't exist, create it
            if (!File.Exists(outputDirectory + "\\common\\history\\states\\")) {
                Directory.CreateDirectory(outputDirectory + "\\common\\history\\states\\");
            }

            //create a hashset of all substates
            HashSet<SubState> subStates = new HashSet<SubState>();
            foreach (Nation n in NationsSet) {
                //add all substates to the hashset
                foreach (SubState s in n.subStates) {
                    subStates.Add(s);
                }
            }


            //group substates by substate.parentState
            Dictionary<State, List<SubState>> parentStateDict = new Dictionary<State, List<SubState>>();
            foreach (SubState subState in subStates) {
                if (parentStateDict.ContainsKey(subState.parentState)) {
                    parentStateDict[subState.parentState].Add(subState);
                }
                else {
                    parentStateDict.Add(subState.parentState, new List<SubState>());
                    parentStateDict[subState.parentState].Add(subState);
                }
            }

            string path = outputDirectory + "\\common\\history\\states\\00_states.txt";
            using (StreamWriter sw = File.CreateText(path)) {
                sw.WriteLine("STATES = {");
                foreach (KeyValuePair<State, List<SubState>> entry in parentStateDict) {
                    sw.WriteLine("\ts:"+entry.Key.name + " = {");
                    foreach (SubState substate in entry.Value) {
                        sw.WriteLine("\t\tcreate_state = {");
                        sw.WriteLine("\t\t\tcountry = c:" + substate.owner.tag + "");
                        if (substate.type != "") {
                            sw.WriteLine("\t\t\tstate_type = " + substate.type);
                        }
                        //find all keys in substate.owner.provDict are also in substate.parrentState.provDict and return the values
                        List<Province> provList = substate.parentState.provDict.Keys.Where(x => substate.owner.provDict.ContainsKey(x)).Select(x => substate.owner.provDict[x]).ToList();
                        //write provList.hexName joined by a space
                        sw.WriteLine("\t\t\towned_provinces = { " + string.Join(" ", provList.Select(x => x.NameHex().Replace("\"","")).ToList()) + " }");

                        sw.WriteLine("\t\t}");
                    }
                    sw.WriteLine();
                    //if key has any claims, write them
                    if (entry.Key.claimList.Count > 0) {
                        foreach (string claim in entry.Key.claimList) {
                            sw.WriteLine("\t\tadd_claim =" + claim);
                        }
                    }
                    //if key has any homeland, write them
                    if (entry.Key.homeLandList.Count > 0) {
                        foreach (string homeland in entry.Key.homeLandList) {
                            sw.WriteLine("\t\tadd_homeland = " + homeland);
                        }
                    }

                    sw.WriteLine("\t}");

                }
                sw.WriteLine("}");
            }

        }

        //write history/pops
        public void WritePops(HashSet<Nation> nations, HashSet<Region> regions) {
            //if outputDirectory/history/pops doesn't exist, create it
            if (!File.Exists(outputDirectory + "\\common\\history\\pops\\")) {
                Directory.CreateDirectory(outputDirectory + "\\common\\history\\pops\\");
            }

            //create a hashset of all substates
            HashSet<SubState> subStates = new HashSet<SubState>();
            foreach (Nation n in nations) {
                //add all substates to the hashset
                foreach (SubState s in n.subStates) {
                    subStates.Add(s);
                }
            }

            //group substates by substate.parentState
            Dictionary<State, List<SubState>> parentStateDict = new Dictionary<State, List<SubState>>();
            foreach (SubState subState in subStates) {
                if (parentStateDict.ContainsKey(subState.parentState)) {
                    parentStateDict[subState.parentState].Add(subState);
                }
                else {
                    parentStateDict.Add(subState.parentState, new List<SubState>());
                    parentStateDict[subState.parentState].Add(subState);
                }
            }

            //group parentStateDict by the region they are in
            Dictionary<Region, Dictionary<State, List<SubState>>> regionDict = new Dictionary<Region, Dictionary<State, List<SubState>>>();
            //foreach region in regions hashset group parentStateDict by region
            foreach (Region region in regions) {
                regionDict.Add(region, new Dictionary<State, List<SubState>>());
                foreach (KeyValuePair<State, List<SubState>> entry in parentStateDict) {
                    if (region.states.Contains(entry.Key)) {
                        regionDict[region].Add(entry.Key, entry.Value);
                    }
                }
            }

            //group regionDict by region.superRegion
            Dictionary<string, Dictionary<Region, Dictionary<State, List<SubState>>>> superRegionDict = new Dictionary<string, Dictionary<Region, Dictionary<State, List<SubState>>>>();

            foreach (KeyValuePair<Region, Dictionary<State, List<SubState>>> entry in regionDict) {
                if (superRegionDict.ContainsKey(entry.Key.superRegion)) {
                    superRegionDict[entry.Key.superRegion].Add(entry.Key, entry.Value);
                }
                else {
                    superRegionDict.Add(entry.Key.superRegion, new Dictionary<Region, Dictionary<State, List<SubState>>>());
                    superRegionDict[entry.Key.superRegion].Add(entry.Key, entry.Value);
                }
            }

            //if a superRegion has no pops in it, remove it
            List<string> removeList = new List<string>();
            //from superRegionDict cascade down to substate List and check if it has any thing in its pop list
            foreach (KeyValuePair<string, Dictionary<Region, Dictionary<State, List<SubState>>>> superRegion in superRegionDict) {
                foreach (KeyValuePair<Region, Dictionary<State, List<SubState>>> region in superRegion.Value) {
                    foreach (KeyValuePair<State, List<SubState>> state in region.Value) {
                        foreach (SubState substate in state.Value) {
                            if (substate.pops.Count > 0) {
                                goto next;
                            }
                        }
                    }
                }
                removeList.Add(superRegion.Key);
                next:;
            }
            //remove all keys in superRegionDict that are in removeList
            foreach(string superRegion in removeList) {
                superRegionDict.Remove(superRegion);
            }



            //write a pop file for each superRegion
            foreach (KeyValuePair<string, Dictionary<Region, Dictionary<State, List<SubState>>>> superRegion in superRegionDict) {
                string path = outputDirectory + "\\common\\history\\pops\\" + superRegion.Key + ".txt";
                using (StreamWriter sw = File.CreateText(path)) {
                    sw.WriteLine("pops = {");
                    foreach (KeyValuePair<Region, Dictionary<State, List<SubState>>> Region in superRegion.Value) {
                        sw.WriteLine("\t#" + Region.Key.name);
                        foreach(KeyValuePair<State,List<SubState>> State in Region.Value) {
                            sw.WriteLine("\ts:" + State.Key.name + " = {");
                            foreach (SubState substate in State.Value) {
                                sw.WriteLine("\t\tregion_state:" + substate.owner.tag + " = {");
                                if (substate.pops.Count == 0) {
                                    sw.WriteLine("\t\t\t#SubState Found Without Pops. Add Some!");
                                    Console.WriteLine("\t\tmissing pops for" + substate.owner + ": " + substate.parentState);
                                }

                                foreach (Pop pop in substate.pops) {
                                    sw.WriteLine("\t\t\tcreate_pop = {");
                                    if(pop.culture != "")
                                        sw.WriteLine("\t\t\t\tculture = " + pop.culture);
                                    if (pop.size > 0)
                                        sw.WriteLine("\t\t\t\tsize = " + pop.size);
                                    if (pop.type != "")
                                        sw.WriteLine("\t\t\t\ttype = " + pop.type);
                                    if (pop.religion != "")
                                        sw.WriteLine("\t\t\t\treligion = " + pop.religion);
                                    sw.WriteLine("\t\t\t}");
                                }
                                sw.WriteLine("\t\t}");
                            }
                            sw.WriteLine("\t}");
                        }
                    }
                    sw.WriteLine("}");
                    sw.Close();
                }
            }


        }

        //write localizations for all nations and hubs
        public void WriteLocalizations(HashSet<Nation> nations, HashSet<Region> regions, string desiredLanguage = "english") {
            //if outputDirectory/localisation doesn't exist, create it
            if (!File.Exists(outputDirectory + "\\localisation\\replace\\"+desiredLanguage+"\\")) {
                Directory.CreateDirectory(outputDirectory + "\\localisation\\replace\\" + desiredLanguage + "\\");
            }

            string path = outputDirectory + "\\localisation\\replace\\" + desiredLanguage + "\\z_countries_l_" + desiredLanguage + ".yml";
            //write localisation file for each nation
            using (StreamWriter sw = File.CreateText(path)) {
                sw.WriteLine("l_" + desiredLanguage + ":");
                foreach (Nation nation in nations) {
                    if(nation.name != "")
                        sw.WriteLine(" " + nation.tag + ":0 \"" + nation.name + "\"");
                    if (nation.adj != "")
                        sw.WriteLine(" " + nation.tag + "_ADJ:0 \"" + nation.adj + "\"");
                }
                sw.Close();

            }

            //write hubs file
            path = outputDirectory + "\\localisation\\replace\\" + desiredLanguage + "\\z_hubs_names_l_" + desiredLanguage + ".yml";
            using (StreamWriter sw = File.CreateText(path)) {
                sw.WriteLine("l_"+desiredLanguage+":");
                foreach (Region region in regions) {
                    //if any state in the region has a hub, write the localization return ture
                    foreach (State state in region.states) {
                        if (state.hubLocalizationList.Count>0) {
                            sw.WriteLine("\n #" + region.name);
                            break;
                        }
                    }
                    
                    foreach (State state in region.states) {
                        foreach ((string type, string name) in state.hubLocalizationList) {
                            //if name is not empty, write it
                            if (name != "") {
                                sw.WriteLine(" HUB_NAME_" + state.name + "_" + type + ":0 \"" + name + "\"");
                            }
                        }
                    }
                }
                sw.Close();
            }
        }
    }
}
