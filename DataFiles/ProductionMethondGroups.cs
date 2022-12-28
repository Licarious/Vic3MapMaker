using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vic3MapMaker.DataFiles
{
    public class ProductionMethondGroups
    {
        public string group = "";
        public List<string> productionMethods = new List<string>();

        public ProductionMethondGroups() { }

        public ProductionMethondGroups(string group) {
            this.group = group;
        }

        //toStirng
        public override string ToString() {
            return group.Replace("pmg_", "").Replace("_", " ");
        }
    }
}
