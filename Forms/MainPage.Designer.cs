using System;
using System.Windows.Forms;

namespace Vic3MapMaker
{
    partial class MainPage
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
            try {
                if (disposing && (components != null)) {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.splitContainerControls_Image = new System.Windows.Forms.SplitContainer();
            this.refreshMapButton = new System.Windows.Forms.Button();
            this.undoButton = new System.Windows.Forms.Button();
            this.statePanel = new System.Windows.Forms.Panel();
            this.farmHubNameTextBox = new System.Windows.Forms.TextBox();
            this.regionPannel = new System.Windows.Forms.FlowLayoutPanel();
            this.transferStateRadioButton = new System.Windows.Forms.RadioButton();
            this.ChangeCapitalRadioButton = new System.Windows.Forms.RadioButton();
            this.regionCapitalTextBox = new System.Windows.Forms.TextBox();
            this.createNewRegionButton = new System.Windows.Forms.Button();
            this.mineHubNameTextBox = new System.Windows.Forms.TextBox();
            this.woodHubNameTextBox = new System.Windows.Forms.TextBox();
            this.portHubNameTextBox = new System.Windows.Forms.TextBox();
            this.cityHubNameTextBox = new System.Windows.Forms.TextBox();
            this.transferProvinceRadioButton = new System.Windows.Forms.RadioButton();
            this.navalExitRadioButton = new System.Windows.Forms.RadioButton();
            this.clearUpdateHubButton = new System.Windows.Forms.Button();
            this.hubFarmUpdateRadioButton = new System.Windows.Forms.RadioButton();
            this.hubMineUpdateRadioButton = new System.Windows.Forms.RadioButton();
            this.hubWoodUpdateRadioButton = new System.Windows.Forms.RadioButton();
            this.hubPortUpdateRadioButton = new System.Windows.Forms.RadioButton();
            this.hubCityUpdateRadioButton = new System.Windows.Forms.RadioButton();
            this.hubFarmTextBox = new System.Windows.Forms.TextBox();
            this.hubMineTextBox = new System.Windows.Forms.TextBox();
            this.hubWoodTextBox = new System.Windows.Forms.TextBox();
            this.hubPortTextBox = new System.Windows.Forms.TextBox();
            this.hubCityTextBox = new System.Windows.Forms.TextBox();
            this.stateNavalExitTextBox = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.nationalPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.transferProvinceNationalRadioButton = new System.Windows.Forms.RadioButton();
            this.transferStateNationalRadioButton = new System.Windows.Forms.RadioButton();
            this.transferRegionNationalRadioButton = new System.Windows.Forms.RadioButton();
            this.createNewCountryButton = new System.Windows.Forms.Button();
            this.textBoxCurrentlySelectedMapArea = new System.Windows.Forms.TextBox();
            this.EditStateRegioon = new System.Windows.Forms.Button();
            this.itemComboBox = new System.Windows.Forms.ComboBox();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControls_Image)).BeginInit();
            this.splitContainerControls_Image.Panel1.SuspendLayout();
            this.splitContainerControls_Image.Panel2.SuspendLayout();
            this.splitContainerControls_Image.SuspendLayout();
            this.statePanel.SuspendLayout();
            this.regionPannel.SuspendLayout();
            this.nationalPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControls_Image
            // 
            this.splitContainerControls_Image.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControls_Image.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControls_Image.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainerControls_Image.Name = "splitContainerControls_Image";
            // 
            // splitContainerControls_Image.Panel1
            // 
            this.splitContainerControls_Image.Panel1.AutoScroll = true;
            this.splitContainerControls_Image.Panel1.Controls.Add(this.refreshMapButton);
            this.splitContainerControls_Image.Panel1.Controls.Add(this.undoButton);
            this.splitContainerControls_Image.Panel1.Controls.Add(this.statePanel);
            this.splitContainerControls_Image.Panel1.Controls.Add(this.buttonSave);
            this.splitContainerControls_Image.Panel1.Controls.Add(this.nationalPanel);
            this.splitContainerControls_Image.Panel1.Controls.Add(this.textBoxCurrentlySelectedMapArea);
            this.splitContainerControls_Image.Panel1.Controls.Add(this.EditStateRegioon);
            this.splitContainerControls_Image.Panel1.Controls.Add(this.itemComboBox);
            this.splitContainerControls_Image.Panel1.Controls.Add(this.categoryComboBox);
            // 
            // splitContainerControls_Image.Panel2
            // 
            this.splitContainerControls_Image.Panel2.AutoScroll = true;
            this.splitContainerControls_Image.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainerControls_Image.Size = new System.Drawing.Size(1283, 690);
            this.splitContainerControls_Image.SplitterDistance = 161;
            this.splitContainerControls_Image.SplitterWidth = 3;
            this.splitContainerControls_Image.TabIndex = 0;
            // 
            // refreshMapButton
            // 
            this.refreshMapButton.Location = new System.Drawing.Point(156, 363);
            this.refreshMapButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.refreshMapButton.Name = "refreshMapButton";
            this.refreshMapButton.Size = new System.Drawing.Size(58, 29);
            this.refreshMapButton.TabIndex = 100;
            this.refreshMapButton.Text = "Refresh";
            this.refreshMapButton.UseVisualStyleBackColor = true;
            this.refreshMapButton.Click += new System.EventHandler(this.RefreshMapButton_Click);
            // 
            // undoButton
            // 
            this.undoButton.Location = new System.Drawing.Point(7, 363);
            this.undoButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(58, 29);
            this.undoButton.TabIndex = 20;
            this.undoButton.Text = "Undo";
            this.undoButton.UseVisualStyleBackColor = true;
            this.undoButton.Click += new System.EventHandler(this.UndoButton_Click);
            // 
            // statePanel
            // 
            this.statePanel.Controls.Add(this.farmHubNameTextBox);
            this.statePanel.Controls.Add(this.regionPannel);
            this.statePanel.Controls.Add(this.mineHubNameTextBox);
            this.statePanel.Controls.Add(this.woodHubNameTextBox);
            this.statePanel.Controls.Add(this.portHubNameTextBox);
            this.statePanel.Controls.Add(this.cityHubNameTextBox);
            this.statePanel.Controls.Add(this.transferProvinceRadioButton);
            this.statePanel.Controls.Add(this.navalExitRadioButton);
            this.statePanel.Controls.Add(this.clearUpdateHubButton);
            this.statePanel.Controls.Add(this.hubFarmUpdateRadioButton);
            this.statePanel.Controls.Add(this.hubMineUpdateRadioButton);
            this.statePanel.Controls.Add(this.hubWoodUpdateRadioButton);
            this.statePanel.Controls.Add(this.hubPortUpdateRadioButton);
            this.statePanel.Controls.Add(this.hubCityUpdateRadioButton);
            this.statePanel.Controls.Add(this.hubFarmTextBox);
            this.statePanel.Controls.Add(this.hubMineTextBox);
            this.statePanel.Controls.Add(this.hubWoodTextBox);
            this.statePanel.Controls.Add(this.hubPortTextBox);
            this.statePanel.Controls.Add(this.hubCityTextBox);
            this.statePanel.Controls.Add(this.stateNavalExitTextBox);
            this.statePanel.Location = new System.Drawing.Point(8, 107);
            this.statePanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.statePanel.Name = "statePanel";
            this.statePanel.Size = new System.Drawing.Size(206, 252);
            this.statePanel.TabIndex = 8;
            this.statePanel.Visible = false;
            // 
            // farmHubNameTextBox
            // 
            this.farmHubNameTextBox.Location = new System.Drawing.Point(133, 181);
            this.farmHubNameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.farmHubNameTextBox.Name = "farmHubNameTextBox";
            this.farmHubNameTextBox.Size = new System.Drawing.Size(73, 20);
            this.farmHubNameTextBox.TabIndex = 21;
            // 
            // regionPannel
            // 
            this.regionPannel.Controls.Add(this.transferStateRadioButton);
            this.regionPannel.Controls.Add(this.ChangeCapitalRadioButton);
            this.regionPannel.Controls.Add(this.regionCapitalTextBox);
            this.regionPannel.Controls.Add(this.createNewRegionButton);
            this.regionPannel.Location = new System.Drawing.Point(19, 13);
            this.regionPannel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.regionPannel.Name = "regionPannel";
            this.regionPannel.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.regionPannel.Size = new System.Drawing.Size(157, 91);
            this.regionPannel.TabIndex = 99;
            // 
            // transferStateRadioButton
            // 
            this.transferStateRadioButton.AutoSize = true;
            this.transferStateRadioButton.Location = new System.Drawing.Point(5, 5);
            this.transferStateRadioButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.transferStateRadioButton.Name = "transferStateRadioButton";
            this.transferStateRadioButton.Size = new System.Drawing.Size(92, 17);
            this.transferStateRadioButton.TabIndex = 10;
            this.transferStateRadioButton.TabStop = true;
            this.transferStateRadioButton.Text = "Transfer State";
            this.transferStateRadioButton.UseVisualStyleBackColor = true;
            // 
            // ChangeCapitalRadioButton
            // 
            this.ChangeCapitalRadioButton.AutoSize = true;
            this.ChangeCapitalRadioButton.Location = new System.Drawing.Point(5, 26);
            this.ChangeCapitalRadioButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ChangeCapitalRadioButton.Name = "ChangeCapitalRadioButton";
            this.ChangeCapitalRadioButton.Size = new System.Drawing.Size(57, 17);
            this.ChangeCapitalRadioButton.TabIndex = 11;
            this.ChangeCapitalRadioButton.TabStop = true;
            this.ChangeCapitalRadioButton.Text = "Capital";
            this.ChangeCapitalRadioButton.UseVisualStyleBackColor = true;
            // 
            // regionCapitalTextBox
            // 
            this.regionCapitalTextBox.Enabled = false;
            this.regionCapitalTextBox.Location = new System.Drawing.Point(66, 26);
            this.regionCapitalTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.regionCapitalTextBox.Name = "regionCapitalTextBox";
            this.regionCapitalTextBox.ReadOnly = true;
            this.regionCapitalTextBox.Size = new System.Drawing.Size(77, 20);
            this.regionCapitalTextBox.TabIndex = 25;
            // 
            // createNewRegionButton
            // 
            this.createNewRegionButton.Location = new System.Drawing.Point(5, 50);
            this.createNewRegionButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.createNewRegionButton.Name = "createNewRegionButton";
            this.createNewRegionButton.Size = new System.Drawing.Size(135, 34);
            this.createNewRegionButton.TabIndex = 26;
            this.createNewRegionButton.Text = "Creat New Region";
            this.createNewRegionButton.UseVisualStyleBackColor = true;
            this.createNewRegionButton.Click += new System.EventHandler(this.CreateNewRegionButton_Click);
            // 
            // mineHubNameTextBox
            // 
            this.mineHubNameTextBox.Location = new System.Drawing.Point(133, 153);
            this.mineHubNameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.mineHubNameTextBox.Name = "mineHubNameTextBox";
            this.mineHubNameTextBox.Size = new System.Drawing.Size(73, 20);
            this.mineHubNameTextBox.TabIndex = 21;
            // 
            // woodHubNameTextBox
            // 
            this.woodHubNameTextBox.Location = new System.Drawing.Point(133, 125);
            this.woodHubNameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.woodHubNameTextBox.Name = "woodHubNameTextBox";
            this.woodHubNameTextBox.Size = new System.Drawing.Size(73, 20);
            this.woodHubNameTextBox.TabIndex = 21;
            // 
            // portHubNameTextBox
            // 
            this.portHubNameTextBox.Location = new System.Drawing.Point(133, 95);
            this.portHubNameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.portHubNameTextBox.Name = "portHubNameTextBox";
            this.portHubNameTextBox.Size = new System.Drawing.Size(73, 20);
            this.portHubNameTextBox.TabIndex = 21;
            // 
            // cityHubNameTextBox
            // 
            this.cityHubNameTextBox.Location = new System.Drawing.Point(133, 65);
            this.cityHubNameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cityHubNameTextBox.Name = "cityHubNameTextBox";
            this.cityHubNameTextBox.Size = new System.Drawing.Size(73, 20);
            this.cityHubNameTextBox.TabIndex = 21;
            // 
            // transferProvinceRadioButton
            // 
            this.transferProvinceRadioButton.AutoSize = true;
            this.transferProvinceRadioButton.Location = new System.Drawing.Point(2, 13);
            this.transferProvinceRadioButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.transferProvinceRadioButton.Name = "transferProvinceRadioButton";
            this.transferProvinceRadioButton.Size = new System.Drawing.Size(109, 17);
            this.transferProvinceRadioButton.TabIndex = 3;
            this.transferProvinceRadioButton.TabStop = true;
            this.transferProvinceRadioButton.Text = "Transfer Province";
            this.transferProvinceRadioButton.UseVisualStyleBackColor = true;
            // 
            // navalExitRadioButton
            // 
            this.navalExitRadioButton.AutoSize = true;
            this.navalExitRadioButton.Location = new System.Drawing.Point(2, 38);
            this.navalExitRadioButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.navalExitRadioButton.Name = "navalExitRadioButton";
            this.navalExitRadioButton.Size = new System.Drawing.Size(73, 17);
            this.navalExitRadioButton.TabIndex = 4;
            this.navalExitRadioButton.TabStop = true;
            this.navalExitRadioButton.Text = "Naval Exit";
            this.navalExitRadioButton.UseVisualStyleBackColor = true;
            // 
            // clearUpdateHubButton
            // 
            this.clearUpdateHubButton.Location = new System.Drawing.Point(75, 209);
            this.clearUpdateHubButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.clearUpdateHubButton.Name = "clearUpdateHubButton";
            this.clearUpdateHubButton.Size = new System.Drawing.Size(129, 36);
            this.clearUpdateHubButton.TabIndex = 20;
            this.clearUpdateHubButton.Text = "Clear Selected";
            this.clearUpdateHubButton.UseVisualStyleBackColor = true;
            this.clearUpdateHubButton.Click += new System.EventHandler(this.ClearUpdateHubButton_Click);
            // 
            // hubFarmUpdateRadioButton
            // 
            this.hubFarmUpdateRadioButton.AutoSize = true;
            this.hubFarmUpdateRadioButton.Location = new System.Drawing.Point(2, 181);
            this.hubFarmUpdateRadioButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.hubFarmUpdateRadioButton.Name = "hubFarmUpdateRadioButton";
            this.hubFarmUpdateRadioButton.Size = new System.Drawing.Size(48, 17);
            this.hubFarmUpdateRadioButton.TabIndex = 9;
            this.hubFarmUpdateRadioButton.TabStop = true;
            this.hubFarmUpdateRadioButton.Text = "Farm";
            this.hubFarmUpdateRadioButton.UseVisualStyleBackColor = true;
            // 
            // hubMineUpdateRadioButton
            // 
            this.hubMineUpdateRadioButton.AutoSize = true;
            this.hubMineUpdateRadioButton.Location = new System.Drawing.Point(2, 153);
            this.hubMineUpdateRadioButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.hubMineUpdateRadioButton.Name = "hubMineUpdateRadioButton";
            this.hubMineUpdateRadioButton.Size = new System.Drawing.Size(48, 17);
            this.hubMineUpdateRadioButton.TabIndex = 8;
            this.hubMineUpdateRadioButton.TabStop = true;
            this.hubMineUpdateRadioButton.Text = "Mine";
            this.hubMineUpdateRadioButton.UseVisualStyleBackColor = true;
            // 
            // hubWoodUpdateRadioButton
            // 
            this.hubWoodUpdateRadioButton.AutoSize = true;
            this.hubWoodUpdateRadioButton.Location = new System.Drawing.Point(2, 125);
            this.hubWoodUpdateRadioButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.hubWoodUpdateRadioButton.Name = "hubWoodUpdateRadioButton";
            this.hubWoodUpdateRadioButton.Size = new System.Drawing.Size(54, 17);
            this.hubWoodUpdateRadioButton.TabIndex = 7;
            this.hubWoodUpdateRadioButton.TabStop = true;
            this.hubWoodUpdateRadioButton.Text = "Wood";
            this.hubWoodUpdateRadioButton.UseVisualStyleBackColor = true;
            // 
            // hubPortUpdateRadioButton
            // 
            this.hubPortUpdateRadioButton.AutoSize = true;
            this.hubPortUpdateRadioButton.Location = new System.Drawing.Point(2, 95);
            this.hubPortUpdateRadioButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.hubPortUpdateRadioButton.Name = "hubPortUpdateRadioButton";
            this.hubPortUpdateRadioButton.Size = new System.Drawing.Size(44, 17);
            this.hubPortUpdateRadioButton.TabIndex = 6;
            this.hubPortUpdateRadioButton.TabStop = true;
            this.hubPortUpdateRadioButton.Text = "Port";
            this.hubPortUpdateRadioButton.UseVisualStyleBackColor = true;
            // 
            // hubCityUpdateRadioButton
            // 
            this.hubCityUpdateRadioButton.AutoSize = true;
            this.hubCityUpdateRadioButton.Location = new System.Drawing.Point(2, 65);
            this.hubCityUpdateRadioButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.hubCityUpdateRadioButton.Name = "hubCityUpdateRadioButton";
            this.hubCityUpdateRadioButton.Size = new System.Drawing.Size(42, 17);
            this.hubCityUpdateRadioButton.TabIndex = 5;
            this.hubCityUpdateRadioButton.TabStop = true;
            this.hubCityUpdateRadioButton.Text = "City";
            this.hubCityUpdateRadioButton.UseVisualStyleBackColor = true;
            // 
            // hubFarmTextBox
            // 
            this.hubFarmTextBox.Enabled = false;
            this.hubFarmTextBox.Location = new System.Drawing.Point(75, 181);
            this.hubFarmTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.hubFarmTextBox.Name = "hubFarmTextBox";
            this.hubFarmTextBox.ReadOnly = true;
            this.hubFarmTextBox.Size = new System.Drawing.Size(55, 20);
            this.hubFarmTextBox.TabIndex = 18;
            // 
            // hubMineTextBox
            // 
            this.hubMineTextBox.Enabled = false;
            this.hubMineTextBox.Location = new System.Drawing.Point(75, 153);
            this.hubMineTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.hubMineTextBox.Name = "hubMineTextBox";
            this.hubMineTextBox.ReadOnly = true;
            this.hubMineTextBox.Size = new System.Drawing.Size(55, 20);
            this.hubMineTextBox.TabIndex = 17;
            // 
            // hubWoodTextBox
            // 
            this.hubWoodTextBox.Enabled = false;
            this.hubWoodTextBox.Location = new System.Drawing.Point(75, 125);
            this.hubWoodTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.hubWoodTextBox.Name = "hubWoodTextBox";
            this.hubWoodTextBox.ReadOnly = true;
            this.hubWoodTextBox.Size = new System.Drawing.Size(55, 20);
            this.hubWoodTextBox.TabIndex = 16;
            // 
            // hubPortTextBox
            // 
            this.hubPortTextBox.Enabled = false;
            this.hubPortTextBox.Location = new System.Drawing.Point(75, 95);
            this.hubPortTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.hubPortTextBox.Name = "hubPortTextBox";
            this.hubPortTextBox.ReadOnly = true;
            this.hubPortTextBox.Size = new System.Drawing.Size(55, 20);
            this.hubPortTextBox.TabIndex = 15;
            // 
            // hubCityTextBox
            // 
            this.hubCityTextBox.Enabled = false;
            this.hubCityTextBox.Location = new System.Drawing.Point(75, 65);
            this.hubCityTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.hubCityTextBox.Name = "hubCityTextBox";
            this.hubCityTextBox.ReadOnly = true;
            this.hubCityTextBox.Size = new System.Drawing.Size(55, 20);
            this.hubCityTextBox.TabIndex = 14;
            // 
            // stateNavalExitTextBox
            // 
            this.stateNavalExitTextBox.Enabled = false;
            this.stateNavalExitTextBox.Location = new System.Drawing.Point(75, 38);
            this.stateNavalExitTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.stateNavalExitTextBox.Name = "stateNavalExitTextBox";
            this.stateNavalExitTextBox.ReadOnly = true;
            this.stateNavalExitTextBox.Size = new System.Drawing.Size(55, 20);
            this.stateNavalExitTextBox.TabIndex = 8;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(7, 395);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.buttonSave.Size = new System.Drawing.Size(58, 29);
            this.buttonSave.TabIndex = 22;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // nationalPanel
            // 
            this.nationalPanel.Controls.Add(this.transferProvinceNationalRadioButton);
            this.nationalPanel.Controls.Add(this.transferStateNationalRadioButton);
            this.nationalPanel.Controls.Add(this.transferRegionNationalRadioButton);
            this.nationalPanel.Controls.Add(this.createNewCountryButton);
            this.nationalPanel.Location = new System.Drawing.Point(27, 443);
            this.nationalPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nationalPanel.Name = "nationalPanel";
            this.nationalPanel.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.nationalPanel.Size = new System.Drawing.Size(157, 119);
            this.nationalPanel.TabIndex = 100;
            // 
            // transferProvinceNationalRadioButton
            // 
            this.transferProvinceNationalRadioButton.AutoSize = true;
            this.transferProvinceNationalRadioButton.Location = new System.Drawing.Point(5, 5);
            this.transferProvinceNationalRadioButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.transferProvinceNationalRadioButton.Name = "transferProvinceNationalRadioButton";
            this.transferProvinceNationalRadioButton.Size = new System.Drawing.Size(109, 17);
            this.transferProvinceNationalRadioButton.TabIndex = 10;
            this.transferProvinceNationalRadioButton.TabStop = true;
            this.transferProvinceNationalRadioButton.Text = "Transfer Province";
            this.transferProvinceNationalRadioButton.UseVisualStyleBackColor = true;
            // 
            // transferStateNationalRadioButton
            // 
            this.transferStateNationalRadioButton.AutoSize = true;
            this.transferStateNationalRadioButton.Location = new System.Drawing.Point(5, 26);
            this.transferStateNationalRadioButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.transferStateNationalRadioButton.Name = "transferStateNationalRadioButton";
            this.transferStateNationalRadioButton.Size = new System.Drawing.Size(92, 17);
            this.transferStateNationalRadioButton.TabIndex = 11;
            this.transferStateNationalRadioButton.TabStop = true;
            this.transferStateNationalRadioButton.Text = "Transfer State";
            this.transferStateNationalRadioButton.UseVisualStyleBackColor = true;
            // 
            // transferRegionNationalRadioButton
            // 
            this.transferRegionNationalRadioButton.AutoSize = true;
            this.transferRegionNationalRadioButton.Location = new System.Drawing.Point(5, 47);
            this.transferRegionNationalRadioButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.transferRegionNationalRadioButton.Name = "transferRegionNationalRadioButton";
            this.transferRegionNationalRadioButton.Size = new System.Drawing.Size(101, 17);
            this.transferRegionNationalRadioButton.TabIndex = 12;
            this.transferRegionNationalRadioButton.TabStop = true;
            this.transferRegionNationalRadioButton.Text = "Transfer Region";
            this.transferRegionNationalRadioButton.UseVisualStyleBackColor = true;
            // 
            // createNewCountryButton
            // 
            this.createNewCountryButton.Location = new System.Drawing.Point(5, 68);
            this.createNewCountryButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.createNewCountryButton.Name = "createNewCountryButton";
            this.createNewCountryButton.Size = new System.Drawing.Size(135, 34);
            this.createNewCountryButton.TabIndex = 27;
            this.createNewCountryButton.Text = "Creat New Country";
            this.createNewCountryButton.UseVisualStyleBackColor = true;
            // 
            // textBoxCurrentlySelectedMapArea
            // 
            this.textBoxCurrentlySelectedMapArea.Enabled = false;
            this.textBoxCurrentlySelectedMapArea.Location = new System.Drawing.Point(8, 30);
            this.textBoxCurrentlySelectedMapArea.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxCurrentlySelectedMapArea.Name = "textBoxCurrentlySelectedMapArea";
            this.textBoxCurrentlySelectedMapArea.ReadOnly = true;
            this.textBoxCurrentlySelectedMapArea.Size = new System.Drawing.Size(207, 20);
            this.textBoxCurrentlySelectedMapArea.TabIndex = 5;
            this.textBoxCurrentlySelectedMapArea.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EditStateRegioon
            // 
            this.EditStateRegioon.Location = new System.Drawing.Point(7, 73);
            this.EditStateRegioon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.EditStateRegioon.Name = "EditStateRegioon";
            this.EditStateRegioon.Size = new System.Drawing.Size(58, 30);
            this.EditStateRegioon.TabIndex = 2;
            this.EditStateRegioon.Text = "Edit";
            this.EditStateRegioon.UseVisualStyleBackColor = true;
            this.EditStateRegioon.Click += new System.EventHandler(this.EditStateRegioon_Click);
            // 
            // itemComboBox
            // 
            this.itemComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.itemComboBox.FormattingEnabled = true;
            this.itemComboBox.Location = new System.Drawing.Point(7, 51);
            this.itemComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.itemComboBox.MinimumSize = new System.Drawing.Size(68, 0);
            this.itemComboBox.Name = "itemComboBox";
            this.itemComboBox.Size = new System.Drawing.Size(208, 21);
            this.itemComboBox.TabIndex = 1;
            this.itemComboBox.SelectedIndexChanged += new System.EventHandler(this.ItemComboBox_SelectedIndexChanged);
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Items.AddRange(new object[] {
            "Prov",
            "State",
            "Region",
            "Country",
            "PrimeLand",
            "Impassable",
            "Terrain"});
            this.categoryComboBox.Location = new System.Drawing.Point(8, 8);
            this.categoryComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.categoryComboBox.MinimumSize = new System.Drawing.Size(68, 0);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(208, 21);
            this.categoryComboBox.TabIndex = 0;
            this.categoryComboBox.SelectedIndexChanged += new System.EventHandler(this.CategoryComboBox_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(2, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1533, 907);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 690);
            this.Controls.Add(this.splitContainerControls_Image);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainPage";
            this.Text = "MainPage";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainerControls_Image.Panel1.ResumeLayout(false);
            this.splitContainerControls_Image.Panel1.PerformLayout();
            this.splitContainerControls_Image.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControls_Image)).EndInit();
            this.splitContainerControls_Image.ResumeLayout(false);
            this.statePanel.ResumeLayout(false);
            this.statePanel.PerformLayout();
            this.regionPannel.ResumeLayout(false);
            this.regionPannel.PerformLayout();
            this.nationalPanel.ResumeLayout(false);
            this.nationalPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.SplitContainer splitContainerControls_Image;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private BindingSource bindingSource1;
        private PictureBox pictureBox1;
        private Button EditStateRegioon;
        private TextBox textBoxCurrentlySelectedMapArea;
        private Button buttonSave;
        private Panel statePanel;
        private TextBox stateNavalExitTextBox;
        private Button undoButton;
        private TextBox hubCityTextBox;
        private RadioButton hubCityUpdateRadioButton;
        private TextBox hubFarmTextBox;
        private TextBox hubMineTextBox;
        private TextBox hubWoodTextBox;
        private TextBox hubPortTextBox;
        private Button clearUpdateHubButton;
        private RadioButton hubFarmUpdateRadioButton;
        private RadioButton hubMineUpdateRadioButton;
        private RadioButton hubWoodUpdateRadioButton;
        private RadioButton hubPortUpdateRadioButton;
        private RadioButton transferProvinceRadioButton;
        private RadioButton navalExitRadioButton;
        private RadioButton transferStateRadioButton;
        private FlowLayoutPanel regionPannel;
        private TextBox regionCapitalTextBox;
        private RadioButton ChangeCapitalRadioButton;
        private Button refreshMapButton;
        private Button createNewRegionButton;
        private FlowLayoutPanel nationalPanel;
        private RadioButton transferProvinceNationalRadioButton;
        private RadioButton transferStateNationalRadioButton;
        private RadioButton transferRegionNationalRadioButton;
        private Button createNewCountryButton;
        public ComboBox itemComboBox;
        private TextBox cityHubNameTextBox;
        private TextBox farmHubNameTextBox;
        private TextBox mineHubNameTextBox;
        private TextBox woodHubNameTextBox;
        private TextBox portHubNameTextBox;
    }
}

