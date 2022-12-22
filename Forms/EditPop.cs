using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vic3MapMaker.Utilities;

namespace Vic3MapMaker.DataFiles
{
    public partial class EditPop : Form
    {
        SubState state;
        Pop pop;
        Vic3ListStorageUnit lsu;
        MapOperation mapOp;
        bool existingPop = false;
        public EditPop(SubState state, Pop pop, Vic3ListStorageUnit lsu, MapOperation mapOp, bool existingPop = false) { 
            this.state = state;
            this.pop = pop;
            this.lsu = lsu;
            this.mapOp = mapOp;
            this.existingPop = existingPop;

            InitializeComponent();

            //set the culture text box to auto complete from the lsu.cultures list
            cultureTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cultureTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection cultures = new AutoCompleteStringCollection();
            foreach (string culture in lsu.cultures) {
                cultures.Add(culture);
            }
            cultureTextBox.AutoCompleteCustomSource = cultures;

            //set the religion text box to auto complete from the lsu.religions list
            religionTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            religionTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection religions = new AutoCompleteStringCollection();
            foreach (string religion in lsu.religions) {
                religions.Add(religion);
            }
            religionTextBox.AutoCompleteCustomSource = religions;

            //set the type text box to auto complete from the lsu.ocupationTypes list
            typeTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            typeTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection types = new AutoCompleteStringCollection();
            foreach (string type in lsu.occupationTypes) {
                types.Add(type);
            }
            typeTextBox.AutoCompleteCustomSource = types;

            //set text boxes to pop values
            cultureTextBox.Text = pop.culture;
            sizeTextBox.Text = pop.size.ToString();
            typeTextBox.Text = pop.type;
            religionTextBox.Text = pop.religion;



        }

        private void SaveButton_Click(object sender, EventArgs e) {
            cultureTextBox.BackColor = Color.White;
            sizeTextBox.BackColor = Color.White;
            
            List<string> errors = new List<string>();
            //check for errors
            if (cultureTextBox.Text.Trim() == "") {
                errors.Add("Culture cannot be blank");
                cultureTextBox.BackColor = Color.Pink;
            }
            //if size is not a positive integer, add error
            if (!int.TryParse(sizeTextBox.Text, out int size) || size < 0) {
                errors.Add("Size must be a positive integer");
                sizeTextBox.BackColor = Color.Pink;
            }

            //if errors, display them
            if (errors.Count > 0) {
                //concatinate all the errors into one string seperated by new lines and show them in a message box
                MessageBox.Show(string.Join(Environment.NewLine, errors.ToArray()), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            Pop newPop = new Pop {
                culture = cultureTextBox.Text,
                religion = religionTextBox.Text,
                size = int.Parse(sizeTextBox.Text),
                type = typeTextBox.Text
            };

            mapOp.UpdatePop(state, newPop, pop);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e) {
            //close the form
            if(!existingPop)
                mapOp.RemovePop(state, pop);
            this.Close();
        }
    }
}
