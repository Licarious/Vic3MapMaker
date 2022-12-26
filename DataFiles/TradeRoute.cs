using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vic3MapMaker.DataFiles
{
    public class TradeRoute
    {
        public Nation target = null;
        public string goods = "";
        public bool isExport = false;
        public int level = 0;

        public TradeRoute() { }


        //toString
        public override string ToString() {
            return target.name + " " + goods + " " + isExport + " " + level;
        }

    }
}
