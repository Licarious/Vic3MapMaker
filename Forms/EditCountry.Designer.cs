namespace Vic3MapMaker.Forms
{
    partial class EditCountry
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
            this.tagTB = new System.Windows.Forms.TextBox();
            this.nameTB = new System.Windows.Forms.TextBox();
            this.tagTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.subStateComboBox = new System.Windows.Forms.ComboBox();
            this.popDataGridView = new System.Windows.Forms.DataGridView();
            this.newPopButton = new System.Windows.Forms.Button();
            this.editPopButton = new System.Windows.Forms.Button();
            this.stateTypeComboBox = new System.Windows.Forms.ComboBox();
            this.deletePopButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.tierComboBox = new System.Windows.Forms.ComboBox();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.colorButton = new System.Windows.Forms.Button();
            this.nationCultureListBox = new System.Windows.Forms.ListBox();
            this.allCulturesListBox = new System.Windows.Forms.ListBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.addCultureButton = new System.Windows.Forms.Button();
            this.removeCultureButton = new System.Windows.Forms.Button();
            this.cultureSearchTextBox = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.capitalComboBox = new System.Windows.Forms.ComboBox();
            this.namedFromCapitalCheckBox = new System.Windows.Forms.CheckBox();
            this.adjTextBox = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.literacyComboBox = new System.Windows.Forms.ComboBox();
            this.wealthComboBox = new System.Windows.Forms.ComboBox();
            this.tradeRouteDataGridView = new System.Windows.Forms.DataGridView();
            this.deleteRouteButton = new System.Windows.Forms.Button();
            this.editRouteButton = new System.Windows.Forms.Button();
            this.newRouteButton = new System.Windows.Forms.Button();
            this.buildingDataGridView = new System.Windows.Forms.DataGridView();
            this.deleteBuildingButton = new System.Windows.Forms.Button();
            this.editBuildngButton = new System.Windows.Forms.Button();
            this.newBuildingButton = new System.Windows.Forms.Button();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.religionComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.popDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tradeRouteDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buildingDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tagTB
            // 
            this.tagTB.Enabled = false;
            this.tagTB.Location = new System.Drawing.Point(20, 20);
            this.tagTB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tagTB.Name = "tagTB";
            this.tagTB.ReadOnly = true;
            this.tagTB.Size = new System.Drawing.Size(92, 26);
            this.tagTB.TabIndex = 0;
            this.tagTB.Text = "Tag:";
            // 
            // nameTB
            // 
            this.nameTB.Enabled = false;
            this.nameTB.Location = new System.Drawing.Point(20, 60);
            this.nameTB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nameTB.Name = "nameTB";
            this.nameTB.ReadOnly = true;
            this.nameTB.Size = new System.Drawing.Size(92, 26);
            this.nameTB.TabIndex = 0;
            this.nameTB.Text = "Name:";
            // 
            // tagTextBox
            // 
            this.tagTextBox.Location = new System.Drawing.Point(120, 18);
            this.tagTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tagTextBox.Name = "tagTextBox";
            this.tagTextBox.Size = new System.Drawing.Size(200, 26);
            this.tagTextBox.TabIndex = 1;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(120, 60);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(200, 26);
            this.nameTextBox.TabIndex = 1;
            // 
            // subStateComboBox
            // 
            this.subStateComboBox.FormattingEnabled = true;
            this.subStateComboBox.Location = new System.Drawing.Point(120, 132);
            this.subStateComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.subStateComboBox.Name = "subStateComboBox";
            this.subStateComboBox.Size = new System.Drawing.Size(200, 28);
            this.subStateComboBox.TabIndex = 2;
            this.subStateComboBox.SelectedIndexChanged += new System.EventHandler(this.SubStateComboBox_SelectedIndexChanged);
            // 
            // popDataGridView
            // 
            this.popDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.popDataGridView.Location = new System.Drawing.Point(20, 208);
            this.popDataGridView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.popDataGridView.Name = "popDataGridView";
            this.popDataGridView.RowHeadersWidth = 62;
            this.popDataGridView.Size = new System.Drawing.Size(604, 245);
            this.popDataGridView.TabIndex = 3;
            // 
            // newPopButton
            // 
            this.newPopButton.Location = new System.Drawing.Point(20, 463);
            this.newPopButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.newPopButton.Name = "newPopButton";
            this.newPopButton.Size = new System.Drawing.Size(112, 35);
            this.newPopButton.TabIndex = 4;
            this.newPopButton.Text = "New Pop";
            this.newPopButton.UseVisualStyleBackColor = true;
            this.newPopButton.Click += new System.EventHandler(this.NewPopButton_Click);
            // 
            // editPopButton
            // 
            this.editPopButton.Location = new System.Drawing.Point(142, 463);
            this.editPopButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.editPopButton.Name = "editPopButton";
            this.editPopButton.Size = new System.Drawing.Size(112, 35);
            this.editPopButton.TabIndex = 5;
            this.editPopButton.Text = "Edit Pop";
            this.editPopButton.UseVisualStyleBackColor = true;
            this.editPopButton.Click += new System.EventHandler(this.EditPopButton_Click);
            // 
            // stateTypeComboBox
            // 
            this.stateTypeComboBox.FormattingEnabled = true;
            this.stateTypeComboBox.Location = new System.Drawing.Point(120, 170);
            this.stateTypeComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.stateTypeComboBox.Name = "stateTypeComboBox";
            this.stateTypeComboBox.Size = new System.Drawing.Size(200, 28);
            this.stateTypeComboBox.TabIndex = 6;
            this.stateTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.StateTypeComboBox_SelectedIndexChanged);
            // 
            // deletePopButton
            // 
            this.deletePopButton.Location = new System.Drawing.Point(262, 463);
            this.deletePopButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deletePopButton.Name = "deletePopButton";
            this.deletePopButton.Size = new System.Drawing.Size(112, 35);
            this.deletePopButton.TabIndex = 7;
            this.deletePopButton.Text = "Delete Pop";
            this.deletePopButton.UseVisualStyleBackColor = true;
            this.deletePopButton.Click += new System.EventHandler(this.DeletePopButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(1260, 827);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 40);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(1368, 827);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 40);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // tierComboBox
            // 
            this.tierComboBox.FormattingEnabled = true;
            this.tierComboBox.Location = new System.Drawing.Point(428, 134);
            this.tierComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tierComboBox.Name = "tierComboBox";
            this.tierComboBox.Size = new System.Drawing.Size(196, 28);
            this.tierComboBox.TabIndex = 10;
            // 
            // typeComboBox
            // 
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Location = new System.Drawing.Point(428, 170);
            this.typeComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(196, 28);
            this.typeComboBox.TabIndex = 11;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(20, 134);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(92, 26);
            this.textBox1.TabIndex = 12;
            this.textBox1.Text = "State:";
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(20, 172);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(92, 26);
            this.textBox2.TabIndex = 13;
            this.textBox2.Text = "State Type:";
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(328, 172);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(92, 26);
            this.textBox3.TabIndex = 14;
            this.textBox3.Text = "Type:";
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.Location = new System.Drawing.Point(328, 134);
            this.textBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(92, 26);
            this.textBox4.TabIndex = 15;
            this.textBox4.Text = "Tier:";
            // 
            // colorButton
            // 
            this.colorButton.Location = new System.Drawing.Point(874, 12);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(171, 59);
            this.colorButton.TabIndex = 16;
            this.colorButton.Text = "Color";
            this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.Click += new System.EventHandler(this.ColorButton_Click);
            // 
            // nationCultureListBox
            // 
            this.nationCultureListBox.FormattingEnabled = true;
            this.nationCultureListBox.ItemHeight = 20;
            this.nationCultureListBox.Location = new System.Drawing.Point(631, 170);
            this.nationCultureListBox.Name = "nationCultureListBox";
            this.nationCultureListBox.Size = new System.Drawing.Size(179, 284);
            this.nationCultureListBox.TabIndex = 17;
            // 
            // allCulturesListBox
            // 
            this.allCulturesListBox.FormattingEnabled = true;
            this.allCulturesListBox.ItemHeight = 20;
            this.allCulturesListBox.Location = new System.Drawing.Point(867, 165);
            this.allCulturesListBox.Name = "allCulturesListBox";
            this.allCulturesListBox.Size = new System.Drawing.Size(179, 284);
            this.allCulturesListBox.TabIndex = 18;
            // 
            // textBox5
            // 
            this.textBox5.Enabled = false;
            this.textBox5.Location = new System.Drawing.Point(631, 136);
            this.textBox5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(179, 26);
            this.textBox5.TabIndex = 19;
            this.textBox5.Text = "Accepted Cultures:";
            // 
            // textBox6
            // 
            this.textBox6.Enabled = false;
            this.textBox6.Location = new System.Drawing.Point(867, 131);
            this.textBox6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(179, 26);
            this.textBox6.TabIndex = 20;
            this.textBox6.Text = "All Cultures:";
            // 
            // addCultureButton
            // 
            this.addCultureButton.Location = new System.Drawing.Point(820, 276);
            this.addCultureButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addCultureButton.Name = "addCultureButton";
            this.addCultureButton.Size = new System.Drawing.Size(40, 38);
            this.addCultureButton.TabIndex = 21;
            this.addCultureButton.Text = "<";
            this.addCultureButton.UseVisualStyleBackColor = true;
            this.addCultureButton.Click += new System.EventHandler(this.AddCultureButton_Click);
            // 
            // removeCultureButton
            // 
            this.removeCultureButton.Location = new System.Drawing.Point(820, 324);
            this.removeCultureButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.removeCultureButton.Name = "removeCultureButton";
            this.removeCultureButton.Size = new System.Drawing.Size(40, 38);
            this.removeCultureButton.TabIndex = 22;
            this.removeCultureButton.Text = ">";
            this.removeCultureButton.UseVisualStyleBackColor = true;
            this.removeCultureButton.Click += new System.EventHandler(this.RemoveCultureButton_Click);
            // 
            // cultureSearchTextBox
            // 
            this.cultureSearchTextBox.Location = new System.Drawing.Point(867, 98);
            this.cultureSearchTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cultureSearchTextBox.Name = "cultureSearchTextBox";
            this.cultureSearchTextBox.Size = new System.Drawing.Size(179, 26);
            this.cultureSearchTextBox.TabIndex = 23;
            this.cultureSearchTextBox.TextChanged += new System.EventHandler(this.CultureSearchTextBox_TextChanged);
            // 
            // textBox7
            // 
            this.textBox7.Enabled = false;
            this.textBox7.Location = new System.Drawing.Point(328, 18);
            this.textBox7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(92, 26);
            this.textBox7.TabIndex = 15;
            this.textBox7.Text = "Capital:";
            // 
            // capitalComboBox
            // 
            this.capitalComboBox.FormattingEnabled = true;
            this.capitalComboBox.Location = new System.Drawing.Point(428, 16);
            this.capitalComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.capitalComboBox.Name = "capitalComboBox";
            this.capitalComboBox.Size = new System.Drawing.Size(196, 28);
            this.capitalComboBox.TabIndex = 10;
            // 
            // namedFromCapitalCheckBox
            // 
            this.namedFromCapitalCheckBox.AutoSize = true;
            this.namedFromCapitalCheckBox.Location = new System.Drawing.Point(631, 20);
            this.namedFromCapitalCheckBox.Name = "namedFromCapitalCheckBox";
            this.namedFromCapitalCheckBox.Size = new System.Drawing.Size(237, 24);
            this.namedFromCapitalCheckBox.TabIndex = 25;
            this.namedFromCapitalCheckBox.Text = "Country Named After Captial";
            this.namedFromCapitalCheckBox.UseVisualStyleBackColor = true;
            // 
            // adjTextBox
            // 
            this.adjTextBox.Location = new System.Drawing.Point(428, 60);
            this.adjTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.adjTextBox.Name = "adjTextBox";
            this.adjTextBox.Size = new System.Drawing.Size(196, 26);
            this.adjTextBox.TabIndex = 27;
            // 
            // textBox9
            // 
            this.textBox9.Enabled = false;
            this.textBox9.Location = new System.Drawing.Point(328, 60);
            this.textBox9.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(92, 26);
            this.textBox9.TabIndex = 26;
            this.textBox9.Text = "Adjective:";
            // 
            // textBox8
            // 
            this.textBox8.Enabled = false;
            this.textBox8.Location = new System.Drawing.Point(328, 98);
            this.textBox8.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(92, 26);
            this.textBox8.TabIndex = 31;
            this.textBox8.Text = "Literacy:";
            // 
            // textBox10
            // 
            this.textBox10.Enabled = false;
            this.textBox10.Location = new System.Drawing.Point(20, 98);
            this.textBox10.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(92, 26);
            this.textBox10.TabIndex = 30;
            this.textBox10.Text = "Wealth:";
            // 
            // literacyComboBox
            // 
            this.literacyComboBox.FormattingEnabled = true;
            this.literacyComboBox.Location = new System.Drawing.Point(428, 96);
            this.literacyComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.literacyComboBox.Name = "literacyComboBox";
            this.literacyComboBox.Size = new System.Drawing.Size(196, 28);
            this.literacyComboBox.TabIndex = 29;
            // 
            // wealthComboBox
            // 
            this.wealthComboBox.FormattingEnabled = true;
            this.wealthComboBox.Location = new System.Drawing.Point(120, 96);
            this.wealthComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.wealthComboBox.Name = "wealthComboBox";
            this.wealthComboBox.Size = new System.Drawing.Size(200, 28);
            this.wealthComboBox.TabIndex = 28;
            // 
            // tradeRouteDataGridView
            // 
            this.tradeRouteDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tradeRouteDataGridView.Location = new System.Drawing.Point(1053, 12);
            this.tradeRouteDataGridView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tradeRouteDataGridView.Name = "tradeRouteDataGridView";
            this.tradeRouteDataGridView.RowHeadersWidth = 62;
            this.tradeRouteDataGridView.Size = new System.Drawing.Size(415, 760);
            this.tradeRouteDataGridView.TabIndex = 32;
            // 
            // deleteRouteButton
            // 
            this.deleteRouteButton.Location = new System.Drawing.Point(1356, 782);
            this.deleteRouteButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deleteRouteButton.Name = "deleteRouteButton";
            this.deleteRouteButton.Size = new System.Drawing.Size(112, 35);
            this.deleteRouteButton.TabIndex = 35;
            this.deleteRouteButton.Text = "Delete Route";
            this.deleteRouteButton.UseVisualStyleBackColor = true;
            this.deleteRouteButton.Click += new System.EventHandler(this.DeleteRouteButton_Click);
            // 
            // editRouteButton
            // 
            this.editRouteButton.Location = new System.Drawing.Point(1236, 782);
            this.editRouteButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.editRouteButton.Name = "editRouteButton";
            this.editRouteButton.Size = new System.Drawing.Size(112, 35);
            this.editRouteButton.TabIndex = 34;
            this.editRouteButton.Text = "Edit Route";
            this.editRouteButton.UseVisualStyleBackColor = true;
            this.editRouteButton.Click += new System.EventHandler(this.EditRouteButton_Click);
            // 
            // newRouteButton
            // 
            this.newRouteButton.Location = new System.Drawing.Point(1114, 782);
            this.newRouteButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.newRouteButton.Name = "newRouteButton";
            this.newRouteButton.Size = new System.Drawing.Size(112, 35);
            this.newRouteButton.TabIndex = 33;
            this.newRouteButton.Text = "New Route";
            this.newRouteButton.UseVisualStyleBackColor = true;
            this.newRouteButton.Click += new System.EventHandler(this.NewRouteButton_Click);
            // 
            // buildingDataGridView
            // 
            this.buildingDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.buildingDataGridView.Location = new System.Drawing.Point(20, 508);
            this.buildingDataGridView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buildingDataGridView.Name = "buildingDataGridView";
            this.buildingDataGridView.RowHeadersWidth = 62;
            this.buildingDataGridView.Size = new System.Drawing.Size(1026, 309);
            this.buildingDataGridView.TabIndex = 36;
            // 
            // deleteBuildingButton
            // 
            this.deleteBuildingButton.Location = new System.Drawing.Point(262, 832);
            this.deleteBuildingButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deleteBuildingButton.Name = "deleteBuildingButton";
            this.deleteBuildingButton.Size = new System.Drawing.Size(126, 35);
            this.deleteBuildingButton.TabIndex = 39;
            this.deleteBuildingButton.Text = "Delete Building";
            this.deleteBuildingButton.UseVisualStyleBackColor = true;
            this.deleteBuildingButton.Click += new System.EventHandler(this.DeleteBuildingButton_Click);
            // 
            // editBuildngButton
            // 
            this.editBuildngButton.Location = new System.Drawing.Point(142, 832);
            this.editBuildngButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.editBuildngButton.Name = "editBuildngButton";
            this.editBuildngButton.Size = new System.Drawing.Size(112, 35);
            this.editBuildngButton.TabIndex = 38;
            this.editBuildngButton.Text = "Edit Building";
            this.editBuildngButton.UseVisualStyleBackColor = true;
            this.editBuildngButton.Click += new System.EventHandler(this.EditBuildngButton_Click);
            // 
            // newBuildingButton
            // 
            this.newBuildingButton.Location = new System.Drawing.Point(20, 832);
            this.newBuildingButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.newBuildingButton.Name = "newBuildingButton";
            this.newBuildingButton.Size = new System.Drawing.Size(112, 35);
            this.newBuildingButton.TabIndex = 37;
            this.newBuildingButton.Text = "New Building";
            this.newBuildingButton.UseVisualStyleBackColor = true;
            this.newBuildingButton.Click += new System.EventHandler(this.NewBuildingButton_Click);
            // 
            // textBox11
            // 
            this.textBox11.Enabled = false;
            this.textBox11.Location = new System.Drawing.Point(632, 60);
            this.textBox11.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(178, 26);
            this.textBox11.TabIndex = 40;
            this.textBox11.Text = "Religion:";
            // 
            // religionComboBox
            // 
            this.religionComboBox.FormattingEnabled = true;
            this.religionComboBox.Location = new System.Drawing.Point(631, 96);
            this.religionComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.religionComboBox.Name = "religionComboBox";
            this.religionComboBox.Size = new System.Drawing.Size(179, 28);
            this.religionComboBox.TabIndex = 41;
            // 
            // EditCountry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1493, 877);
            this.Controls.Add(this.religionComboBox);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.deleteBuildingButton);
            this.Controls.Add(this.editBuildngButton);
            this.Controls.Add(this.newBuildingButton);
            this.Controls.Add(this.buildingDataGridView);
            this.Controls.Add(this.deleteRouteButton);
            this.Controls.Add(this.editRouteButton);
            this.Controls.Add(this.newRouteButton);
            this.Controls.Add(this.tradeRouteDataGridView);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.literacyComboBox);
            this.Controls.Add(this.wealthComboBox);
            this.Controls.Add(this.adjTextBox);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.namedFromCapitalCheckBox);
            this.Controls.Add(this.cultureSearchTextBox);
            this.Controls.Add(this.removeCultureButton);
            this.Controls.Add(this.addCultureButton);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.allCulturesListBox);
            this.Controls.Add(this.nationCultureListBox);
            this.Controls.Add(this.colorButton);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.typeComboBox);
            this.Controls.Add(this.capitalComboBox);
            this.Controls.Add(this.tierComboBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.deletePopButton);
            this.Controls.Add(this.stateTypeComboBox);
            this.Controls.Add(this.editPopButton);
            this.Controls.Add(this.newPopButton);
            this.Controls.Add(this.popDataGridView);
            this.Controls.Add(this.subStateComboBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.tagTextBox);
            this.Controls.Add(this.nameTB);
            this.Controls.Add(this.tagTB);
            this.Name = "EditCountry";
            this.Text = "EditCountry";
            ((System.ComponentModel.ISupportInitialize)(this.popDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tradeRouteDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buildingDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tagTB;
        private System.Windows.Forms.TextBox nameTB;
        private System.Windows.Forms.TextBox tagTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.ComboBox subStateComboBox;
        private System.Windows.Forms.DataGridView popDataGridView;
        private System.Windows.Forms.Button newPopButton;
        private System.Windows.Forms.Button editPopButton;
        private System.Windows.Forms.ComboBox stateTypeComboBox;
        private System.Windows.Forms.Button deletePopButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ComboBox tierComboBox;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.ListBox nationCultureListBox;
        private System.Windows.Forms.ListBox allCulturesListBox;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Button addCultureButton;
        private System.Windows.Forms.Button removeCultureButton;
        private System.Windows.Forms.TextBox cultureSearchTextBox;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.ComboBox capitalComboBox;
        private System.Windows.Forms.CheckBox namedFromCapitalCheckBox;
        private System.Windows.Forms.TextBox adjTextBox;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.ComboBox literacyComboBox;
        private System.Windows.Forms.ComboBox wealthComboBox;
        private System.Windows.Forms.DataGridView tradeRouteDataGridView;
        private System.Windows.Forms.Button deleteRouteButton;
        private System.Windows.Forms.Button editRouteButton;
        private System.Windows.Forms.Button newRouteButton;
        private System.Windows.Forms.DataGridView buildingDataGridView;
        private System.Windows.Forms.Button deleteBuildingButton;
        private System.Windows.Forms.Button editBuildngButton;
        private System.Windows.Forms.Button newBuildingButton;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.ComboBox religionComboBox;
    }
}