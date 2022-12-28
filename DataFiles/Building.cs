using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vic3MapMaker.DataFiles
{
    public class Building
    {
        public string name = "";
        public string buildingGroup = "";
        public enum CityTypes { none, city, port, farm, mine, wood };
        public CityTypes cityType = CityTypes.none;
        public List<string> productionMethodGroups = new List<string>();

        public Building() { }

        public Building(string name) {
            this.name = name;
        }

        //toStirng
        public override string ToString() {
            return name + " " + buildingGroup + " " + cityType + " " + string.Join(", ", productionMethodGroups);
        }
    }
}
