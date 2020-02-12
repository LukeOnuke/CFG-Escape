using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OST
{
    class Markup
    {
        private const string newline = "\n";
        private const string quotation = "\u0022";
        static string[] filter = { "=", "-", "+", "*", @"\", "/", "(", ")", "{", "}", "[", "]" };
        //Color boolBlue = Color.FromArgb(0, 102, 204);
        //Color intigerGreen = Color.FromArgb(160, 222, 53);
        //Color orange = Color.FromArgb(255, 204, 51);
        //red = Color.FromArgb(156, 48, 48);

        public static void MarkupMake(RichTextBox richTextBox) 
        {
            int sl = richTextBox.SelectionStart;
            // richTextBox.Enabled = false; //stop people from writing when markup event is happening
            
            HighlightText(richTextBox, "true", Color.FromArgb(0, 102, 204));
            HighlightText(richTextBox, "false", Color.FromArgb(0, 102, 204));
            HighlightText(richTextBox, quotation, Color.FromArgb(156, 48, 48));
            
            foreach (string f in filter)
            {
                HighlightText(richTextBox, f, Color.FromArgb(255, 204, 51));
            }
            for (int i = 0;i < 10;i++)
            {
                HighlightText(richTextBox, i.ToString(), Color.FromArgb(160, 222, 53));
            }

            HighlightText(richTextBox, "//", Color.FromArgb(34, 189, 160));

            richTextBox.SelectionStart = richTextBox.Text.Length;
            richTextBox.SelectionLength = 0;
            richTextBox.SelectionColor = Color.White;

            richTextBox.SelectionStart = sl; //get the marker to be back on the place where it was/*richTextBox.Text.Length;*/
            richTextBox.SelectionLength = 0;
            richTextBox.SelectionColor = Color.White;

            richTextBox.Enabled = true;
        }

        public static void HighlightText(RichTextBox rtb, string text, Color? highlight = null)
        {
            if (rtb == null || rtb.TextLength == 0) return;

            // Find the first index of the text
            var index = rtb.Text.IndexOf(text);
            var length = text.Length;

            while (index > -1)
            {
                rtb.SelectionStart = index;
                rtb.SelectionLength = length;
                rtb.SelectionColor = highlight ?? Color.Purple;  // Use Purple if no color was specified

                // Find the next index of the text
                index = rtb.Text.IndexOf(text, index + length);
            }
        }

       [Obsolete] public static void HighlightBetween(RichTextBox rtb, string charFIlter, Color? highlight = null) 
        {
            if (rtb == null || rtb.TextLength == 0) return;

            var index = rtb.Text.IndexOf(charFIlter);
            var length = rtb.Text.IndexOf(charFIlter, index) - index;

            while (index > -1)
            {
                rtb.SelectionStart = index;
                rtb.SelectionLength = length;
                rtb.SelectionColor = highlight ?? Color.Purple;  // Use Purple if no color was specified

                // Find the next index of the text
                index = rtb.Text.IndexOf(charFIlter, index + length);
                length = rtb.Text.IndexOf(charFIlter, index) - index;
            }


        }
    }
}
