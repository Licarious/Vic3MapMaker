namespace Vic3MapMaker.Forms
{
    partial class EditRegion
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
            this.regionNameTB = new System.Windows.Forms.TextBox();
            this.regionNameTextBox = new System.Windows.Forms.TextBox();
            this.cultureGFXTextBox = new System.Windows.Forms.TextBox();
            this.cultureGFXTB = new System.Windows.Forms.TextBox();
            this.colorButton = new System.Windows.Forms.Button();
            this.stateListBox = new System.Windows.Forms.ListBox();
            this.createNewStateButton = new System.Windows.Forms.Button();
            this.editStateButton = new System.Windows.Forms.Button();
            this.deleteStateButton = new System.Windows.Forms.Button();
            this.superRegionTextBox = new System.Windows.Forms.TextBox();
            this.superRegionTB = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // regionNameTB
            // 
            this.regionNameTB.Enabled = false;
            this.regionNameTB.Location = new System.Drawing.Point(13, 13);
            this.regionNameTB.Name = "regionNameTB";
            this.regionNameTB.ReadOnly = true;
            this.regionNameTB.Size = new System.Drawing.Size(157, 26);
            this.regionNameTB.TabIndex = 0;
            this.regionNameTB.Text = "Region Name:";
            // 
            // regionNameTextBox
            // 
            this.regionNameTextBox.Location = new System.Drawing.Point(13, 46);
            this.regionNameTextBox.Name = "regionNameTextBox";
            this.regionNameTextBox.Size = new System.Drawing.Size(199, 26);
            this.regionNameTextBox.TabIndex = 1;
            // 
            // cultureGFXTextBox
            // 
            this.cultureGFXTextBox.Location = new System.Drawing.Point(13, 176);
            this.cultureGFXTextBox.Name = "cultureGFXTextBox";
            this.cultureGFXTextBox.Size = new System.Drawing.Size(199, 26);
            this.cultureGFXTextBox.TabIndex = 3;
            // 
            // cultureGFXTB
            // 
            this.cultureGFXTB.Enabled = false;
            this.cultureGFXTB.Location = new System.Drawing.Point(13, 143);
            this.cultureGFXTB.Name = "cultureGFXTB";
            this.cultureGFXTB.ReadOnly = true;
            this.cultureGFXTB.Size = new System.Drawing.Size(157, 26);
            this.cultureGFXTB.TabIndex = 2;
            this.cultureGFXTB.Text = "Cultural GFX:";
            // 
            // colorButton
            // 
            this.colorButton.Location = new System.Drawing.Point(218, 13);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(98, 59);
            this.colorButton.TabIndex = 4;
            this.colorButton.Text = "Color";
            this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.Click += new System.EventHandler(this.ColorButton_Click);
            // 
            // stateListBox
            // 
            this.stateListBox.FormattingEnabled = true;
            this.stateListBox.ItemHeight = 20;
            this.stateListBox.Location = new System.Drawing.Point(14, 209);
            this.stateListBox.Name = "stateListBox";
            this.stateListBox.Size = new System.Drawing.Size(199, 184);
            this.stateListBox.TabIndex = 5;
            // 
            // createNewStateButton
            // 
            this.createNewStateButton.Location = new System.Drawing.Point(220, 209);
            this.createNewStateButton.Name = "createNewStateButton";
            this.createNewStateButton.Size = new System.Drawing.Size(98, 57);
            this.createNewStateButton.TabIndex = 6;
            this.createNewStateButton.Text = "Create New State";
            this.createNewStateButton.UseVisualStyleBackColor = true;
            this.createNewStateButton.Click += new System.EventHandler(this.CreateNewStateButton_Click);
            // 
            // editStateButton
            // 
            this.editStateButton.Location = new System.Drawing.Point(220, 272);
            this.editStateButton.Name = "editStateButton";
            this.editStateButton.Size = new System.Drawing.Size(98, 57);
            this.editStateButton.TabIndex = 7;
            this.editStateButton.Text = "Edit State";
            this.editStateButton.UseVisualStyleBackColor = true;
            this.editStateButton.Click += new System.EventHandler(this.EditStateButton_Click);
            // 
            // deleteStateButton
            // 
            this.deleteStateButton.Location = new System.Drawing.Point(220, 335);
            this.deleteStateButton.Name = "deleteStateButton";
            this.deleteStateButton.Size = new System.Drawing.Size(98, 57);
            this.deleteStateButton.TabIndex = 8;
            this.deleteStateButton.Text = "Delete State";
            this.deleteStateButton.UseVisualStyleBackColor = true;
            this.deleteStateButton.Click += new System.EventHandler(this.DeleteStateButton_Click);
            // 
            // superRegionTextBox
            // 
            this.superRegionTextBox.Location = new System.Drawing.Point(13, 111);
            this.superRegionTextBox.Name = "superRegionTextBox";
            this.superRegionTextBox.Size = new System.Drawing.Size(199, 26);
            this.superRegionTextBox.TabIndex = 10;
            // 
            // superRegionTB
            // 
            this.superRegionTB.Enabled = false;
            this.superRegionTB.Location = new System.Drawing.Point(13, 78);
            this.superRegionTB.Name = "superRegionTB";
            this.superRegionTB.ReadOnly = true;
            this.superRegionTB.Size = new System.Drawing.Size(157, 26);
            this.superRegionTB.TabIndex = 9;
            this.superRegionTB.Text = "Super Region:";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(14, 399);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 39);
            this.saveButton.TabIndex = 11;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(95, 399);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 39);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // EditRegion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 450);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.superRegionTextBox);
            this.Controls.Add(this.superRegionTB);
            this.Controls.Add(this.deleteStateButton);
            this.Controls.Add(this.editStateButton);
            this.Controls.Add(this.createNewStateButton);
            this.Controls.Add(this.stateListBox);
            this.Controls.Add(this.colorButton);
            this.Controls.Add(this.cultureGFXTextBox);
            this.Controls.Add(this.cultureGFXTB);
            this.Controls.Add(this.regionNameTextBox);
            this.Controls.Add(this.regionNameTB);
            this.Name = "EditRegion";
            this.Text = "EditRegion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox regionNameTB;
        private System.Windows.Forms.TextBox regionNameTextBox;
        private System.Windows.Forms.TextBox cultureGFXTextBox;
        private System.Windows.Forms.TextBox cultureGFXTB;
        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.ListBox stateListBox;
        private System.Windows.Forms.Button createNewStateButton;
        private System.Windows.Forms.Button editStateButton;
        private System.Windows.Forms.Button deleteStateButton;
        private System.Windows.Forms.TextBox superRegionTextBox;
        private System.Windows.Forms.TextBox superRegionTB;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
    }
}