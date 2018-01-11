using System;
using System.Drawing;
using System.Windows.Forms;

namespace DragRacerGwil
{
    public partial class frmSerialMonitor : Form
    {
        #region Constructors

        public frmSerialMonitor()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods

        public void LogMessageGwil(string messageGwil, int textColorGwil = -16777216)
        {
            try
            {
                //set the color of the next text and append the log message to it
                Color textColorFormatedGwil = Color.FromArgb(textColorGwil);
                richTextBox1.SelectionColor = textColorFormatedGwil;
                richTextBox1.AppendText("[" + DateTime.Now.ToString() + ":" + DateTime.Now.Millisecond + "] " +
                    ((messageGwil.EndsWith("\n") == false) ? messageGwil + '\n' : messageGwil));
                richTextBox1.ScrollToCaret();
            }
            catch (Exception obExGwil)
            {
                if (obExGwil.Message != "Cannot access a disposed object.\r\nObject name: 'RichTextBox'.")
                    //write exception to debugger since serial monitor wont work
                    System.Diagnostics.Debug.WriteLine(obExGwil.Message);
            }
        }

        #endregion Methods
    }
}