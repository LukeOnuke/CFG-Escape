using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OST
{
    public partial class MessageProvider : Form
    {
        public MessageProvider()
        {
            InitializeComponent();
            
        }

        public void SetText(string text, string title) 
        {
            MessageProvider mp = new MessageProvider();
            textBox1.Text = text;
            mp.Text = title;
            
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
