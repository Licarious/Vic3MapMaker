using System.Windows.Forms;

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
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.levelNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.reservesNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.pmDataGridView = new System.Windows.Forms.DataGridView();
            this.pmgDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.levelNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reservesNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmgDataGridView)).BeginInit();
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
            this.saveButton.Location = new System.Drawing.Point(401, 399);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 40);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(320, 399);
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
            this.buildingComboBox.SelectedIndexChanged += new System.EventHandler(this.BuildingComboBox_SelectedIndexChanged);
            // 
            // textBox5
            // 
            this.textBox5.Enabled = false;
            this.textBox5.Location = new System.Drawing.Point(13, 109);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(463, 26);
            this.textBox5.TabIndex = 13;
            this.textBox5.Text = "Production Method:";
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
            // pmDataGridView
            // 
            this.pmDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pmDataGridView.Location = new System.Drawing.Point(245, 141);
            this.pmDataGridView.Name = "pmDataGridView";
            this.pmDataGridView.RowHeadersWidth = 62;
            this.pmDataGridView.RowTemplate.Height = 28;
            this.pmDataGridView.Size = new System.Drawing.Size(231, 252);
            this.pmDataGridView.TabIndex = 18;
            this.pmDataGridView.CellEnter += new DataGridViewCellEventHandler(pmDataGridView_CellEnter); 
            // 
            // pmgDataGridView
            // 
            this.pmgDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pmgDataGridView.Location = new System.Drawing.Point(13, 141);
            this.pmgDataGridView.Name = "pmgDataGridView";
            this.pmgDataGridView.RowHeadersWidth = 62;
            this.pmgDataGridView.RowTemplate.Height = 28;
            this.pmgDataGridView.Size = new System.Drawing.Size(231, 252);
            this.pmgDataGridView.TabIndex = 19;
            this.pmgDataGridView.SelectionChanged += new System.EventHandler(this.PmgDataGridView_SelectionChanged);
            // 
            // EditStateBuilding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 449);
            this.Controls.Add(this.pmgDataGridView);
            this.Controls.Add(this.pmDataGridView);
            this.Controls.Add(this.reservesNumericUpDown);
            this.Controls.Add(this.levelNumericUpDown);
            this.Controls.Add(this.textBox5);
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
            ((System.ComponentModel.ISupportInitialize)(this.pmDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmgDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void PmDataGridView_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e) {
            throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.ComboBox buildingComboBox;
        private System.Windows.Forms.NumericUpDown levelNumericUpDown;
        private System.Windows.Forms.NumericUpDown reservesNumericUpDown;
        private System.Windows.Forms.DataGridView pmDataGridView;
        private System.Windows.Forms.DataGridView pmgDataGridView;
    }
}