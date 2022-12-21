using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;

namespace Vic3MapMaker
{
    [DataContract(IsReference = true)]
    //State class stores provIDlsit, name, arabelResoures, cappedResoures, and discoverableResources
    public class State
    {
        public string name = "";
        public int stateID = -1;
        public List<string> traits = new List<string>();
        public string subsistenceBuilding = "";
        public int navalID = -1;
        public List<Resource> resources = new List<Resource>();
        public int arableLand = 0;
        public Color color = Color.FromArgb(0, 0, 0, 0);

        //common\history\states stuff
        public List<string> homeLandList = new List<string>();
        public List<string> claimList = new List<string>();
        public List<(string tag, string stateType)> stateTypeList = new List<(string tag, string stateType)>();

        //hub list for writing to file
        public List<(string, string)> hubList = new List<(string, string)>();

        //dictionary of color and its province
        public Dictionary<Color, Province> provDict = new Dictionary<Color, Province>();

        public State(string name) {
            this.name = name;
        }
        public State() { }


        //creat a new province object and add it to provDict
        public void AddProv(string p) {
            Province prov = new Province(p, ColorTranslator.FromHtml("#" + p.Replace("x", "")));
            provDict.Add(prov.color, prov);
        }


        //tostring
        public override string ToString() {
            return name.Replace("STATE_", "");
        }

        public void GenerateHubList() {
            hubList.Clear();
            foreach (KeyValuePair<Color, Province> prov in provDict) {
                if (prov.Value.hubName != "") {
                    //if hubName is already in hubList
                    if (hubList.Exists(x => x.Item1 == prov.Value.hubName)) {
                        //clear this hubName from prov
                        prov.Value.hubName = "";
                        continue;
                    }
                    hubList.Add((prov.Value.hubName, prov.Value.NameHex()));
                }
            }
        }

    }
}