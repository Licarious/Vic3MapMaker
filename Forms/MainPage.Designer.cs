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
            this.sideControleTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.regionPannel = new System.Windows.Forms.FlowLayoutPanel();
            this.transferStateRadioButton = new System.Windows.Forms.RadioButton();
            this.ChangeCapitalRadioButton = new System.Windows.Forms.RadioButton();
            this.regionCapitalTextBox = new System.Windows.Forms.TextBox();
            this.createNewRegionButton = new System.Windows.Forms.Button();
            this.undoButton = new System.Windows.Forms.Button();
            this.nationalPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.transferProvinceNationalRadioButton = new System.Windows.Forms.RadioButton();
            this.transferStateNationalRadioButton = new System.Windows.Forms.RadioButton();
            this.transferRegionNationalRadioButton = new System.Windows.Forms.RadioButton();
            this.createNewCountryButton = new System.Windows.Forms.Button();
            this.itemComboBox = new System.Windows.Forms.ComboBox();
            this.textBoxCurrentlySelectedMapArea = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.EditStateRegioon = new System.Windows.Forms.Button();
            this.refreshMapButton = new System.Windows.Forms.Button();
            this.statePanel = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.transferProvinceRadioButton = new System.Windows.Forms.RadioButton();
            this.navalExitRadioButton = new System.Windows.Forms.RadioButton();
            this.hubCityUpdateRadioButton = new System.Windows.Forms.RadioButton();
            this.hubPortUpdateRadioButton = new System.Windows.Forms.RadioButton();
            this.hubWoodUpdateRadioButton = new System.Windows.Forms.RadioButton();
            this.hubMineUpdateRadioButton = new System.Windows.Forms.RadioButton();
            this.hubFarmUpdateRadioButton = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.saveHubNamesButton = new System.Windows.Forms.Button();
            this.stateNavalExitTextBox = new System.Windows.Forms.TextBox();
            this.farmHubNameTextBox = new System.Windows.Forms.TextBox();
            this.hubCityTextBox = new System.Windows.Forms.TextBox();
            this.mineHubNameTextBox = new System.Windows.Forms.TextBox();
            this.hubPortTextBox = new System.Windows.Forms.TextBox();
            this.woodHubNameTextBox = new System.Windows.Forms.TextBox();
            this.hubWoodTextBox = new System.Windows.Forms.TextBox();
            this.portHubNameTextBox = new System.Windows.Forms.TextBox();
            this.hubMineTextBox = new System.Windows.Forms.TextBox();
            this.cityHubNameTextBox = new System.Windows.Forms.TextBox();
            this.hubFarmTextBox = new System.Windows.Forms.TextBox();
            this.clearUpdateHubButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControls_Image)).BeginInit();
            this.splitContainerControls_Image.Panel1.SuspendLayout();
            this.splitContainerControls_Image.Panel2.SuspendLayout();
            this.splitContainerControls_Image.SuspendLayout();
            this.sideControleTableLayoutPanel.SuspendLayout();
            this.regionPannel.SuspendLayout();
            this.nationalPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statePanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
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
            this.splitContainerControls_Image.Panel1.Controls.Add(this.sideControleTableLayoutPanel);
            // 
            // splitContainerControls_Image.Panel2
            // 
            this.splitContainerControls_Image.Panel2.AutoScroll = true;
            this.splitContainerControls_Image.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainerControls_Image.Size = new System.Drawing.Size(1924, 1183);
            this.splitContainerControls_Image.SplitterDistance = 387;
            this.splitContainerControls_Image.TabIndex = 0;
            // 
            // sideControleTableLayoutPanel
            // 
            this.sideControleTableLayoutPanel.AutoSize = true;
            this.sideControleTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sideControleTableLayoutPanel.ColumnCount = 1;
            this.sideControleTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.sideControleTableLayoutPanel.Controls.Add(this.categoryComboBox, 0, 0);
            this.sideControleTableLayoutPanel.Controls.Add(this.regionPannel, 0, 5);
            this.sideControleTableLayoutPanel.Controls.Add(this.undoButton, 0, 7);
            this.sideControleTableLayoutPanel.Controls.Add(this.nationalPanel, 0, 6);
            this.sideControleTableLayoutPanel.Controls.Add(this.itemComboBox, 0, 2);
            this.sideControleTableLayoutPanel.Controls.Add(this.textBoxCurrentlySelectedMapArea, 0, 1);
            this.sideControleTableLayoutPanel.Controls.Add(this.buttonSave, 0, 8);
            this.sideControleTableLayoutPanel.Controls.Add(this.panel1, 0, 3);
            this.sideControleTableLayoutPanel.Controls.Add(this.statePanel, 0, 4);
            this.sideControleTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.sideControleTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.sideControleTableLayoutPanel.Name = "sideControleTableLayoutPanel";
            this.sideControleTableLayoutPanel.RowCount = 9;
            this.sideControleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.sideControleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.sideControleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.sideControleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.sideControleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.sideControleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.sideControleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.sideControleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.sideControleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.sideControleTableLayoutPanel.Size = new System.Drawing.Size(387, 1006);
            this.sideControleTableLayoutPanel.TabIndex = 101;
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.categoryComboBox.Location = new System.Drawing.Point(3, 3);
            this.categoryComboBox.MinimumSize = new System.Drawing.Size(30, 0);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(381, 28);
            this.categoryComboBox.TabIndex = 0;
            this.categoryComboBox.SelectedIndexChanged += new System.EventHandler(this.CategoryComboBox_SelectedIndexChanged);
            // 
            // regionPannel
            // 
            this.regionPannel.AutoSize = true;
            this.regionPannel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.regionPannel.Controls.Add(this.transferStateRadioButton);
            this.regionPannel.Controls.Add(this.ChangeCapitalRadioButton);
            this.regionPannel.Controls.Add(this.regionCapitalTextBox);
            this.regionPannel.Controls.Add(this.createNewRegionButton);
            this.regionPannel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.regionPannel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.regionPannel.Location = new System.Drawing.Point(3, 558);
            this.regionPannel.Name = "regionPannel";
            this.regionPannel.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.regionPannel.Size = new System.Drawing.Size(381, 169);
            this.regionPannel.TabIndex = 99;
            // 
            // transferStateRadioButton
            // 
            this.transferStateRadioButton.AutoSize = true;
            this.transferStateRadioButton.Location = new System.Drawing.Point(7, 8);
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
            this.ChangeCapitalRadioButton.Location = new System.Drawing.Point(7, 38);
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
            this.regionCapitalTextBox.Location = new System.Drawing.Point(7, 68);
            this.regionCapitalTextBox.Name = "regionCapitalTextBox";
            this.regionCapitalTextBox.ReadOnly = true;
            this.regionCapitalTextBox.Size = new System.Drawing.Size(114, 26);
            this.regionCapitalTextBox.TabIndex = 25;
            // 
            // createNewRegionButton
            // 
            this.createNewRegionButton.Location = new System.Drawing.Point(7, 100);
            this.createNewRegionButton.Name = "createNewRegionButton";
            this.createNewRegionButton.Size = new System.Drawing.Size(136, 52);
            this.createNewRegionButton.TabIndex = 26;
            this.createNewRegionButton.Text = "Creat New Region";
            this.createNewRegionButton.UseVisualStyleBackColor = true;
            this.createNewRegionButton.Click += new System.EventHandler(this.CreateNewRegionButton_Click);
            // 
            // undoButton
            // 
            this.undoButton.Location = new System.Drawing.Point(3, 908);
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(87, 44);
            this.undoButton.TabIndex = 20;
            this.undoButton.Text = "Undo";
            this.undoButton.UseVisualStyleBackColor = true;
            this.undoButton.Click += new System.EventHandler(this.UndoButton_Click);
            // 
            // nationalPanel
            // 
            this.nationalPanel.AutoSize = true;
            this.nationalPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.nationalPanel.Controls.Add(this.transferProvinceNationalRadioButton);
            this.nationalPanel.Controls.Add(this.transferStateNationalRadioButton);
            this.nationalPanel.Controls.Add(this.transferRegionNationalRadioButton);
            this.nationalPanel.Controls.Add(this.createNewCountryButton);
            this.nationalPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nationalPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.nationalPanel.Location = new System.Drawing.Point(3, 733);
            this.nationalPanel.Name = "nationalPanel";
            this.nationalPanel.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nationalPanel.Size = new System.Drawing.Size(381, 169);
            this.nationalPanel.TabIndex = 100;
            // 
            // transferProvinceNationalRadioButton
            // 
            this.transferProvinceNationalRadioButton.AutoSize = true;
            this.transferProvinceNationalRadioButton.Location = new System.Drawing.Point(7, 8);
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
            this.transferStateNationalRadioButton.Location = new System.Drawing.Point(7, 38);
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
            this.transferRegionNationalRadioButton.Location = new System.Drawing.Point(7, 68);
            this.transferRegionNationalRadioButton.Name = "transferRegionNationalRadioButton";
            this.transferRegionNationalRadioButton.Size = new System.Drawing.Size(148, 24);
            this.transferRegionNationalRadioButton.TabIndex = 12;
            this.transferRegionNationalRadioButton.TabStop = true;
            this.transferRegionNationalRadioButton.Text = "Transfer Region";
            this.transferRegionNationalRadioButton.UseVisualStyleBackColor = true;
            // 
            // createNewCountryButton
            // 
            this.createNewCountryButton.Location = new System.Drawing.Point(7, 98);
            this.createNewCountryButton.Name = "createNewCountryButton";
            this.createNewCountryButton.Size = new System.Drawing.Size(157, 52);
            this.createNewCountryButton.TabIndex = 27;
            this.createNewCountryButton.Text = "Creat New Country";
            this.createNewCountryButton.UseVisualStyleBackColor = true;
            this.createNewCountryButton.Click += new System.EventHandler(this.CreateNewCountryButton_Click);
            // 
            // itemComboBox
            // 
            this.itemComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.itemComboBox.FormattingEnabled = true;
            this.itemComboBox.Location = new System.Drawing.Point(3, 73);
            this.itemComboBox.MinimumSize = new System.Drawing.Size(30, 0);
            this.itemComboBox.Name = "itemComboBox";
            this.itemComboBox.Size = new System.Drawing.Size(381, 28);
            this.itemComboBox.TabIndex = 1;
            this.itemComboBox.SelectedIndexChanged += new System.EventHandler(this.ItemComboBox_SelectedIndexChanged);
            // 
            // textBoxCurrentlySelectedMapArea
            // 
            this.textBoxCurrentlySelectedMapArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxCurrentlySelectedMapArea.Enabled = false;
            this.textBoxCurrentlySelectedMapArea.Location = new System.Drawing.Point(3, 38);
            this.textBoxCurrentlySelectedMapArea.Name = "textBoxCurrentlySelectedMapArea";
            this.textBoxCurrentlySelectedMapArea.ReadOnly = true;
            this.textBoxCurrentlySelectedMapArea.Size = new System.Drawing.Size(381, 26);
            this.textBoxCurrentlySelectedMapArea.TabIndex = 5;
            this.textBoxCurrentlySelectedMapArea.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(3, 958);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.buttonSave.Size = new System.Drawing.Size(87, 45);
            this.buttonSave.TabIndex = 22;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.EditStateRegioon);
            this.panel1.Controls.Add(this.refreshMapButton);
            this.panel1.Location = new System.Drawing.Point(3, 108);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(381, 44);
            this.panel1.TabIndex = 6;
            // 
            // EditStateRegioon
            // 
            this.EditStateRegioon.Dock = System.Windows.Forms.DockStyle.Left;
            this.EditStateRegioon.Location = new System.Drawing.Point(0, 0);
            this.EditStateRegioon.Name = "EditStateRegioon";
            this.EditStateRegioon.Size = new System.Drawing.Size(87, 44);
            this.EditStateRegioon.TabIndex = 2;
            this.EditStateRegioon.Text = "Edit";
            this.EditStateRegioon.UseVisualStyleBackColor = true;
            this.EditStateRegioon.Click += new System.EventHandler(this.EditStateRegioon_Click);
            // 
            // refreshMapButton
            // 
            this.refreshMapButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.refreshMapButton.Location = new System.Drawing.Point(294, 0);
            this.refreshMapButton.Name = "refreshMapButton";
            this.refreshMapButton.Size = new System.Drawing.Size(87, 44);
            this.refreshMapButton.TabIndex = 100;
            this.refreshMapButton.Text = "Refresh";
            this.refreshMapButton.UseVisualStyleBackColor = true;
            this.refreshMapButton.Click += new System.EventHandler(this.RefreshMapButton_Click);
            // 
            // statePanel
            // 
            this.statePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statePanel.AutoSize = true;
            this.statePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.statePanel.ColumnCount = 2;
            this.statePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.06452F));
            this.statePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.93548F));
            this.statePanel.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.statePanel.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.statePanel.Location = new System.Drawing.Point(3, 158);
            this.statePanel.Name = "statePanel";
            this.statePanel.RowCount = 1;
            this.statePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.statePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 394F));
            this.statePanel.Size = new System.Drawing.Size(381, 394);
            this.statePanel.TabIndex = 8;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.transferProvinceRadioButton);
            this.flowLayoutPanel1.Controls.Add(this.navalExitRadioButton);
            this.flowLayoutPanel1.Controls.Add(this.hubCityUpdateRadioButton);
            this.flowLayoutPanel1.Controls.Add(this.hubPortUpdateRadioButton);
            this.flowLayoutPanel1.Controls.Add(this.hubWoodUpdateRadioButton);
            this.flowLayoutPanel1.Controls.Add(this.hubMineUpdateRadioButton);
            this.flowLayoutPanel1.Controls.Add(this.hubFarmUpdateRadioButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(139, 388);
            this.flowLayoutPanel1.TabIndex = 102;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // transferProvinceRadioButton
            // 
            this.transferProvinceRadioButton.AutoSize = true;
            this.transferProvinceRadioButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.transferProvinceRadioButton.Location = new System.Drawing.Point(3, 3);
            this.transferProvinceRadioButton.Name = "transferProvinceRadioButton";
            this.transferProvinceRadioButton.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.transferProvinceRadioButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.transferProvinceRadioButton.Size = new System.Drawing.Size(107, 54);
            this.transferProvinceRadioButton.TabIndex = 3;
            this.transferProvinceRadioButton.Text = "Move Prov";
            this.transferProvinceRadioButton.UseVisualStyleBackColor = true;
            // 
            // navalExitRadioButton
            // 
            this.navalExitRadioButton.AutoSize = true;
            this.navalExitRadioButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.navalExitRadioButton.Location = new System.Drawing.Point(3, 63);
            this.navalExitRadioButton.Name = "navalExitRadioButton";
            this.navalExitRadioButton.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.navalExitRadioButton.Size = new System.Drawing.Size(107, 54);
            this.navalExitRadioButton.TabIndex = 4;
            this.navalExitRadioButton.Text = "Naval Exit";
            this.navalExitRadioButton.UseVisualStyleBackColor = true;
            // 
            // hubCityUpdateRadioButton
            // 
            this.hubCityUpdateRadioButton.AutoSize = true;
            this.hubCityUpdateRadioButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.hubCityUpdateRadioButton.Location = new System.Drawing.Point(3, 123);
            this.hubCityUpdateRadioButton.Name = "hubCityUpdateRadioButton";
            this.hubCityUpdateRadioButton.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.hubCityUpdateRadioButton.Size = new System.Drawing.Size(107, 54);
            this.hubCityUpdateRadioButton.TabIndex = 5;
            this.hubCityUpdateRadioButton.Text = "City";
            this.hubCityUpdateRadioButton.UseVisualStyleBackColor = true;
            // 
            // hubPortUpdateRadioButton
            // 
            this.hubPortUpdateRadioButton.AutoSize = true;
            this.hubPortUpdateRadioButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.hubPortUpdateRadioButton.Location = new System.Drawing.Point(3, 183);
            this.hubPortUpdateRadioButton.Name = "hubPortUpdateRadioButton";
            this.hubPortUpdateRadioButton.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.hubPortUpdateRadioButton.Size = new System.Drawing.Size(107, 54);
            this.hubPortUpdateRadioButton.TabIndex = 6;
            this.hubPortUpdateRadioButton.Text = "Port";
            this.hubPortUpdateRadioButton.UseVisualStyleBackColor = true;
            // 
            // hubWoodUpdateRadioButton
            // 
            this.hubWoodUpdateRadioButton.AutoSize = true;
            this.hubWoodUpdateRadioButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.hubWoodUpdateRadioButton.Location = new System.Drawing.Point(3, 243);
            this.hubWoodUpdateRadioButton.Name = "hubWoodUpdateRadioButton";
            this.hubWoodUpdateRadioButton.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.hubWoodUpdateRadioButton.Size = new System.Drawing.Size(107, 54);
            this.hubWoodUpdateRadioButton.TabIndex = 7;
            this.hubWoodUpdateRadioButton.Text = "Wood";
            this.hubWoodUpdateRadioButton.UseVisualStyleBackColor = true;
            // 
            // hubMineUpdateRadioButton
            // 
            this.hubMineUpdateRadioButton.AutoSize = true;
            this.hubMineUpdateRadioButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.hubMineUpdateRadioButton.Location = new System.Drawing.Point(3, 303);
            this.hubMineUpdateRadioButton.Name = "hubMineUpdateRadioButton";
            this.hubMineUpdateRadioButton.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.hubMineUpdateRadioButton.Size = new System.Drawing.Size(107, 54);
            this.hubMineUpdateRadioButton.TabIndex = 8;
            this.hubMineUpdateRadioButton.Text = "Mine";
            this.hubMineUpdateRadioButton.UseVisualStyleBackColor = true;
            // 
            // hubFarmUpdateRadioButton
            // 
            this.hubFarmUpdateRadioButton.AutoSize = true;
            this.hubFarmUpdateRadioButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.hubFarmUpdateRadioButton.Location = new System.Drawing.Point(3, 363);
            this.hubFarmUpdateRadioButton.Name = "hubFarmUpdateRadioButton";
            this.hubFarmUpdateRadioButton.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.hubFarmUpdateRadioButton.Size = new System.Drawing.Size(107, 54);
            this.hubFarmUpdateRadioButton.TabIndex = 9;
            this.hubFarmUpdateRadioButton.Text = "Farm";
            this.hubFarmUpdateRadioButton.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel2.Controls.Add(this.saveHubNamesButton, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.stateNavalExitTextBox, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.farmHubNameTextBox, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.hubCityTextBox, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.mineHubNameTextBox, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.hubPortTextBox, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.woodHubNameTextBox, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.hubWoodTextBox, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.portHubNameTextBox, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.hubMineTextBox, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.cityHubNameTextBox, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.hubFarmTextBox, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.clearUpdateHubButton, 0, 7);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(148, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 8;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(230, 388);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // saveHubNamesButton
            // 
            this.saveHubNamesButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saveHubNamesButton.Location = new System.Drawing.Point(106, 428);
            this.saveHubNamesButton.Name = "saveHubNamesButton";
            this.saveHubNamesButton.Size = new System.Drawing.Size(121, 57);
            this.saveHubNamesButton.TabIndex = 100;
            this.saveHubNamesButton.Text = "Save Hub Names";
            this.saveHubNamesButton.UseVisualStyleBackColor = true;
            this.saveHubNamesButton.Click += new System.EventHandler(this.SaveHubNamesButton_Click);
            // 
            // stateNavalExitTextBox
            // 
            this.stateNavalExitTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stateNavalExitTextBox.Enabled = false;
            this.stateNavalExitTextBox.Location = new System.Drawing.Point(3, 78);
            this.stateNavalExitTextBox.Name = "stateNavalExitTextBox";
            this.stateNavalExitTextBox.ReadOnly = true;
            this.stateNavalExitTextBox.Size = new System.Drawing.Size(97, 26);
            this.stateNavalExitTextBox.TabIndex = 8;
            // 
            // farmHubNameTextBox
            // 
            this.farmHubNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.farmHubNameTextBox.Location = new System.Drawing.Point(106, 378);
            this.farmHubNameTextBox.Name = "farmHubNameTextBox";
            this.farmHubNameTextBox.Size = new System.Drawing.Size(121, 26);
            this.farmHubNameTextBox.TabIndex = 21;
            // 
            // hubCityTextBox
            // 
            this.hubCityTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hubCityTextBox.Enabled = false;
            this.hubCityTextBox.Location = new System.Drawing.Point(3, 138);
            this.hubCityTextBox.Name = "hubCityTextBox";
            this.hubCityTextBox.ReadOnly = true;
            this.hubCityTextBox.Size = new System.Drawing.Size(97, 26);
            this.hubCityTextBox.TabIndex = 14;
            // 
            // mineHubNameTextBox
            // 
            this.mineHubNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mineHubNameTextBox.Location = new System.Drawing.Point(106, 318);
            this.mineHubNameTextBox.Name = "mineHubNameTextBox";
            this.mineHubNameTextBox.Size = new System.Drawing.Size(121, 26);
            this.mineHubNameTextBox.TabIndex = 21;
            // 
            // hubPortTextBox
            // 
            this.hubPortTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hubPortTextBox.Enabled = false;
            this.hubPortTextBox.Location = new System.Drawing.Point(3, 198);
            this.hubPortTextBox.Name = "hubPortTextBox";
            this.hubPortTextBox.ReadOnly = true;
            this.hubPortTextBox.Size = new System.Drawing.Size(97, 26);
            this.hubPortTextBox.TabIndex = 15;
            // 
            // woodHubNameTextBox
            // 
            this.woodHubNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.woodHubNameTextBox.Location = new System.Drawing.Point(106, 258);
            this.woodHubNameTextBox.Name = "woodHubNameTextBox";
            this.woodHubNameTextBox.Size = new System.Drawing.Size(121, 26);
            this.woodHubNameTextBox.TabIndex = 21;
            // 
            // hubWoodTextBox
            // 
            this.hubWoodTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hubWoodTextBox.Enabled = false;
            this.hubWoodTextBox.Location = new System.Drawing.Point(3, 258);
            this.hubWoodTextBox.Name = "hubWoodTextBox";
            this.hubWoodTextBox.ReadOnly = true;
            this.hubWoodTextBox.Size = new System.Drawing.Size(97, 26);
            this.hubWoodTextBox.TabIndex = 16;
            // 
            // portHubNameTextBox
            // 
            this.portHubNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.portHubNameTextBox.Location = new System.Drawing.Point(106, 198);
            this.portHubNameTextBox.Name = "portHubNameTextBox";
            this.portHubNameTextBox.Size = new System.Drawing.Size(121, 26);
            this.portHubNameTextBox.TabIndex = 21;
            // 
            // hubMineTextBox
            // 
            this.hubMineTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hubMineTextBox.Enabled = false;
            this.hubMineTextBox.Location = new System.Drawing.Point(3, 318);
            this.hubMineTextBox.Name = "hubMineTextBox";
            this.hubMineTextBox.ReadOnly = true;
            this.hubMineTextBox.Size = new System.Drawing.Size(97, 26);
            this.hubMineTextBox.TabIndex = 17;
            // 
            // cityHubNameTextBox
            // 
            this.cityHubNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cityHubNameTextBox.Location = new System.Drawing.Point(106, 138);
            this.cityHubNameTextBox.Name = "cityHubNameTextBox";
            this.cityHubNameTextBox.Size = new System.Drawing.Size(121, 26);
            this.cityHubNameTextBox.TabIndex = 21;
            // 
            // hubFarmTextBox
            // 
            this.hubFarmTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hubFarmTextBox.Enabled = false;
            this.hubFarmTextBox.Location = new System.Drawing.Point(3, 378);
            this.hubFarmTextBox.Name = "hubFarmTextBox";
            this.hubFarmTextBox.ReadOnly = true;
            this.hubFarmTextBox.Size = new System.Drawing.Size(97, 26);
            this.hubFarmTextBox.TabIndex = 18;
            // 
            // clearUpdateHubButton
            // 
            this.clearUpdateHubButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clearUpdateHubButton.Location = new System.Drawing.Point(3, 428);
            this.clearUpdateHubButton.Name = "clearUpdateHubButton";
            this.clearUpdateHubButton.Size = new System.Drawing.Size(97, 57);
            this.clearUpdateHubButton.TabIndex = 20;
            this.clearUpdateHubButton.Text = "Clear Selected";
            this.clearUpdateHubButton.UseVisualStyleBackColor = true;
            this.clearUpdateHubButton.Click += new System.EventHandler(this.ClearUpdateHubButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(2300, 1395);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1183);
            this.Controls.Add(this.splitContainerControls_Image);
            this.Name = "MainPage";
            this.Text = "MainPage";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainerControls_Image.Panel1.ResumeLayout(false);
            this.splitContainerControls_Image.Panel1.PerformLayout();
            this.splitContainerControls_Image.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControls_Image)).EndInit();
            this.splitContainerControls_Image.ResumeLayout(false);
            this.sideControleTableLayoutPanel.ResumeLayout(false);
            this.sideControleTableLayoutPanel.PerformLayout();
            this.regionPannel.ResumeLayout(false);
            this.regionPannel.PerformLayout();
            this.nationalPanel.ResumeLayout(false);
            this.nationalPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.statePanel.ResumeLayout(false);
            this.statePanel.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
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
        private Button saveHubNamesButton;
        private TableLayoutPanel sideControleTableLayoutPanel;
        private Panel panel1;
        private TableLayoutPanel statePanel;
        private TableLayoutPanel tableLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}

