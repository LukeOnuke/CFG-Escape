using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OST
{
    class Program
    {
        string fileByOS;

        public string FileByOS { get => fileByOS; set => fileByOS = value; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new mainWindow());

            Program program = new Program();
            mainWindow MainWindow = new mainWindow();

            if (args.Length > 0)
            {
                program.FileByOS = args[0];

                MainWindow.ReadTextFile(args[0]);
            }

        }
    }
}
