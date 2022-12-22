using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vic3MapMaker.DataFiles;
using Vic3MapMaker.Utilities;

namespace Vic3MapMaker.Forms
{
    public partial class EditCountry : Form
    {
        Nation nation;
        Vic3ListStorageUnit lsu;
        MapOperation mapOp;
        int startingUndoCount;

        public EditCountry(Nation nation, Vic3ListStorageUnit lsu, MapOperation mapOp) {
            this.nation = nation;
            this.lsu = lsu;
            this.mapOp = mapOp;
            startingUndoCount = mapOp.UndoStack.Count;

            InitializeComponent();

            //set tagTextBox to nation.tag
            tagTextBox.Text = nation.tag;

            //set combobox values to nation substates.parentState
            foreach (SubState subState in nation.subStates) {
                subStateComboBox.Items.Add(subState);
            }

            //add 4 colums to the popGridView
            popGridView.Columns.Add("Culture", "Culture");
            popGridView.Columns.Add("Size", "Size");
            popGridView.Columns.Add("Type", "Type");       
            popGridView.Columns.Add("Religion", "Religion");

            //don't allow uncommitted new rows
            popGridView.AllowUserToAddRows = false;

            //disable editing of the popGridView
            popGridView.ReadOnly = true;

            //set the popGridView colmn widths to auto with a minimum size to fit the borders
            for (int i = 0; i < popGridView.Columns.Count; i++) {
                popGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                popGridView.Columns[i].MinimumWidth = 100;
            }

            //center the text in the popGridView
            popGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //remove the select all row from the popGridView
            popGridView.RowHeadersVisible = false;




            //add "incorporated", "unincorporated", and "treaty_port" stateTypeComboBox
            stateTypeComboBox.Items.Add("incorporated");
            stateTypeComboBox.Items.Add("unincorporated");
            stateTypeComboBox.Items.Add("treaty_port");

            //set nationCultureListBox to nation.cultures
            nationCultureListBox.Items.AddRange(nation.cultures.ToArray());

            //set allCulturesListBox to lsu.cultures - nation.cultures
            allCulturesListBox.Items.AddRange(lsu.cultures.Except(nation.cultures).ToArray());

            //set colorButton to nation.color
            colorButton.BackColor = nation.color;


            //select first item in subStateComboBox
            subStateComboBox.SelectedIndex = 0;

            //set tierComboBox list to lsu.tiers
            tierComboBox.Items.AddRange(lsu.nationTiers.ToArray());
            //set tierComboBox to nation.tier
            tierComboBox.SelectedItem = nation.tier;

            //set typeComboBox list to lsu.nationTypes
            typeComboBox.Items.AddRange(lsu.nationTypes.ToArray());
            //set typeComboBox to nation.type
            typeComboBox.SelectedItem = nation.type;

            //if nation has any substates
            if (nation.subStates.Count > 0) {
                //set capitalComboBox list to nation.subStates
                capitalComboBox.Items.AddRange(nation.subStates.ToArray());
                //set capitalComboBox to nation.capital to the subState that contains nation.capital
                capitalComboBox.SelectedItem = nation.subStates.First(subState => subState.parentState == nation.capital);
            }
            else {
                //set capitalComboBox list to lsu.states
                capitalComboBox.Items.AddRange(lsu.states.ToArray());
                //set capitalComboBox to nation.capital
                capitalComboBox.SelectedItem = nation.capital;
            }

            //if nation is named from capital
            if (nation.isNamedFromCapital) {
                //set nameFromCapitalCheckBox to checked
                namedFromCapitalCheckBox.Checked = true;
            }


        }


        private void SubStateComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            //clear the popGridView
            popGridView.Rows.Clear();

            //set the popGridView to the substate.pops
            SubState state = (SubState)subStateComboBox.SelectedItem;
            //popGridView.DataSource = state.pops;
            //add the values to the columns
            foreach (Pop pop in state.pops) {
                popGridView.Rows.Add(pop.culture, pop.size, pop.type, pop.religion);
                Console.WriteLine(pop.culture + " " + pop.size + " " + pop.type + " " + pop.religion);
            }
            Console.WriteLine(state.parentState.name + "\t" + state.pops.Count);

            //set the stateTypeComboBox to the substate.parentState.stateType if it is "" then it is "incorporated"
            if (state.type == "") {
                stateTypeComboBox.SelectedItem = "incorporated";
            }
            else {
                stateTypeComboBox.SelectedItem = state.type;
            }
        }
        

        private void NewPopButton_Click(object sender, EventArgs e) {
            Pop newPop = new Pop();

            //open a editPop form and add the pop to the substate.pops
            SubState state = (SubState)subStateComboBox.SelectedItem;

            mapOp.AddPop(state, newPop);
            EditPop editPop = new EditPop(state, newPop, lsu, mapOp);
            editPop.ShowDialog();

            //after the editPop form is closed, refresh the popGridView
            SubStateComboBox_SelectedIndexChanged(sender, e);


        }

        private void EditPopButton_Click(object sender, EventArgs e) {
            //get the selected pop from the popGridView
            SubState state = (SubState)subStateComboBox.SelectedItem;
            if (state == null) return;
            int index = popGridView.CurrentCell.RowIndex;
            Pop pop = state.pops.ElementAt(index);

            if (pop == null) return;

            //open a editPop form and edit the pop
            EditPop editPop = new EditPop(state, pop, lsu, mapOp, true);
            editPop.ShowDialog();

            //after the editPop form is closed, refresh the popGridView
            SubStateComboBox_SelectedIndexChanged(sender, e);

        }

        private void DeletePopButton_Click(object sender, EventArgs e) {
            //get the selected pop from the popGridView
            SubState state = (SubState)subStateComboBox.SelectedItem;
            if (state == null) return;
            int index = popGridView.CurrentCell.RowIndex;
            Pop pop = state.pops.ElementAt(index);

            if (pop == null) return;

            //delete the pop from the substate.pops
            mapOp.RemovePop(state, pop);

            //refresh the popGridView
            SubStateComboBox_SelectedIndexChanged(sender, e);
        }

        private void StateTypeComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            //get the selected substate
            SubState state = (SubState)subStateComboBox.SelectedItem;
            if (state == null) return;
            //get the selected stateType
            string stateType = (string)stateTypeComboBox.SelectedItem;
            if (stateType == null) return;
            //if the stateType is "incorporated" then set the substate.parentState.stateType to ""
            if (stateType == "incorporated") {
                mapOp.UpdateSubStateType(state, "");
            }
            //else set the substate.parentState.stateType to the selected stateType
            else {
                mapOp.UpdateSubStateType(state, stateType);
            }


        }

        private void CancelButton_Click(object sender, EventArgs e) {
            //undo all changes
            while (mapOp.UndoStack.Count > startingUndoCount) {
                mapOp.Undo();
            }
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e) {
            tagTextBox.BackColor = Color.White;
            subStateComboBox.BackColor = Color.White;
            capitalComboBox.BackColor = Color.White;
            nationCultureListBox.BackColor = Color.White;
            typeComboBox.BackColor = Color.White;
            tierComboBox.BackColor = Color.White;

            List<string> errors = new List<string>();
            //is there something in the tagTextBox
            if (tagTextBox.Text.Trim() == "") {
                errors.Add("Tag cannot be blank");
                tagTextBox.BackColor = Color.Pink;
            }
            //if tag is not nation.tag and already exists in lsu.tags then add error
            if (tagTextBox.Text.Trim() != nation.tag && lsu.tags.Contains(tagTextBox.Text.Trim())) {
                errors.Add("Tag already exists");
                tagTextBox.BackColor = Color.Pink;
            }

            //do all substates have pops
            foreach (SubState state in nation.subStates) {
                if (state.pops.Count == 0) {
                    errors.Add("SubState " + state.parentState.name + " needs atleast one pop group");
                    subStateComboBox.BackColor = Color.Pink;
                }
            }
            //is there a non null capital in the capitalComboBox
            if (capitalComboBox.SelectedItem == null) {
                errors.Add("Capital cannot be blank");
                capitalComboBox.BackColor = Color.Pink;
            }
            //if there a non null type in the typeComboBox
            if (typeComboBox.SelectedItem == null) {
                errors.Add("Type cannot be blank");
                typeComboBox.BackColor = Color.Pink;
            }
            //if there a non null type in the tierComboBox
            if (tierComboBox.SelectedItem == null) {
                errors.Add("Tier cannot be blank");
                tierComboBox.BackColor = Color.Pink;
            }
            //if there are no cultures in the nation.cultures
            if (nation.cultures.Count == 0) {
                errors.Add("Nation needs atleast one culture");
                nationCultureListBox.BackColor = Color.Pink;
            }

            //if there is no selected item in the capitalComboBox
            if (capitalComboBox.SelectedItem == null) {
                errors.Add("Capital cannot be blank");
                capitalComboBox.BackColor = Color.Pink;
            }

            //if there are errors then show them in a messageBox
            if (errors.Count > 0) {
                string errorString = "";
                foreach (string error in errors) {
                    errorString += error + "\n";
                }
                MessageBox.Show(errorString);
                return;
            }

            State capital = null;
            //if capital is a substate
            if (capitalComboBox.SelectedItem is SubState) {
                SubState sstemp = (SubState)capitalComboBox.SelectedItem;
                capital = sstemp.parentState;
            }
            else if(capitalComboBox.SelectedItem is State) {
                capital = capitalComboBox.SelectedItem as State;
            }


            mapOp.UpdateNation(nation, tagTextBox.Text, nameTextBox.Text, colorButton.BackColor, tierComboBox.Text, typeComboBox.Text,  capital, namedFromCapitalCheckBox.Checked);

            //close the form
            this.Close();
        }

        private void ColorButton_Click(object sender, EventArgs e) {
            //open a colorDialog
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.ShowDialog();

            //change the button color to the selected color
            colorButton.BackColor = colorDialog.Color;
        }

        private void AddCultureButton_Click(object sender, EventArgs e) {
            //get the selected culture from the allCulturesListBox
            string culture = (string)allCulturesListBox.SelectedItem;
            if (culture == null) return;

            //add the culture to the nation.cultures
            mapOp.AddNationCulture(nation, culture);

            //remove the culture from the allCulturesListBox
            allCulturesListBox.Items.Remove(culture);

            //add the culture to the nationCultureListBox
            nationCultureListBox.Items.Add(culture);
        }

        private void RemoveCultureButton_Click(object sender, EventArgs e) {
            //get the selected culture from the nationCultureListBox
            string culture = (string)nationCultureListBox.SelectedItem;
            if (culture == null) return;

            //remove the culture from the nation.cultures
            mapOp.RemoveNationCulture(nation, culture);

            //remove the culture from the nationCultureListBox
            nationCultureListBox.Items.Remove(culture);

            //add the culture to the allCulturesListBox
            allCulturesListBox.Items.Add(culture);
        }

        private void CultureSearchTextBox_TextChanged(object sender, EventArgs e) {
            //update the allCulturesListBox to only show cultures that contain the search text and are not already in the nation.cultures
            allCulturesListBox.Items.Clear();
            
            //if the search text is empty then add all cultures that are not already in the nation.cultures
            if (cultureSearchTextBox.Text == "") {
                foreach (string culture in lsu.cultures) {
                    if (!nation.cultures.Contains(culture)) {
                        allCulturesListBox.Items.Add(culture);
                    }
                }
            }
            else {
                foreach (string culture in lsu.cultures) {
                    if (culture.Contains(cultureSearchTextBox.Text) && !nation.cultures.Contains(culture)) {
                        allCulturesListBox.Items.Add(culture);
                    }
                }
            }

        }
    }
}
