using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vic3MapMaker
{
    public partial class EditResource : Form
    {
        State state;
        Resource resource;
        MapOperation mapOp;

        public EditResource(State state, Resource resource, List<string> depletableList, MapOperation mapOp) {
            this.state = state;
            this.resource = resource;

            this.mapOp = mapOp;

            depletableList.Remove(resource.name);
            depletableList.Add("");
            depletableList.Sort();

            InitializeComponent();

            //set nameTextBox to resource.name
            nameTextBox.Text = resource.name;
            //set depletedTypeComboBox to depletableList and select resource.depletedType
            depletedTypeComboBox.Items.AddRange(depletableList.ToArray());
            depletedTypeComboBox.SelectedItem = resource.depletedType;

            //case switch for resource.type
            switch (resource.type) {
                case "resource":
                    CappedRadioButton.Checked = true;
                    break;
                case "discoverable":
                    DiscoverableRadioButton.Checked = true;
                    break;
                default:
                    ArableRadioButton.Checked = true;
                    break;
            }

        }

        private void ArableRadioButton_CheckedChanged(object sender, EventArgs e) {
            //if check set know and discoverable text boxes to invisible
            if (ArableRadioButton.Checked) {
                depletedTB.Visible = false;
                depletedTypeComboBox.Visible = false;
                DiscoverableTB.Visible = false;
                DiscoverableAmmountTextBox.Visible = false;
                KnownTB.Text = "Arable Lnad";

                KnowAmmountTextBox.Text = state.arableLand.ToString();
                KnowAmmountTextBox.Enabled = false;
            }
        }

        private void CappedRadioButton_CheckedChanged(object sender, EventArgs e) {
            if (CappedRadioButton.Checked) {
                depletedTB.Visible = false;
                depletedTypeComboBox.Visible = false;
                DiscoverableTB.Visible = false;
                DiscoverableAmmountTextBox.Visible = false;
                KnownTB.Text = "Ammount";

                KnowAmmountTextBox.Text = resource.knownAmmount.ToString();
                KnowAmmountTextBox.Enabled = true;
            }
        }

        private void DiscoverableRadioButton_CheckedChanged(object sender, EventArgs e) {
            if (DiscoverableRadioButton.Checked) {
                depletedTB.Visible = true;
                depletedTypeComboBox.Visible = true;
                DiscoverableTB.Visible = true;
                DiscoverableTB.Text = "Unknown Ammount";
                DiscoverableAmmountTextBox.Visible = true;
                KnownTB.Text = "Know Ammount";

                KnowAmmountTextBox.Text = resource.knownAmmount.ToString();
                KnowAmmountTextBox.Enabled = true;

                DiscoverableAmmountTextBox.Text = resource.discoverableAmmount.ToString();

                //depletedTypeComboBox set index to resource.depletedType
                depletedTypeComboBox.SelectedIndex = depletedTypeComboBox.FindStringExact(resource.depletedType);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e) {
            //close form
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e) {
            Resource newResource = new Resource(nameTextBox.Text);
            bool passesChecks = true;

            //if areable is checked
            if (ArableRadioButton.Checked) {
                //set resource.knownAmmount to state.arableLand
                newResource.knownAmmount = state.arableLand;
                //set resource.discoverableAmmount to 0
                newResource.discoverableAmmount = 0;
                //set resource.depletedType to ""
                newResource.depletedType = "";
                //type
                newResource.type = "agriculture";
            }

            //if capped is checked
            else if (CappedRadioButton.Checked) {
                KnowAmmountTextBox.BackColor = Color.White;
                //knowAmmount = knowAmmountTextBox if knowAmmountTextBox is an in else set canSave to false
                if (int.TryParse(KnowAmmountTextBox.Text.Trim(), out int knowAmmount)) {
                    newResource.knownAmmount = knowAmmount;
                }
                else {
                    //set knowAmmountTextBox to red
                    KnowAmmountTextBox.BackColor = Color.Pink;
                    KnowAmmountTextBox.Font = new Font(KnowAmmountTextBox.Font, FontStyle.Bold);
                    passesChecks = false;
                }


                //set resource.discoverableAmmount to 0
                newResource.discoverableAmmount = 0;
                //set resource.depletedType to ""
                newResource.depletedType = "";
                //type
                newResource.type = "resource";
            }

            //if discoverable is checked
            else if (DiscoverableRadioButton.Checked) {
                KnowAmmountTextBox.BackColor = Color.White;
                DiscoverableAmmountTextBox.BackColor = Color.White;
                //knowAmmount = knowAmmountTextBox if knowAmmountTextBox is an in else set canSave to false
                if (int.TryParse(KnowAmmountTextBox.Text.Trim(), out int knowAmmount)) {
                    newResource.knownAmmount = knowAmmount;
                }
                else {
                    //set knowAmmountTextBox to red
                    KnowAmmountTextBox.BackColor = Color.Pink;
                    KnowAmmountTextBox.Font = new Font(KnowAmmountTextBox.Font, FontStyle.Bold);
                    passesChecks = false;
                }


                //set resource.discoverableAmmount to 0
                if (int.TryParse(DiscoverableAmmountTextBox.Text.Trim(), out int discoverableAmmount)) {
                    newResource.discoverableAmmount = discoverableAmmount;
                }
                else {
                    //set DiscoverableAmmountTextBox to red
                    DiscoverableAmmountTextBox.BackColor = Color.Pink;
                    //set text to bold
                    DiscoverableAmmountTextBox.Font = new Font(DiscoverableAmmountTextBox.Font, FontStyle.Bold);
                    passesChecks = false;
                }
                //set resource.depletedType to depletedTypeComboBox
                if (depletedTypeComboBox.SelectedItem != null) {
                    newResource.depletedType = depletedTypeComboBox.SelectedItem.ToString();
                }
                //type
                newResource.type = "discoverable";
            }
            if (!passesChecks) {
                MessageBox.Show("TextBoxes in red are not valid numbers");
                return;
            }
            
            mapOp.UpdateResource(state, newResource, resource);

            this.Close();
        }
        
    }
}
