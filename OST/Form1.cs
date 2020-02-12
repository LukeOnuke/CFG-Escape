using System;
using System.Windows.Forms;

namespace OST
{
    public partial class mainWindow : Form
    {
        //seting up valiues
        File file = new File();
        Markup markup = new Markup();
        //temp valiue
        private string path;
        private string textBoxTextC = " ";
        //-----------

        public mainWindow()
        {
            InitializeComponent();
            toolStripStatusFile.Text = "Initilasing...";
            //setting up all the keydown events
            textContainer.KeyDown += TextContainer_KeyDown;

            toolStripStatusFile.Text = "Ready";
            textBox1.Text = (timer1.Interval / 1000).ToString();

            string[] args = Environment.GetCommandLineArgs(); //getting the arguments
            try
            {
                if (args.Length > 1 && !args[1].Contains("OST.exe")) //Args[1] contains the directory if the program is called to open a file
                {
                    ReadTextFile(args[1]);
                }
            }
            catch (Exception e) { File.ShowMessage(e.ToString(), "Error"); }
        }

        public void ReadTextFile(string path)
        {
            toolStripStatusFile.Text = "Reading : " + path;
            textContainer.Text = file.Read(path);
            toolStripStatusFile.Text = path;

            Markup.MarkupMake(textContainer);
        }

        private void TextContainer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S && path != null && path != "" && textContainer.Text != null)
            {
                StatusLabel2.Text = "Saving";
                file.Write(textContainer.Text, path);
                StatusLabel2.Text = "";
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                File.Create(saveFileDialog2);
                if (path != null)
                {
                    path = saveFileDialog2.FileName;
                    toolStripStatusFile.Text = path;
                }
            }
            catch (Exception ex)
            {
                File.ShowMessage(ex.ToString(), "ERROR");
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //show dialog
            openFileDialog1.ShowDialog();
            //get the dir
            path = openFileDialog1.FileName;
            if (path != null && path != "")
            {
                toolStripStatusFile.Text = "Reading : " + path;
                textContainer.Text = file.Read(path);
                toolStripStatusFile.Text = path;

                Markup.MarkupMake(textContainer);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textContainer.Text != null && path != null && path != "")
            {
                file.Write(textContainer.Text, path);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            path = saveFileDialog1.FileName;
            if (path != null && path != "")
            {
                file.Write(textContainer.Text, path);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //reload file button
            if (path != null && path != "" && textContainer.Text != null)
            {
                textContainer.Text = file.Read(path);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //remarkup
            if (textContainer.Text != null && textContainer.Text != "")
            {
                Markup.MarkupMake(textContainer);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        { // remarkupping
            if (checkBox1.Checked && textContainer.Text != textBoxTextC)
            {
                //remarkup
                if (textContainer.Text != null && textContainer.Text != "")
                {
                    Markup.MarkupMake(textContainer);
                    textBoxTextC = textContainer.Text;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int time = Convert.ToInt32(Convert.ToSingle(textBox1.Text) * 1000f);
                timer1.Interval = time;
            }
            catch (Exception ex)
            {
                File.ShowMessage(ex.ToString(), "Error");
            }
        }

        //limiting input
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 5000;
            textBox1.Text = (timer1.Interval / 1000).ToString();
            checkBox1.Checked = true;
        }
    }
}
