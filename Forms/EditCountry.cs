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
using static System.Windows.Forms.AxHost;

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
            //set nameTextBox to nation.name
            nameTextBox.Text = nation.name;
            //set adjTextBox to nation.adj
            adjTextBox.Text = nation.adj;

            //set combobox values to nation substates.parentState
            foreach (SubState subState in nation.subStates) {
                subStateComboBox.Items.Add(subState);
            }

            //buildingDataGridView
            //add 5 colums to buildingDataGridView stateBuilding, name, level, reserves, and activeProductionMethods
            buildingDataGridView.Columns.Add("", "");
            buildingDataGridView.Columns.Add("Name", "Name");
            buildingDataGridView.Columns.Add("Level", "Level");
            buildingDataGridView.Columns.Add("Reserves", "Reserves");
            buildingDataGridView.Columns.Add("\t\tActive Production Methods\t\t", "\t\tActive Production Methods\t\t");

            //don't allow uncommitted new rows
            buildingDataGridView.AllowUserToAddRows = false;

            //disable editing of the buildingDataGridView
            buildingDataGridView.ReadOnly = true;
            /*
            //set the buildingDataGridView colmn widths to auto with a minimum size to fit the borders
            for (int i = 0; i < buildingDataGridView.Columns.Count; i++) {
                buildingDataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                buildingDataGridView.Columns[i].MinimumWidth = 65;
            }
            */
            //center the text in the buildingDataGridView
            buildingDataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //remove the select all row from the buildingDataGridView
            buildingDataGridView.RowHeadersVisible = false;

            //hide the first column in the buildingDataGridView
            buildingDataGridView.Columns[0].Visible = false;

            //allow for multi line text in the buildingDataGridView
            buildingDataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            //set row heights to be dynamic
            buildingDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            //strech colums to fill the buildingDataGridView
            buildingDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            buildingDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            //center headders
            buildingDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //select whole row
            buildingDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            //add 4 colums to the popDataGridView
            popDataGridView.Columns.Add("", "");
            popDataGridView.Columns.Add("Culture", "Culture");
            popDataGridView.Columns.Add("Size", "Size");
            popDataGridView.Columns.Add("Type", "Type");       
            popDataGridView.Columns.Add("Religion", "Religion");

            //set popDataGridView to only select one row at a time
            popDataGridView.MultiSelect = false;
            //and highlight the selected row
            popDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //hide first column
            popDataGridView.Columns[0].Visible = false;

            //don't allow uncommitted new rows
            popDataGridView.AllowUserToAddRows = false;

            //disable editing of the popDataGridView
            popDataGridView.ReadOnly = true;

            //set the popDataGridView colmn widths to auto with a minimum size to fit the borders
            for (int i = 0; i < popDataGridView.Columns.Count; i++) {
                popDataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                popDataGridView.Columns[i].MinimumWidth = 100;
            }

            //center the text in the popDataGridView
            popDataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //remove the select all row from the popDataGridView
            popDataGridView.RowHeadersVisible = false;

            //center headders
            popDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;




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


            //select first item in subStateComboBox if there are substates
            if (nation.subStates.Count > 0) {
                subStateComboBox.SelectedIndex = 0;
            }

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
                //set capitalComboBox list to nation.subStates.parentState
                capitalComboBox.Items.AddRange(nation.subStates.Select(x => x.parentState).ToArray());

                //if nation.capital is not null is not in capitalComboBox list add it
                if (nation.capital != null ) {
                    if(!capitalComboBox.Items.Contains(nation.capital))
                        capitalComboBox.Items.Add(nation.capital);
                    //get the index of nation.capital in capitalComboBox
                    int index = capitalComboBox.Items.IndexOf(nation.capital);
                    //set capitalComboBox to nation.capital
                    capitalComboBox.SelectedIndex = index;
                }
                
            }
            else {
                //set capitalComboBox list to lsu.states
                capitalComboBox.Items.AddRange(lsu.states.ToArray());
                //set capitalComboBox to nation.capital
                if(nation.capital != null)
                    capitalComboBox.SelectedItem = nation.capital;
            }
            

            //if nation is named from capital
            if (nation.isNamedFromCapital) {
                //set nameFromCapitalCheckBox to checked
                namedFromCapitalCheckBox.Checked = true;
            }

            //set wealthComboBox list to lsu.welthLevels
            wealthComboBox.Items.AddRange(lsu.welthLevels.ToArray());
            //set wealthComboBox to nation.wealth
            wealthComboBox.SelectedItem = nation.wealth;

            //set literacyComboBox list to lsu.literacyLevels
            literacyComboBox.Items.AddRange(lsu.literacyLevels.ToArray());
            //set literacyComboBox to nation.literacy
            literacyComboBox.SelectedItem = nation.literacy;

            
            //add 5 colums to tradeRouteDataGridView TradeRoute object, target, goods, level, Import/Export
            tradeRouteDataGridView.Columns.Add("", "");
            tradeRouteDataGridView.Columns.Add("Target", "Target");
            tradeRouteDataGridView.Columns.Add("Goods", "Goods");
            tradeRouteDataGridView.Columns.Add("Level", "Level");
            tradeRouteDataGridView.Columns.Add("In/Out", "In/Out");

            //don't allow uncommitted new rows
            tradeRouteDataGridView.AllowUserToAddRows = false;

            //disable editing of the tradeRouteDataGridView
            tradeRouteDataGridView.ReadOnly = true;
            /*
            //set the tradeRouteDataGridView colmn widths to auto with a minimum size to fit the borders
            for (int i = 0; i < tradeRouteDataGridView.Columns.Count; i++) {
                tradeRouteDataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                tradeRouteDataGridView.Columns[i].MinimumWidth = 65;
            }
            */
            //center the text in the tradeRouteDataGridView
            tradeRouteDataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //remove the select all row from the tradeRouteDataGridView
            tradeRouteDataGridView.RowHeadersVisible = false;

            //strech colums to fill the buildingDataGridView
            tradeRouteDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tradeRouteDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            RefreshTradRouteGrid();

            //set tradeRouteDataGridView to only select one row at a time
            tradeRouteDataGridView.MultiSelect = false;
            //and highlight the selected row
            tradeRouteDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //hide first column
            tradeRouteDataGridView.Columns[0].Visible = false;

            //center headders
            tradeRouteDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;





        }

        private void RefreshBuildingGrid() {
            //clear the buildingDataGridView
            buildingDataGridView.Rows.Clear();
            //if subStateComboBox.SelectedIndex is not -1
            if (subStateComboBox.SelectedIndex != -1) {
                //get the selected substate from subStateComboBox
                SubState subState = (SubState)subStateComboBox.SelectedItem;
                //for each sb in subState.buildings add a row to buildingDataGridView
                foreach (StateBuilding sb in subState.buildings) {
                    //for each string in sb.activeProductionMethods run ReadableName with it as name and "pm_" as prefix and join the results with a \n
                    buildingDataGridView.Rows.Add(sb, ReadableName(sb.building.name,"building_"), sb.level, sb.reserves, string.Join("\n", sb.activeProductionMethods.Select(x => ReadableName(x, "pm_"))));
                }
            }
        }

        private string ReadableName(string name, string prefix) {
            return name.Replace(prefix, "").Replace("_", " ");
        }

        private void SubStateComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            //clear the popDataGridView
            popDataGridView.Rows.Clear();

            //set the popDataGridView to the substate.pops
            SubState state = (SubState)subStateComboBox.SelectedItem;
            //popDataGridView.DataSource = state.pops;
            //add the values to the columns
            foreach (Pop pop in state.pops) {
                popDataGridView.Rows.Add(pop, pop.culture, pop.size, pop.type, pop.religion);
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

            RefreshBuildingGrid();
        }
        

        private void NewPopButton_Click(object sender, EventArgs e) {
            Pop newPop = new Pop();
            //open a editPop form and add the pop to the substate.pops
            SubState state = (SubState)subStateComboBox.SelectedItem;
            
            EditPop editPop = new EditPop(state, newPop, lsu, mapOp);
            editPop.ShowDialog();

            //if editPop returns ok
            if (editPop.DialogResult == DialogResult.OK) {
                //add the pop to the substate.pops
                mapOp.AddPop(state, newPop);
                //after the editPop form is closed, refresh the popDataGridView
                SubStateComboBox_SelectedIndexChanged(sender, e);
            }

            


        }

        private void EditPopButton_Click(object sender, EventArgs e) {
            //get the selected pop from the popDataGridView
            SubState state = (SubState)subStateComboBox.SelectedItem;
            if (state == null) return;

            Pop pop = (Pop)popDataGridView.SelectedCells[0].Value;
            if (pop == null) return;

            //open a editPop form and edit the pop
            EditPop editPop = new EditPop(state, pop, lsu, mapOp, true);
            editPop.ShowDialog();

            //after the editPop form is closed, refresh the popDataGridView
            SubStateComboBox_SelectedIndexChanged(sender, e);

        }

        private void DeletePopButton_Click(object sender, EventArgs e) {
            
            //get the selected pop from the popDataGridView
            SubState state = (SubState)subStateComboBox.SelectedItem;
            if (state == null) return;          

            Pop pop = (Pop)popDataGridView.SelectedCells[0].Value;
            if (pop == null) return;

            //delete the pop from the substate.pops
            mapOp.RemovePop(state, pop);

            //refresh the popDataGridView
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
            nameTextBox.BackColor = Color.White;
            adjTextBox.BackColor = Color.White;
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

            //if adjTextBox is blank
            if (adjTextBox.Text.Trim() == "") {
                errors.Add("Country adjective cannot be blank");
                adjTextBox.BackColor = Color.Pink;
            }
            //if nameTextBox is blank
            if (nameTextBox.Text.Trim() == "") {
                errors.Add("Country name cannot be blank");
                nameTextBox.BackColor = Color.Pink;
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


            mapOp.UpdateNation(nation, tagTextBox.Text, nameTextBox.Text, adjTextBox.Text, colorButton.BackColor, tierComboBox.Text, typeComboBox.Text, wealthComboBox.Text, literacyComboBox.Text,  capital, namedFromCapitalCheckBox.Checked);

            //close the form with a dialogResult of OK
            this.DialogResult = DialogResult.OK;
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

        private void DeleteRouteButton_Click(object sender, EventArgs e) {
            TradeRoute route = (TradeRoute)tradeRouteDataGridView.SelectedCells[0].Value;

            //if route is null then return
            if (route == null) return;

            Console.WriteLine("Deleting route " + route);
            

            //remove the route from the nation.tradeRoutes
            mapOp.RemoveTradeRoute(nation, route);
            
            //remove the route from the tradeRouteDataGridView
            //tradeRouteDataGridView.Rows.Remove(tradeRouteDataGridView.SelectedRows[0]);
            RefreshTradRouteGrid();
        }

        private void EditRouteButton_Click(object sender, EventArgs e) {
            
            //tradeRoute is the first column of the selected row
            TradeRoute route = (TradeRoute)tradeRouteDataGridView.SelectedCells[0].Value;

            //if route is null then return
            if (route == null) return;


            //open a EditTradeRoute
            EditTradeRoute tradeRouteForm = new EditTradeRoute(route, lsu, mapOp);
            //wait to close the form until the dialogResult is OK
            tradeRouteForm.ShowDialog();

            //if the dialogResult is OK then update the tradeRouteDataGridView
            if (tradeRouteForm.DialogResult == DialogResult.OK) {
                RefreshTradRouteGrid();
            }
            
        }

        private void NewRouteButton_Click(object sender, EventArgs e) {
            TradeRoute route = new TradeRoute();
            //open a EditTradeRoute
            EditTradeRoute tradeRouteForm = new EditTradeRoute(route, lsu, mapOp);

            //wait to close the form until the dialogResult is OK
            tradeRouteForm.ShowDialog();

            //if the dialogResult is OK then add the route to the nation.tradeRoutes and update the tradeRouteDataGridView
            if (tradeRouteForm.DialogResult == DialogResult.OK) {
                mapOp.AddTradeRoute(nation, route);
                //clear the tradeRouteDataGridView
                RefreshTradRouteGrid();
            }

        }

        private void RefreshTradRouteGrid() {
            //clear the tradeRouteDataGridView
            tradeRouteDataGridView.Rows.Clear();
            //add all the routes to the tradeRouteDataGridView
            foreach (TradeRoute tradeRoute in nation.tradeRoutes) {
                tradeRouteDataGridView.Rows.Add(tradeRoute, tradeRoute.target, tradeRoute.goods, tradeRoute.level, tradeRoute.isExport ? "Export" : "Import");
            }
        }

        private void NewBuildingButton_Click(object sender, EventArgs e) {
            //find the selected substate from the substateComboBox
            SubState substate = (SubState)subStateComboBox.SelectedItem;
            //if substate is null then return
            if (substate == null) return;

            StateBuilding stateBuilding = new StateBuilding();
            //open a EditStateBuilding
            EditStateBuilding stateBuildingForm = new EditStateBuilding(stateBuilding, lsu, mapOp);

            //wait to close the form until the dialogResult is OK
            stateBuildingForm.ShowDialog();

            //if the dialogResult is OK then add the stateBuilding to the nation.stateBuildings and update the stateBuildingDataGridView
            if (stateBuildingForm.DialogResult == DialogResult.OK) {
                mapOp.AddStateBuilding(substate, stateBuilding);
                //clear the stateBuildingDataGridView
                RefreshBuildingGrid();
            }
        }

        private void EditBuildngButton_Click(object sender, EventArgs e) {
            //find the selected stateBuildng from the BuildingDataGridView
            StateBuilding building = (StateBuilding)buildingDataGridView.SelectedCells[0].Value;

            //if building is null then return
            if (building == null) return;

            //open a EditStateBuilding
            EditStateBuilding stateBuildingForm = new EditStateBuilding(building, lsu, mapOp);
            //wait to close the form until the dialogResult is OK
            stateBuildingForm.ShowDialog();

            //if the dialogResult is OK then update the buildingDataGridView
            if (stateBuildingForm.DialogResult == DialogResult.OK) {
                RefreshBuildingGrid();
            }


        }

        private void deleteBuildingButton_Click(object sender, EventArgs e) {
            //find the selected stateBuildng from the BuildingDataGridView
            StateBuilding building = (StateBuilding)buildingDataGridView.SelectedCells[0].Value;
            if (building == null) return;

            //find the selected substate from the substateComboBox
            SubState substate = (SubState)subStateComboBox.SelectedItem;
            if (substate == null) return;

            //remove the building from the substate.stateBuildings
            mapOp.RemoveStateBuilding(substate, building);

            RefreshBuildingGrid();
        }
    }
}
