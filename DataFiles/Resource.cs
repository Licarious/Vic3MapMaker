using System.Drawing;
using System.Runtime.Serialization;

namespace Vic3MapMaker
{
    [DataContract(IsReference = true)]
    //Resource class stores type, knownAmmount, discoverableAmmount
    public class Resource
    {
        public string name = "";
        public int knownAmmount = 0;
        public int discoverableAmmount = 0;
        public string type = "";
        public string depletedType = "";
        public Color color = Color.HotPink;
        public Color textColor = Color.DarkBlue;

        public Resource(string name) {
            this.name = name;
        }
        public Resource() { }
        
        //toString method
        public override string ToString() {
            //if agriculture
            if (type == "resource") {
                return name + ":\t" + knownAmmount;
            }
            //if discoverable
            else if (type == "discoverable") {
                string tmpNmae = this.name+":\t";
                if (knownAmmount > 0) {
                    tmpNmae +=  knownAmmount;
                    if (discoverableAmmount > 0) {
                        tmpNmae += " | " ;
                    }
                }
                if (discoverableAmmount > 0) {
                    tmpNmae += "(" + discoverableAmmount+")";
                }
                return tmpNmae;
            }
            return name;

            //return name + ": " + knownAmmount + "|(" + discoverableAmmount+")";
        }
    }
}