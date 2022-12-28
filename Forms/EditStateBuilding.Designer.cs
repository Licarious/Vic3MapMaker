namespace Vic3MapMaker.Forms
{
    partial class EditStateBuilding
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.buildingComboBox = new System.Windows.Forms.ComboBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.pmgComboBox = new System.Windows.Forms.ComboBox();
            this.pmComboBox = new System.Windows.Forms.ComboBox();
            this.levelNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.reservesNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.levelNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reservesNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(13, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(154, 26);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Building:";
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(13, 45);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(154, 26);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "Level:";
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(13, 77);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(154, 26);
            this.textBox3.TabIndex = 2;
            this.textBox3.Text = "Reserves:";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(400, 175);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 40);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(319, 175);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 40);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // buildingComboBox
            // 
            this.buildingComboBox.FormattingEnabled = true;
            this.buildingComboBox.Location = new System.Drawing.Point(173, 10);
            this.buildingComboBox.Name = "buildingComboBox";
            this.buildingComboBox.Size = new System.Drawing.Size(302, 28);
            this.buildingComboBox.TabIndex = 9;
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.Location = new System.Drawing.Point(13, 109);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(154, 26);
            this.textBox4.TabIndex = 12;
            this.textBox4.Text = "Production Groups:";
            // 
            // textBox5
            // 
            this.textBox5.Enabled = false;
            this.textBox5.Location = new System.Drawing.Point(12, 141);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(154, 26);
            this.textBox5.TabIndex = 13;
            this.textBox5.Text = "Production Method:";
            // 
            // pmgComboBox
            // 
            this.pmgComboBox.FormattingEnabled = true;
            this.pmgComboBox.Location = new System.Drawing.Point(173, 107);
            this.pmgComboBox.Name = "pmgComboBox";
            this.pmgComboBox.Size = new System.Drawing.Size(302, 28);
            this.pmgComboBox.TabIndex = 14;
            this.pmgComboBox.SelectedIndexChanged += new System.EventHandler(this.PmgComboBox_SelectedIndexChanged);
            // 
            // pmComboBox
            // 
            this.pmComboBox.FormattingEnabled = true;
            this.pmComboBox.Location = new System.Drawing.Point(173, 141);
            this.pmComboBox.Name = "pmComboBox";
            this.pmComboBox.Size = new System.Drawing.Size(302, 28);
            this.pmComboBox.TabIndex = 15;
            this.pmComboBox.SelectedIndexChanged += new System.EventHandler(this.PmComboBox_SelectedIndexChanged);
            // 
            // levelNumericUpDown
            // 
            this.levelNumericUpDown.Location = new System.Drawing.Point(173, 44);
            this.levelNumericUpDown.Name = "levelNumericUpDown";
            this.levelNumericUpDown.Size = new System.Drawing.Size(302, 26);
            this.levelNumericUpDown.TabIndex = 16;
            // 
            // reservesNumericUpDown
            // 
            this.reservesNumericUpDown.Location = new System.Drawing.Point(173, 75);
            this.reservesNumericUpDown.Name = "reservesNumericUpDown";
            this.reservesNumericUpDown.Size = new System.Drawing.Size(302, 26);
            this.reservesNumericUpDown.TabIndex = 17;
            // 
            // EditStateBuilding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 228);
            this.Controls.Add(this.reservesNumericUpDown);
            this.Controls.Add(this.levelNumericUpDown);
            this.Controls.Add(this.pmComboBox);
            this.Controls.Add(this.pmgComboBox);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.buildingComboBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "EditStateBuilding";
            this.Text = "EditStateBuilding";
            ((System.ComponentModel.ISupportInitialize)(this.levelNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reservesNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.ComboBox pmgComboBox;
        private System.Windows.Forms.ComboBox pmComboBox;
        private System.Windows.Forms.ComboBox buildingComboBox;
        private System.Windows.Forms.NumericUpDown levelNumericUpDown;
        private System.Windows.Forms.NumericUpDown reservesNumericUpDown;
    }
}