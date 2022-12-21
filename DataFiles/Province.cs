using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization;

namespace Vic3MapMaker
{
    [DataContract(IsReference = true)]
    public class Province
    {
        public string name = "";
        public int internalID = -1;
        public string terrain = "";
        public Color color = Color.FromArgb(0, 0, 0, 0);
        public HashSet<(int, int)> coordSet = new HashSet<(int, int)>();
        public string hubName = "";
        public List<string> hubList = new List<string>();
        public bool isImpassible = false;
        public bool isPrimeLand = false;
        public bool isLake = false;
        public bool isSea = false;

        public string originalOwnerTAG = "";

        //list of hub enum and its name (hubEnum, hubName)
        public List<(Enum, string)> hubEnumList = new List<(Enum, string)>();
        //enum of hubTypes "City", "Port", "Wood", "Mine", "Farm", "None"
        public enum HubType { City, Port, Wood, Mine, Farm, None };


        public Province(string name) {
            this.name = name;
            this.color = ColorTranslator.FromHtml("#" + name.Replace("x", ""));
        }
        public Province(string name, Color color) {
            this.name = name;
            this.color = color;
        }
        public Province(Color color) {
            this.color = color;
            //convert color to hexidecimal
            this.name = "x"+color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
        }

        //tostring
        public override string ToString() {
            return name + ": " + coordSet.Count;
        }

        public string NameHex() {
            return "\"x"+(color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2")).ToUpper()+"\"";
        }

        public void Merge(Province other) {
            //merge any properties that are not default values from other to this
            if (other.name != "") {
                this.name = other.name;
            }
            if (other.internalID != -1) {
                this.internalID = other.internalID;
            }
            if (other.terrain != "") {
                this.terrain = other.terrain;
            }
            if (other.color != Color.FromArgb(0, 0, 0, 0)) {
                this.color = other.color;
            }
            if (other.hubName != "") {
                this.hubName = other.hubName;
            }
            if (other.isImpassible) {
                this.isImpassible = other.isImpassible;
            }
            if (other.isPrimeLand) {
                this.isPrimeLand = other.isPrimeLand;
            }
            if (other.isLake) {
                this.isLake = other.isLake;
            }
            if (other.isSea) {
                this.isSea = other.isSea;
            }
            if (other.coordSet.Count >= 0) {
                this.coordSet.UnionWith(other.coordSet);
            }
            if (other.originalOwnerTAG != "") {
                this.originalOwnerTAG = other.originalOwnerTAG;
            }
            if (other.hubList.Count > 0) {
                this.hubList = other.hubList;
            }

            //set other to an instance of this
            other = this;

        }

    }
}