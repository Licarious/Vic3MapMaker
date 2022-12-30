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

            //pmDataGridView
            pmDataGridView.Columns.Add("", "");
            pmDataGridView.Columns.Add("pm", "Method");
            //clear selection
            pmDataGridView.ClearSelection();
            //dont show the first column
            pmDataGridView.Columns[0].Visible = false;
            //have second column fill the whole width
            pmDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dont allow user to select multiple rows
            pmDataGridView.MultiSelect = false;
            //select all rows when user clicks on a row
            pmDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dont allow user to add rows
            pmDataGridView.AllowUserToAddRows = false;
            //dont allow user to delete rows
            pmDataGridView.AllowUserToDeleteRows = false;
            //hide the row headers
            pmDataGridView.RowHeadersVisible = false;
            //disable editing
            pmDataGridView.ReadOnly = true;
            //dont allow user to resize the columns
            pmDataGridView.AllowUserToResizeColumns = false;
            //dont allow user to resize the rows
            pmDataGridView.AllowUserToResizeRows = false;


            //pmgDataGridView
            pmgDataGridView.Columns.Add("", "");
            pmgDataGridView.Columns.Add("pmg", "Group");
            //clear selection
            pmgDataGridView.ClearSelection();
            //dont show the first column
            pmgDataGridView.Columns[0].Visible = false;
            //have second column fill the whole width
            pmgDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dont allow user to select multiple rows
            pmgDataGridView.MultiSelect = false;
            //select all rows when user clicks on a row
            pmgDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dont allow user to add rows
            pmgDataGridView.AllowUserToAddRows = false;
            //dont allow user to delete rows
            pmgDataGridView.AllowUserToDeleteRows = false;
            //hide the row headers
            pmgDataGridView.RowHeadersVisible = false;
            //disable editing
            pmgDataGridView.ReadOnly = true;
            //dont allow user to resize the columns
            pmgDataGridView.AllowUserToResizeColumns = false;
            //donw allow user to resize the rows
            pmgDataGridView.AllowUserToResizeRows = false;



            //if building is null, then this is a new building
            if (stateBuilding.building != null) {
                //set the building combobox to the building
                buildingComboBox.SelectedItem = stateBuilding.building;
                //disable the building combobox
                buildingComboBox.Enabled = false;
                RefreshpmgDataGridView();
                RefreshpmDataGridView2();
            }

            //set level and reserves
            levelNumericUpDown.Value = stateBuilding.level;
            reservesNumericUpDown.Value = stateBuilding.reserves;
            

        }


        private void RefreshpmgDataGridView() {
            //clear the pmgDataGridView
            pmgDataGridView.Rows.Clear();

            Building currentBuilding = (Building)buildingComboBox.SelectedItem;

            if (currentBuilding != null) {
                //add blank row to pmgDataGridView
                pmgDataGridView.Rows.Add(null, "");

                //add all production method groups to the list
                foreach (ProductionMethondGroups pmg in currentBuilding.productionMethodGroups) {
                    pmgDataGridView.Rows.Add(pmg, pmg.group.Replace(currentBuilding.name, "").Replace("pmg_","").Replace("_"," ").Trim());
                }

                //select second row
                pmgDataGridView.Rows[1].Selected = true;

                


                //RefreshpmDataGridView();
            }

        }

        private void RefreshpmDataGridView2() {
            pmDataGridView.Rows.Clear();

            //if nothing is selected in the pmgDataGridView, then return
            if (pmgDataGridView.SelectedRows.Count == 0) return;

            //see if the selected item in the pmgDataGridView is null return
            if (pmgDataGridView.SelectedRows[0].Cells[0].Value == null) return;

            //get the selected production method group
            ProductionMethondGroups pmg = (ProductionMethondGroups)pmgDataGridView.SelectedRows[0].Cells[0].Value;

            //add a null row
            pmDataGridView.Rows.Add(null, "");
            

            //add a blank row to the pmDataGridView
            pmDataGridView.Rows.Add("", "");

            bool found = false;
            //add all production methods to the list that are in the selected production method group
            foreach (string pm in pmg.productionMethods) {
                pmDataGridView.Rows.Add(pm, pm.Replace(pmg.group, "").Replace("pm_", "").Replace("_", " ").Trim());
                //check if the production method is in the state building active production methods
                if (stateBuilding.activeProductionMethods.Contains(pm)) {
                    //if it is, then select the row
                    pmDataGridView.Rows[pmDataGridView.Rows.Count - 1].Selected = true;
                    Console.WriteLine("Selected " + pm);
                    found = true;
                }
            }

            if (!found) {
                //select second row
                pmDataGridView.Rows[1].Selected = true;
            }

            //hide the first row
            pmDataGridView.Rows[0].Visible = false;
        }
        

        private void pmDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 1 && !pmDataGridView.IsCurrentCellInEditMode) {
                //hide first row
                pmgDataGridView.Rows[0].Visible = false;
                
                string currentPM = pmDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                ProductionMethondGroups currentPMG = null;
                try {
                    currentPMG = (ProductionMethondGroups)pmgDataGridView.SelectedRows[0].Cells[0].Value;
                }
                catch (Exception ex) {
                    Console.WriteLine("pmgDataGridView.SelectedRows[0].Cells[0].Value: " + ex.Message);
                    return;
                }
                Console.WriteLine("\t\tCellChange event: "+currentPM);

                if (currentPM != null && currentPMG != null) {
                    //old production method
                    //from the current pmg, find an active production method from the state building
                    string oldPM = "";
                    foreach (string pm in currentPMG.productionMethods) {
                        if (stateBuilding.activeProductionMethods.Contains(pm)) {
                            oldPM = pm;
                            break;
                        }
                    }

                    mapOp.UpdateProducitonMethond(stateBuilding, currentPM, oldPM);
                }

            }
            
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
            buildingComboBox.BackColor = Color.White;
            levelNumericUpDown.BackColor = Color.White;
            reservesNumericUpDown.BackColor = Color.White;

            Building building = null;
            //check nothing is selected in the building combobox
            if (buildingComboBox.SelectedItem == null) {
                errors.Add("No building selected");
                buildingComboBox.BackColor = Color.Pink;
            }
            else {
                building = (Building)buildingComboBox.SelectedItem;
                if (building == null) {
                    errors.Add("Building is null");
                    buildingComboBox.BackColor = Color.Pink;
                }
            }

            int level = 0;
            //check if level is a positive integers
            if (levelNumericUpDown.Value < 0) {
                errors.Add("Level must be a positive integer");
                levelNumericUpDown.BackColor = Color.Pink;
            }
            else {
                level = (int)levelNumericUpDown.Value;
            }

            int reserves = 0;
            //check if reserves is a positive integers
            if (reservesNumericUpDown.Value < 0) {
                errors.Add("Reserves must be a positive integer");
                reservesNumericUpDown.BackColor = Color.Pink;
            }
            else {
                reserves = (int)reservesNumericUpDown.Value;
            }

            //if there are errors, show them and return
            if (errors.Count > 0) {
                MessageBox.Show(string.Join(Environment.NewLine, errors));
                return;
            }


            mapOp.UpdateStateBuilding(stateBuilding, building, level, reserves);

            Console.WriteLine(stateBuilding);
            //set exit code to ok
            this.DialogResult = DialogResult.OK;
            this.Close();

        }


        //pmgDataGridView cell click
        private void PmgDataGridView_SelectionChanged(object sender, EventArgs e) {
            //get the current pmg from pmgDataGridView

            ProductionMethondGroups currentPMG = null;
            try {
                currentPMG = (ProductionMethondGroups)pmgDataGridView.SelectedRows[0].Cells[0].Value;
            }
            catch (Exception ex) {
                //Console.WriteLine(ex.Message);
            }
            if (currentPMG != null) {
                Console.WriteLine("pmg: " + pmgDataGridView.SelectedRows[0].Cells[0].Value.ToString());
                RefreshpmDataGridView2();
            }
        }

        //pmgDataGridView cell changed event

        private void BuildingComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            RefreshpmgDataGridView();
        }
        

    }

}
