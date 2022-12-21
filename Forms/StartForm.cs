using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vic3MapMaker
{
    public partial class StartForm : Form
    {
        readonly bool needsModFolder = false;
        string directory = "";

        public StartForm(string gameInput, string modInput, string output, bool autorun, string directory) { 


            InitializeComponent();
            gameFolderTextBox.Text = gameInput;
            modFolderTextBox.Text = modInput;
            outputFolderTextBox.Text = output;
            if (autorun) {
                startButton_Click(null, null);
            }
            this.directory = directory;

        }

        private void SelectGameFolderButton_Click(object sender, EventArgs e) {
            updateFolderSelection(gameFolderTextBox);
        }

        private void selectModFolderButton_Click(object sender, EventArgs e) {
            updateFolderSelection(modFolderTextBox);
        }
        private void selectOutputFolderButton_Click(object sender, EventArgs e) {
            updateFolderSelection(outputFolderTextBox);
        }

        //update folder select textbox, takes input from the textbox and opens the folder browser dialog in that folder, and set the selected path to the textbox
        private void updateFolderSelection(TextBox textBox) {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "Select the folder";
            folderBrowserDialog.ShowNewFolderButton = false;
            
            //if there is any text in the gameFolderTextBox, try to use that as the initial directory
            if (textBox.Text != "") {
                try {
                    folderBrowserDialog.SelectedPath = textBox.Text;
                }
                catch (Exception) {
                    Console.WriteLine("Invalid path in gameFolderTextBox");
                }
            }
            
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK) {
                textBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void startButton_Click(object sender, EventArgs e) {            
            List<string> errorList = new List<string>();
            gameFolderTextBox.BackColor = Color.White;
            modFolderTextBox.BackColor = Color.White;
            outputFolderTextBox.BackColor = Color.White;
            //check if the input folders exist
            if (!System.IO.Directory.Exists(gameFolderTextBox.Text)) {
                errorList.Add("Game folder does not exist");
                gameFolderTextBox.BackColor = Color.Pink;
            }
            if (!System.IO.Directory.Exists(modFolderTextBox.Text) && needsModFolder) {
                errorList.Add("Mod folder does not exist");
                modFolderTextBox.BackColor = Color.Pink;
            }
            if (!System.IO.Directory.Exists(outputFolderTextBox.Text)) {
                errorList.Add("Output folder does not exist");
                outputFolderTextBox.BackColor = Color.Pink;
            }

            //if there are any errors, show them in a message box
            if (errorList.Count > 0) {
                //open a message box with the lines in the errorList joined with a newline
                MessageBox.Show(string.Join(Environment.NewLine, errorList));
                return;
            }

            //vic3FileParser
            Vic3FileParser vic3FileParser = new Vic3FileParser(gameFolderTextBox.Text, modFolderTextBox.Text, outputFolderTextBox.Text);

            //open the main form with the vic3FileParser as input and the output folder as output folder and show this form as the owner of the main form (so it will be on top of this form) and close this form
            MainPage mainForm = new MainPage(vic3FileParser.GetData(), outputFolderTextBox.Text) {
                Owner = this
            };
            mainForm.Show();
            this.Hide();
            
        }

        private void SaveSettingsButton_Click(object sender, EventArgs e) {
            //if autorun.cgf does not exist, create it and write setting to it line by line
            if (!System.IO.File.Exists(directory + "\\autorun.cfg")) {
                System.IO.File.Create(directory + "\\autorun.cfg").Close();
            }

            //write the settings to the autorun.cfg file line by line
            System.IO.File.WriteAllLines(directory + "\\autorun.cfg", new string[] {
                gameFolderTextBox.Text,
                modFolderTextBox.Text,
                outputFolderTextBox.Text,
                autoRunCheckBox.Checked.ToString()
            });

        }
    }


}
