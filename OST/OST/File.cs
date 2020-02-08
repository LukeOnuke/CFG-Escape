using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OST
{
    class File
    {
        public string Read(string path)
        {
            string text = "";
            string[] arrayText;
            //getting the array of the file by reading it
            try
            {
                arrayText = System.IO.File.ReadAllLines(path);
            }
            catch (Exception e)
            { ShowMessage(e.ToString(), "Error"); return null; }
            //splitting it up so that it can be displayed properly
            foreach (string f in arrayText) 
            {
                text = text + f + "\n";
            }

            return text;
        }

        public void Write(string textContents, string path) {
            //setting up the valiuables
            string[] text;
            //spliting the string into a array and removing the \n (newline tag)
            text = textContents.Split('\n');
            //setting up stream writer and making it so that it flushes itself after usage
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(path))
                //writing the document line by line
                try
                {
                    foreach (string line in text)
                    {
                        sw.WriteLine(line);
                    }
                }
                catch (Exception e){ ShowMessage(e.ToString(), "Error"); }

        }

        public static void Create(SaveFileDialog sfd) {
            sfd.ShowDialog();
            sfd.RestoreDirectory = true;
            string path = sfd.FileName;
            if (path != null && path != "") 
            {
                try
                {
                    System.IO.File.Create(path);
                }
                catch (Exception e) {
                    ShowMessage(e.ToString(), "Error");

                }
            }
        }

        public static void ShowMessage(string Message, string Title) {
            MessageProvider form2 = new MessageProvider();
            form2.Show();
            form2.SetText(Message, Title);
        
        }

    }
}
