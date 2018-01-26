using System;
using System.Drawing;
using System.Windows.Forms;

namespace DragRacerGwil
{
    public partial class frmSerialMonitor : Form
    {
        #region Fields
        public bool IsShownGwil = false;
        private System.Collections.Generic.List<string> obDebugLogGwil = new System.Collections.Generic.List<string>();

        #endregion Fields

        #region Constructors

        public frmSerialMonitor()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods
        /// <summary>
        /// Log a message to the serial monitor
        /// </summary>
        /// <param name="messageGwil">The message to log</param>
        /// <param name="extensizeItemGwil">Whether it belong in the advanced log only</param>
        /// <param name="textColorGwil">The color the text(default black)</param>
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

                //check if we need to clean up lines
                int maxLinesPerPageGwil = (int)(this.Height / (rtbAdvancedLogGwil.Font.Height + 1.5));
                if (rtbAdvancedLogGwil.Lines.Length > maxLinesPerPageGwil)
                    while (rtbAdvancedLogGwil.Lines.Length > maxLinesPerPageGwil)
                    {
                        rtbAdvancedLogGwil.Select(0, rtbAdvancedLogGwil.GetFirstCharIndexFromLine(1)); // select the first line
                        rtbAdvancedLogGwil.SelectedText = "";
                    }

                if (rtbSimpleLogGwil.Lines.Length > maxLinesPerPageGwil)
                    while (rtbSimpleLogGwil.Lines.Length > maxLinesPerPageGwil)
                    {
                        rtbSimpleLogGwil.Select(0, rtbSimpleLogGwil.GetFirstCharIndexFromLine(1)); // select the first line
                        rtbSimpleLogGwil.SelectedText = "";
                    }
            }
            catch (Exception obExGwil)
            {
                if (obExGwil.Message != "Cannot access a disposed object.\r\nObject name: 'RichTextBox'.")
                    //write exception to debugger since serial monitor wont work
                    System.Diagnostics.Debug.WriteLine(obExGwil.Message);
            }
        }

        /// <summary>
        /// Show the serial monitor
        /// </summary>
        public void ShowFormGwil()
        {
            //show the form itself
            this.Show();
            //let others know
            IsShownGwil = true;
        }

        private void cbkAdvancedLogGwil_CheckedChanged(object sender, EventArgs e)
        {

            //if it is check show th advanced log, otherwise hide it
            if (cbkAdvancedLogGwil.Checked == true)
            {
                csMessageHelperGwil.LogMessage("Showing advanced log");
                rtbAdvancedLogGwil.BringToFront();
            }
            else
            {
                csMessageHelperGwil.LogMessage("Showing simple log");
                rtbAdvancedLogGwil.SendToBack();
            }
        }

        private void frmSerialMonitor_FormClosing(object sender, FormClosingEventArgs e)
        {
            //cancel close event
            e.Cancel = true;
            //make it hide so we can continue the monitor once shown again
            this.Hide();
            IsShownGwil = false;
            csMessageHelperGwil.LogMessage("Closing serial monitor");
        }

        #endregion Methods
    }
}