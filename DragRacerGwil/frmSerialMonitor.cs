using System;
using System.Drawing;
using System.Windows.Forms;

namespace DragRacerGwil
{
    public partial class frmSerialMonitor : Form
    {
        #region Fields
        private System.Collections.Generic.List<string> obDebugLogGwil = new System.Collections.Generic.List<string>();

        #endregion Fields

        #region Constructors

        public frmSerialMonitor()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods

        public void LogMessageGwil(string messageGwil, bool extensizeItemGwil, int textColorGwil = -16777216)
        {
            try
            {
                //set the color of the next text and append the log message to it
                Color textColorFormatedGwil = Color.FromArgb(textColorGwil);

                //set the color of the next text and append the log message to it
                rtbAdvancedLogGwil.SelectionColor = textColorFormatedGwil;
                rtbAdvancedLogGwil.AppendText("[" + DateTime.Now.ToString() + ":" + DateTime.Now.Millisecond + "] " +
                    ((messageGwil.EndsWith("\n") == false) ? messageGwil + '\n' : messageGwil));
                rtbAdvancedLogGwil.ScrollToCaret();

                //if the item is an advanced item don't show in simple log
                if (extensizeItemGwil == false)
                {
                    rtbSimpleLogGwil.SelectionColor = textColorFormatedGwil;
                    rtbSimpleLogGwil.AppendText("[" + DateTime.Now.ToString() + ":" + DateTime.Now.Millisecond + "] " +
                        ((messageGwil.EndsWith("\n") == false) ? messageGwil + '\n' : messageGwil));
                    rtbSimpleLogGwil.ScrollToCaret();
                }
            }
            catch (Exception obExGwil)
            {
                if (obExGwil.Message != "Cannot access a disposed object.\r\nObject name: 'RichTextBox'.")
                    //write exception to debugger since serial monitor wont work
                    System.Diagnostics.Debug.WriteLine(obExGwil.Message);
            }
        }

        private void cbkAdvancedLogGwil_CheckedChanged(object sender, EventArgs e)
        {
            if (cbkAdvancedLogGwil.Checked == true)
                rtbAdvancedLogGwil.BringToFront();
            else
                rtbAdvancedLogGwil.SendToBack();
        }

        private void frmSerialMonitor_FormClosing(object sender, FormClosingEventArgs e)
        {
            //cancel close event
            e.Cancel = true;
            //make it hide so we can continue the monitor once shown again
            this.Hide();
        }

        #endregion Methods
    }
}