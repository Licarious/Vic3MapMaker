namespace Vic3MapMaker
{
    partial class EditResource
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
            this.ArableRadioButton = new System.Windows.Forms.RadioButton();
            this.CappedRadioButton = new System.Windows.Forms.RadioButton();
            this.DiscoverableRadioButton = new System.Windows.Forms.RadioButton();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.KnownTB = new System.Windows.Forms.TextBox();
            this.DiscoverableTB = new System.Windows.Forms.TextBox();
            this.KnowAmmountTextBox = new System.Windows.Forms.TextBox();
            this.DiscoverableAmmountTextBox = new System.Windows.Forms.TextBox();
            this.depletedTB = new System.Windows.Forms.TextBox();
            this.depletedTypeComboBox = new System.Windows.Forms.ComboBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ArableRadioButton
            // 
            this.ArableRadioButton.AutoSize = true;
            this.ArableRadioButton.Location = new System.Drawing.Point(264, 63);
            this.ArableRadioButton.Name = "ArableRadioButton";
            this.ArableRadioButton.Size = new System.Drawing.Size(80, 24);
            this.ArableRadioButton.TabIndex = 0;
            this.ArableRadioButton.TabStop = true;
            this.ArableRadioButton.Text = "Arable";
            this.ArableRadioButton.UseVisualStyleBackColor = true;
            this.ArableRadioButton.CheckedChanged += new System.EventHandler(this.ArableRadioButton_CheckedChanged);
            // 
            // CappedRadioButton
            // 
            this.CappedRadioButton.AutoSize = true;
            this.CappedRadioButton.Location = new System.Drawing.Point(264, 95);
            this.CappedRadioButton.Name = "CappedRadioButton";
            this.CappedRadioButton.Size = new System.Drawing.Size(90, 24);
            this.CappedRadioButton.TabIndex = 0;
            this.CappedRadioButton.TabStop = true;
            this.CappedRadioButton.Text = "Capped";
            this.CappedRadioButton.UseVisualStyleBackColor = true;
            this.CappedRadioButton.CheckedChanged += new System.EventHandler(this.CappedRadioButton_CheckedChanged);
            // 
            // DiscoverableRadioButton
            // 
            this.DiscoverableRadioButton.AutoSize = true;
            this.DiscoverableRadioButton.Location = new System.Drawing.Point(264, 126);
            this.DiscoverableRadioButton.Name = "DiscoverableRadioButton";
            this.DiscoverableRadioButton.Size = new System.Drawing.Size(125, 24);
            this.DiscoverableRadioButton.TabIndex = 0;
            this.DiscoverableRadioButton.TabStop = true;
            this.DiscoverableRadioButton.Text = "Discoverable";
            this.DiscoverableRadioButton.UseVisualStyleBackColor = true;
            this.DiscoverableRadioButton.CheckedChanged += new System.EventHandler(this.DiscoverableRadioButton_CheckedChanged);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Enabled = false;
            this.nameTextBox.Location = new System.Drawing.Point(13, 13);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.ReadOnly = true;
            this.nameTextBox.Size = new System.Drawing.Size(376, 26);
            this.nameTextBox.TabIndex = 1;
            this.nameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // KnownTB
            // 
            this.KnownTB.Enabled = false;
            this.KnownTB.Location = new System.Drawing.Point(12, 61);
            this.KnownTB.Name = "KnownTB";
            this.KnownTB.ReadOnly = true;
            this.KnownTB.Size = new System.Drawing.Size(140, 26);
            this.KnownTB.TabIndex = 2;
            // 
            // DiscoverableTB
            // 
            this.DiscoverableTB.Enabled = false;
            this.DiscoverableTB.Location = new System.Drawing.Point(12, 93);
            this.DiscoverableTB.Name = "DiscoverableTB";
            this.DiscoverableTB.ReadOnly = true;
            this.DiscoverableTB.Size = new System.Drawing.Size(140, 26);
            this.DiscoverableTB.TabIndex = 2;
            // 
            // KnowAmmountTextBox
            // 
            this.KnowAmmountTextBox.Location = new System.Drawing.Point(158, 61);
            this.KnowAmmountTextBox.Name = "KnowAmmountTextBox";
            this.KnowAmmountTextBox.Size = new System.Drawing.Size(100, 26);
            this.KnowAmmountTextBox.TabIndex = 2;
            this.KnowAmmountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DiscoverableAmmountTextBox
            // 
            this.DiscoverableAmmountTextBox.Location = new System.Drawing.Point(158, 93);
            this.DiscoverableAmmountTextBox.Name = "DiscoverableAmmountTextBox";
            this.DiscoverableAmmountTextBox.Size = new System.Drawing.Size(100, 26);
            this.DiscoverableAmmountTextBox.TabIndex = 2;
            this.DiscoverableAmmountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // depletedTB
            // 
            this.depletedTB.Enabled = false;
            this.depletedTB.Location = new System.Drawing.Point(13, 126);
            this.depletedTB.Name = "depletedTB";
            this.depletedTB.ReadOnly = true;
            this.depletedTB.Size = new System.Drawing.Size(245, 26);
            this.depletedTB.TabIndex = 4;
            this.depletedTB.Text = "Depletes to:";
            // 
            // depletedTypeComboBox
            // 
            this.depletedTypeComboBox.FormattingEnabled = true;
            this.depletedTypeComboBox.Location = new System.Drawing.Point(13, 159);
            this.depletedTypeComboBox.Name = "depletedTypeComboBox";
            this.depletedTypeComboBox.Size = new System.Drawing.Size(376, 28);
            this.depletedTypeComboBox.TabIndex = 5;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(289, 193);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 40);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.cancelButton.Location = new System.Drawing.Point(183, 193);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 40);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // EditResource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 241);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.depletedTypeComboBox);
            this.Controls.Add(this.depletedTB);
            this.Controls.Add(this.DiscoverableTB);
            this.Controls.Add(this.DiscoverableAmmountTextBox);
            this.Controls.Add(this.KnowAmmountTextBox);
            this.Controls.Add(this.KnownTB);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.DiscoverableRadioButton);
            this.Controls.Add(this.CappedRadioButton);
            this.Controls.Add(this.ArableRadioButton);
            this.Name = "EditResource";
            this.Text = "UpdateResource";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton ArableRadioButton;
        private System.Windows.Forms.RadioButton CappedRadioButton;
        private System.Windows.Forms.RadioButton DiscoverableRadioButton;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox KnownTB;
        private System.Windows.Forms.TextBox DiscoverableTB;
        private System.Windows.Forms.TextBox KnowAmmountTextBox;
        private System.Windows.Forms.TextBox DiscoverableAmmountTextBox;
        private System.Windows.Forms.TextBox depletedTB;
        private System.Windows.Forms.ComboBox depletedTypeComboBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
    }
}