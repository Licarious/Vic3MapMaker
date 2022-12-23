using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vic3MapMaker.DataFiles
{
    public class SubState
    {
        public State parentState;
        public Nation owner;
        public string type = "";
        public Dictionary<Color, Province> provDict = new Dictionary<Color, Province>();
        public HashSet<Pop> pops = new HashSet<Pop>();
        public HashSet<Province> provs = new HashSet<Province>();

        public bool stillExists = true;

        public SubState(State parentState, Nation owner) {
            this.parentState = parentState;
            this.owner = owner;
        }

        public SubState() {
        }

        //toStirng
        public override string ToString() {
            return parentState.name.Replace("STATE_", "").Replace("_", " ");

        }

    }
}
