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
        public EditPop(SubState state, Pop pop, Vic3ListStorageUnit lsu, MapOperation mapOp) {
            this.state = state;
            this.pop = pop;
            this.lsu = lsu;
            this.mapOp = mapOp;
            
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

        private void saveButton_Click(object sender, EventArgs e) {
            Pop newPop = new Pop {
                culture = cultureTextBox.Text,
                religion = religionTextBox.Text,
                size = int.Parse(sizeTextBox.Text),
                type = typeTextBox.Text
            };

            mapOp.UpdatePop(state, newPop, pop);
            this.Close();
        }
    }
}
