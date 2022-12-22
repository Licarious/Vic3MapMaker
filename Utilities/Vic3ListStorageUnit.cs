using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vic3MapMaker.Utilities
{
    public class Vic3ListStorageUnit
    {
        public List<string> stateTraits = new List<string>();
        public List<string> stateNames = new List<string>();
        public List<string> regionNames = new List<string>();
        public List<string> subsistenceBuildings = new List<string>();
        public List<string> resources = new List<string>();
        public List<string> cultures = new List<string>();
        public List<string> cultureGFX = new List<string>();
        public List<string> nationTags = new List<string>();
        public List<string> superRegions = new List<string>();
        public List<string> religions = new List<string>();
        public List<string> occupationTypes = new List<string>();
        public List<string> tags = new List<string>();

        public HashSet<State> states = new HashSet<State>();


        //set nationTier lsit to "recognized", "colonial", "unrecognized", and "decentralized"
        public List<string> nationTypes = new List<string>() { "recognized", "colonial", "unrecognized", "decentralized" };
        public List<string> nationTiers  = new List<string>();
    }
}
