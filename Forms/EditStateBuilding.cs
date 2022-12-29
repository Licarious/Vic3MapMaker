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
    public partial class EditStateBuilding : Form
    {
        StateBuilding stateBuilding;
        Vic3ListStorageUnit lsu;
        MapOperation mapOp;
        int initialUndoSize;
        
        public EditStateBuilding(StateBuilding stateBuilding, Vic3ListStorageUnit lsu, MapOperation mapOp) {
            this.stateBuilding = stateBuilding;
            this.lsu = lsu;
            this.mapOp = mapOp;
            initialUndoSize = mapOp.StackSize;

            InitializeComponent();

            foreach (Building building in lsu.buildings) {
                buildingComboBox.Items.Add(building);
                Console.WriteLine("\t" + building);
            }
            //if building is null, then this is a new building
            if (stateBuilding.building != null) {
                //set the building combobox to the building
                buildingComboBox.SelectedItem = stateBuilding.building;
                //disable the building combobox
                buildingComboBox.Enabled = false;
                RefreshpmgComboBox();
            }

            //set level and reserves
            levelNumericUpDown.Value = stateBuilding.level;
            reservesNumericUpDown.Value = stateBuilding.reserves;

            
            
        }

        private void RefreshpmgComboBox() {
            //clear the pmg combobox
            pmgComboBox.Items.Clear();

            Building currentBuilding = (Building)buildingComboBox.SelectedItem;

            if (currentBuilding != null) {
                //add all production method groups to the list
                foreach (ProductionMethondGroups pmg in currentBuilding.productionMethodGroups) {
                    pmgComboBox.Items.Add(pmg);
                }
                //select the first item
                if (pmgComboBox.Items.Count > 0)
                    pmgComboBox.SelectedIndex = 0;
                RefreshpmComboBox();
            }
        }
        
        private void RefreshpmComboBox() {
            //clear the pm combobox
            pmComboBox.Items.Clear();

            ProductionMethondGroups currentPMG = (ProductionMethondGroups)pmgComboBox.SelectedItem;

            if (currentPMG != null) {
                // add a "" to the list to represent no production method
                pmComboBox.Items.Add("");
                //add all production methods to the list
                foreach (string pm in currentPMG.productionMethods) {
                    pmComboBox.Items.Add(pm);
                }
                //select the first item that is in the active production methods list
                bool found = false;
                for (int i = 1; i < pmComboBox.Items.Count; i++) {
                    if (stateBuilding.activeProductionMethods.Contains((string)pmComboBox.Items[i])) {
                        pmComboBox.SelectedIndex = i;
                        found = true;
                        break;
                    }
                }
                //if no item was found, select the first item
                if (!found)
                    pmComboBox.SelectedIndex = 0;
            }
        }

        private void PmgComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            RefreshpmComboBox();
        }

        private void PmComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            //find the current production method group
            ProductionMethondGroups currentPMG = (ProductionMethondGroups)pmgComboBox.SelectedItem;
            //find the current production method
            string currentPM = (string)pmComboBox.SelectedItem;
            
            
            //if stateBuilding has an active production method from the current production method group replace it with the new one
            string oldPM = stateBuilding.activeProductionMethods.Find(x => currentPMG.productionMethods.Contains(x));
            
            mapOp.UpdateProducitonMethond(stateBuilding, currentPM, oldPM);

        }

        private void CancelButton_Click(object sender, EventArgs e) {
            //undo all changes
            mapOp.Undo(mapOp.StackSize - initialUndoSize);

            //set exit code to cancel
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e) {
            List<string> errors = new List<string>();
            StateBuilding newStateBuilding = new StateBuilding();
            buildingComboBox.BackColor = Color.White;
            levelNumericUpDown.BackColor = Color.White;
            reservesNumericUpDown.BackColor = Color.White;

            //check nothing is selected in the building combobox
            if (buildingComboBox.SelectedItem == null) {
                errors.Add("No building selected");
                buildingComboBox.BackColor = Color.Pink;
            }
            else {
                newStateBuilding.building = (Building)buildingComboBox.SelectedItem;
            }

            //check if level is a positive integers
            if (levelNumericUpDown.Value < 0) {
                errors.Add("Level must be a positive integer");
                levelNumericUpDown.BackColor = Color.Pink;
            }
            else {
                newStateBuilding.level = (int)levelNumericUpDown.Value;
            }

            //check if reserves is a positive integers
            if (reservesNumericUpDown.Value < 0) {
                errors.Add("Reserves must be a positive integer");
                reservesNumericUpDown.BackColor = Color.Pink;
            }
            else {
                newStateBuilding.reserves = (int)reservesNumericUpDown.Value;
            }

            //if there are errors, show them and return
            if (errors.Count > 0) {
                MessageBox.Show(string.Join(Environment.NewLine, errors));
                return;
            }


            mapOp.UpdateStateBuilding(stateBuilding, newStateBuilding);

            //set exit code to ok
            this.DialogResult = DialogResult.OK;
            this.Close();

        }
    }
}
