using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vic3MapMaker
{
    internal static class Program
    {
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            bool autorun = false;
            string defaultGameFolder = "";
            string defaultModFolder = "--Not Implemented--";
            string defaultOutputFolder = "";

            //check if the version of .NET is 4.0 or higher
            if (Environment.Version.Major < 4) {
                MessageBox.Show("This program requires .NET 4.0 or higher to run. Please update your .NET version and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //get directory of the executable
            string executablePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            //check if autorun.txt exists in the same directory as the executable
            if (File.Exists(Path.Combine(Path.GetDirectoryName(executablePath), "autorun.cfg"))) {
                //read the autorun.txt file
                string[] autorunLines = File.ReadAllLines(Path.Combine(Path.GetDirectoryName(executablePath), "autorun.cfg"));
                //if there are 3 lines, use the first 3 lines as the game folder, mod folder, and output folder
                if (autorunLines.Length >= 4) {
                    defaultGameFolder = autorunLines[0];
                    defaultModFolder = autorunLines[1];
                    defaultOutputFolder = autorunLines[2];
                    autorun = bool.Parse(autorunLines[3]);
                }
            }


            //open the mainStarted form
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartForm(defaultGameFolder, defaultModFolder, defaultOutputFolder, autorun, Path.GetDirectoryName(executablePath)));

            

            return;

        }
    }
}
