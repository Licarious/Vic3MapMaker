using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;

namespace Vic3MapMaker
{
    [DataContract(IsReference = true)]
    //class Region stores Name, Color, and States
    public class Region
    {
        public string name = "";
        public string gfxCulture = "";
        public string superRegion = "";
        public Color color = Color.FromArgb(0, 0, 0, 0);
        public HashSet<State> states = new HashSet<State>();
        public Province capital = null;
        public string capitalName = "";

        public Region(string name) {
            this.name = name;
        }
        public Region() { }

        //tostring
        public override string ToString() {
            return name.Replace("region_", "");
        }
    }
}