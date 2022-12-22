using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using Vic3MapMaker.DataFiles;

namespace Vic3MapMaker
{
    [DataContract(IsReference = true)]
    public class Nation
    {
        public string tag = "";
        public string name = "";
        public int interalID = -1;
        public Color color = Color.FromArgb(0, 0, 0, 0);
        public Dictionary<Color, Province> provDict = new Dictionary<Color, Province>();
        public List<string> cultures = new List<string>();
        public string type = "";
        public string tier = "";
        public State capital = null;
        public List<State> claimList = new List<State>();
        public bool isNamedFromCapital = false;

        //Hash set of coordinates
        public HashSet<(int, int)> coordSet = new HashSet<(int, int)>();
        
        public HashSet<SubState> subStates = new HashSet<SubState>();

        public Nation(string tag) {
            this.tag = tag;
        }

        public Nation() {
        }

        //tostring override
        public override string ToString() {
            return tag;
        }


    }

}