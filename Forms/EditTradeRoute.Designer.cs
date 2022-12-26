namespace Vic3MapMaker.Forms
{
    partial class EditTradeRoute
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
            this.levelTextBox = new System.Windows.Forms.TextBox();
            this.targetComboBox = new System.Windows.Forms.ComboBox();
            this.importRadioButton = new System.Windows.Forms.RadioButton();
            this.exportRadioButton = new System.Windows.Forms.RadioButton();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.goodsTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(13, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(80, 26);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Target:";
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(13, 45);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(80, 26);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "Goods:";
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(13, 77);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(80, 26);
            this.textBox3.TabIndex = 2;
            this.textBox3.Text = "Level:";
            // 
            // levelTextBox
            // 
            this.levelTextBox.Location = new System.Drawing.Point(99, 77);
            this.levelTextBox.Name = "levelTextBox";
            this.levelTextBox.Size = new System.Drawing.Size(153, 26);
            this.levelTextBox.TabIndex = 3;
            // 
            // targetComboBox
            // 
            this.targetComboBox.FormattingEnabled = true;
            this.targetComboBox.Location = new System.Drawing.Point(99, 13);
            this.targetComboBox.Name = "targetComboBox";
            this.targetComboBox.Size = new System.Drawing.Size(152, 28);
            this.targetComboBox.Sorted = true;
            this.targetComboBox.TabIndex = 4;
            // 
            // importRadioButton
            // 
            this.importRadioButton.AutoSize = true;
            this.importRadioButton.Location = new System.Drawing.Point(13, 110);
            this.importRadioButton.Name = "importRadioButton";
            this.importRadioButton.Size = new System.Drawing.Size(80, 24);
            this.importRadioButton.TabIndex = 6;
            this.importRadioButton.TabStop = true;
            this.importRadioButton.Text = "Import";
            this.importRadioButton.UseVisualStyleBackColor = true;
            // 
            // exportRadioButton
            // 
            this.exportRadioButton.AutoSize = true;
            this.exportRadioButton.Location = new System.Drawing.Point(172, 110);
            this.exportRadioButton.Name = "exportRadioButton";
            this.exportRadioButton.Size = new System.Drawing.Size(80, 24);
            this.exportRadioButton.TabIndex = 7;
            this.exportRadioButton.TabStop = true;
            this.exportRadioButton.Text = "Export";
            this.exportRadioButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(44, 142);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 40);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(152, 142);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 40);
            this.saveButton.TabIndex = 10;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // goodsTextBox
            // 
            this.goodsTextBox.Location = new System.Drawing.Point(99, 44);
            this.goodsTextBox.Name = "goodsTextBox";
            this.goodsTextBox.Size = new System.Drawing.Size(153, 26);
            this.goodsTextBox.TabIndex = 12;
            // 
            // EditTradeRoute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 193);
            this.Controls.Add(this.goodsTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.exportRadioButton);
            this.Controls.Add(this.importRadioButton);
            this.Controls.Add(this.targetComboBox);
            this.Controls.Add(this.levelTextBox);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "EditTradeRoute";
            this.Text = "EditTradeRoute";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox levelTextBox;
        private System.Windows.Forms.ComboBox targetComboBox;
        private System.Windows.Forms.RadioButton importRadioButton;
        private System.Windows.Forms.RadioButton exportRadioButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox goodsTextBox;
    }
}