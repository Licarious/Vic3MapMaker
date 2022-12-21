using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace Vic3MapMaker
{
    [DataContract(IsReference = true)]
    public class Terrain
    {
        public string name;
        public Color color;


        public Terrain(string name) {
            this.name = name;
        }

        //toString
        public override string ToString() {
            return name;
        }
    }
}
