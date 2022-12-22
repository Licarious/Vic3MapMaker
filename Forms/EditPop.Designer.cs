namespace Vic3MapMaker.DataFiles
{
    partial class EditPop
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
            this.cultureTB = new System.Windows.Forms.TextBox();
            this.cultureTextBox = new System.Windows.Forms.TextBox();
            this.sizeTextBox = new System.Windows.Forms.TextBox();
            this.sizeTB = new System.Windows.Forms.TextBox();
            this.optionalTB = new System.Windows.Forms.TextBox();
            this.religionTextBox = new System.Windows.Forms.TextBox();
            this.religionTB = new System.Windows.Forms.TextBox();
            this.typeTextBox = new System.Windows.Forms.TextBox();
            this.typeTB = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cultureTB
            // 
            this.cultureTB.Enabled = false;
            this.cultureTB.Location = new System.Drawing.Point(14, 12);
            this.cultureTB.Name = "cultureTB";
            this.cultureTB.ReadOnly = true;
            this.cultureTB.Size = new System.Drawing.Size(132, 26);
            this.cultureTB.TabIndex = 0;
            this.cultureTB.Text = "Culture:";
            // 
            // cultureTextBox
            // 
            this.cultureTextBox.Location = new System.Drawing.Point(152, 12);
            this.cultureTextBox.Name = "cultureTextBox";
            this.cultureTextBox.Size = new System.Drawing.Size(168, 26);
            this.cultureTextBox.TabIndex = 1;
            // 
            // sizeTextBox
            // 
            this.sizeTextBox.Location = new System.Drawing.Point(152, 45);
            this.sizeTextBox.Name = "sizeTextBox";
            this.sizeTextBox.Size = new System.Drawing.Size(168, 26);
            this.sizeTextBox.TabIndex = 3;
            // 
            // sizeTB
            // 
            this.sizeTB.Enabled = false;
            this.sizeTB.Location = new System.Drawing.Point(14, 45);
            this.sizeTB.Name = "sizeTB";
            this.sizeTB.ReadOnly = true;
            this.sizeTB.Size = new System.Drawing.Size(132, 26);
            this.sizeTB.TabIndex = 2;
            this.sizeTB.Text = "Size:";
            // 
            // optionalTB
            // 
            this.optionalTB.Enabled = false;
            this.optionalTB.Location = new System.Drawing.Point(14, 77);
            this.optionalTB.Name = "optionalTB";
            this.optionalTB.ReadOnly = true;
            this.optionalTB.Size = new System.Drawing.Size(306, 26);
            this.optionalTB.TabIndex = 4;
            this.optionalTB.Text = "Optional:";
            // 
            // religionTextBox
            // 
            this.religionTextBox.Location = new System.Drawing.Point(152, 140);
            this.religionTextBox.Name = "religionTextBox";
            this.religionTextBox.Size = new System.Drawing.Size(168, 26);
            this.religionTextBox.TabIndex = 7;
            // 
            // religionTB
            // 
            this.religionTB.Enabled = false;
            this.religionTB.Location = new System.Drawing.Point(14, 140);
            this.religionTB.Name = "religionTB";
            this.religionTB.ReadOnly = true;
            this.religionTB.Size = new System.Drawing.Size(132, 26);
            this.religionTB.TabIndex = 6;
            this.religionTB.Text = "Religion:";
            // 
            // typeTextBox
            // 
            this.typeTextBox.Location = new System.Drawing.Point(152, 109);
            this.typeTextBox.Name = "typeTextBox";
            this.typeTextBox.Size = new System.Drawing.Size(168, 26);
            this.typeTextBox.TabIndex = 9;
            // 
            // typeTB
            // 
            this.typeTB.Enabled = false;
            this.typeTB.Location = new System.Drawing.Point(14, 109);
            this.typeTB.Name = "typeTB";
            this.typeTB.ReadOnly = true;
            this.typeTB.Size = new System.Drawing.Size(132, 26);
            this.typeTB.TabIndex = 8;
            this.typeTB.Text = "Type:";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(152, 172);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(76, 35);
            this.saveButton.TabIndex = 10;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(242, 172);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(78, 35);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // EditPop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 220);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.typeTextBox);
            this.Controls.Add(this.typeTB);
            this.Controls.Add(this.religionTextBox);
            this.Controls.Add(this.religionTB);
            this.Controls.Add(this.optionalTB);
            this.Controls.Add(this.sizeTextBox);
            this.Controls.Add(this.sizeTB);
            this.Controls.Add(this.cultureTextBox);
            this.Controls.Add(this.cultureTB);
            this.Name = "EditPop";
            this.Text = "EditPop";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox cultureTB;
        private System.Windows.Forms.TextBox cultureTextBox;
        private System.Windows.Forms.TextBox sizeTextBox;
        private System.Windows.Forms.TextBox sizeTB;
        private System.Windows.Forms.TextBox optionalTB;
        private System.Windows.Forms.TextBox religionTextBox;
        private System.Windows.Forms.TextBox religionTB;
        private System.Windows.Forms.TextBox typeTextBox;
        private System.Windows.Forms.TextBox typeTB;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
    }
}