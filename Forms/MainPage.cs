﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Vic3MapMaker.DataFiles;
using Vic3MapMaker.Forms;
using Vic3MapMaker.Utilities;

namespace Vic3MapMaker
{
    public partial class MainPage : Form
    {
        HashSet<Region> regionSet;
        HashSet<Province> provSet;
        HashSet<Terrain> terrainSet;
        HashSet<Culture> cultureSet;
        HashSet<Nation> nationSet;
        Bitmap mergedImage;
        MapOperation mapOp = new MapOperation();
        Vic3ListStorageUnit lsu = new Vic3ListStorageUnit();
        double imageScale = 1.0;

        readonly double maximumZoom = 4.0;
        readonly FileOutputer fo;


        public MainPage((HashSet<Region> regionSet, HashSet<Province> provSet, HashSet<Terrain> terrainSet, HashSet<Culture> cultureSet, HashSet<Nation> nationSet, Bitmap mapImage) parssedTupple, string outputDirectory) {
            this.regionSet = parssedTupple.regionSet;
            this.provSet = parssedTupple.provSet;
            this.terrainSet = parssedTupple.terrainSet;
            this.mergedImage = parssedTupple.mapImage;
            this.cultureSet = parssedTupple.cultureSet;
            this.nationSet = parssedTupple.nationSet;

            fo = new FileOutputer(outputDirectory);

            InitializeComponent();

            //set the size of the picturebox to the size of the image
            pictureBox1.Size = mergedImage.Size;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = mergedImage;
            //pictureBox1.Refresh();


            //add ability to zoom in and out with + and - keys on the picturebox
            this.KeyPreview = true;
            this.KeyPress += new KeyPressEventHandler(MainForm_KeyPress);

            //check transfer prov and state radio buttons to default
            transferProvinceRadioButton.Checked = true;
            transferStateRadioButton.Checked = true;

            //default selection in categoryComboBox to state
            categoryComboBox.SelectedIndex = 1;
            


        }

        //detect if close button on top right is pressed
        protected override void OnFormClosing(FormClosingEventArgs e) {
            //exit application if close button is pressed
            if (e.CloseReason == CloseReason.UserClosing) {
                Application.Exit();
            }
        }


        private void Form1_Load(object sender, EventArgs e) {

        }

        //main progarm key press handeler
        private void MainForm_KeyPress(object sender, KeyPressEventArgs e) {
            //if the mouse wheel is scrolled up (forward) scale up the picturebox and image by 10%
            if (e.KeyChar == '+') {
                //no more than 400% zoom
                if (imageScale >= maximumZoom) {
                    return;
                }
                //scale up the image
                imageScale += 0.25;
                //scale up the picturebox
                pictureBox1.Size = new Size((int)(mergedImage.Width * imageScale), (int)(mergedImage.Height * imageScale));
            }
            //if the mouse wheel is scrolled down (backward) scale down the picturebox and image by 10%
            else if (e.KeyChar == '-' && imageScale > 0.25) {
                //scale down the image
                imageScale -= 0.25;
                //scale down the picturebox
                pictureBox1.Size = new Size((int)(mergedImage.Width * imageScale), (int)(mergedImage.Height * imageScale));
            }
            //Console.WriteLine("pressed " + e.KeyChar);

        }

        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            //set specific panels to invisible
            statePanel.Visible = false;
            regionPannel.Visible = false;

            //case statement to determine what to do with the selected item
            switch (categoryComboBox.SelectedItem) {
                case "Prov":
                    //highlight each province in the province set
                    foreach (Province p in provSet) {
                        HighlightProv(p, p.color, false);
                    }
                    pictureBox1.Refresh();
                    break;
                case "State":
                    statePanel.Visible = true;
                    //update itemComboBox to show all states in each r in regionSet and sort by name
                    itemComboBox.DataSource = regionSet.SelectMany(r => r.states).OrderBy(s => s.name).ToList();
                    //highlight each s in the map
                    foreach (State state in regionSet.SelectMany(r => r.states)) {
                        HighlightState(state, state.color);
                    }

                    break;
                case "Region":
                    regionPannel.Visible = true;
                    //update itemComboBox to show the regions in the regionSet
                    itemComboBox.DataSource = regionSet.OrderBy(r => r.name).ToList();
                    //highlight each r in the map
                    foreach (Region region in regionSet) {
                        foreach (State state in region.states) {
                            HighlightState(state, region.color);
                        }
                    }
                    break;
                case "PrimeLand":
                    ColorPrimeLand();
                    break;
                case "Impassable":
                    ColorImpassable();
                    break;
                case "Terrain":
                    //update itemComboBox to show the terrains in the terrainSet starting with a blank entry
                    List<string> terrainList = new List<string> { "" };
                    terrainList.AddRange(terrainSet.Select(t => t.name).OrderBy(t => t).ToList());

                    itemComboBox.DataSource = terrainList;
                    break;
                case "Country":
                    //set other combo box to show all nations
                    itemComboBox.DataSource = nationSet.OrderBy(n => n.tag).ToList();
                    RefreshMap();

                    break;
                default:
                    //clear the dropdown box
                    itemComboBox.DataSource = null;
                    break;

            }
        }

        private void ItemComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            //case statement to determine what to do with the selected item
            switch (categoryComboBox.SelectedItem) {
                //if item selected is a State object
                case "State":
                    //cast the selected item to a State object
                    State state = (State)itemComboBox.SelectedItem;
                    HighlightState(state, state.color);
                    RefreshHubTextBoxes(state);

                    break;
                case "Region":
                    //cast the selected item to a Region object
                    Region region = (Region)itemComboBox.SelectedItem;
                    //if region is not null
                    if (region != null) {
                        //highlight each s in the r
                        foreach (State state1 in region.states) {
                            HighlightState(state1, region.color);
                        }
                        RefreshRegionTextBoxes(region);
                    }
                    break;
                case "Terrain":
                    //set text box to the selected item
                    textBoxCurrentlySelectedMapArea.Text = itemComboBox.SelectedItem.ToString();
                    ColorTerrain(highlightTerrain: textBoxCurrentlySelectedMapArea.Text);

                    break;
                case "Country":
                    //set text box to the selected item
                    Nation nation = (Nation)itemComboBox.SelectedItem;
                    if (nation != null) {
                        textBoxCurrentlySelectedMapArea.Text = nation.tag;
                    }

                    break;
                default:
                    break;
            }
        }

        private void RefreshHubTextBoxes(State state) {
            //set stateNavalExitTextBox to the s's naval ID
            stateNavalExitTextBox.Text = state.navalID.ToString();

            //clear all the hubTextBoxes
            hubCityTextBox.Text = "";
            hubPortTextBox.Text = "";
            hubWoodTextBox.Text = "";
            hubMineTextBox.Text = "";
            hubFarmTextBox.Text = "";
            //go through each prov in the states provDict and add the hub info to the hubTextBoxes
            foreach (Province prov in state.provDict.Values) {
                if (prov.hubList.Count > 0) {
                    if (prov.hubList.Contains("city")) {
                        hubCityTextBox.Text = prov.name;
                    }
                    if (prov.hubList.Contains("port")) {
                        hubPortTextBox.Text = prov.name;
                    }
                    if (prov.hubList.Contains("wood")) {
                        hubWoodTextBox.Text = prov.name;
                    }
                    if (prov.hubList.Contains("mine")) {
                        hubMineTextBox.Text = prov.name;
                    }
                    if (prov.hubList.Contains("farm")) {
                        hubFarmTextBox.Text = prov.name;
                    }
                }
            }
        }

        private void RefreshRegionTextBoxes(Region region) {
            //clear regionCapitalTextBox
            regionCapitalTextBox.Text = "";

            if (region.capital != null) {
                regionCapitalTextBox.Text = region.capital.name;
            }

        }

        private void HighlightState(State state, Color color, bool refresh = true) {
            //change the color of the pixels in the s to s.color
            foreach (Province province in state.provDict.Values) {
                //Console.WriteLine(province);
                HighlightProv(province, color, false);
            }
            //Console.WriteLine(s.name + " Completed color change");
            //update the picturebox
            if (refresh) {
                pictureBox1.Refresh();
            }
        }
        private void HighlightProv(Province province, Color color, bool refresh = true) {
            //change the color of the pixels in the s to s.color
            foreach ((int, int) coord in province.coordSet) {
                //if mergedImage has an alpha value of 250 continue
                if (mergedImage.GetPixel(coord.Item1, coord.Item2).A == 250) {
                    continue;
                }

                mergedImage.SetPixel(coord.Item1, coord.Item2, color);
            }
            //update the picturebox
            if (refresh) {
                pictureBox1.Refresh();
            }

        }

        private void PictureBox1_Click(object sender, EventArgs e) {
            //get mouse button pressed
            MouseButtons mouseButton = ((MouseEventArgs)e).Button;
            //Console.WriteLine(mouseButton);

            //get and normalize the mouse position
            Point curcerPoint = pictureBox1.PointToClient(Cursor.Position);
            Point normalizedPoint = new Point((int)(curcerPoint.X / imageScale), (int)(curcerPoint.Y / imageScale));

            //Store Region, State, and Province of the pixel clicked
            Region fromRegion = null;
            State fromState = null;
            Province fromProvince = null;
            Nation fromNation = null;

            bool exitRegion = false;
            foreach (Region region in regionSet) {
                foreach (State state in region.states) {
                    foreach (Province province in state.provDict.Values) {
                        if (province.coordSet.Contains((normalizedPoint.X, normalizedPoint.Y))) {
                            fromRegion = region;
                            fromState = state;
                            fromProvince = province;
                            exitRegion = true;
                            Console.WriteLine(fromProvince.name + " " + fromState.name + " " + fromRegion.name);
                            break;
                        }
                    }
                    if (exitRegion) break;
                }
                if (exitRegion) break;
            }
            if (fromProvince == null) {
                foreach (Province province in provSet) {
                    if (province.coordSet.Contains((normalizedPoint.X, normalizedPoint.Y))) {
                        fromProvince = province;
                        break;
                    }
                }
            }
            //find nation with fromProvince in its provDict
            foreach (Nation nation in nationSet) {
                if (nation.provDict.ContainsValue(fromProvince)) {
                    fromNation = nation;
                    break;
                }
            }

            //case statement to determine what to do with the selected item
            switch (categoryComboBox.SelectedItem) {
                case "Prov":
                    //set text box to the name of the province
                    textBoxCurrentlySelectedMapArea.Text = fromProvince.name;
                    break;

                //if item selected is a State object
                case "State":
                    //if the right mouse button is pressed
                    if (fromState == null) break;
                    //case statement to determine which radio button is selected
                    if (mouseButton == MouseButtons.Right) {

                        textBoxCurrentlySelectedMapArea.Text = fromState.name;
                        HighlightState(fromState, fromState.color);
                        stateNavalExitTextBox.Text = fromState.navalID.ToString();

                        //go through itemComboBox and set the selected item to the s
                        foreach (State item in itemComboBox.Items) {
                            if (item == fromState) {
                                itemComboBox.SelectedItem = item;
                                break;
                            }
                        }

                    }
                    else if (mouseButton == MouseButtons.Left) {
                        State toState = null;
                        //if textbox contains a s name then print out the s
                        foreach (State state in regionSet.SelectMany(x => x.states)) {
                            if (state.name == textBoxCurrentlySelectedMapArea.Text) {
                                toState = state;
                                //Console.WriteLine(toState.name);
                                break;
                            }
                        }
                        if (toState != null) {
                            //raido button is checked
                            //remove the province from the toState and add it to the fromState
                            if (transferProvinceRadioButton.Checked) {
                                try {
                                    mapOp.MoveProvince(fromState, toState, fromProvince);
                                    //push the change onto the undo stack

                                    //update the picturebox
                                    HighlightState(toState, toState.color);
                                    pictureBox1.Refresh();
                                }
                                catch {
                                    Console.WriteLine("Error: " + fromProvince.color + " is already in " + fromState.name);
                                }
                            }

                            //chagne naval exit
                            else if (navalExitRadioButton.Checked) {
                                //set the naval exit of the toState to the fromState and uncheck the checkbox if successful
                                if (mapOp.ChangeStateNavalID(toState, fromState.stateID, fromProvince.isSea)) {
                                    stateNavalExitTextBox.Text = toState.navalID.ToString();
                                }
                            }

                            //Hubs
                            else if (hubCityUpdateRadioButton.Checked) {
                                //find prov in toState with the same name as name in textBox
                                Province oldProv = toState.provDict.Values.FirstOrDefault(x => x.name == hubCityTextBox.Text);

                                if (mapOp.SetHub(toState, fromProvince, oldProv, "city")) {
                                    hubCityTextBox.Text = fromProvince.name;
                                }

                            }
                            else if (hubPortUpdateRadioButton.Checked) {
                                //find prov in toState with the same name as name in textBox
                                Province oldProv = toState.provDict.Values.FirstOrDefault(x => x.name == hubPortTextBox.Text);

                                if (mapOp.SetHub(toState, fromProvince, oldProv, "port")) {
                                    hubPortTextBox.Text = fromProvince.name;
                                }

                            }
                            else if (hubWoodUpdateRadioButton.Checked) {
                                //find prov in toState with the same name as name in textBox
                                Province oldProv = toState.provDict.Values.FirstOrDefault(x => x.name == hubWoodTextBox.Text);

                                if (mapOp.SetHub(toState, fromProvince, oldProv, "wood")) {
                                    hubWoodTextBox.Text = fromProvince.name;
                                }
                            }
                            else if (hubMineUpdateRadioButton.Checked) {
                                //find prov in toState with the same name as name in textBox
                                Province oldProv = toState.provDict.Values.FirstOrDefault(x => x.name == hubMineTextBox.Text);

                                if (mapOp.SetHub(toState, fromProvince, oldProv, "mine")) {
                                    hubMineTextBox.Text = fromProvince.name;
                                }
                            }
                            else if (hubFarmUpdateRadioButton.Checked) {
                                //find prov in toState with the same name as name in textBox
                                Province oldProv = toState.provDict.Values.FirstOrDefault(x => x.name == hubFarmTextBox.Text);

                                if (mapOp.SetHub(toState, fromProvince, oldProv, "farm")) {
                                    hubFarmTextBox.Text = fromProvince.name;
                                }
                            }

                        }
                        break;
                    }


                    if (mouseButton == MouseButtons.Left) {
                        State toState = null;
                        //if textbox contains a s name then print out the s
                        foreach (State state in regionSet.SelectMany(x => x.states)) {
                            if (state.name == textBoxCurrentlySelectedMapArea.Text) {
                                toState = state;
                                break;
                            }
                        }

                        if (fromProvince == null || fromState == toState) break;


                        //add the prov ouside of any state into a state
                        if (transferProvinceRadioButton.Checked) {
                            try {
                                mapOp.MoveProvince(fromState, toState, fromProvince);

                                //update the picturebox
                                HighlightState(toState, toState.color);
                                pictureBox1.Refresh();
                            }
                            catch {
                                Console.WriteLine("Error: " + fromProvince.color + " is already in " + fromState.name);
                            }
                        }
                    }

                    break;
                case "Region":
                    if (fromRegion == null) break;
                    //if the right mouse button is pressed
                    if (mouseButton == MouseButtons.Right) {
                        //set the textbox to the selected r
                        textBoxCurrentlySelectedMapArea.Text = fromRegion.name;

                        //go through categoryComboBox and set the selected item to the region
                        foreach (Region item in itemComboBox.Items) {
                            if (item == fromRegion) {
                                itemComboBox.SelectedItem = item;
                                break;
                            }
                        }
                    }
                    else if (mouseButton == MouseButtons.Left) {
                        //get the r to apply the s to
                        Region toRegion = null;
                        foreach (Region region in regionSet) {
                            if (region.name == textBoxCurrentlySelectedMapArea.Text) {
                                toRegion = region;
                                break;
                            }
                        }

                        if (toRegion == null || fromRegion == toRegion) break;

                        //transfer s clicked on to the r in the textbox
                        if (transferStateRadioButton.Checked) {
                            //remove the s from the toProvince and add it to the fromRegion
                            if (toRegion != null) {
                                try {
                                    mapOp.MoveState(fromRegion, toRegion, fromState);
                                    //push the change onto the undo stack

                                    //update the picturebox
                                    HighlightState(fromState, toRegion.color);
                                    pictureBox1.Refresh();
                                }
                                catch {
                                    Console.WriteLine("Error: " + fromState.name + " is already in " + fromRegion.name);
                                }
                            }
                        }
                        //change Capital
                        else if (ChangeCapitalRadioButton.Checked) {
                            //check if the prov is in any of the states in the r
                            if (toRegion.states.Any(x => x.provDict.Values.Any(y => y == fromProvince))) {
                                //change the capital of the r
                                if (mapOp.ChangeCapital(toRegion, fromProvince)) {
                                    //update the textbox
                                    regionCapitalTextBox.Text = fromProvince.name;
                                }
                            }
                        }
                    }
                    break;
                //case PrimeLand is selected
                case "PrimeLand":
                    if (fromProvince == null) break;
                    //toggle the prime land in the province
                    mapOp.TogglePrimeland(fromProvince);

                    if (!(fromProvince.isSea || fromProvince.isLake)) {
                        Color primeColor = fromProvince.isPrimeLand ? Color.Green : Color.White;

                        HighlightProv(fromProvince, primeColor);
                    }

                    break;
                case "Impassable":
                    if (fromProvince == null) break;
                    //toggle the impassible in the province
                    mapOp.ToggleImpassable(fromProvince);
                    Color impassableColor = fromProvince.isImpassible ? Color.DarkGray : Color.White;
                    if (fromProvince.isSea || fromProvince.isLake) {
                        impassableColor = fromProvince.isImpassible ? Color.DarkBlue : Color.Blue;
                    }
                    HighlightProv(fromProvince, impassableColor);

                    break;
                case "Terrain":
                    if (fromProvince == null) break;
                    if (mouseButton == MouseButtons.Right) {
                        //set text box to the terrain type of the province
                        textBoxCurrentlySelectedMapArea.Text = fromProvince.terrain;

                    }
                    else if (mouseButton == MouseButtons.Left) {
                        //get the terrain name from textBoxCurrentlySelectedMapArea and set the terrain of the province to that
                        mapOp.ChangeTerrain(fromProvince, textBoxCurrentlySelectedMapArea.Text.ToString());

                        ColorTerrain(prov: fromProvince);
                    }

                    break;
                case "Country":
                    if (fromNation == null) break;
                    if (mouseButton == MouseButtons.Right) {
                        //set text box to the terrain type of the province
                        textBoxCurrentlySelectedMapArea.Text = fromNation.tag;
                        //set itemComboBox to the nation
                        itemComboBox.SelectedItem = fromNation;

                    }
                    else if (mouseButton == MouseButtons.Left) {
                        Nation toNation = null;
                        foreach (Nation nation in nationSet) {
                            if (nation.tag == textBoxCurrentlySelectedMapArea.Text) {
                                toNation = nation;
                                break;
                            }
                        }

                        if (toNation == fromNation) break;

                        //transfer s clicked on to the apply nation in the textbox
                        if (transferProvinceNationalRadioButton.Checked) {
                            mapOp.MoveProvince(fromNation, toNation, fromProvince);
                            HighlightProv(fromProvince, toNation.color, false);
                        }
                        else if (transferStateNationalRadioButton.Checked) {
                            foreach (Province p in fromState.provDict.Values) {
                                //check if p is in fromNation.provDict
                                if (fromNation.provDict.Values.Contains(p)) {
                                    mapOp.MoveProvince(fromNation, toNation, p);
                                    HighlightProv(p, toNation.color, false);
                                }
                            }
                        }
                        else if (transferRegionNationalRadioButton.Checked) {
                            foreach (State s in fromRegion.states) {
                                foreach (Province p in s.provDict.Values) {
                                    //check if p is in fromNation.provDict
                                    if (fromNation.provDict.Values.Contains(p)) {
                                        mapOp.MoveProvince(fromNation, toNation, p);
                                        HighlightProv(p, toNation.color, false);
                                    }
                                }
                            }
                        }
                        pictureBox1.Refresh();
                    }

                    break;
            }
        }


        private void ColorPrimeLand() {
            //for each prov in each s in each r set primland to green
            foreach (Region region in regionSet) {
                foreach (State state in region.states) {
                    foreach (Province province in state.provDict.Values) {
                        //if the prov is prime land
                        if (province.isPrimeLand) {
                            HighlightProv(province, Color.Green, false);
                        }
                        else if (province.isSea || province.isLake) {
                            HighlightProv(province, Color.Blue, false);
                        }
                        else {
                            HighlightProv(province, Color.White, false);
                        }

                    }
                }
            }
            //update the picturebox
            pictureBox1.Refresh();
        }

        private void ColorImpassable() {
            //for each prov in each s in each r set primland to green
            foreach (Region region in regionSet) {
                foreach (State state in region.states) {
                    foreach (Province province in state.provDict.Values) {
                        //if the prov isImpassible
                        if (province.isImpassible) {
                            if (province.isSea || province.isLake) {
                                HighlightProv(province, Color.DarkBlue, false);
                            }
                            else {
                                HighlightProv(province, Color.DarkGray, false);
                            }
                        }
                        else if (province.isSea || province.isLake) {
                            HighlightProv(province, Color.Blue, false);
                        }
                        else {
                            HighlightProv(province, Color.White, false);
                        }
                    }
                }
            }
            //update the picturebox
            pictureBox1.Refresh();
        }

        private void EditStateRegioon_Click(object sender, EventArgs e) {
            RefreshLSU();

            //case statement to determine what to do with the selected item
            switch (categoryComboBox.SelectedItem) {
                //if item selected is a State object
                case "State":
                    //open new form to edit the s
                    State state = (State)itemComboBox.SelectedItem;
                    //EditState open form
                    EditState editState = new EditState(state, lsu, mapOp);
                    editState.ShowDialog();

                    break;
                case "Region":
                    //open new form to edit the region
                    Region region = (Region)itemComboBox.SelectedItem;

                    //EditRegion open form
                    EditRegion editRegion = new EditRegion(region, lsu, mapOp);
                    editRegion.ShowDialog();

                    break;
            }

        }

        private void ColorTerrain(string highlightTerrain = "", Province prov = null) {
            if (prov != null) {
                //find color of terrain for the province
                foreach (Terrain terrain in terrainSet) {
                    if (terrain.name == prov.terrain) {
                        HighlightProv(prov, terrain.color);
                        break;
                    }
                }
            }
            else {
                //for each prov in provSet
                foreach (Province province in provSet) {

                    Color terrainColor = Color.White;
                    //find color of terrain for the province
                    foreach (Terrain terrain in terrainSet) {
                        if (terrain.name == province.terrain) {
                            if (terrain.name.Contains(highlightTerrain) || highlightTerrain == "") {
                                terrainColor = terrain.color;
                            }
                            break;
                        }
                    }

                    HighlightProv(province, terrainColor, false);

                }
            }
            //update the picturebox
            pictureBox1.Refresh();
        }

        private void ButtonSave_Click(object sender, EventArgs e) {
            fo.WriteStateRegions(regionSet);
            fo.WriteTerrain(provSet);
            fo.WriteRegions(regionSet);
        }

        private void UndoButton_Click(object sender, EventArgs e) {
            mapOp.Undo();
            switch (categoryComboBox.SelectedItem) {
                //if s is selected from the dropdown box
                case "State":
                    //find the s in text box
                    State state = (State)categoryComboBox.SelectedItem;
                    RefreshHubTextBoxes(state);
                    break;
                case "Region":
                    //find the r in text box
                    Region region = (Region)categoryComboBox.SelectedItem;
                    RefreshRegionTextBoxes(region);
                    break;
            }
        }

        private void ClearUpdateHubButton_Click(object sender, EventArgs e) {
            Console.WriteLine("Clear button ckicked");

            //find the s in text box
            State state = (State)categoryComboBox.SelectedItem;
            //exit navel
            if (navalExitRadioButton.Checked) {
                mapOp.ClearStateNavalID(state);
                //update naval exit text box
                stateNavalExitTextBox.Text = state.navalID.ToString();


            }
            //clear the update hub
            else if (hubCityUpdateRadioButton.Checked) {
                Province oldProv = state.provDict.Values.FirstOrDefault(x => x.name == hubCityTextBox.Text);
                mapOp.ClearHub(state, oldProv, "city");
                //update hub city text box
                hubCityTextBox.Text = "";
            }
            else if (hubPortUpdateRadioButton.Checked) {
                Province oldProv = state.provDict.Values.FirstOrDefault(x => x.name == hubPortTextBox.Text);
                mapOp.ClearHub(state, oldProv, "port");
                //update hub city text box
                hubPortTextBox.Text = "";
            }
            else if (hubWoodUpdateRadioButton.Checked) {
                Province oldProv = state.provDict.Values.FirstOrDefault(x => x.name == hubWoodTextBox.Text);
                mapOp.ClearHub(state, oldProv, "wood");
                //update hub city text box
                hubWoodTextBox.Text = "";
            }
            else if (hubMineUpdateRadioButton.Checked) {
                Province oldProv = state.provDict.Values.FirstOrDefault(x => x.name == hubMineTextBox.Text);
                mapOp.ClearHub(state, oldProv, "mine");
                //update hub city text box
                hubMineTextBox.Text = "";
            }
            else if (hubFarmUpdateRadioButton.Checked) {
                Province oldProv = state.provDict.Values.FirstOrDefault(x => x.name == hubFarmTextBox.Text);
                mapOp.ClearHub(state, oldProv, "farm");
                //update hub city text box
                hubFarmTextBox.Text = "";
            }
            RefreshHubTextBoxes(state);
        }

        private void RefreshMap() {
            int count=0;
            switch (categoryComboBox.SelectedItem) {
                case "State":
                    //highlight all states
                    foreach (Region r in regionSet) {
                        foreach (State s in r.states) {
                            count++;
                            HighlightState(s, s.color, false);
                        }
                    }
                    break;
                case "Region":
                    //highlight all regions
                    foreach (Region r in regionSet) {
                        foreach (State s in r.states) {
                            HighlightState(s, r.color, false);
                        }
                    }
                    break;
                case "Terrain":
                    //highlight all terrain
                    ColorTerrain(highlightTerrain: textBoxCurrentlySelectedMapArea.Text);
                    break;
                case "PrimeLand":
                    ColorPrimeLand();
                    break;
                case "Impassable":
                    ColorImpassable();
                    break;
                case "Country":
                    //highlight all nations
                    foreach (Nation n in nationSet) {
                        //for each province in nation.provDict
                        foreach (Province p in n.provDict.Values) {
                            count++;
                            HighlightProv(p, n.color, count % 1000 == 0);
                        }
                    }
                    break;

            }
            pictureBox1.Refresh();
        }

        private void refreshMapButton_Click(object sender, EventArgs e) {
            RefreshMap();
        }

        private void CreateNewRegionButton_Click(object sender, EventArgs e) {
            RefreshLSU();

            //create a new region
            Region newRegion = new Region();

            //EditRegion open form
            EditRegion editRegion = new EditRegion(newRegion, lsu, mapOp);
            //set the name of the form to "Create Region"
            editRegion.Text = "Create New Region";
            editRegion.ShowDialog();

            //if user saved the region in editRegion form add it to regionSet using mapOp
            if (editRegion.DialogResult == DialogResult.OK) {
                mapOp.AddRegion(newRegion, regionSet);
                //disable dataSource for categoryComboBox
                categoryComboBox.DataSource = null;
                //update the region drop down box
                categoryComboBox.Items.Clear();
                foreach (Region region in regionSet) {
                    categoryComboBox.Items.Add(region);
                }
                categoryComboBox.SelectedItem = newRegion;
            }

            
        }

        //refresh lsu
        private void RefreshLSU() {
            //clear stateTraits
            lsu.stateTraits.Clear();
            //get a list of all s traits from regionSet
            foreach (Region region1 in regionSet) {
                foreach (State state1 in region1.states) {
                    foreach (string trait in state1.traits) {
                        if (!lsu.stateTraits.Contains(trait)) {
                            lsu.stateTraits.Add(trait);
                        }
                    }
                }
            }
            //clear subsistenceBuildings
            lsu.subsistenceBuildings.Clear();
            //get a list of all subsistenceBuildings from regionSet
            foreach (Region region1 in regionSet) {
                foreach (State state1 in region1.states) {
                    if (!lsu.subsistenceBuildings.Contains(state1.subsistenceBuilding)) {
                        lsu.subsistenceBuildings.Add(state1.subsistenceBuilding);
                    }
                }
            }

            //clear resources
            lsu.resources.Clear();
            //get a list of all resources from regionSet
            foreach (Region region1 in regionSet) {
                foreach (State state1 in region1.states) {
                    foreach (Resource resource in state1.resources) {
                        if (!lsu.resources.Contains(resource.name)) {
                            lsu.resources.Add(resource.name);
                        }
                    }
                }
            }

            //clear cultures
            lsu.cultures.Clear();
            //get a list of all cultures from cultureSet
            foreach (Culture culture in cultureSet) {
                lsu.cultures.Add(culture.name);
            }

            //clear cultureGFX
            lsu.cultureGFX.Clear();
            //get a list of all cultureGFX from regionSet
            foreach (Region region1 in regionSet) {
                if (!lsu.cultureGFX.Contains(region1.gfxCulture)) {
                    lsu.cultureGFX.Add(region1.gfxCulture);
                }
            }

            //clear state names
            lsu.stateNames.Clear();
            //get a list of all state names from regionSet
            foreach (Region region1 in regionSet) {
                foreach (State state1 in region1.states) {
                    if (!lsu.stateNames.Contains(state1.name)) {
                        lsu.stateNames.Add(state1.name);
                    }
                }
            }

            //clear region names
            lsu.regionNames.Clear();
            //get a list of all region names from regionSet
            foreach (Region region1 in regionSet) {
                if (!lsu.regionNames.Contains(region1.name)) {
                    lsu.regionNames.Add(region1.name);
                }
            }

            //clear nationtags
            lsu.nationTags.Clear();
            //get a list of all nationtags from nationSet
            foreach (Nation nation in nationSet) {
                if (!lsu.nationTags.Contains(nation.tag)) {
                    lsu.nationTags.Add(nation.tag);
                }
            }

            //clear superRegions
            lsu.superRegions.Clear();
            //get a list of all superRegions from regionSet
            foreach (Region region1 in regionSet) {
                if (!lsu.superRegions.Contains(region1.superRegion)) {
                    lsu.superRegions.Add(region1.superRegion);
                }
            }


        }
    }
}