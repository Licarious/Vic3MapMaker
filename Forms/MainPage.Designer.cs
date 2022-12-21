﻿using System;
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
            this.transferProvinceRadioButton = new System.Windows.Forms.RadioButton();
            this.regionPannel = new System.Windows.Forms.FlowLayoutPanel();
            this.transferStateRadioButton = new System.Windows.Forms.RadioButton();
            this.ChangeCapitalRadioButton = new System.Windows.Forms.RadioButton();
            this.regionCapitalTextBox = new System.Windows.Forms.TextBox();
            this.createNewRegionButton = new System.Windows.Forms.Button();
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
            this.cityHubNameTextBox = new System.Windows.Forms.TextBox();
            this.portHubNameTextBox = new System.Windows.Forms.TextBox();
            this.woodHubNameTextBox = new System.Windows.Forms.TextBox();
            this.mineHubNameTextBox = new System.Windows.Forms.TextBox();
            this.farmHubNameTextBox = new System.Windows.Forms.TextBox();
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
            this.splitContainerControls_Image.Size = new System.Drawing.Size(2638, 1395);
            this.splitContainerControls_Image.SplitterDistance = 332;
            this.splitContainerControls_Image.TabIndex = 0;
            // 
            // refreshMapButton
            // 
            this.refreshMapButton.Location = new System.Drawing.Point(234, 558);
            this.refreshMapButton.Name = "refreshMapButton";
            this.refreshMapButton.Size = new System.Drawing.Size(87, 44);
            this.refreshMapButton.TabIndex = 100;
            this.refreshMapButton.Text = "Refresh";
            this.refreshMapButton.UseVisualStyleBackColor = true;
            this.refreshMapButton.Click += new System.EventHandler(this.refreshMapButton_Click);
            // 
            // undoButton
            // 
            this.undoButton.Location = new System.Drawing.Point(11, 558);
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(87, 44);
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
            this.statePanel.Location = new System.Drawing.Point(12, 164);
            this.statePanel.Name = "statePanel";
            this.statePanel.Size = new System.Drawing.Size(309, 388);
            this.statePanel.TabIndex = 8;
            this.statePanel.Visible = false;
            // 
            // transferProvinceRadioButton
            // 
            this.transferProvinceRadioButton.AutoSize = true;
            this.transferProvinceRadioButton.Location = new System.Drawing.Point(3, 20);
            this.transferProvinceRadioButton.Name = "transferProvinceRadioButton";
            this.transferProvinceRadioButton.Size = new System.Drawing.Size(157, 24);
            this.transferProvinceRadioButton.TabIndex = 3;
            this.transferProvinceRadioButton.TabStop = true;
            this.transferProvinceRadioButton.Text = "Transfer Province";
            this.transferProvinceRadioButton.UseVisualStyleBackColor = true;
            // 
            // regionPannel
            // 
            this.regionPannel.Controls.Add(this.transferStateRadioButton);
            this.regionPannel.Controls.Add(this.ChangeCapitalRadioButton);
            this.regionPannel.Controls.Add(this.regionCapitalTextBox);
            this.regionPannel.Controls.Add(this.createNewRegionButton);
            this.regionPannel.Location = new System.Drawing.Point(28, 20);
            this.regionPannel.Name = "regionPannel";
            this.regionPannel.Padding = new System.Windows.Forms.Padding(5);
            this.regionPannel.Size = new System.Drawing.Size(235, 140);
            this.regionPannel.TabIndex = 99;
            // 
            // transferStateRadioButton
            // 
            this.transferStateRadioButton.AutoSize = true;
            this.transferStateRadioButton.Location = new System.Drawing.Point(8, 8);
            this.transferStateRadioButton.Name = "transferStateRadioButton";
            this.transferStateRadioButton.Size = new System.Drawing.Size(136, 24);
            this.transferStateRadioButton.TabIndex = 10;
            this.transferStateRadioButton.TabStop = true;
            this.transferStateRadioButton.Text = "Transfer State";
            this.transferStateRadioButton.UseVisualStyleBackColor = true;
            // 
            // ChangeCapitalRadioButton
            // 
            this.ChangeCapitalRadioButton.AutoSize = true;
            this.ChangeCapitalRadioButton.Location = new System.Drawing.Point(8, 38);
            this.ChangeCapitalRadioButton.Name = "ChangeCapitalRadioButton";
            this.ChangeCapitalRadioButton.Size = new System.Drawing.Size(83, 24);
            this.ChangeCapitalRadioButton.TabIndex = 11;
            this.ChangeCapitalRadioButton.TabStop = true;
            this.ChangeCapitalRadioButton.Text = "Capital";
            this.ChangeCapitalRadioButton.UseVisualStyleBackColor = true;
            // 
            // regionCapitalTextBox
            // 
            this.regionCapitalTextBox.Enabled = false;
            this.regionCapitalTextBox.Location = new System.Drawing.Point(97, 38);
            this.regionCapitalTextBox.Name = "regionCapitalTextBox";
            this.regionCapitalTextBox.ReadOnly = true;
            this.regionCapitalTextBox.Size = new System.Drawing.Size(114, 26);
            this.regionCapitalTextBox.TabIndex = 25;
            // 
            // createNewRegionButton
            // 
            this.createNewRegionButton.Location = new System.Drawing.Point(8, 70);
            this.createNewRegionButton.Name = "createNewRegionButton";
            this.createNewRegionButton.Size = new System.Drawing.Size(203, 53);
            this.createNewRegionButton.TabIndex = 26;
            this.createNewRegionButton.Text = "Creat New Region";
            this.createNewRegionButton.UseVisualStyleBackColor = true;
            this.createNewRegionButton.Click += new System.EventHandler(this.CreateNewRegionButton_Click);
            // 
            // navalExitRadioButton
            // 
            this.navalExitRadioButton.AutoSize = true;
            this.navalExitRadioButton.Location = new System.Drawing.Point(3, 59);
            this.navalExitRadioButton.Name = "navalExitRadioButton";
            this.navalExitRadioButton.Size = new System.Drawing.Size(103, 24);
            this.navalExitRadioButton.TabIndex = 4;
            this.navalExitRadioButton.TabStop = true;
            this.navalExitRadioButton.Text = "Naval Exit";
            this.navalExitRadioButton.UseVisualStyleBackColor = true;
            // 
            // clearUpdateHubButton
            // 
            this.clearUpdateHubButton.Location = new System.Drawing.Point(113, 321);
            this.clearUpdateHubButton.Name = "clearUpdateHubButton";
            this.clearUpdateHubButton.Size = new System.Drawing.Size(193, 55);
            this.clearUpdateHubButton.TabIndex = 20;
            this.clearUpdateHubButton.Text = "Clear Selected";
            this.clearUpdateHubButton.UseVisualStyleBackColor = true;
            this.clearUpdateHubButton.Click += new System.EventHandler(this.ClearUpdateHubButton_Click);
            // 
            // hubFarmUpdateRadioButton
            // 
            this.hubFarmUpdateRadioButton.AutoSize = true;
            this.hubFarmUpdateRadioButton.Location = new System.Drawing.Point(3, 279);
            this.hubFarmUpdateRadioButton.Name = "hubFarmUpdateRadioButton";
            this.hubFarmUpdateRadioButton.Size = new System.Drawing.Size(71, 24);
            this.hubFarmUpdateRadioButton.TabIndex = 9;
            this.hubFarmUpdateRadioButton.TabStop = true;
            this.hubFarmUpdateRadioButton.Text = "Farm";
            this.hubFarmUpdateRadioButton.UseVisualStyleBackColor = true;
            // 
            // hubMineUpdateRadioButton
            // 
            this.hubMineUpdateRadioButton.AutoSize = true;
            this.hubMineUpdateRadioButton.Location = new System.Drawing.Point(3, 235);
            this.hubMineUpdateRadioButton.Name = "hubMineUpdateRadioButton";
            this.hubMineUpdateRadioButton.Size = new System.Drawing.Size(68, 24);
            this.hubMineUpdateRadioButton.TabIndex = 8;
            this.hubMineUpdateRadioButton.TabStop = true;
            this.hubMineUpdateRadioButton.Text = "Mine";
            this.hubMineUpdateRadioButton.UseVisualStyleBackColor = true;
            // 
            // hubWoodUpdateRadioButton
            // 
            this.hubWoodUpdateRadioButton.AutoSize = true;
            this.hubWoodUpdateRadioButton.Location = new System.Drawing.Point(3, 192);
            this.hubWoodUpdateRadioButton.Name = "hubWoodUpdateRadioButton";
            this.hubWoodUpdateRadioButton.Size = new System.Drawing.Size(76, 24);
            this.hubWoodUpdateRadioButton.TabIndex = 7;
            this.hubWoodUpdateRadioButton.TabStop = true;
            this.hubWoodUpdateRadioButton.Text = "Wood";
            this.hubWoodUpdateRadioButton.UseVisualStyleBackColor = true;
            // 
            // hubPortUpdateRadioButton
            // 
            this.hubPortUpdateRadioButton.AutoSize = true;
            this.hubPortUpdateRadioButton.Location = new System.Drawing.Point(3, 146);
            this.hubPortUpdateRadioButton.Name = "hubPortUpdateRadioButton";
            this.hubPortUpdateRadioButton.Size = new System.Drawing.Size(63, 24);
            this.hubPortUpdateRadioButton.TabIndex = 6;
            this.hubPortUpdateRadioButton.TabStop = true;
            this.hubPortUpdateRadioButton.Text = "Port";
            this.hubPortUpdateRadioButton.UseVisualStyleBackColor = true;
            // 
            // hubCityUpdateRadioButton
            // 
            this.hubCityUpdateRadioButton.AutoSize = true;
            this.hubCityUpdateRadioButton.Location = new System.Drawing.Point(3, 100);
            this.hubCityUpdateRadioButton.Name = "hubCityUpdateRadioButton";
            this.hubCityUpdateRadioButton.Size = new System.Drawing.Size(60, 24);
            this.hubCityUpdateRadioButton.TabIndex = 5;
            this.hubCityUpdateRadioButton.TabStop = true;
            this.hubCityUpdateRadioButton.Text = "City";
            this.hubCityUpdateRadioButton.UseVisualStyleBackColor = true;
            // 
            // hubFarmTextBox
            // 
            this.hubFarmTextBox.Enabled = false;
            this.hubFarmTextBox.Location = new System.Drawing.Point(113, 279);
            this.hubFarmTextBox.Name = "hubFarmTextBox";
            this.hubFarmTextBox.ReadOnly = true;
            this.hubFarmTextBox.Size = new System.Drawing.Size(80, 26);
            this.hubFarmTextBox.TabIndex = 18;
            // 
            // hubMineTextBox
            // 
            this.hubMineTextBox.Enabled = false;
            this.hubMineTextBox.Location = new System.Drawing.Point(113, 235);
            this.hubMineTextBox.Name = "hubMineTextBox";
            this.hubMineTextBox.ReadOnly = true;
            this.hubMineTextBox.Size = new System.Drawing.Size(80, 26);
            this.hubMineTextBox.TabIndex = 17;
            // 
            // hubWoodTextBox
            // 
            this.hubWoodTextBox.Enabled = false;
            this.hubWoodTextBox.Location = new System.Drawing.Point(113, 192);
            this.hubWoodTextBox.Name = "hubWoodTextBox";
            this.hubWoodTextBox.ReadOnly = true;
            this.hubWoodTextBox.Size = new System.Drawing.Size(80, 26);
            this.hubWoodTextBox.TabIndex = 16;
            // 
            // hubPortTextBox
            // 
            this.hubPortTextBox.Enabled = false;
            this.hubPortTextBox.Location = new System.Drawing.Point(113, 146);
            this.hubPortTextBox.Name = "hubPortTextBox";
            this.hubPortTextBox.ReadOnly = true;
            this.hubPortTextBox.Size = new System.Drawing.Size(80, 26);
            this.hubPortTextBox.TabIndex = 15;
            // 
            // hubCityTextBox
            // 
            this.hubCityTextBox.Enabled = false;
            this.hubCityTextBox.Location = new System.Drawing.Point(113, 100);
            this.hubCityTextBox.Name = "hubCityTextBox";
            this.hubCityTextBox.ReadOnly = true;
            this.hubCityTextBox.Size = new System.Drawing.Size(80, 26);
            this.hubCityTextBox.TabIndex = 14;
            // 
            // stateNavalExitTextBox
            // 
            this.stateNavalExitTextBox.Enabled = false;
            this.stateNavalExitTextBox.Location = new System.Drawing.Point(113, 59);
            this.stateNavalExitTextBox.Name = "stateNavalExitTextBox";
            this.stateNavalExitTextBox.ReadOnly = true;
            this.stateNavalExitTextBox.Size = new System.Drawing.Size(80, 26);
            this.stateNavalExitTextBox.TabIndex = 8;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(11, 608);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.buttonSave.Size = new System.Drawing.Size(87, 45);
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
            this.nationalPanel.Location = new System.Drawing.Point(40, 682);
            this.nationalPanel.Name = "nationalPanel";
            this.nationalPanel.Padding = new System.Windows.Forms.Padding(5);
            this.nationalPanel.Size = new System.Drawing.Size(235, 183);
            this.nationalPanel.TabIndex = 100;
            // 
            // transferProvinceNationalRadioButton
            // 
            this.transferProvinceNationalRadioButton.AutoSize = true;
            this.transferProvinceNationalRadioButton.Location = new System.Drawing.Point(8, 8);
            this.transferProvinceNationalRadioButton.Name = "transferProvinceNationalRadioButton";
            this.transferProvinceNationalRadioButton.Size = new System.Drawing.Size(157, 24);
            this.transferProvinceNationalRadioButton.TabIndex = 10;
            this.transferProvinceNationalRadioButton.TabStop = true;
            this.transferProvinceNationalRadioButton.Text = "Transfer Province";
            this.transferProvinceNationalRadioButton.UseVisualStyleBackColor = true;
            // 
            // transferStateNationalRadioButton
            // 
            this.transferStateNationalRadioButton.AutoSize = true;
            this.transferStateNationalRadioButton.Location = new System.Drawing.Point(8, 38);
            this.transferStateNationalRadioButton.Name = "transferStateNationalRadioButton";
            this.transferStateNationalRadioButton.Size = new System.Drawing.Size(136, 24);
            this.transferStateNationalRadioButton.TabIndex = 11;
            this.transferStateNationalRadioButton.TabStop = true;
            this.transferStateNationalRadioButton.Text = "Transfer State";
            this.transferStateNationalRadioButton.UseVisualStyleBackColor = true;
            // 
            // transferRegionNationalRadioButton
            // 
            this.transferRegionNationalRadioButton.AutoSize = true;
            this.transferRegionNationalRadioButton.Location = new System.Drawing.Point(8, 68);
            this.transferRegionNationalRadioButton.Name = "transferRegionNationalRadioButton";
            this.transferRegionNationalRadioButton.Size = new System.Drawing.Size(148, 24);
            this.transferRegionNationalRadioButton.TabIndex = 12;
            this.transferRegionNationalRadioButton.TabStop = true;
            this.transferRegionNationalRadioButton.Text = "Transfer Region";
            this.transferRegionNationalRadioButton.UseVisualStyleBackColor = true;
            // 
            // createNewCountryButton
            // 
            this.createNewCountryButton.Location = new System.Drawing.Point(8, 98);
            this.createNewCountryButton.Name = "createNewCountryButton";
            this.createNewCountryButton.Size = new System.Drawing.Size(203, 53);
            this.createNewCountryButton.TabIndex = 27;
            this.createNewCountryButton.Text = "Creat New Country";
            this.createNewCountryButton.UseVisualStyleBackColor = true;
            // 
            // textBoxCurrentlySelectedMapArea
            // 
            this.textBoxCurrentlySelectedMapArea.Enabled = false;
            this.textBoxCurrentlySelectedMapArea.Location = new System.Drawing.Point(12, 46);
            this.textBoxCurrentlySelectedMapArea.Name = "textBoxCurrentlySelectedMapArea";
            this.textBoxCurrentlySelectedMapArea.ReadOnly = true;
            this.textBoxCurrentlySelectedMapArea.Size = new System.Drawing.Size(309, 26);
            this.textBoxCurrentlySelectedMapArea.TabIndex = 5;
            this.textBoxCurrentlySelectedMapArea.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EditStateRegioon
            // 
            this.EditStateRegioon.Location = new System.Drawing.Point(11, 112);
            this.EditStateRegioon.Name = "EditStateRegioon";
            this.EditStateRegioon.Size = new System.Drawing.Size(87, 46);
            this.EditStateRegioon.TabIndex = 2;
            this.EditStateRegioon.Text = "Edit";
            this.EditStateRegioon.UseVisualStyleBackColor = true;
            this.EditStateRegioon.Click += new System.EventHandler(this.EditStateRegioon_Click);
            // 
            // itemComboBox
            // 
            this.itemComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.itemComboBox.FormattingEnabled = true;
            this.itemComboBox.Location = new System.Drawing.Point(11, 78);
            this.itemComboBox.MinimumSize = new System.Drawing.Size(100, 0);
            this.itemComboBox.Name = "itemComboBox";
            this.itemComboBox.Size = new System.Drawing.Size(310, 28);
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
            this.categoryComboBox.Location = new System.Drawing.Point(12, 12);
            this.categoryComboBox.MinimumSize = new System.Drawing.Size(100, 0);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(310, 28);
            this.categoryComboBox.TabIndex = 0;
            this.categoryComboBox.SelectedIndexChanged += new System.EventHandler(this.CategoryComboBox_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(2299, 1395);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // cityHubNameTextBox
            // 
            this.cityHubNameTextBox.Location = new System.Drawing.Point(199, 100);
            this.cityHubNameTextBox.Name = "cityHubNameTextBox";
            this.cityHubNameTextBox.Size = new System.Drawing.Size(107, 26);
            this.cityHubNameTextBox.TabIndex = 21;
            // 
            // portHubNameTextBox
            // 
            this.portHubNameTextBox.Location = new System.Drawing.Point(199, 146);
            this.portHubNameTextBox.Name = "portHubNameTextBox";
            this.portHubNameTextBox.Size = new System.Drawing.Size(107, 26);
            this.portHubNameTextBox.TabIndex = 21;
            // 
            // woodHubNameTextBox
            // 
            this.woodHubNameTextBox.Location = new System.Drawing.Point(199, 192);
            this.woodHubNameTextBox.Name = "woodHubNameTextBox";
            this.woodHubNameTextBox.Size = new System.Drawing.Size(107, 26);
            this.woodHubNameTextBox.TabIndex = 21;
            // 
            // mineHubNameTextBox
            // 
            this.mineHubNameTextBox.Location = new System.Drawing.Point(199, 235);
            this.mineHubNameTextBox.Name = "mineHubNameTextBox";
            this.mineHubNameTextBox.Size = new System.Drawing.Size(107, 26);
            this.mineHubNameTextBox.TabIndex = 21;
            // 
            // farmHubNameTextBox
            // 
            this.farmHubNameTextBox.Location = new System.Drawing.Point(199, 279);
            this.farmHubNameTextBox.Name = "farmHubNameTextBox";
            this.farmHubNameTextBox.Size = new System.Drawing.Size(107, 26);
            this.farmHubNameTextBox.TabIndex = 21;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2638, 1395);
            this.Controls.Add(this.splitContainerControls_Image);
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

