using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Vic3MapMaker.DataFiles;
using Vic3MapMaker.Utilities;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using static Vic3MapMaker.DataFiles.Building;

namespace Vic3MapMaker
{
    internal class Vic3FileParser
    {

        HashSet<Region> regionSet = new HashSet<Region>();
        HashSet<State> stateSet = new HashSet<State>();
        HashSet<Province> provSet = new HashSet<Province>();
        HashSet<Terrain> terrainSet = new HashSet<Terrain>();
        HashSet<Culture> cultureSet = new HashSet<Culture>();
        HashSet<Nation> nationSet = new HashSet<Nation>();
        Bitmap mapImage;
        Vic3ListStorageUnit lsu = new Vic3ListStorageUnit();

        string gameDirectory;
        string modDirectory; //Not used yet
        string outDirectory;
        Stopwatch sw = new Stopwatch();

        public Vic3FileParser(string gameDirectory, string modDirectory, string outDirectory) {
            this.gameDirectory = gameDirectory;
            this.modDirectory = modDirectory;
            this.outDirectory = outDirectory;

            //stopwatch             
            sw.Start();
            //print time each method takes
            Console.WriteLine("Parsing files...");
            ParseStateFiles();
            ParseRegionFiles();
            ParseDefaultMap();
            ParseTerrain();
            ParseMap();
            ParseCulture();
            ParseCountries();
            ParseSubStates();
            ParseLocal();
            ParseWelthLiteracy();
            ParseTradeRoutes();
            ParseBuildings();
            ParseStateBuildings();

            sw.Stop();
            Console.WriteLine("Time elapsed: {0}", sw.Elapsed);
        }

        //method to parse state files
        void ParseStateFiles() {
            DateTime startTime = DateTime.Now;

            //read all files in outputDirectory/_Input/state_regions
            string[] files = Directory.GetFiles(gameDirectory + "/map_data/state_regions");
            //for each file
            int count = 0;
            foreach (string file in files) {
                if (file.EndsWith(".txt")) {
                    //if directory outDirectory + "/map_data/state_regions/"+ Path.GetFileName(file) does not exist, create it
                    if (!Directory.Exists(outDirectory + "/map_data/state_regions/")) {
                        Directory.CreateDirectory(outDirectory + "/map_data/state_regions/");
                    }
                    //create a new blank txt file of same name to outDirectory + /map_data/state_regions/ using System.IO.File.Create
                    System.IO.File.Create(outDirectory + "/map_data/state_regions/"+ Path.GetFileName(file)).Close();

                    //read file
                    string[] lines = File.ReadAllLines(file);
                    //for each line
                    //Console.WriteLine(file);
                    State s = new State();
                    Resource dr = new Resource();
                    bool cappedResourseFound = false;
                    bool discoverableResourseFound = false;
                    bool traitsfound = false;
                    foreach (string l1 in lines) {
                        string line = CleanLine(l1);

                        //get STATE_NAME
                        if (line.StartsWith("STATE_")) {
                            //Console.WriteLine("\t"+line.Split()[0]);
                            s = new State(line.Split()[0]);

                            //incase people are orverriding states in latter files
                            //check if state with same name already exists in stateSet and if so, delete it
                            foreach (State state in stateSet) {
                                if (state.name == s.name) {
                                    stateSet.Remove(state);
                                    break;
                                }
                            }

                            stateSet.Add(s);
                        }
                        //get stateID
                        if (line.StartsWith("id")) {
                            s.stateID = int.Parse(line.Split()[2]);
                        }
                        if (line.StartsWith("subsistence_building")) {
                            s.subsistenceBuilding = line.Split('=')[1].Replace("\"", "").Trim();
                        }

                        //get provinces
                        if (line.TrimStart().StartsWith("provinces")) {
                            string[] l2 = line.Split('=')[1].Split(' ');
                            for (int i = 0; i < l2.Length; i++) {
                                if (l2[i].StartsWith("\"x") || l2[i].StartsWith("x")) {
                                    string n = l2[i].Replace("\"", "").Replace("x", "");
                                    s.AddProv(n);
                                }
                            }

                        }
                        //get impassable colors
                        if (line.TrimStart().StartsWith("impassable")) {
                            string[] l2 = line.Split('=')[1].Split(' ');
                            for (int i = 0; i < l2.Length; i++) {
                                if (l2[i].StartsWith("\"x") || l2[i].StartsWith("x")) {
                                    string n = l2[i].Replace("\"", "").Replace("x", "");
                                    Color c = ColorTranslator.FromHtml("#" + n);
                                    //set province with color c to isImpassible
                                    if (s.provDict.TryGetValue(c, out Province p)) {
                                        p.isImpassible = true;
                                    }

                                }
                            }
                        }
                        //get prime_land colors
                        if (line.TrimStart().StartsWith("prime_land")) {
                            string[] l2 = line.Split('=')[1].Split(' ');
                            for (int i = 0; i < l2.Length; i++) {
                                if (l2[i].StartsWith("\"x") || l2[i].StartsWith("x")) {
                                    string n = l2[i].Replace("\"", "").Replace("x", "");
                                    Color c = ColorTranslator.FromHtml("#" + n);
                                    //set province with color c to prime land
                                    if (s.provDict.TryGetValue(c, out Province p)) {
                                        p.isPrimeLand = true;
                                    }
                                }
                            }
                        }

                        //get traits
                        if (line.Trim().StartsWith("traits")) {
                            traitsfound = true;
                        }
                        if (traitsfound) {
                            string[] l2 = line.Split(' ');
                            for (int i = 0; i < l2.Length; i++) {
                                if (l2[i].StartsWith("\"")) {
                                    s.traits.Add(l2[i].Replace("\"", ""));
                                }
                            }
                        }

                        //get arable_land
                        if (line.TrimStart().StartsWith("arable_land")) {
                            s.arableLand = int.Parse(line.Split('=')[1].Trim());
                            count++;
                        }
                        //get arable_resources
                        if (line.TrimStart().StartsWith("arable_resources")) {
                            string[] resList = line.Split('=')[1].Replace("\"", "").Split();
                            for (int i = 0; i < resList.Length; i++) {
                                if (resList[i].StartsWith("bg_")) {
                                    Resource r = new Resource(resList[i]) {
                                        knownAmmount = s.arableLand,
                                        type = "agriculture"
                                    };
                                    s.resources.Add(r);
                                }
                            }
                        }
                        //get capped_resources
                        if (line.TrimStart().StartsWith("capped_resources")) {
                            cappedResourseFound = true;
                        }
                        if (cappedResourseFound) {
                            if (line.TrimStart().StartsWith("bg_")) {
                                string[] l2 = line.Replace("\"", "").Split('=');
                                Resource r = new Resource(l2[0].Trim()) {
                                    knownAmmount = int.Parse(l2[1].Trim()),
                                    type = "resource"
                                };
                                s.resources.Add(r);
                            }
                        }
                        //get discvorable resources
                        if (line.TrimStart().StartsWith("resource")) {
                            discoverableResourseFound = true;
                        }
                        if (discoverableResourseFound) {

                            if (line.TrimStart().StartsWith("type")) {
                                string[] l2 = line.Split('=');
                                dr = new Resource(l2[1].Trim().Replace("\"", "")) {
                                    type = "discoverable"
                                };
                                s.resources.Add(dr);
                            }
                            else if (line.TrimStart().StartsWith("undiscovered_amount")) {
                                string[] l2 = line.Split('=');
                                dr.discoverableAmmount = int.Parse(l2[1].Trim());
                            }
                            else if (line.TrimStart().StartsWith("amount") || line.TrimStart().StartsWith("discovered_amount")) {
                                string[] l2 = line.Split('=');
                                dr.knownAmmount = int.Parse(l2[1].Trim());
                            }
                            else if (line.TrimStart().StartsWith("depleted_type")) {
                                string[] l2 = line.Split('=');
                                dr.depletedType = l2[1].Trim().Replace("\"", "");
                            }
                        }
                        //get naval id
                        if (line.TrimStart().StartsWith("naval_exit_id")) {
                            string[] l2 = line.Split('=');
                            s.navalID = int.Parse(l2[1].Trim());
                        }

                        //get city color
                        if (line.TrimStart().ToLower().StartsWith("city") || line.TrimStart().ToLower().StartsWith("port") || line.TrimStart().ToLower().StartsWith("farm") || line.TrimStart().ToLower().StartsWith("mine") || line.TrimStart().ToLower().StartsWith("wood")) {

                            Color hubC = ColorTranslator.FromHtml("#" + line.Split('=')[1].Replace("\"", "").Replace("x", "").Trim());
                            //set province with color c hubName to name
                            if (s.provDict.TryGetValue(hubC, out Province p)) {
                                p.hubList.Add(line.Split('=')[0].Trim().ToLower());
                                //p.hubName = line.Split('=')[0].Trim().ToLower();
                                //if s.color.A is 0 set the color to hubcolor
                                if (s.color.A == 0) {
                                    s.color = p.color;
                                }
                            }
                        }
                        //reset cappedResourseFound and discoverableResourseFound
                        if (line.Contains("}")) {
                            cappedResourseFound = false;
                            discoverableResourseFound = false;
                            traitsfound = false;
                        }

                    }
                }
            }

            //open all .txt files in gameDirectory + \common\history\states
            files = Directory.GetFiles(gameDirectory + "/common/history/states/");
            foreach (string file in files) {

                int indintation = 0;
                bool foundProvs = false;
                State currentState = null;
                string currentNation = "";

                //read file
                string[] lines = File.ReadAllLines(file);
                foreach (string l1 in lines) {
                    string line = CleanLine(l1);
                    //if line is empty skip it
                    if (line == "") continue;

                    //state
                    if (indintation == 1) {

                        if (line.StartsWith("s:")) {
                            //find state with same name as one in line
                            string stateName = line.Split(':')[1].Split('=')[0].Trim();
                            //search the stateSet hashset for a state with the same name
                            foreach (var s in stateSet.Where(s => s.name == stateName)) {
                                currentState = s;
                                break;
                            }

                            
                            //if state is not found create a new state
                            if (currentState == null) {
                                currentState = new State(stateName);
                                stateSet.Add(currentState);
                                Console.WriteLine("State " + stateName + " found in history folder but not in map_data folder");
                            }
                        }
                    }
                    if (currentState != null) {
                        //homeland and exteral cores
                        if (indintation == 2) {
                            //homeland
                            if (line.StartsWith("add_homeland")) {
                                currentState.homeLandList.Add(line.Split('=')[1].Trim());
                            }
                            //external cores
                            if (line.StartsWith("add_claim")) {
                                currentState.claimList.Add(line.Split('=')[1].Trim());
                            }
                        }
                        //country tag, state_type and provinces
                        if (indintation == 3) {
                            if (line.StartsWith("country")) {
                                currentNation = line.Split(':')[1].Trim();
                            }
                            else if (line.StartsWith("state_type")) {
                                currentState.stateTypeList.Add((currentNation, line.Split('=')[1].Trim()));
                            }
                            else if (line.StartsWith("owned_provinces")) {
                                foundProvs = true;
                            }
                        }

                        //if foundProvs is true
                        if (foundProvs) {
                            string[] l2 = line.Split();
                            //for each province in l2 try to turn it into a color by hex
                            foreach (string prov in l2) {
                                //if prov does not contain an x continue
                                if (!prov.Contains("x")) continue;
                                try {
                                    Color c = ColorTranslator.FromHtml("#" + prov.Replace("x", "").Replace("\"", "").Trim());
                                    //if the color is in the provDict add the nation to the ownerList
                                    if (currentState.provDict.TryGetValue(c, out Province p)) {
                                        p.originalOwnerTAG = currentNation;
                                    }
                                }
                                catch {
                                    Console.WriteLine("Error parsing province color " + prov);
                                }
                            }
                        }
                    }


                    //adjust indintation
                    if (line.Contains("{")) {
                        indintation++;
                    }
                    if (line.Contains("}")) {
                        indintation--;
                        foundProvs = false;
                        if(indintation == 1) {
                            currentState = null;
                        }
                    }
                }
            }



            //add all state provs to provSet
            foreach (State s in stateSet) {
                foreach (Province p in s.provDict.Values) {
                    provSet.Add(p);
                }
            }
            
            Console.WriteLine("Parsed States in " + (DateTime.Now - startTime).TotalSeconds + " seconds");

        }

        //parse all region files
        void ParseRegionFiles() {
            DateTime startTime = DateTime.Now;
            
            string[] files = Directory.GetFiles(gameDirectory + "/common/strategic_regions");

            int count = 0;
            foreach (string file in files) {
                if (file.EndsWith(".txt")) {
                    string[] lines = File.ReadAllLines(file);
                    Region r = new Region();
                    //Console.WriteLine(file);
                    foreach (string l1 in lines) {
                        string line = CleanLine(l1);

                        if (line.Trim().StartsWith("region_")) {
                            r = new Region(line.Split('=')[0].Trim());

                            //incase people are orverriding regions in latter files
                            //check if region with same name already exists in regionSet and if so, delete it
                            foreach (Region region in regionSet) {
                                if (region.name == r.name) {
                                    regionSet.Remove(region);
                                    break;
                                }
                            }

                            regionSet.Add(r);
                            //set superRegion to name of file
                            r.superRegion = file.Split('\\')[file.Split('\\').Length - 1].Replace(".txt", "");
                        }
                        else if (line.Trim().StartsWith("states")) {
                            string[] states = line.Split('=')[1].Replace("{", "").Replace("}", "").Split();
                            for (int i = 0; i < states.Length; i++) {
                                //if states[i] is a state.name in stateSet add it to r.states
                                foreach (State s in stateSet) {
                                    if (s.name == states[i]) {
                                        r.states.Add(s);
                                        break;
                                    }
                                }
                            }
                        }
                        else if (line.Trim().StartsWith("map_color")) {
                            count++;
                            string[] e = line.Split('=')[1].Split();

                            List<double> rgbValues = new List<double>();

                            foreach (string s in e) {
                                //try parse float
                                if (double.TryParse(s, out double d)) {
                                    //if d is between 0 and 1.1 then multiply it by 255
                                    if (d > 0 && d < 1.1) {
                                        d *= 255;
                                    }
                                    //if d is outsied of 0-255 range, then set it to 0 or 255
                                    if (d < 0) {
                                        d = 0;
                                    }
                                    else if (d > 255) {
                                        d = 255;
                                    }

                                    rgbValues.Add(d);
                                }
                            }
                            //if rgbValues has less than 3 values, then add 128 to make it 3
                            while (rgbValues.Count < 3) {
                                rgbValues.Add(128);
                            }

                            r.color = Color.FromArgb((int)rgbValues[0], (int)rgbValues[1], (int)rgbValues[2]);

                        }
                        else if (line.StartsWith("graphical_culture")) {
                            r.gfxCulture = line.Split('=')[1].Replace("\"", "").Trim();
                        }
                        else if (line.StartsWith("capital_province")) {
                            r.capitalName = line.Split('=')[1].Replace("\"", "").Trim();
                        }
                    }
                }
            }
            Console.WriteLine("Regions: " + count + " | " + regionSet.Count);
            //print time taken
            Console.WriteLine("Parsed Regions in " + (DateTime.Now - startTime).TotalSeconds + " seconds");
        }

        //parse default.map
        void ParseDefaultMap() {
            DateTime startTime = DateTime.Now;

            //itterate throu all states in regionSet and add their provDict to colorToProv
            foreach (Region r in regionSet) {
                foreach (State s in r.states) {
                    foreach (KeyValuePair<Color, Province> kvp in s.provDict) {
                        provSet.Add(kvp.Value);
                    }
                }
            }

            string[] lines = File.ReadAllLines(gameDirectory + "/map_data/default.map");
            bool seaStart = false;
            bool lakeStart = false;
            foreach (string line in lines) {
                if (line.Trim().StartsWith("sea_starts")) {
                    seaStart = true;
                }
                else if (line.Trim().StartsWith("lakes")) {
                    lakeStart = true;
                }
                if (seaStart || lakeStart) {
                    string[] l2 = line.Trim().Split(' ');
                    for (int i = 0; i < l2.Length; i++) {
                        if (l2[i].StartsWith("#")) {
                            break;
                        }
                        else if (l2[i].StartsWith("x")) {
                            //if there is a Province with name l2[i] in provSet then set it to sea or lake
                            Province p = null;
                            bool found = false;
                            foreach (Province prov in provSet) {
                                if (prov.name == l2[i]) {
                                    p = prov;
                                    found = true;
                                    break;
                                }
                            }
                            if (!found) {
                                p = new Province(l2[i]);
                                provSet.Add(p);
                            }
                            if (seaStart) {
                                p.isSea = true;
                            }
                            else if (lakeStart) {
                                p.isLake = true;
                            }
                        }
                        else if (l2[i].StartsWith("}")) {
                            seaStart = false;
                            lakeStart = false;
                            break;
                        }
                    }
                }
            }
            
            Console.WriteLine("Parsed default.map in " + (DateTime.Now - startTime).TotalSeconds + " seconds");
        }

        //parse province_terrains.txt
        void ParseTerrain() {
            DateTime startTime = DateTime.Now;

            string[] lines = File.ReadAllLines(gameDirectory + "/map_data/province_terrains.txt");
            int internalID = 1;
            foreach (string l1 in lines) {
                string line = CleanLine(l1);

                //if line is blank or starts with # then skip it
                if (line == "" || line.StartsWith("#")) {
                    continue;
                }

                //if line contains = then it is a province
                if (line.Contains("=")) {
                    string[] l2 = line.Split('=');
                    string name = l2[0].Replace("\"", "").Trim();
                    string terrain = l2[1].Replace("\"", "").Trim();

                    //if there is a Province with name of name in get the province else create a new one
                    Province p = null;
                    bool found = false;
                    foreach (Province prov in provSet) {
                        if (prov.name == name) {
                            p = prov;
                            found = true;
                            break;
                        }
                    }
                    if (!found) {
                        p = new Province(name);
                        provSet.Add(p);
                    }
                    p.terrain = terrain;
                    p.internalID = internalID;

                    internalID++;
                }
            }

            //get a list of all txt files in the common\Terrain folder
            string[] terrainFiles = Directory.GetFiles(gameDirectory + "/common/Terrain", "*.txt");

            //itterate through all Terrain files
            foreach (string file in terrainFiles) {
                //read all terrainLines in the file
                string[] terrainLines = File.ReadAllLines(file);

                int indentation = 0;

                Terrain currentTerrain = null;

                //itterate through all terrainLines
                foreach (string l1 in terrainLines) {
                    string line = CleanLine(l1);

                    //if line is blank or starts with # then skip it
                    if (line == "" || line.StartsWith("#")) {
                        continue;
                    }

                    if (indentation == 0) {
                        if (line.Contains("=")) {
                            currentTerrain = new Terrain(line.Split('=')[0].Trim());
                            terrainSet.Add(currentTerrain);
                        }

                    }
                    if (indentation == 1) {
                        if (line.Contains("debug_color")) {

                            currentTerrain.color = GetColor(line);
                        }
                    }
                    //if { or } in line then change indentation
                    if (line.Contains("{")) {
                        indentation++;
                    }
                    if (line.Contains("}")) {
                        indentation--;
                    }

                }
            }
            
            Console.WriteLine("Parsed province_terrains.txt in " + (DateTime.Now - startTime).TotalSeconds + " seconds");
        }

        //parse provinces png
        private void ParseMap() {
            DateTime startTime = DateTime.Now;

            Dictionary<Color, Province> provinceDict = new Dictionary<Color, Province>();

            //add all provinces from provSet to the provinceDict if not already in the dict
            foreach (Province province in provSet) {
                if (!provinceDict.ContainsKey(province.color)) {
                    provinceDict.Add(province.color, province);
                }
                else {
                    //merge the provinces if they have the same color
                    provinceDict[province.color].Merge(province);
                }
            }

            //remove any duplicate names from the provSet
            provSet = provSet.GroupBy(p => p.name).Select(g => g.First()).ToHashSet();

            //set capital of each r
            foreach (Region region in regionSet) {
                //find prov with the same name as capitanName
                region.capital = provSet.Where(p => p.name == region.capitalName).FirstOrDefault();
            }

            mapImage = new Bitmap(gameDirectory + "\\map_data\\provinces.png");

            //create a new image borderImage with the same size as mergedImage and alpha channel set to 0
            Bitmap borderImage = new Bitmap(mapImage.Width, mapImage.Height, PixelFormat.Format32bppArgb);

            //loop through all the pixels in the image
            for (int x = 0; x < mapImage.Width; x++) {
                for (int y = 0; y < mapImage.Height; y++) {
                    //get the color of the pixel
                    Color pixelColor = mapImage.GetPixel(x, y);
                    //if color is in the dictionary
                    if (provinceDict.ContainsKey(pixelColor)) {
                        //add the coordinate to the province
                        provinceDict[pixelColor].coordSet.Add((x, y));
                    }
                    else {
                        //if prov with that color is in r.states.provinces
                        foreach (Region r in regionSet) {
                            foreach (State s in r.states) {
                                //if color is in provDict
                                if (s.provDict.ContainsKey(pixelColor)) {
                                    //add the province to the provDict
                                    provinceDict.Add(pixelColor, s.provDict[pixelColor]);
                                    //add the coordinate to the province
                                    provinceDict[pixelColor].coordSet.Add((x, y));
                                    //exit the loop
                                    goto exitRegion;
                                }
                            }
                        }
                        exitRegion:;
                    }

                    //prov border set to black
                    //if the pixel is not the same as the pixel to the right or down
                    if (x < mapImage.Width - 1 && y < mapImage.Height - 1) {
                        if (pixelColor != mapImage.GetPixel(x + 1, y) || pixelColor != mapImage.GetPixel(x, y + 1)) {
                            //set the pixel in borderImage to black
                            borderImage.SetPixel(x, y, Color.Black);
                        }
                    }
                    //if the pixel is on the right edge
                    else if (x == mapImage.Width - 1 && y < mapImage.Height - 1) {
                        if (pixelColor != mapImage.GetPixel(x, y + 1)) {
                            //set the pixel in borderImage to black
                            borderImage.SetPixel(x, y, Color.Black);
                        }
                    }
                    //if the pixel is on the bottom edge
                    else if (x < mapImage.Width - 1 && y == mapImage.Height - 1) {
                        if (pixelColor != mapImage.GetPixel(x + 1, y)) {
                            //set the pixel in borderImage to black
                            borderImage.SetPixel(x, y, Color.Black);
                        }
                    }

                }
            }

            for (int x = 0; x < mapImage.Width; x++) {
                for (int y = 0; y < mapImage.Height; y++) {
                    Color borderColor = borderImage.GetPixel(x, y);
                    if (borderColor.A != 0) {
                        borderImage.SetPixel(x, y, Color.FromArgb(250, borderColor));
                    }
                    else {
                        borderImage.SetPixel(x, y, Color.FromArgb(255, mapImage.GetPixel(x, y)));
                    }
                }
            }
            mapImage = borderImage;
            
            Console.WriteLine("Parsed provinces.png in " + (DateTime.Now - startTime).TotalSeconds + " seconds");
        }

        private Color GetColor(string line) {
            //split on space and add the 3 values to the color list
            string[] l2 = line.Split(' ');
            List<double> colorList = new List<double>();
            //if l2 is a doubel then add it to colorList
            foreach (string s in l2) {
                if (double.TryParse(s, out double d)) {
                    colorList.Add(d);
                }
            }
            if (line.Contains("hsv360")) {
                //while there is less than 3 values in colorList add 0
                while (colorList.Count < 3) {
                    colorList.Add(0);
                }
                //convert the colorList from hsv360 to rgb
                return ColorFromHSV360(colorList[0], colorList[1], colorList[2]);
            }
            //if hsv is in the line then convert the colorList to rgb
            else if (line.Contains("hsv")) {
                //while there is less than 3 values in colorList add 0.5
                while (colorList.Count < 3) {
                    colorList.Add(0.5);
                }
                //convert the colorList from hsv to rgb
                return ColorFromHSV(colorList[0], colorList[1], colorList[2]);
            }

            //rgb values
            return ColorRGB(colorList);
        }

        //convert hsv to rgb
        private Color ColorFromHSV(double v1, double v2, double v3) {
            //convert hsv to rgb
            double r, g, b;
            if (v3 == 0) {
                r = g = b = 0;
            }
            else {
                if (v2 == -1) v2 = 1;
                int i = (int)Math.Floor(v1 * 6);
                double f = v1 * 6 - i;
                double p = v3 * (1 - v2);
                double q = v3 * (1 - f * v2);
                double t = v3 * (1 - (1 - f) * v2);
                switch (i % 6) {
                    case 0: r = v3; g = t; b = p; break;
                    case 1: r = q; g = v3; b = p; break;
                    case 2: r = p; g = v3; b = t; break;
                    case 3: r = p; g = q; b = v3; break;
                    case 4: r = t; g = p; b = v3; break;
                    case 5: r = v3; g = p; b = q; break;
                    default: r = g = b = v3; break;
                }
            }
            List<double> colorList = new List<double> { r, g, b };

            return ColorRGB(colorList);
        }
        private Color ColorFromHSV360(double v1, double v2, double v3) {
            //converts hsv360 to rgb
            return ColorFromHSV(v1 / 360, v2 / 100, v3 / 100);
        }
        private Color ColorRGB(List<double> colorList) {
            //if all doubles in colorList are between 0 and 1 then convert them to 0-255
            bool allBetween0and1 = true;
            foreach (double d in colorList) {
                if (d < 0 || d > 1) {
                    allBetween0and1 = false;
                    break;
                }
            }
            if (allBetween0and1) {
                for (int i = 0; i < colorList.Count; i++) {
                    colorList[i] = colorList[i] * 255;
                }
            }
            //while there is less than 3 values in colorList add 128
            while (colorList.Count < 3) {
                colorList.Add(128);
            }
            //if the values are outside of the 0-255 range then set them to 0 or 255
            for (int i = 0; i < colorList.Count; i++) {
                if (colorList[i] < 0) {
                    colorList[i] = 0;
                }
                else if (colorList[i] > 255) {
                    colorList[i] = 255;
                }
            }
            return Color.FromArgb((int)(colorList[0]), (int)(colorList[1]), (int)(colorList[2]));
        }

        //parse cultures
        private void ParseCulture() {
            //start time
            DateTime startTime = DateTime.Now;

            //get the culture files from game folder +\common\cultures
            string[] cultureFiles = Directory.GetFiles(gameDirectory + @"\common\cultures\", "*.txt");

            //for each culture file
            foreach (string cultureFile in cultureFiles) {
                string[] lines = File.ReadAllLines(cultureFile);
                int indentation = 0;
                bool traitsFound = false;
                Culture currentCulture = new Culture();
                //for each line in the culture file
                foreach (string l1 in lines) {
                    string line = CleanLine(l1);
                    //if line is empty then continue
                    if (line == "") continue;

                    if (indentation == 0) {
                        //if line contains = then it is a culture
                        if (line.Contains("=")) {
                            //create a new culture
                            currentCulture = new Culture(line.Split('=')[0].Trim());
                            //if there is a culture in the set with the same name then delete it and add the new one
                            if (cultureSet.Any(c => c.name == currentCulture.name)) {
                                cultureSet.Remove(cultureSet.First(c => c.name == currentCulture.name));
                            }
                            cultureSet.Add(currentCulture);
                        }
                    }
                    else if (indentation == 1) {
                        //color
                        if (line.StartsWith("color")) {
                            currentCulture.color = GetColor(line);
                        }
                        //religion
                        else if (line.StartsWith("religion")) {
                            currentCulture.religionName = line.Split('=')[1].Trim();
                        }
                        //traits
                        else if (line.StartsWith("traits")) {
                            traitsFound = true;
                        }
                        //graphics
                        else if (line.StartsWith("graphical_culture")) {
                            currentCulture.graphics = line.Split('=')[1].Trim();
                        }

                    }


                    //if traits are found then add the traits to the culture
                    if (traitsFound) {
                        string[] l2;
                        if (line.Contains("="))
                            l2 = line.Split('=')[1].Replace("{", "").Replace("}", "").Trim().Split();
                        else
                            l2 = line.Replace("{", "").Replace("}", "").Trim().Split();
                        foreach (string trait in l2) {
                            currentCulture.traits.Add(trait);
                        }
                    }

                    //if { in line then increase indentation
                    if (line.Contains("{")) {
                        indentation++;
                    }
                    //if } in line then decrease indentation
                    if (line.Contains("}")) {
                        indentation--;
                        traitsFound = false;
                    }
                }

            }

            Console.WriteLine("Parsed cultures.txt in " + (DateTime.Now - startTime).TotalSeconds + " seconds");
        }

        //replace line with cleaned up line
        private string CleanLine(string l1) {
            return l1.Replace("{", " { ").Replace("}", " } ").Replace("=", " = ").Replace("  ", " ").Split('#')[0].Trim();
        }

        //parse countries
        private void ParseCountries() {
            DateTime startTime = DateTime.Now;

            //get all country files from game folder +\common\country_definitions\
            string[] countryFiles = Directory.GetFiles(gameDirectory + @"\common\country_definitions\", "*.txt");

            //for each country file
            foreach (string file in countryFiles) {
                string[] lines = File.ReadAllLines(file);
                int indentation = 0;
                bool culturesFound = false;
                Nation currentCountry = new Nation();

                //for each line in the country file
                foreach (string l1 in lines) {
                    string line = CleanLine(l1);
                    //if line is empty then continue
                    if (line == "") continue;

                    //indentation 0
                    if (indentation == 0) {
                        //if line contains = then it is a country
                        if (line.Contains("="))
                            //create a new country
                            currentCountry = new Nation(line.Split('=')[0].Trim());
                        //if there is a country in the set with the same tag then delete it and add the new one
                        if (nationSet.Any(c => c.tag == currentCountry.tag))
                            nationSet.Remove(nationSet.First(c => c.tag == currentCountry.tag));
                        nationSet.Add(currentCountry);

                    }

                    //indentation 1
                    else if (indentation == 1) {
                        //color
                        if (line.StartsWith("color"))
                            currentCountry.color = GetColor(line);
                        //type
                        else if (line.StartsWith("country_type"))
                            currentCountry.type = line.Split('=')[1].Trim();
                        //tier
                        else if (line.StartsWith("tier"))
                            currentCountry.tier = line.Split('=')[1].Trim();
                        //culture
                        else if (line.StartsWith("culture"))
                            culturesFound = true;
                        //capital
                        else if (line.StartsWith("capital")) {
                            //try to find the state in the state set with the same name as the capital
                            State capital = stateSet.FirstOrDefault(s => s.name == line.Split('=')[1].Trim());
                            //if the state is found then set the capital to the state
                            if (capital != null) 
                                currentCountry.capital = capital;
                                
                        }
                        else if(line.StartsWith("is_named_from_capital") && line.Contains("yes")) {
                            currentCountry.isNamedFromCapital = true;
                        }
                    }


                    //if cultures are found then add the cultures to the country
                    if (culturesFound) {
                        string[] l2;
                        if (line.Contains("="))
                            l2 = line.Split('=')[1].Replace("{", "").Replace("}", "").Trim().Split();
                        else
                            l2 = line.Replace("{", "").Replace("}", "").Trim().Split();
                        foreach (string culture in l2)
                            currentCountry.cultures.Add(culture);
                    }


                    //change indentation
                    if (line.Contains("{")) {
                        indentation++;
                    }
                    if (line.Contains("}")) {
                        indentation--;
                        culturesFound = false;
                    }
                }


            }
            //merge provs into countries.provDict
            foreach (Province p in provSet) {
                Nation n = nationSet.FirstOrDefault(nation => nation.tag == p.originalOwnerTAG);
                n?.provDict.Add(p.color, p);
            }

            Console.WriteLine("Parsed countries in " + (DateTime.Now - startTime).TotalSeconds + " seconds");

        }

        //parse subStates
        private void ParseSubStates() {
            DateTime startTime = DateTime.Now;

            HashSet<SubState> subStateSet = new HashSet<SubState>();
            
            //get all substate files in game folder +\common\history\pops\
            string[] subStateFiles = Directory.GetFiles(gameDirectory + @"\common\history\pops\", "*.txt");

            //for each substate file
            foreach (string file in subStateFiles) {
                //create a new blank txt file of same name to outDirectory + \history\population\ using System.IO.File.Create
                System.IO.File.Create(outDirectory + @"\common\history\pops\" + Path.GetFileName(file)).Close();

                //open file
                string[] lines = File.ReadAllLines(file);

                int indentation = 0;
                bool popFound = false;
                SubState currentSubState = new SubState();
                State currentState = null;
                Pop currentPop = new Pop();
                //for each line in the file
                foreach (string l1 in lines) {
                    string line = CleanLine(l1);

                    //if line is empty then continue
                    if (line == "") continue;

                    //indentation 1
                    if (indentation == 1) {
                        //is substate
                        if (line.StartsWith("s:")) {
                            //find state with the same name as the substate
                            currentState = stateSet.FirstOrDefault(s => s.name == line.Split(':')[1].Split('=')[0].Trim());
                        }
                    }

                    if (currentState != null) {
                        //indentation 2
                        if (indentation == 2) {
                            //if nation found
                            if (line.StartsWith("region_state:")) {
                                //find nation with the same tag as the substate
                                Nation nation = nationSet.FirstOrDefault(n => n.tag == line.Split(':')[1].Split('=')[0].Trim());

                                if (nation != null && currentState != null) {
                                    //create new substate
                                    currentSubState = new SubState(currentState, nation);
                                    //add substate to nation
                                    nation.subStates.Add(currentSubState);

                                    //check stateTypeList tupple list for nation.tag
                                    foreach ((string tag, string type) t in currentState.stateTypeList) {
                                        if (t.tag == nation.tag) {
                                            //set state type
                                            currentSubState.type = t.type;
                                            break;
                                        }
                                    }

                                }
                            }
                        }

                        //indentation 3
                        else if (indentation == 3) {
                            //if pops found
                            if (line.StartsWith("create_pop")) {
                                popFound = true;
                                //Console.WriteLine(currentPop);
                                currentPop = new Pop();
                                //currentSubState.pops.Add(currentPop);
                            }
                        }


                        if (popFound) {
                            if (line.StartsWith("culture"))
                                currentPop.culture = line.Split('=')[1].Trim();
                            else if (line.StartsWith("size"))
                                currentPop.size = int.Parse(line.Split('=')[1].Trim());
                            else if (line.StartsWith("type"))
                                currentPop.type = line.Split('=')[1].Trim();
                            else if (line.StartsWith("religion"))
                                currentPop.religion = line.Split('=')[1].Trim();
                        }

                    }

                    //update indentation
                    if (line.Contains("{") || line.Contains("}")) {
                        foreach (string s in line.Split()) {
                            if (s.StartsWith("{")) indentation++;
                            else if (s.StartsWith("}")) {
                                indentation--;
                                if (popFound && currentState != null) {
                                    currentSubState.pops.Add(currentPop);
                                }
                                popFound = false;
                                //if (indentation == 3) currentSubState = null;
                                //else if (indentation == 1) currentState = null;

                            }
                        }
                    }
                }

            }

            //give each substate to its owner
            foreach (SubState s in subStateSet) {
                Nation n = nationSet.FirstOrDefault(nation => nation.tag == s.owner.tag);
                if (n != null)
                    n.subStates.Add(s);
            }

            //add prov to substate where the prov is in both its state provDict and its owner provDict
            foreach (SubState s in subStateSet) {
                //for each prov in the substate's parentState
                foreach (Province p in s.parentState.provDict.Values) {
                    //if p is also in the substate's owner provDict
                    if (s.owner.provDict.ContainsKey(p.color)) {
                        //add p to the substate's provDict
                        s.provDict.Add(p.color, p);
                    }
                }
            }

            Console.WriteLine("Parsed substates in " + (DateTime.Now - startTime).TotalSeconds + " seconds");

        }

        //parse localization files
        public void ParseLocal() {
            DateTime startTime = DateTime.Now;

            string desiredLanguage = "english";
            //country names
            //get all files in game folder +\localization\** that contian countries in their name
            string[] countryFiles = Directory.GetFiles(gameDirectory + @"\localization\", "*countries*"+ desiredLanguage+".yml", SearchOption.AllDirectories);

            //for each country file
            foreach (string file in countryFiles) {
                Console.WriteLine(file);
                //open file
                string[] lines = File.ReadAllLines(file);

                //for each line in the file
                foreach (string l1 in lines) {
                    string line = CleanLine(l1);

                    //if line is empty then continue
                    if (line == "") continue;

                    string potentialTag = line.Split(':')[0].Trim();
                    if (potentialTag.Contains("_ADJ")) {
                        //split potentialTag on _ and check if the first part is a tag
                        Nation n = nationSet.FirstOrDefault(nation => nation.tag == potentialTag.Split('_')[0].Trim());
                        if (n != null) {
                            //set country adjective
                            n.adj = Regex.Match(line, "\"(.*?)\"").Value.Replace("\"", "").Trim();
                        }
                    }
                    else {
                        //check if potentialTag is a tag in nationSet
                        Nation n = nationSet.FirstOrDefault(nation => nation.tag.ToLower() == potentialTag.ToLower());
                        if (n != null) {
                            //regex to get a string between quotes
                            n.name = Regex.Match(line, "\"(.*?)\"").Value.Replace("\"", "").Trim();
                        }
                    }
                }
            }

            //hub names
            //get all files in game folder +\localization\** that contian hubs in their name
            string[] hubFiles = Directory.GetFiles(gameDirectory + @"\localization\", "*hub*name*" + desiredLanguage + ".yml", SearchOption.AllDirectories);

            //for each hub file
            foreach (string file in hubFiles) {
                Console.WriteLine(file);
                //open file
                string[] lines = File.ReadAllLines(file);

                //for each line in the file
                foreach (string l1 in lines) {
                    string line = CleanLine(l1);
                    
                    //if line is empty then continue
                    if (line == "") continue;

                    string potentialStateHub = line.Split(':')[0].Trim();
                    //check if potentialStateHub has a state name from stateSet in it
                    State s = stateSet.FirstOrDefault(state => potentialStateHub.Contains(state.name));
                    if (s != null) {
                        //find hub type
                        string hubType = line.Split('_')[line.Split('_').Length - 1].Split(':')[0].Trim();
                        //find hub name
                        string hubName = line.Split()[line.Split().Length - 1].Replace("\"","").Trim();

                        //find index of hub type in hubLocalizationList
                        int index = s.hubLocalizationList.FindIndex(h => h.type == hubType);
                        //if hub type not found in hubLocalizationList
                        if (index == -1) {
                            //add new hubLocalization to hubLocalizationList
                            s.hubLocalizationList.Add((hubType, hubName));
                        }
                        //if hub type found in hubLocalizationList
                        else {
                            //update hub name
                            s.hubLocalizationList[index] = (hubType, hubName);
                        }

                    }
                }
            }

            Console.WriteLine("Parsed localisation in " + (DateTime.Now - startTime).TotalSeconds + " seconds");
        }

        //parse nation pops starting welth and literacy
        private void ParseWelthLiteracy() {
            DateTime startTime = DateTime.Now;

            //get all files in game folder +\common\history\population\
            string[] popFiles = Directory.GetFiles(gameDirectory + @"\common\history\population\", "*.txt", SearchOption.AllDirectories);

            //for each nation file
            foreach (string file in popFiles) {
                //create a new blank txt file of same name to outDirectory + \history\population\ using System.IO.File.Create
                System.IO.File.Create(outDirectory + @"\common\history\population\" + Path.GetFileName(file)).Close();

                //open file
                string[] lines = File.ReadAllLines(file);
                

                Nation currentNation = null;
                //for each line in the file
                foreach (string l1 in lines) {
                    string line = CleanLine(l1);

                    //if line is empty then continue
                    if (line == "") continue;

                    if (line.StartsWith("c:")) {
                        string potentialTag = line.Split(':')[1].Split('=')[0].Trim();
                        //check if potentialTag is a tag in nationSet
                        currentNation = nationSet.FirstOrDefault(nation => nation.tag == potentialTag);
                    }

                    if (currentNation != null) {
                        //if line starts with "literacy" then set literacy
                        if (line.Contains("literacy")) {
                            string[] splitLine = Regex.Split(line, "literacy_");
                            currentNation.literacy = splitLine[1].Split('=')[0].Trim();
                        }
                        //if line starts with "wealth" then set wealth
                        else if (line.Contains("wealth")) {
                            string[] splitLine = Regex.Split(line, "wealth_");
                            currentNation.wealth = splitLine[1].Split('=')[0].Trim();
                        }
                    }

                    if (line.StartsWith("}")) {
                        currentNation = null;
                    }

                }
            }

            Console.WriteLine("Parsed welth and literacy in " + (DateTime.Now - startTime).TotalSeconds + " seconds");

        }

        //parse trade routes
        private void ParseTradeRoutes() {
            DateTime dateTime = DateTime.Now;

            //get all files in game folder +\common\trade_routes\
            string[] tradeRouteFiles = Directory.GetFiles(gameDirectory + @"\common\history\trade_routes\", "*.txt", SearchOption.AllDirectories);

            //for each trade route file
            foreach (string file in tradeRouteFiles) {
                //open file
                string[] lines = File.ReadAllLines(file);

                int indentation = 0;
                Nation currentNation = null;
                TradeRoute currentTradeRoute = null;

                //for each line in the file
                foreach (string l1 in lines) {
                    string line = CleanLine(l1);

                    //if line is empty then continue
                    if (line == "") continue;

                    if (indentation == 1) {
                        if (line.StartsWith("c:")) {
                            string potentialTag = line.Split(':')[1].Split('=')[0].Trim();
                            //check if potentialTag is a tag in nationSet
                            currentNation = nationSet.FirstOrDefault(nation => nation.tag == potentialTag);
                        }
                    }
                    if (indentation == 2) {
                        if (line.StartsWith("create_trade_route")) {
                            currentTradeRoute = new TradeRoute();
                            currentNation.tradeRoutes.Add(currentTradeRoute);
                        }
                    }
                    if(indentation == 3) {
                        if (line.StartsWith("goods"))
                            currentTradeRoute.goods = line.Split('=')[1].Trim();
                        else if (line.StartsWith("level")) {
                            //try to parse level to int
                            if (int.TryParse(line.Split('=')[1].Trim(), out int level)) {
                                currentTradeRoute.level = level;
                            }
                        }
                        else if (line.StartsWith("direction")) {
                            currentTradeRoute.isExport = line.ToLower().Contains("export");
                        }
                        else if (line.StartsWith("target")) {
                            string targetTag = line.Split(':')[1].Split('.')[0].Trim();
                            //check if targetTag is a tag in nationSet
                            currentTradeRoute.target = nationSet.FirstOrDefault(nation => nation.tag == targetTag);
                            
                        }

                    }



                    if (line.Contains("{") || line.Contains("}")) {
                        string[] l2 = line.Split();
                        foreach (string word in l2) {
                            if (word.Contains("{")) {
                                indentation++;
                            }
                            else if (word.Contains("}")) {
                                indentation--;
                                if (indentation == 1) {
                                    currentNation = null;
                                }
                                else if (indentation == 2) {
                                    currentTradeRoute = null;
                                }
                            }
                        }
                    }
                }
            }

        }

        //parse buildings
        private void ParseBuildings() {
            DateTime startTime = DateTime.Now;

            //get all files in game folder +\common\production_method_groups\ .txt
            string[] pmgFiles = Directory.GetFiles(gameDirectory + @"\common\production_method_groups\", "*.txt", SearchOption.AllDirectories);
            
            HashSet<ProductionMethondGroups> pmgSet = new HashSet<ProductionMethondGroups>();

            //for each production method group file
            foreach (string file in pmgFiles) {
                

                //open file
                string[] lines = File.ReadAllLines(file);

                int indentaiton = 0;
                ProductionMethondGroups currentPMG = null;
                bool foundMethods = false;
                //for each line in the file
                foreach (string l1 in lines) {
                    string line = CleanLine(l1);

                    //if line is empty then continue
                    if (line == "") continue;

                    if (indentaiton == 0) {
                        if (line.Contains("=")) {
                            currentPMG = new ProductionMethondGroups(line.Split('=')[0].Trim());
                            pmgSet.Add(currentPMG);
                        }
                    }

                    if(indentaiton == 1) {
                        if (line.StartsWith("production_methods")) {
                            foundMethods = true;
                        }
                    }

                    if (foundMethods) {
                        string[] l2 = line.Split();
                        foreach (string word in l2) {
                            if (word.StartsWith("pm_")) {
                                currentPMG.productionMethods.Add(word.Trim());
                            }
                        }
                    }


                    if (line.Contains("{") || line.Contains("}")) {
                        string[] l2 = line.Split();
                        foreach (string word in l2) {
                            if (word.Contains("{")) {
                                indentaiton++;
                            }
                            else if (word.Contains("}")) {
                                indentaiton--;
                                if (indentaiton == 0) {
                                    currentPMG = null;
                                }
                                else if (indentaiton == 1) {
                                    foundMethods = false;
                                }
                            }
                        }
                    }
                }
            }



            //get all files in game folder +\common\buildings\ .txt
            string[] buildingFiles = Directory.GetFiles(gameDirectory + @"\common\buildings\", "*.txt", SearchOption.AllDirectories);

            //for each building file
            foreach(string file in buildingFiles) {
                string[] lines = File.ReadAllLines(file);


                int indentation = 0;
                Building currentBuilding = null;
                bool foundProductionMethods = false;
                //for each line in the file
                foreach (string l1 in lines) {
                    string line = CleanLine(l1);

                    //if line is empty then continue
                    if (line == "") continue;

                    if (indentation == 0) {
                        if (line.Contains("=")) {
                            currentBuilding = new Building(line.Split('=')[0].Trim());
                            //if building with same name already exists then replace it
                            if (lsu.buildings.Any(building => building.name == currentBuilding.name)) {
                                lsu.buildings.Remove(lsu.buildings.First(building => building.name == currentBuilding.name));
                            }
                            lsu.buildings.Add(currentBuilding);
                        }
                    }
                    
                    if(indentation == 1) {
                        if(line.StartsWith("building_group"))
                            currentBuilding.buildingGroup = line.Split('=')[1].Trim();
                        else if (line.StartsWith("city_type")) {
                            //set cityType enum value based on string value after =
                            currentBuilding.cityType = (CityTypes)Enum.Parse(typeof(CityTypes), line.Split('=')[1].Trim());
                        }
                        else if (line.StartsWith("production_method_groups")) {
                            foundProductionMethods = true;
                        }
                    }

                    if (foundProductionMethods) {
                        if (line.StartsWith("pmg")){
                            string pmgName = line.Trim();
                            //find production method group in pmgSet
                            currentBuilding.productionMethodGroups.Add(pmgSet.FirstOrDefault(p => p.group == pmgName));
                        }
                    }
                    
                    if (line.Contains("{") || line.Contains("}")) {
                        string[] l2 = line.Split();
                        foreach (string word in l2) {
                            if (word.Contains("{")) {
                                indentation++;
                            }
                            else if (word.Contains("}")) {
                                indentation--;
                                if (indentation == 0) {
                                    //print building
                                    //Console.WriteLine("\t"+currentBuilding.ToString());
                                    currentBuilding = null;
                                }
                                else if (indentation == 1) {
                                    foundProductionMethods = false;
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Parsed buildings in " + (DateTime.Now - startTime).TotalSeconds + " seconds");
        }

        //parse state buildings
        private void ParseStateBuildings() {
            DateTime dateTime = DateTime.Now;

            //get all files in game folder +\common\history\buildings\ .txt
            string[] stateBuildingFiles = Directory.GetFiles(gameDirectory + @"\common\history\buildings\", "*.txt", SearchOption.AllDirectories);

            //for each state building file
            foreach(string file in stateBuildingFiles) {
                //create a new blank txt file of same name to outDirectory + \history\buildings\ using System.IO.File.Create
                System.IO.File.Create(outDirectory + @"\common\history\buildings\" + Path.GetFileName(file)).Close();

                string[] lines = File.ReadAllLines(file);

                int indentation = 0;
                State currentState = null;
                Nation currentNation = null;
                StateBuilding currentBuilding = null;
                SubState currentSubState = null;
                bool activeProductionMethodsFound = false;

                //for each line in the file
                foreach (string l1 in lines) {
                    string line = CleanLine(l1);

                    //if line is empty then continue
                    if (line == "") continue;

                    if (indentation == 1) {
                        if (line.StartsWith("s:")) {
                            string stateName = line.Split('=')[0].Split(':')[1].Trim();
                            //check if stateID is a state in stateSet
                            currentState = stateSet.FirstOrDefault(state => state.name == stateName);
                        }
                    }

                    else if (indentation == 2) {
                        if (line.StartsWith("region_state:")) {
                            string nationTag = line.Split(':')[1].Split('=')[0].Trim();
                            //check if nationTag is a tag in nationSet
                            currentNation = nationSet.FirstOrDefault(nation => nation.tag == nationTag);

                            //find the substate in currentNation.subStates where substate.parentState == currentState
                            currentSubState = currentNation.subStates.FirstOrDefault(substate => substate.parentState == currentState);
                        }
                    }

                    else if (indentation == 3) {
                        if (line.StartsWith("create_building")) {
                            currentBuilding = new StateBuilding();
                            //if currentSubState is not null then add to currentNation.stateBuildings
                            if (currentSubState != null) {
                                currentSubState.buildings.Add(currentBuilding);
                            }
                        }
                    }

                    else if(indentation == 4) {
                        if (line.StartsWith("building")) {
                            string buildingName = line.Split('=')[1].Replace("\"","").Trim();
                            //check if buildingName is a building in lsu.buildings
                            currentBuilding.building = lsu.buildings.FirstOrDefault(building => building.name == buildingName);
                        }
                        else if (line.StartsWith("level")) {
                            currentBuilding.level = int.Parse(line.Split('=')[1].Trim());
                        }
                        else if (line.StartsWith("reserves")){
                            currentBuilding.reserves = int.Parse(line.Split('=')[1].Trim());
                        }
                        else if (line.StartsWith("activate_production_methods")) {
                            activeProductionMethodsFound = true;
                        }
                    }

                    if (activeProductionMethodsFound) {
                        string[] words = line.Split();
                        foreach (string word in words) {
                            if (word.Contains("\"")) {
                                currentBuilding.activeProductionMethods.Add(word.Replace("\"", ""));
                            }
                        }
                    }

                    if (line.Contains("{") || line.Contains("}")) {
                        string[] l2 = line.Split();
                        foreach (string word in l2) {
                            if (word.Contains("{")) {
                                indentation++;
                            }
                            else if (word.Contains("}")) {
                                indentation--;
                                if (indentation == 1) {
                                    currentState = null;
                                }
                                else if (indentation == 2) {
                                    currentNation = null;
                                }
                                else if (indentation == 3) {
                                    currentBuilding = null;
                                }
                                else if (indentation == 4) {
                                    activeProductionMethodsFound = false;
                                }
                            }
                        }
                    }
                }

            }

            Console.WriteLine("Parsed state buildings in " + (DateTime.Now - dateTime).TotalSeconds + " seconds");
        }

        //get data returns regionSet, provSet, terrainSet, and mergedImage
        public (HashSet<Region>, HashSet<Province>, HashSet<Terrain>, HashSet<Culture>, HashSet<Nation>, Vic3ListStorageUnit, Bitmap) GetData() {

            return (regionSet, provSet, terrainSet, cultureSet, nationSet, lsu, mapImage);
        }
    }
}
