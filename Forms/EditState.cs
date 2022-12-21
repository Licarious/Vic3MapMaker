using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Vic3MapMaker.Utilities;

namespace Vic3MapMaker
{
    public partial class EditState : Form
    {
        List<string> stateTrait = new List<string>();
        List<string> unusedStateTraits = new List<string>();
        List<string> unusedResources = new List<string>();
        List<Resource> stateRecources = new List<Resource>();
        List<string> unusedCultureList = new List<string>();
        List<string> unusedTags = new List<string>();
        List<string> tagList;
        Vic3ListStorageUnit lsu;
        MapOperation mapOp;
        State state;
        private int initalUndoStackSize;

        public EditState(State state, Vic3ListStorageUnit lsu, MapOperation mapOp) {
            InitializeComponent();

            this.mapOp = mapOp;
            initalUndoStackSize = mapOp.StackSize;

            this.state = state;
            this.lsu = lsu;

            //set stateNameTextBox to state name
            stateNameTextBox.Text = state.name;
            //set stateTraitsListBox to state modifiers
            stateTrait.AddRange(state.traits);
            stateTraitsListBox.Items.AddRange(state.traits.ToArray());

            //set allStateModifersListBox to stateModifers - stateModifers
            foreach (string mod in lsu.stateTraits) {
                if (!state.traits.Contains(mod)) {
                    unusedStateTraits.Add(mod);
                }
            }
            //sort unusedStateTraits alphabetically
            unusedStateTraits.Sort();
            allStateTraitsListBox.Items.AddRange(unusedStateTraits.ToArray());


            //set subsistenceBuildingTextBox to state subsistenceBuilding 
            subsistenceBuildingTextBox.Text = state.subsistenceBuilding;

            RefreshResourceListBox();

            arableLandTextBox.Text = state.arableLand.ToString();


            //add a scroll bar to the EditState form
            this.AutoScroll = true;


            //subsistenceBuildingTextBox auto complete mode from subsistenceBuildings
            subsistenceBuildingTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            subsistenceBuildingTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection subsistanceBuildingCollection = new AutoCompleteStringCollection();
            subsistanceBuildingCollection.AddRange(lsu.subsistenceBuildings.ToArray());
            subsistenceBuildingTextBox.AutoCompleteCustomSource = subsistanceBuildingCollection;



            //Culutre homeland
            //set homeLandListBox to state.cultureHomeland
            homeLandListBox.Items.AddRange(state.homeLandList.ToArray());
            //set unused culture list to allCulturesList - state.cultureHomeland
            foreach (string culture in lsu.cultures) {
                if (!state.homeLandList.Contains(culture)) {
                    unusedCultureList.Add(culture);
                }
            }
            //set allCulturesListBox to unusedCultureList
            allCulturesListBox.Items.AddRange(unusedCultureList.ToArray());

        }

        private void AddStateModiderButton_Click(object sender, EventArgs e) {
            //check if allStateTraitsListBox has a selected item
            if (allStateTraitsListBox.SelectedItem != null) {
                //get selected item from allStateModifersListBox
                string selected = allStateTraitsListBox.SelectedItem.ToString();
                //add selected item to stateTraitsListBox
                stateTrait.Add(selected);
                stateTraitsListBox.Items.Add(selected);
                //remove selected item from allStateModifersListBox
                unusedStateTraits.Remove(selected);
                allStateTraitsListBox.Items.Remove(selected);
            }
        }

        private void RemoveStateModiferButton_Click(object sender, EventArgs e) {
            //check if stateTraitsListBox has a selected item
            if (stateTraitsListBox.SelectedItem != null) {
                //get selected item from stateTraitsListBox
                string selected = stateTraitsListBox.SelectedItem.ToString();
                //add selected item to allStateTraitsListBox
                unusedStateTraits.Add(selected);
                allStateTraitsListBox.Items.Add(selected);

                stateTrait.Remove(selected);
                stateTraitsListBox.Items.Remove(selected);
            }
        }

        private void CreateNewStateModiderButton_Click(object sender, EventArgs e) {
            //add new trait from StateTraitSearchTextBox to allStateModifersListBox if it doesn't already exist
            if (!allStateTraitsListBox.Items.Contains(StateTraitSearchTextBox.Text.Replace(" ", "_"))) {
                unusedStateTraits.Add(StateTraitSearchTextBox.Text.Replace(" ", "_"));
                unusedStateTraits.Sort();

                //set allStateTraitsListBox items to unusedStateTraits
                allStateTraitsListBox.Items.Clear();
                allStateTraitsListBox.Items.AddRange(unusedStateTraits.ToArray());

            }
        }

        private void StateTraitSearchTextBox_TextChanged(object sender, EventArgs e) {
            string[] searchResults = unusedStateTraits.ToArray();
            if (StateTraitSearchTextBox.Text != "") {

                //if there are spaces in StateTraitSearchTextBox.Text split it into an array
                List<string> searchTerms = StateTraitSearchTextBox.Text.Split().ToList();
                //remove empty strings from searchTerms
                searchTerms.RemoveAll(x => x == "");
                if (searchTerms.Count() > 1) {
                    //or searchTerms together
                    //searchResults = unusedStateTraits.Where(x => searchTerms.All(y => x.Contains(y))).ToArray();

                    //and searchTerms together
                    searchResults = searchResults.Where(x => searchTerms.All(y => x.Contains(y))).ToArray();
                }
                else {
                    searchResults = unusedStateTraits.FindAll(x => x.ToLower().Contains(StateTraitSearchTextBox.Text.ToLower())).ToArray();
                }
            }


            //set allStateTraitsListBox items to searchResults
            allStateTraitsListBox.Items.Clear();
            allStateTraitsListBox.Items.AddRange(searchResults);

        }

        private void CancelButton_Click(object sender, EventArgs e) {
            //undo any saved changes to state
            while (mapOp.StackSize > initalUndoStackSize) {
                Console.WriteLine(mapOp.Undo());
            }

            //close the form
            this.Close();
        }

        private void RemoveResourceButton_Click(object sender, EventArgs e) {

            //get the Resource at the selected index in resourceListBox and remove it from state.resources
            if (resourceListBox.SelectedItem != null) {
                mapOp.RemoveResource(state, (Resource)resourceListBox.SelectedItem);
            }

            RefreshResourceListBox();
        }

        private void EditResourceButton_Click(object sender, EventArgs e) {
            //get the Resource at the selected index in resourceListBox
            if (resourceListBox.SelectedItem != null) {
                OpenResourceForm((Resource)resourceListBox.SelectedItem);
            }
        }
        private void CreateNewResourceButton_Click(object sender, EventArgs e) {
            //if search box is not empty
            if (resourceSearchBox.Text != "") {
                //if resourceSearchBox.Text is not already in allResources
                if (!lsu.resources.Contains(resourceSearchBox.Text)) {
                    //add resourceSearchBox.Text to allResources
                    lsu.resources.Add(resourceSearchBox.Text);
                    //create new Resource with name from resourceSearchBox and open UpdateResource form
                    OpenResourceForm(new Resource(resourceSearchBox.Text));
                }
            }
            RefreshResourceListBox();
        }
        private void AddResourceButton_Click(object sender, EventArgs e) {
            //get the Resource at the selected index in allResourcesListBox            
            if (allResourcesListBox.SelectedItems != null) {
                try {
                    OpenResourceForm(new Resource(allResourcesListBox.SelectedItem.ToString()));
                }
                catch {
                    Console.WriteLine("Error: Resource already exists");
                }
            }
            RefreshResourceListBox();
        }

        private void OpenResourceForm(Resource resource) {
            //depletable resource is allResources and ""
            List<string> depletableResources = new List<string>(lsu.resources);
            depletableResources.Add("");
            depletableResources.Sort();
            EditResource editResource = new EditResource(state, resource, depletableResources, mapOp);
            editResource.ShowDialog();
            RefreshResourceListBox();
        }

        //refresh resourceListBox and allResourcesListBox
        private void RefreshResourceListBox() {
            //set resourceListBox items to stateRecources
            resourceListBox.Items.Clear();
            resourceListBox.Items.AddRange(state.resources.ToArray());

            //unusedResources = allResources - state.resources.name
            unusedResources = lsu.resources.Except(state.resources.Select(x => x.name)).ToList();
            //sort unusedResources alphabetically
            unusedResources.Sort();
            allResourcesListBox.Items.Clear();
            allResourcesListBox.Items.AddRange(unusedResources.ToArray());
        }

        //search all resources for searchTerms
        private void ResourceSearchBox_TextChanged(object sender, EventArgs e) {
            //get searchTerms from resourceSearchBox
            List<string> searchTerms = resourceSearchBox.Text.Split().ToList();
            //remove empty strings from searchTerms
            searchTerms.RemoveAll(x => x == "");
            //search allResources for searchTerms that are not in stateRecources
            string[] searchResults = lsu.resources.FindAll(x => searchTerms.All(y => x.Contains(y)) && !stateRecources.Exists(z => z.name == x)).ToArray();
            //set allResourcesListBox items to searchResults
            allResourcesListBox.Items.Clear();
            allResourcesListBox.Items.AddRange(searchResults.ToArray());

        }

        private void SaveButton_Click(object sender, EventArgs e) {
            bool valid = true;
            List<string> errors = new List<string>();

            stateNameTextBox.BackColor = Color.White;
            arableLandTextBox.BackColor = Color.White;
            subsistenceBuildingTextBox.BackColor = Color.White;

            //update state with values from form fields
            //Name
            string name = stateNameTextBox.Text;
            if (name == "") {
                valid = false;
                stateNameTextBox.BackColor = Color.Pink;
                errors.Add("Name cannot be blank");
            }
            else if (lsu.stateNames.Contains(name) && name != state.name) {
                valid = false;
                stateNameTextBox.BackColor = Color.Pink;
                errors.Add("Name already exists");
            }

            //Arable Land
            //try parse
            if (!int.TryParse(arableLandTextBox.Text, out int arableLand) || arableLand < 0) {
                valid = false;
                arableLandTextBox.BackColor = Color.Pink;
                arableLandTextBox.Font = new Font(arableLandTextBox.Font, FontStyle.Bold);
                errors.Add("Arable Land must be a positive integer");
            }

            //subsistence Building
            string subsistenceBuilding = subsistenceBuildingTextBox.Text;
            if (subsistenceBuilding == "") {
                valid = false;
                subsistenceBuildingTextBox.BackColor = Color.Pink;
                errors.Add("Subsistence Building cannot be blank");
            }

            //traits
            List<string> traits = stateTraitsListBox.Items.Cast<string>().ToList();

            if (!valid) {
                //message box with errors
                MessageBox.Show(string.Join(Environment.NewLine, errors.ToArray()), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            //update state
            mapOp.UpdateState(state, name, arableLand, subsistenceBuilding, traits);

            //dialogResult = OK
            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        private void EditState_Load(object sender, EventArgs e) {

        }

        private void AllCultureSearchTextBox_TextChanged(object sender, EventArgs e) {
            try {
                //get searchTerms from cultureSearchTextBox
                List<string> searchTerms = cultureSearchTextBox.Text.Split().ToList();
                //remove empty strings from searchTerms
                searchTerms.RemoveAll(x => x == "");
                //search allCulturesList for searchTerms that are not string in state.homeLandList
                string[] searchResults = lsu.cultures.FindAll(x => searchTerms.All(y => x.Contains(y)) && !state.homeLandList.Exists(z => z == x)).ToArray();
                //set allCulturesListBox items to searchResults
                allCulturesListBox.Items.Clear();
                allCulturesListBox.Items.AddRange(searchResults.ToArray());
            }
            catch {
                Console.WriteLine("Error: cultureSearchTextBox_TextChanged");
            }

        }

        private void AddHomeLandButton_Click(object sender, EventArgs e) {
            if (allCulturesListBox.SelectedItems == null) return;
            
            //move selected item from allCulturesListBox to state.homeLandList using mapOp
            mapOp.AddCulturalHomeLand(state, allCulturesListBox.SelectedItem.ToString());
            //refresh homeLandListBox
            homeLandListBox.Items.Clear();
            homeLandListBox.Items.AddRange(state.homeLandList.ToArray());
            //remove selected item from allCulturesListBox
            allCulturesListBox.Items.Remove(allCulturesListBox.SelectedItem);
        }

        private void RemoveHomeLandButton_Click(object sender, EventArgs e) {
            //opisite of AddHomeLandButton_Click
            if (homeLandListBox.SelectedItems == null) return;
            
            mapOp.RemoveCulturalHomeLand(state, homeLandListBox.SelectedItem.ToString());
            allCulturesListBox.Items.Add(homeLandListBox.SelectedItem);
            homeLandListBox.Items.Remove(homeLandListBox.SelectedItem);
        }


        private void TagSeachTextBox_TextChanged(object sender, EventArgs e) {

            //get searchTerms from tagSearchTextBox
            List<string> searchTerms = tagSearchTextBox.Text.Split().ToList();
            //remove empty strings from searchTerms
            searchTerms.RemoveAll(x => x == "");
            //search allTagsList for searchTerms that are not string in state.claimList
            string[] searchResults = lsu.nationTags.FindAll(x => searchTerms.All(y => x.Contains(y)) && !state.claimList.Exists(z => z == x)).ToArray();
            //set allTagsListBox items to searchResults
            allTagsListBox.Items.Clear();
            allTagsListBox.Items.AddRange(searchResults.ToArray());

        }
        private void AddClaimButton_Click(object sender, EventArgs e) {            
            if (allTagsListBox.SelectedItems == null) return;
            
            //move selected item from allClaimsListBox to state.claims using mapOp
            mapOp.AddClaim(state, allTagsListBox.SelectedItem.ToString());
            //refresh claimsListBox
            claimTagListBox.Items.Clear();
            claimTagListBox.Items.AddRange(state.claimList.ToArray());
            //remove selected item from allClaimsListBox
            allTagsListBox.Items.Remove(allTagsListBox.SelectedItem);
        }

        private void RemoveClaimButton_Click(object sender, EventArgs e) {
            //opisite of AddClaimButton_Click
            if (claimTagListBox.SelectedItems == null) return;
            
            mapOp.RemoveClaim(state, claimTagListBox.SelectedItem.ToString());
            allTagsListBox.Items.Add(claimTagListBox.SelectedItem);
            claimTagListBox.Items.Remove(claimTagListBox.SelectedItem);

        }


    }
}
