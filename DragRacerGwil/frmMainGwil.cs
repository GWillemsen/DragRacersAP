using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DragRacerGwil.Controls;
namespace DragRacerGwil
{
    public partial class frmMainGwil : Form
    {
        private static List<csBasicControlGwil> controlsGwil = new List<csBasicControlGwil>();
        Point graphicsOffsetGwil = new Point();

        public frmMainGwil()
        {
            InitializeComponent();  
            Graphics grGwil = this.CreateGraphics();
            this.Show();
            controlsGwil.Add(new csButtonGwil());
            controlsGwil[0].Size = new Size(100, 20);
            (controlsGwil[0] as csButtonGwil).Text = "hello this is a button";
            (controlsGwil[0]).OnClickGwil += (senderGwil, eventGwil) => { MessageBox.Show("hello this is a button"); };
            foreach (csBasicControlGwil controlGwil in controlsGwil)
            {
                controlGwil.Name = "hello";
                System.Diagnostics.Debug.WriteLine(controlGwil.Name);
                controlGwil.changedSinceDrawGwil = true;
                controlGwil.DrawGwil(grGwil);
            }
            tmrKeepDrawingGwil.Enabled = true;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics grGwil = e.Graphics;
            grGwil.Clear(Color.White);
            foreach (csBasicControlGwil controlGwil in controlsGwil)
            {
                controlGwil.changedSinceDrawGwil = true;
                Point currentPosMouseGwil = new Point(MousePosition.X - this.Location.X, MousePosition.Y - this.Location.Y);
                if (currentPosMouseGwil.X > Width || currentPosMouseGwil.Y > Height)
                    controlGwil.MouseLeaveGwil(this, new MouseEventArgs(MouseButtons.None, 0, currentPosMouseGwil.X, currentPosMouseGwil.Y, 0));
                controlGwil.DrawGwil(grGwil);                
            }
            base.OnPaint(e);
        }

        private void frmMainGwil_MouseClick(object sender, MouseEventArgs e)
        {
            foreach(csBasicControlGwil controlGwil in controlsGwil)
            {
                if(e.X >= controlGwil.Location.X + graphicsOffsetGwil.X &&
                    e.X <= controlGwil.Size.Width + controlGwil.Location.X + graphicsOffsetGwil.X)
                {
                    if (e.Y >= controlGwil.Location.Y + graphicsOffsetGwil.Y &&
                         e.Y <= controlGwil.Location.Y + controlGwil.Size.Height + graphicsOffsetGwil.Y)
                    {
                        controlGwil.ClickGwil(this, e);
                    }
                }
            }
        }

        private void frmMainGwil_MouseMove(object sender, MouseEventArgs e)
        {
            //bool the use when we want the invalidate our form
            bool somethingChangedGwil = false;

            //loop through all controls
            foreach (csBasicControlGwil controlGwil in controlsGwil)
            {
                if(e.X >= controlGwil.Location.X + graphicsOffsetGwil.X &&
                    e.X <= controlGwil.Size.Width + controlGwil.Location.X + graphicsOffsetGwil.X)
                {
                    if (e.Y >= controlGwil.Location.Y + graphicsOffsetGwil.Y &&
                         e.Y <= controlGwil.Location.Y + controlGwil.Size.Height + graphicsOffsetGwil.Y)
                    {
                        controlGwil.MouseMoveRaiseGwil(this, e);
                    }
                    else if (controlGwil.mouseEnteredGwil == true)
                        controlGwil.MouseLeaveGwil(sender, e);
                }
                else
                {
                    if(controlGwil.mouseEnteredGwil == true)
                        controlGwil.MouseLeaveGwil(sender, e);
                }
                if (controlGwil.changedSinceDrawGwil == true)
                    somethingChangedGwil = true;
            }
            if(somethingChangedGwil == true)
                this.Invalidate();
        }

        private void tmrKeepDrawingGwil_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmMainGwil_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (csBasicControlGwil controlGwil in controlsGwil)
            {
                if (e.X >= controlGwil.Location.X + graphicsOffsetGwil.X &&
                    e.X <= controlGwil.Size.Width + controlGwil.Location.X + graphicsOffsetGwil.X)
                {
                    if (e.Y >= controlGwil.Location.Y + graphicsOffsetGwil.Y &&
                         e.Y <= controlGwil.Location.Y + controlGwil.Size.Height + graphicsOffsetGwil.Y)
                    {
                        controlGwil.MouseDownRaiseGwil(this, e);
                    }
                    else
                    {
                        if (controlGwil.mouseDownGwil == true || controlGwil.mouseEnteredGwil == true)
                        {
                            controlGwil.mouseDownGwil = false;
                            controlGwil.mouseEnteredGwil = false;
                        }
                    }
                }
                else
                {
                    if (controlGwil.mouseDownGwil == true || controlGwil.mouseEnteredGwil == true)
                    {
                        controlGwil.mouseDownGwil = false;
                        controlGwil.mouseEnteredGwil = false;
                    }
                }
            }
        }
    }
}

