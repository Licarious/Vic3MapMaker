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
            bool useGameFolder = false;

            string defaultGameFolder = "C:\\Users\\fligh\\OneDrive\\Desktop\\Vic3\\Vic3MapMaker\\Vic3MapMaker\\_Input";
            if (useGameFolder) {
                defaultGameFolder = "E:\\Steam\\steamapps\\common\\Victoria 3\\game";
            }
            string defaultModFolder = "--Not Implemented--";
            string defaultOutputFolder = "C:\\Users\\fligh\\OneDrive\\Desktop\\Vic3\\Vic3MapMaker\\Vic3MapMaker\\_Output";
            bool autorun = true;
            

            //open the mainStarted form
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartForm(defaultGameFolder, defaultModFolder, defaultOutputFolder, autorun));

            

            return;

        }
    }
}
