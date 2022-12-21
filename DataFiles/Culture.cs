using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;

namespace Vic3MapMaker.DataFiles
{
    [DataContract(IsReference = true)]
    public class Culture
    {
        public string name;
        public Color color = Color.FromArgb(0, 0, 0, 0);
        public string religionName = "";
        //public Religion religion; //TODO add religion class
        public List<string> traits = new List<string>();
        public string graphics = "";

        public Culture() {
        }

        public Culture(string name) {
            this.name = name;
        }


    }
}
