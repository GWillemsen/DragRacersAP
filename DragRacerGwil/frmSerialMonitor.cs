using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DragRacerGwil
{
    public partial class frmSerialMonitor : Form
    {
        public frmSerialMonitor()
        {
            InitializeComponent();
        }

        public void LogMessageGwil(string messageGwil, int textColorGwil = -16777216)
        {            
            Color textColorFormatedGwil = Color.FromArgb(textColorGwil);
            richTextBox1.SelectionColor = textColorFormatedGwil;
            richTextBox1.AppendText((messageGwil.EndsWith("\n") == false) ? 
                messageGwil + '\n' : messageGwil);
            richTextBox1.ScrollToCaret();
        }
    }
}
