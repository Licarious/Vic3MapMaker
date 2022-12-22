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

            //add "incorporated", "unincorporated", and "treaty_port" stateTypeComboBox
            stateTypeComboBox.Items.Add("incorporated");
            stateTypeComboBox.Items.Add("unincorporated");
            stateTypeComboBox.Items.Add("treaty_port");
            


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

        private void editPopButton_Click(object sender, EventArgs e) {
            //get the selected pop from the popGridView
            SubState state = (SubState)subStateComboBox.SelectedItem;
            if (state == null) return;
            int index = popGridView.CurrentCell.RowIndex;
            Pop pop = state.pops.ElementAt(index);

            if (pop == null) return;

            //open a editPop form and edit the pop
            EditPop editPop = new EditPop(state, pop, lsu, mapOp);
            editPop.ShowDialog();

            //after the editPop form is closed, refresh the popGridView
            SubStateComboBox_SelectedIndexChanged(sender, e);

        }

        private void deletePopButton_Click(object sender, EventArgs e) {
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
    }
}
