namespace Vic3MapMaker
{
    partial class StartForm
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
            this.gameFolderTextBox = new System.Windows.Forms.TextBox();
            this.modFolderTextBox = new System.Windows.Forms.TextBox();
            this.outputFolderTextBox = new System.Windows.Forms.TextBox();
            this.gameFolderTB = new System.Windows.Forms.TextBox();
            this.modFolderTB = new System.Windows.Forms.TextBox();
            this.outputFolderTB = new System.Windows.Forms.TextBox();
            this.selectGameFolderButton = new System.Windows.Forms.Button();
            this.selectModFolderButton = new System.Windows.Forms.Button();
            this.selectOutputFolderButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.autoRunCheckBox = new System.Windows.Forms.CheckBox();
            this.saveSettingsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gameFolderTextBox
            // 
            this.gameFolderTextBox.Location = new System.Drawing.Point(141, 12);
            this.gameFolderTextBox.Name = "gameFolderTextBox";
            this.gameFolderTextBox.Size = new System.Drawing.Size(400, 26);
            this.gameFolderTextBox.TabIndex = 0;
            // 
            // modFolderTextBox
            // 
            this.modFolderTextBox.Location = new System.Drawing.Point(140, 55);
            this.modFolderTextBox.Name = "modFolderTextBox";
            this.modFolderTextBox.Size = new System.Drawing.Size(400, 26);
            this.modFolderTextBox.TabIndex = 0;
            this.modFolderTextBox.Text = "--Not Implemented--";
            this.modFolderTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // outputFolderTextBox
            // 
            this.outputFolderTextBox.Location = new System.Drawing.Point(141, 102);
            this.outputFolderTextBox.Name = "outputFolderTextBox";
            this.outputFolderTextBox.Size = new System.Drawing.Size(400, 26);
            this.outputFolderTextBox.TabIndex = 0;
            // 
            // gameFolderTB
            // 
            this.gameFolderTB.Enabled = false;
            this.gameFolderTB.Location = new System.Drawing.Point(12, 12);
            this.gameFolderTB.Name = "gameFolderTB";
            this.gameFolderTB.ReadOnly = true;
            this.gameFolderTB.Size = new System.Drawing.Size(130, 26);
            this.gameFolderTB.TabIndex = 1;
            this.gameFolderTB.Text = "Game Folder:";
            // 
            // modFolderTB
            // 
            this.modFolderTB.Enabled = false;
            this.modFolderTB.Location = new System.Drawing.Point(13, 55);
            this.modFolderTB.Name = "modFolderTB";
            this.modFolderTB.ReadOnly = true;
            this.modFolderTB.Size = new System.Drawing.Size(130, 26);
            this.modFolderTB.TabIndex = 2;
            this.modFolderTB.Text = "Mod Folder:";
            // 
            // outputFolderTB
            // 
            this.outputFolderTB.Enabled = false;
            this.outputFolderTB.Location = new System.Drawing.Point(14, 102);
            this.outputFolderTB.Name = "outputFolderTB";
            this.outputFolderTB.ReadOnly = true;
            this.outputFolderTB.Size = new System.Drawing.Size(130, 26);
            this.outputFolderTB.TabIndex = 3;
            this.outputFolderTB.Text = "Output Folder:";
            // 
            // selectGameFolderButton
            // 
            this.selectGameFolderButton.Location = new System.Drawing.Point(547, 9);
            this.selectGameFolderButton.Name = "selectGameFolderButton";
            this.selectGameFolderButton.Size = new System.Drawing.Size(119, 33);
            this.selectGameFolderButton.TabIndex = 4;
            this.selectGameFolderButton.Text = "Select Folder";
            this.selectGameFolderButton.UseVisualStyleBackColor = true;
            this.selectGameFolderButton.Click += new System.EventHandler(this.SelectGameFolderButton_Click);
            // 
            // selectModFolderButton
            // 
            this.selectModFolderButton.Location = new System.Drawing.Point(547, 52);
            this.selectModFolderButton.Name = "selectModFolderButton";
            this.selectModFolderButton.Size = new System.Drawing.Size(119, 33);
            this.selectModFolderButton.TabIndex = 5;
            this.selectModFolderButton.Text = "Select Folder";
            this.selectModFolderButton.UseVisualStyleBackColor = true;
            this.selectModFolderButton.Click += new System.EventHandler(this.selectModFolderButton_Click);
            // 
            // selectOutputFolderButton
            // 
            this.selectOutputFolderButton.Location = new System.Drawing.Point(547, 99);
            this.selectOutputFolderButton.Name = "selectOutputFolderButton";
            this.selectOutputFolderButton.Size = new System.Drawing.Size(119, 33);
            this.selectOutputFolderButton.TabIndex = 6;
            this.selectOutputFolderButton.Text = "Select Folder";
            this.selectOutputFolderButton.UseVisualStyleBackColor = true;
            this.selectOutputFolderButton.Click += new System.EventHandler(this.selectOutputFolderButton_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(547, 147);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(119, 33);
            this.startButton.TabIndex = 7;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // autoRunCheckBox
            // 
            this.autoRunCheckBox.AutoSize = true;
            this.autoRunCheckBox.Location = new System.Drawing.Point(12, 152);
            this.autoRunCheckBox.Name = "autoRunCheckBox";
            this.autoRunCheckBox.Size = new System.Drawing.Size(103, 24);
            this.autoRunCheckBox.TabIndex = 8;
            this.autoRunCheckBox.Text = "Auto Run";
            this.autoRunCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveSettingsButton
            // 
            this.saveSettingsButton.Location = new System.Drawing.Point(141, 147);
            this.saveSettingsButton.Name = "saveSettingsButton";
            this.saveSettingsButton.Size = new System.Drawing.Size(149, 33);
            this.saveSettingsButton.TabIndex = 9;
            this.saveSettingsButton.Text = "Save Settings";
            this.saveSettingsButton.UseVisualStyleBackColor = true;
            this.saveSettingsButton.Click += new System.EventHandler(this.SaveSettingsButton_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 199);
            this.Controls.Add(this.saveSettingsButton);
            this.Controls.Add(this.autoRunCheckBox);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.selectOutputFolderButton);
            this.Controls.Add(this.selectModFolderButton);
            this.Controls.Add(this.selectGameFolderButton);
            this.Controls.Add(this.outputFolderTB);
            this.Controls.Add(this.modFolderTB);
            this.Controls.Add(this.gameFolderTB);
            this.Controls.Add(this.outputFolderTextBox);
            this.Controls.Add(this.modFolderTextBox);
            this.Controls.Add(this.gameFolderTextBox);
            this.Name = "StartForm";
            this.Text = "StartForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox gameFolderTextBox;
        private System.Windows.Forms.TextBox modFolderTextBox;
        private System.Windows.Forms.TextBox outputFolderTextBox;
        private System.Windows.Forms.TextBox gameFolderTB;
        private System.Windows.Forms.TextBox modFolderTB;
        private System.Windows.Forms.TextBox outputFolderTB;
        private System.Windows.Forms.Button selectGameFolderButton;
        private System.Windows.Forms.Button selectModFolderButton;
        private System.Windows.Forms.Button selectOutputFolderButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.CheckBox autoRunCheckBox;
        private System.Windows.Forms.Button saveSettingsButton;
    }
}