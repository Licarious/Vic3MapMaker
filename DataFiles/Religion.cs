using System.Collections.Generic;
using System.Drawing;

namespace Vic3MapMaker.DataFiles
{
    public class Religion
    {
        public string name;
        public Color color = Color.FromArgb(0, 0, 0, 0);
        public List<string> traits = new List<string>();
        public List<string> taboos = new List<string>();

        public Religion() { }

        public Religion(string name) {
            this.name = name;
        }

        public override string ToString() {
            return name;
        }
    }
}
