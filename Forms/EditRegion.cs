using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Vic3MapMaker.Utilities;

namespace Vic3MapMaker.Forms
{
    public partial class EditRegion : Form
    {
        public Region region;
        Vic3ListStorageUnit lsu = new Vic3ListStorageUnit();
        MapOperation mapOp;
        int initalUndoCount;

        public EditRegion(Region region,  Vic3ListStorageUnit lsu, MapOperation mapOp) {
            this.region = region;
            this.lsu = lsu;
            this.mapOp = mapOp;

            initalUndoCount = mapOp.StackSize;

            InitializeComponent();

            //set the textboxes to the region's values
            regionNameTextBox.Text = region.name;
            cultureGFXTextBox.Text = region.gfxCulture;
            superRegionTextBox.Text = region.superRegion;

            //set the color button to the region's color
            colorButton.BackColor = region.color;

            //add autocomplte to the cultureGFXTextBox from the list of allCultureGFX
            cultureGFXTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cultureGFXTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cultureGFXTextBox.AutoCompleteCustomSource.AddRange(lsu.cultureGFX.ToArray());

            //add autocomplte to the superRegionTextBox from the list of allSuperRegions
            superRegionTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            superRegionTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            superRegionTextBox.AutoCompleteCustomSource.AddRange(lsu.superRegions.ToArray());

            //set stateListBox to the region's states
            stateListBox.DataSource = region.states.ToList();

        }

        private void ColorButton_Click(object sender, EventArgs e) {
            //open up a color dialog
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = colorButton.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK) {
                colorButton.BackColor = colorDialog.Color;
            }
        }

        private void DeleteStateButton_Click(object sender, EventArgs e) {
            if (stateListBox.SelectedItem == null) return;

            //if there is a state selected in the stateListBox remove it
            State state = (State)stateListBox.SelectedItem;
            mapOp.RemoveState(region, state);
            stateListBox.DataSource = region.states.ToList();
        }

        private void EditStateButton_Click(object sender, EventArgs e) {            
            if (stateListBox.SelectedItem == null) return;
            
            //open up the edit state form if there is a state selected in the stateListBox
            State state = (State)stateListBox.SelectedItem;
            EditState editState = new EditState(state, lsu, mapOp);
            editState.ShowDialog();

            //if the edit state form was closed with the save button, update the stateListBox
            if (editState.DialogResult == DialogResult.OK) {
                stateListBox.DataSource = region.states.ToList();
            }
        }

        private void CreateNewStateButton_Click(object sender, EventArgs e) {
            //open up the edit state form with a new state
            State state = new State();
            EditState editState = new EditState(state, lsu, mapOp);
            //set the name of editState to "Create New State"
            editState.Text = "Create New State";
            editState.ShowDialog();

            //if the edit state form was closed with the save button, add the state to the region and update the stateListBox
            if (editState.DialogResult == DialogResult.OK) {
                mapOp.AddState(region, state);
                stateListBox.DataSource = region.states.ToList();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e) {
            //undo all the changes made to the region
            while (mapOp.StackSize > initalUndoCount) {
                mapOp.Undo();
            }
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void SaveButton_Click(object sender, EventArgs e) {
            List<string> errors = new List<string>();

            regionNameTextBox.BackColor = Color.White;
            stateListBox.BackColor = Color.White;

            //if regionNameTextBox is empty, show an error message
            if (regionNameTextBox.Text == "") {
                errors.Add("Region name cannot be empty");
                regionNameTextBox.BackColor = Color.Pink;
            }
            //if regionNameTextBox is not unique, show an error message
            else if (lsu.regionNames.Contains(regionNameTextBox.Text) && regionNameTextBox.Text != region.name) {
                errors.Add("Region name must be unique");
                regionNameTextBox.BackColor = Color.Pink;
            }

            //if there are no state in stateListBox, show an error message
            if (stateListBox.Items.Count == 0) {
                errors.Add("Region must have at least one state");
                stateListBox.BackColor = Color.Pink;
            }


            //if there are any errors, show them in a message box
            if (errors.Count > 0) {
                //concatinate all the errors into one string seperated by new lines and show them in a message box
                MessageBox.Show(string.Join(Environment.NewLine, errors.ToArray()), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //save the changes made to the region
            mapOp.UpdateRegion(region, regionNameTextBox.Text, cultureGFXTextBox.Text, superRegionTextBox.Text, colorButton.BackColor);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
