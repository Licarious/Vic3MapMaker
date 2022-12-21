namespace Vic3MapMaker
{
    partial class EditState
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.nameTB1 = new System.Windows.Forms.TextBox();
            this.stateNameTextBox = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.stateTraitsListBox = new System.Windows.Forms.ListBox();
            this.allStateTraitsListBox = new System.Windows.Forms.ListBox();
            this.StateTraitSearchTextBox = new System.Windows.Forms.TextBox();
            this.addStateModiderButton = new System.Windows.Forms.Button();
            this.removeStateModiferButton = new System.Windows.Forms.Button();
            this.createNewStateModiderButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.subsistenceBuildingTextBox = new System.Windows.Forms.TextBox();
            this.createNewResourceButton = new System.Windows.Forms.Button();
            this.removeResourceButton = new System.Windows.Forms.Button();
            this.addResourceButton = new System.Windows.Forms.Button();
            this.resourceSearchBox = new System.Windows.Forms.TextBox();
            this.allResourcesListBox = new System.Windows.Forms.ListBox();
            this.resourceListBox = new System.Windows.Forms.ListBox();
            this.arableLandTextBox = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.editResourceButton = new System.Windows.Forms.Button();
            this.homeLandListBox = new System.Windows.Forms.ListBox();
            this.allCulturesListBox = new System.Windows.Forms.ListBox();
            this.removeHomeLandButton = new System.Windows.Forms.Button();
            this.addHomeLandButton = new System.Windows.Forms.Button();
            this.cultureSearchTextBox = new System.Windows.Forms.TextBox();
            this.homeLandTB = new System.Windows.Forms.TextBox();
            this.externalCoresTB = new System.Windows.Forms.TextBox();
            this.tagSearchTextBox = new System.Windows.Forms.TextBox();
            this.removeClaimButton = new System.Windows.Forms.Button();
            this.addClaimButton = new System.Windows.Forms.Button();
            this.allTagsListBox = new System.Windows.Forms.ListBox();
            this.claimTagListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // nameTB1
            // 
            this.nameTB1.Enabled = false;
            this.nameTB1.Location = new System.Drawing.Point(12, 12);
            this.nameTB1.Name = "nameTB1";
            this.nameTB1.ReadOnly = true;
            this.nameTB1.Size = new System.Drawing.Size(256, 26);
            this.nameTB1.TabIndex = 28;
            this.nameTB1.Text = "State Name:";
            // 
            // stateNameTextBox
            // 
            this.stateNameTextBox.Location = new System.Drawing.Point(12, 44);
            this.stateNameTextBox.Name = "stateNameTextBox";
            this.stateNameTextBox.Size = new System.Drawing.Size(256, 26);
            this.stateNameTextBox.TabIndex = 1;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(1150, 608);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 44);
            this.SaveButton.TabIndex = 2;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(1059, 608);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 44);
            this.CancelButton.TabIndex = 3;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // stateTraitsListBox
            // 
            this.stateTraitsListBox.FormattingEnabled = true;
            this.stateTraitsListBox.ItemHeight = 20;
            this.stateTraitsListBox.Location = new System.Drawing.Point(12, 76);
            this.stateTraitsListBox.Name = "stateTraitsListBox";
            this.stateTraitsListBox.Size = new System.Drawing.Size(256, 204);
            this.stateTraitsListBox.TabIndex = 4;
            // 
            // allStateTraitsListBox
            // 
            this.allStateTraitsListBox.FormattingEnabled = true;
            this.allStateTraitsListBox.ItemHeight = 20;
            this.allStateTraitsListBox.Location = new System.Drawing.Point(328, 116);
            this.allStateTraitsListBox.Name = "allStateTraitsListBox";
            this.allStateTraitsListBox.Size = new System.Drawing.Size(253, 164);
            this.allStateTraitsListBox.TabIndex = 5;
            // 
            // StateTraitSearchTextBox
            // 
            this.StateTraitSearchTextBox.Location = new System.Drawing.Point(328, 77);
            this.StateTraitSearchTextBox.Name = "StateTraitSearchTextBox";
            this.StateTraitSearchTextBox.Size = new System.Drawing.Size(253, 26);
            this.StateTraitSearchTextBox.TabIndex = 6;
            this.StateTraitSearchTextBox.TextChanged += new System.EventHandler(this.StateTraitSearchTextBox_TextChanged);
            // 
            // addStateModiderButton
            // 
            this.addStateModiderButton.Location = new System.Drawing.Point(274, 145);
            this.addStateModiderButton.Name = "addStateModiderButton";
            this.addStateModiderButton.Size = new System.Drawing.Size(48, 40);
            this.addStateModiderButton.TabIndex = 7;
            this.addStateModiderButton.Text = "<";
            this.addStateModiderButton.UseVisualStyleBackColor = true;
            this.addStateModiderButton.Click += new System.EventHandler(this.AddStateModiderButton_Click);
            // 
            // removeStateModiferButton
            // 
            this.removeStateModiferButton.Location = new System.Drawing.Point(274, 191);
            this.removeStateModiferButton.Name = "removeStateModiferButton";
            this.removeStateModiferButton.Size = new System.Drawing.Size(48, 40);
            this.removeStateModiferButton.TabIndex = 8;
            this.removeStateModiferButton.Text = ">";
            this.removeStateModiferButton.UseVisualStyleBackColor = true;
            this.removeStateModiferButton.Click += new System.EventHandler(this.RemoveStateModiferButton_Click);
            // 
            // createNewStateModiderButton
            // 
            this.createNewStateModiderButton.Location = new System.Drawing.Point(328, 34);
            this.createNewStateModiderButton.Name = "createNewStateModiderButton";
            this.createNewStateModiderButton.Size = new System.Drawing.Size(253, 37);
            this.createNewStateModiderButton.TabIndex = 9;
            this.createNewStateModiderButton.Text = "Create New State Modifer";
            this.createNewStateModiderButton.UseVisualStyleBackColor = true;
            this.createNewStateModiderButton.Click += new System.EventHandler(this.CreateNewStateModiderButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(12, 330);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(256, 26);
            this.textBox1.TabIndex = 29;
            this.textBox1.Text = "Subsistence Building";
            // 
            // subsistenceBuildingTextBox
            // 
            this.subsistenceBuildingTextBox.Location = new System.Drawing.Point(12, 362);
            this.subsistenceBuildingTextBox.Name = "subsistenceBuildingTextBox";
            this.subsistenceBuildingTextBox.Size = new System.Drawing.Size(256, 26);
            this.subsistenceBuildingTextBox.TabIndex = 1;
            // 
            // createNewResourceButton
            // 
            this.createNewResourceButton.Location = new System.Drawing.Point(328, 298);
            this.createNewResourceButton.Name = "createNewResourceButton";
            this.createNewResourceButton.Size = new System.Drawing.Size(253, 37);
            this.createNewResourceButton.TabIndex = 17;
            this.createNewResourceButton.Text = "Create New Resource";
            this.createNewResourceButton.UseVisualStyleBackColor = true;
            this.createNewResourceButton.Click += new System.EventHandler(this.CreateNewResourceButton_Click);
            // 
            // removeResourceButton
            // 
            this.removeResourceButton.Location = new System.Drawing.Point(274, 511);
            this.removeResourceButton.Name = "removeResourceButton";
            this.removeResourceButton.Size = new System.Drawing.Size(48, 40);
            this.removeResourceButton.TabIndex = 16;
            this.removeResourceButton.Text = ">";
            this.removeResourceButton.UseVisualStyleBackColor = true;
            this.removeResourceButton.Click += new System.EventHandler(this.RemoveResourceButton_Click);
            // 
            // addResourceButton
            // 
            this.addResourceButton.Location = new System.Drawing.Point(274, 465);
            this.addResourceButton.Name = "addResourceButton";
            this.addResourceButton.Size = new System.Drawing.Size(48, 40);
            this.addResourceButton.TabIndex = 15;
            this.addResourceButton.Text = "<";
            this.addResourceButton.UseVisualStyleBackColor = true;
            this.addResourceButton.Click += new System.EventHandler(this.AddResourceButton_Click);
            // 
            // resourceSearchBox
            // 
            this.resourceSearchBox.Location = new System.Drawing.Point(328, 342);
            this.resourceSearchBox.Name = "resourceSearchBox";
            this.resourceSearchBox.Size = new System.Drawing.Size(253, 26);
            this.resourceSearchBox.TabIndex = 14;
            this.resourceSearchBox.TextChanged += new System.EventHandler(this.ResourceSearchBox_TextChanged);
            // 
            // allResourcesListBox
            // 
            this.allResourcesListBox.FormattingEnabled = true;
            this.allResourcesListBox.ItemHeight = 20;
            this.allResourcesListBox.Location = new System.Drawing.Point(328, 374);
            this.allResourcesListBox.Name = "allResourcesListBox";
            this.allResourcesListBox.Size = new System.Drawing.Size(253, 264);
            this.allResourcesListBox.TabIndex = 13;
            // 
            // resourceListBox
            // 
            this.resourceListBox.FormattingEnabled = true;
            this.resourceListBox.ItemHeight = 20;
            this.resourceListBox.Location = new System.Drawing.Point(12, 394);
            this.resourceListBox.Name = "resourceListBox";
            this.resourceListBox.Size = new System.Drawing.Size(256, 204);
            this.resourceListBox.TabIndex = 12;
            // 
            // arableLandTextBox
            // 
            this.arableLandTextBox.Location = new System.Drawing.Point(132, 298);
            this.arableLandTextBox.Name = "arableLandTextBox";
            this.arableLandTextBox.Size = new System.Drawing.Size(136, 26);
            this.arableLandTextBox.TabIndex = 19;
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(12, 298);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(114, 26);
            this.textBox3.TabIndex = 18;
            this.textBox3.Text = "Arable Land";
            // 
            // editResourceButton
            // 
            this.editResourceButton.Location = new System.Drawing.Point(12, 604);
            this.editResourceButton.Name = "editResourceButton";
            this.editResourceButton.Size = new System.Drawing.Size(256, 34);
            this.editResourceButton.TabIndex = 30;
            this.editResourceButton.Text = "Edit Resource";
            this.editResourceButton.UseVisualStyleBackColor = true;
            this.editResourceButton.Click += new System.EventHandler(this.EditResourceButton_Click);
            // 
            // homeLandListBox
            // 
            this.homeLandListBox.FormattingEnabled = true;
            this.homeLandListBox.ItemHeight = 20;
            this.homeLandListBox.Location = new System.Drawing.Point(656, 56);
            this.homeLandListBox.Name = "homeLandListBox";
            this.homeLandListBox.Size = new System.Drawing.Size(256, 224);
            this.homeLandListBox.Sorted = true;
            this.homeLandListBox.TabIndex = 31;
            // 
            // allCulturesListBox
            // 
            this.allCulturesListBox.FormattingEnabled = true;
            this.allCulturesListBox.ItemHeight = 20;
            this.allCulturesListBox.Location = new System.Drawing.Point(972, 96);
            this.allCulturesListBox.Name = "allCulturesListBox";
            this.allCulturesListBox.Size = new System.Drawing.Size(253, 184);
            this.allCulturesListBox.Sorted = true;
            this.allCulturesListBox.TabIndex = 32;
            // 
            // removeHomeLandButton
            // 
            this.removeHomeLandButton.Location = new System.Drawing.Point(918, 181);
            this.removeHomeLandButton.Name = "removeHomeLandButton";
            this.removeHomeLandButton.Size = new System.Drawing.Size(48, 40);
            this.removeHomeLandButton.TabIndex = 34;
            this.removeHomeLandButton.Text = ">";
            this.removeHomeLandButton.UseVisualStyleBackColor = true;
            this.removeHomeLandButton.Click += new System.EventHandler(this.RemoveHomeLandButton_Click);
            // 
            // addHomeLandButton
            // 
            this.addHomeLandButton.Location = new System.Drawing.Point(918, 135);
            this.addHomeLandButton.Name = "addHomeLandButton";
            this.addHomeLandButton.Size = new System.Drawing.Size(48, 40);
            this.addHomeLandButton.TabIndex = 33;
            this.addHomeLandButton.Text = "<";
            this.addHomeLandButton.UseVisualStyleBackColor = true;
            this.addHomeLandButton.Click += new System.EventHandler(this.AddHomeLandButton_Click);
            // 
            // cultureSearchTextBox
            // 
            this.cultureSearchTextBox.Location = new System.Drawing.Point(972, 56);
            this.cultureSearchTextBox.Name = "cultureSearchTextBox";
            this.cultureSearchTextBox.Size = new System.Drawing.Size(253, 26);
            this.cultureSearchTextBox.TabIndex = 35;
            this.cultureSearchTextBox.TextChanged += new System.EventHandler(this.AllCultureSearchTextBox_TextChanged);
            // 
            // homeLandTB
            // 
            this.homeLandTB.Enabled = false;
            this.homeLandTB.Location = new System.Drawing.Point(656, 24);
            this.homeLandTB.Name = "homeLandTB";
            this.homeLandTB.ReadOnly = true;
            this.homeLandTB.Size = new System.Drawing.Size(256, 26);
            this.homeLandTB.TabIndex = 36;
            this.homeLandTB.Text = "Home Land:";
            // 
            // externalCoresTB
            // 
            this.externalCoresTB.Enabled = false;
            this.externalCoresTB.Location = new System.Drawing.Point(656, 298);
            this.externalCoresTB.Name = "externalCoresTB";
            this.externalCoresTB.ReadOnly = true;
            this.externalCoresTB.Size = new System.Drawing.Size(256, 26);
            this.externalCoresTB.TabIndex = 42;
            this.externalCoresTB.Text = "Claims:";
            // 
            // tagSearchTextBox
            // 
            this.tagSearchTextBox.Location = new System.Drawing.Point(972, 298);
            this.tagSearchTextBox.Name = "tagSearchTextBox";
            this.tagSearchTextBox.Size = new System.Drawing.Size(253, 26);
            this.tagSearchTextBox.TabIndex = 41;
            this.tagSearchTextBox.TextChanged += new System.EventHandler(this.TagSeachTextBox_TextChanged);
            // 
            // removeClaimButton
            // 
            this.removeClaimButton.Location = new System.Drawing.Point(918, 455);
            this.removeClaimButton.Name = "removeClaimButton";
            this.removeClaimButton.Size = new System.Drawing.Size(48, 40);
            this.removeClaimButton.TabIndex = 40;
            this.removeClaimButton.Text = ">";
            this.removeClaimButton.UseVisualStyleBackColor = true;
            this.removeClaimButton.Click += new System.EventHandler(this.RemoveClaimButton_Click);
            // 
            // addClaimButton
            // 
            this.addClaimButton.Location = new System.Drawing.Point(918, 409);
            this.addClaimButton.Name = "addClaimButton";
            this.addClaimButton.Size = new System.Drawing.Size(48, 40);
            this.addClaimButton.TabIndex = 39;
            this.addClaimButton.Text = "<";
            this.addClaimButton.UseVisualStyleBackColor = true;
            this.addClaimButton.Click += new System.EventHandler(this.AddClaimButton_Click);
            // 
            // allTagsListBox
            // 
            this.allTagsListBox.FormattingEnabled = true;
            this.allTagsListBox.ItemHeight = 20;
            this.allTagsListBox.Location = new System.Drawing.Point(972, 330);
            this.allTagsListBox.Name = "allTagsListBox";
            this.allTagsListBox.Size = new System.Drawing.Size(253, 264);
            this.allTagsListBox.Sorted = true;
            this.allTagsListBox.TabIndex = 38;
            // 
            // claimTagListBox
            // 
            this.claimTagListBox.FormattingEnabled = true;
            this.claimTagListBox.ItemHeight = 20;
            this.claimTagListBox.Location = new System.Drawing.Point(656, 330);
            this.claimTagListBox.Name = "claimTagListBox";
            this.claimTagListBox.Size = new System.Drawing.Size(256, 264);
            this.claimTagListBox.Sorted = true;
            this.claimTagListBox.TabIndex = 37;
            // 
            // EditState
            // 
            this.ClientSize = new System.Drawing.Size(1238, 664);
            this.Controls.Add(this.externalCoresTB);
            this.Controls.Add(this.tagSearchTextBox);
            this.Controls.Add(this.removeClaimButton);
            this.Controls.Add(this.addClaimButton);
            this.Controls.Add(this.allTagsListBox);
            this.Controls.Add(this.claimTagListBox);
            this.Controls.Add(this.homeLandTB);
            this.Controls.Add(this.cultureSearchTextBox);
            this.Controls.Add(this.removeHomeLandButton);
            this.Controls.Add(this.addHomeLandButton);
            this.Controls.Add(this.allCulturesListBox);
            this.Controls.Add(this.homeLandListBox);
            this.Controls.Add(this.editResourceButton);
            this.Controls.Add(this.arableLandTextBox);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.createNewResourceButton);
            this.Controls.Add(this.removeResourceButton);
            this.Controls.Add(this.addResourceButton);
            this.Controls.Add(this.resourceSearchBox);
            this.Controls.Add(this.allResourcesListBox);
            this.Controls.Add(this.resourceListBox);
            this.Controls.Add(this.createNewStateModiderButton);
            this.Controls.Add(this.removeStateModiferButton);
            this.Controls.Add(this.addStateModiderButton);
            this.Controls.Add(this.StateTraitSearchTextBox);
            this.Controls.Add(this.allStateTraitsListBox);
            this.Controls.Add(this.stateTraitsListBox);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.subsistenceBuildingTextBox);
            this.Controls.Add(this.stateNameTextBox);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.nameTB1);
            this.Name = "EditState";
            this.Text = "EditSate";
            this.Load += new System.EventHandler(this.EditState_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameTB1;
        private System.Windows.Forms.TextBox stateNameTextBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.ListBox stateTraitsListBox;
        private System.Windows.Forms.ListBox allStateTraitsListBox;
        private System.Windows.Forms.TextBox StateTraitSearchTextBox;
        private System.Windows.Forms.Button addStateModiderButton;
        private System.Windows.Forms.Button removeStateModiferButton;
        private System.Windows.Forms.Button createNewStateModiderButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox subsistenceBuildingTextBox;
        private System.Windows.Forms.Button createNewResourceButton;
        private System.Windows.Forms.Button removeResourceButton;
        private System.Windows.Forms.Button addResourceButton;
        private System.Windows.Forms.TextBox resourceSearchBox;
        private System.Windows.Forms.ListBox allResourcesListBox;
        private System.Windows.Forms.ListBox resourceListBox;
        private System.Windows.Forms.TextBox arableLandTextBox;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button editResourceButton;
        private System.Windows.Forms.ListBox homeLandListBox;
        private System.Windows.Forms.ListBox allCulturesListBox;
        private System.Windows.Forms.Button removeHomeLandButton;
        private System.Windows.Forms.Button addHomeLandButton;
        private System.Windows.Forms.TextBox cultureSearchTextBox;
        private System.Windows.Forms.TextBox homeLandTB;
        private System.Windows.Forms.TextBox externalCoresTB;
        private System.Windows.Forms.TextBox tagSearchTextBox;
        private System.Windows.Forms.Button addClaimButton;
        private System.Windows.Forms.ListBox allTagsListBox;
        private System.Windows.Forms.ListBox claimTagListBox;
        private System.Windows.Forms.Button removeClaimButton;
    }
}
