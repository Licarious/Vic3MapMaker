using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vic3MapMaker.DataFiles
{
    public class StateBuilding
    {
        public Building building = null;
        public int level = 0;
        public int reserves = 0;
        public List<string> activeProductionMethods = new List<string>();

        public StateBuilding() { }

        //toStirng
        public override string ToString() {
            //join activeProductionMethods with ", "
            return building.name + " " + level + " " + reserves + " " + string.Join(", ", activeProductionMethods);
        }
    }
}
