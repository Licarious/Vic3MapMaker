using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vic3MapMaker.DataFiles
{
    public class Pop
    {
        public string cultureString = "";
        public Culture culture;
        public int size = 0;
        public string type  = "";
        public string religion = "";

        public Pop() { }
        
        public Pop(string culture, int size) {
            this.cultureString = culture;
            this.size = size;
        }
        public Pop(Culture culture, int size) {
            this.culture = culture;
            this.size = size;
        }

        //toString
        public override string ToString() {
            return type + " " + size + " " + cultureString + " " + religion;
        }
    }
}
