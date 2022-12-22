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
            this.popGridView = new System.Windows.Forms.DataGridView();
            this.newPopButton = new System.Windows.Forms.Button();
            this.editPopButton = new System.Windows.Forms.Button();
            this.stateTypeComboBox = new System.Windows.Forms.ComboBox();
            this.deletePopButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.popGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tagTB
            // 
            this.tagTB.Enabled = false;
            this.tagTB.Location = new System.Drawing.Point(13, 13);
            this.tagTB.Name = "tagTB";
            this.tagTB.ReadOnly = true;
            this.tagTB.Size = new System.Drawing.Size(48, 20);
            this.tagTB.TabIndex = 0;
            this.tagTB.Text = "Tag:";
            // 
            // nameTB
            // 
            this.nameTB.Enabled = false;
            this.nameTB.Location = new System.Drawing.Point(13, 39);
            this.nameTB.Name = "nameTB";
            this.nameTB.ReadOnly = true;
            this.nameTB.Size = new System.Drawing.Size(48, 20);
            this.nameTB.TabIndex = 0;
            this.nameTB.Text = "Name:";
            // 
            // tagTextBox
            // 
            this.tagTextBox.Location = new System.Drawing.Point(80, 12);
            this.tagTextBox.Name = "tagTextBox";
            this.tagTextBox.Size = new System.Drawing.Size(100, 20);
            this.tagTextBox.TabIndex = 1;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(80, 39);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.nameTextBox.TabIndex = 1;
            // 
            // subStateComboBox
            // 
            this.subStateComboBox.FormattingEnabled = true;
            this.subStateComboBox.Location = new System.Drawing.Point(13, 66);
            this.subStateComboBox.Name = "subStateComboBox";
            this.subStateComboBox.Size = new System.Drawing.Size(167, 21);
            this.subStateComboBox.TabIndex = 2;
            this.subStateComboBox.SelectedIndexChanged += new System.EventHandler(this.SubStateComboBox_SelectedIndexChanged);
            // 
            // popGridView
            // 
            this.popGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.popGridView.Location = new System.Drawing.Point(13, 120);
            this.popGridView.Name = "popGridView";
            this.popGridView.Size = new System.Drawing.Size(412, 192);
            this.popGridView.TabIndex = 3;
            // 
            // newPopButton
            // 
            this.newPopButton.Location = new System.Drawing.Point(188, 91);
            this.newPopButton.Name = "newPopButton";
            this.newPopButton.Size = new System.Drawing.Size(75, 23);
            this.newPopButton.TabIndex = 4;
            this.newPopButton.Text = "New Pop";
            this.newPopButton.UseVisualStyleBackColor = true;
            this.newPopButton.Click += new System.EventHandler(this.NewPopButton_Click);
            // 
            // editPopButton
            // 
            this.editPopButton.Location = new System.Drawing.Point(269, 91);
            this.editPopButton.Name = "editPopButton";
            this.editPopButton.Size = new System.Drawing.Size(75, 23);
            this.editPopButton.TabIndex = 5;
            this.editPopButton.Text = "Edit Pop";
            this.editPopButton.UseVisualStyleBackColor = true;
            this.editPopButton.Click += new System.EventHandler(this.editPopButton_Click);
            // 
            // stateTypeComboBox
            // 
            this.stateTypeComboBox.FormattingEnabled = true;
            this.stateTypeComboBox.Location = new System.Drawing.Point(13, 93);
            this.stateTypeComboBox.Name = "stateTypeComboBox";
            this.stateTypeComboBox.Size = new System.Drawing.Size(167, 21);
            this.stateTypeComboBox.TabIndex = 6;
            // 
            // deletePopButton
            // 
            this.deletePopButton.Location = new System.Drawing.Point(350, 91);
            this.deletePopButton.Name = "deletePopButton";
            this.deletePopButton.Size = new System.Drawing.Size(75, 23);
            this.deletePopButton.TabIndex = 7;
            this.deletePopButton.Text = "Delete Pop";
            this.deletePopButton.UseVisualStyleBackColor = true;
            this.deletePopButton.Click += new System.EventHandler(this.deletePopButton_Click);
            // 
            // EditCountry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 467);
            this.Controls.Add(this.deletePopButton);
            this.Controls.Add(this.stateTypeComboBox);
            this.Controls.Add(this.editPopButton);
            this.Controls.Add(this.newPopButton);
            this.Controls.Add(this.popGridView);
            this.Controls.Add(this.subStateComboBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.tagTextBox);
            this.Controls.Add(this.nameTB);
            this.Controls.Add(this.tagTB);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "EditCountry";
            this.Text = "EditCountry";
            ((System.ComponentModel.ISupportInitialize)(this.popGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tagTB;
        private System.Windows.Forms.TextBox nameTB;
        private System.Windows.Forms.TextBox tagTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.ComboBox subStateComboBox;
        private System.Windows.Forms.DataGridView popGridView;
        private System.Windows.Forms.Button newPopButton;
        private System.Windows.Forms.Button editPopButton;
        private System.Windows.Forms.ComboBox stateTypeComboBox;
        private System.Windows.Forms.Button deletePopButton;
    }
}