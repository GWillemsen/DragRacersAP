using DragRacerGwil.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DragRacerGwil
{
    public partial class frmMainGwil : Form
    {
        #region Fields

        //list of controls to draw
        private static List<csBasicControlGwil> controlsGwil = new List<csBasicControlGwil>();

        //offset of the graphics on the screen
        private Point graphicsOffsetGwil = new Point(0, 0);

        private Size lastKnowSizeGwil = new Size(0, 0);

        #endregion Fields

        #region Constructors

        public frmMainGwil()
        {
            //initialize the normal form items
            InitializeComponent();
            //create a graphics out of the current form
            Graphics grGwil = this.CreateGraphics();

            //create a new button
            csButtonGwil obHelloWorldButtonGwil = new csButtonGwil();

            //set the controls properties
            obHelloWorldButtonGwil.SizeGwil = new Size(100, 20);
            obHelloWorldButtonGwil.TextGwil = "Hello this is a button";
            //add the event function that is raised when it is clicked
            obHelloWorldButtonGwil.OnClickGwil += (senderGwil, eventGwil) => { MessageBox.Show("Hello this is a button"); };
            //add the button to the list of controls
            controlsGwil.Add(obHelloWorldButtonGwil);

            foreach (csBasicControlGwil controlGwil in controlsGwil)
            {
                //make sure it will draw it self
                controlGwil.changedSinceDrawGwil = true;
                //draw the control on the graphics
                controlGwil.DrawGwil(grGwil);
            }
            //start the timer for a regular form update
            tmrKeepDrawingGwil.Enabled = false;
        }

        #endregion Constructors

        #region Methods

        protected override void OnPaint(PaintEventArgs e)
        {
            //create an new graphics object from the existing e.graphics
            Graphics grGwil = e.Graphics;
            grGwil.Clear(Color.White);//clear it with the color white(since there is no color control)
            foreach (csBasicControlGwil controlGwil in controlsGwil)
            {
                //set the to true so the control will be forced to update
                controlGwil.changedSinceDrawGwil = true;

                //calculate mouse position and check if mouse is in control than leave the control
                Point currentPosMouseGwil = new Point(MousePosition.X - this.Location.X, MousePosition.Y - this.Location.Y);
                if ((currentPosMouseGwil.X > Width || currentPosMouseGwil.Y > Height) && controlGwil.mouseEnteredGwil)
                    controlGwil.MouseLeaveGwil(this, new MouseEventArgs(MouseButtons.None, 0, currentPosMouseGwil.X, currentPosMouseGwil.Y, 0));
                //also if it thinks the mouse is down than tell it otherwise
                if ((currentPosMouseGwil.X > Width || currentPosMouseGwil.Y > Height) && controlGwil.mouseDownGwil)
                    controlGwil.MouseUpRaiseGwil(this, new MouseEventArgs(MouseButtons.None, 0, currentPosMouseGwil.X, currentPosMouseGwil.Y, 0));
                //draw the control on the graphic
                controlGwil.DrawGwil(grGwil);
            }
            /*send message to the original on-paint that it can do its job
             * (we are first and than the original on-paint(that handles toolbox items etc.)
             * will do its run
             */
            base.OnPaint(e);
        }

        private void frmMainGwil_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (csBasicControlGwil controlGwil in controlsGwil)
            {
                //check if the mouse is in the control bounds
                if (e.X >= controlGwil.LocationGwil.X + graphicsOffsetGwil.X &&
                    e.X <= controlGwil.SizeGwil.Width + controlGwil.LocationGwil.X + graphicsOffsetGwil.X)
                {
                    if (e.Y >= controlGwil.LocationGwil.Y + graphicsOffsetGwil.Y &&
                         e.Y <= controlGwil.LocationGwil.Y + controlGwil.SizeGwil.Height + graphicsOffsetGwil.Y)
                    {
                        //raise the controls click event
                        controlGwil.ClickGwil(this, e);
                    }
                }
            }
        }

        private void frmMainGwil_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (csBasicControlGwil controlGwil in controlsGwil)
            {
                //check if mouse is in the control
                if (e.X >= controlGwil.LocationGwil.X + graphicsOffsetGwil.X &&
                    e.X <= controlGwil.SizeGwil.Width + controlGwil.LocationGwil.X + graphicsOffsetGwil.X)
                {
                    if (e.Y >= controlGwil.LocationGwil.Y + graphicsOffsetGwil.Y &&
                         e.Y <= controlGwil.LocationGwil.Y + controlGwil.SizeGwil.Height + graphicsOffsetGwil.Y)
                    {
                        //raise the mouse down event
                        controlGwil.MouseDownRaiseGwil(this, e);
                    }
                    else
                    {
                        //if mouse is down or mouse is entered, but the mouse is not actualy there reset to properties
                        if (controlGwil.mouseDownGwil == true || controlGwil.mouseEnteredGwil == true)
                        {
                            controlGwil.mouseDownGwil = false;
                            controlGwil.mouseEnteredGwil = false;
                        }
                    }
                }
                else
                {
                    //if mouse is down or mouse is entered, but the mouse is not actualy there reset to properties
                    if (controlGwil.mouseDownGwil == true || controlGwil.mouseEnteredGwil == true)
                    {
                        controlGwil.mouseDownGwil = false;
                        controlGwil.mouseEnteredGwil = false;
                    }
                }
            }
        }

        private void frmMainGwil_MouseMove(object sender, MouseEventArgs e)
        {
            //boolean the use when we want the invalidate our form
            bool somethingChangedGwil = false;

            //loop through all controls
            foreach (csBasicControlGwil controlGwil in controlsGwil)
            {
                //check if mouse is with the current control
                if (e.X >= controlGwil.LocationGwil.X + graphicsOffsetGwil.X &&
                    e.X <= controlGwil.SizeGwil.Width + controlGwil.LocationGwil.X + graphicsOffsetGwil.X)
                {
                    if (e.Y >= controlGwil.LocationGwil.Y + graphicsOffsetGwil.Y &&
                         e.Y <= controlGwil.LocationGwil.Y + controlGwil.SizeGwil.Height + graphicsOffsetGwil.Y)
                    {
                        //ifso click a move event
                        controlGwil.MouseMoveRaiseGwil(this, e);
                    }
                    else if (controlGwil.mouseEnteredGwil == true)
                        //otherwise raise leave events
                        controlGwil.MouseLeaveGwil(sender, e);
                }
                else
                {
                    if (controlGwil.mouseEnteredGwil == true)
                        //otherwise raise leave events
                        controlGwil.MouseLeaveGwil(sender, e);
                }

                //check if the control has detected that is should redraw
                if (controlGwil.changedSinceDrawGwil == true)
                    somethingChangedGwil = true;//set our bool to true so the form will invalidate
            }

            //if we changed something invalidate the form
            if (somethingChangedGwil == true)
                this.Invalidate();
        }

        private void frmMainGwil_MouseUp(object sender, MouseEventArgs e)
        {
            foreach (csBasicControlGwil controlGwil in controlsGwil)
            {
                //check if mouse is in the control
                if (e.X >= controlGwil.LocationGwil.X + graphicsOffsetGwil.X &&
                    e.X <= controlGwil.SizeGwil.Width + controlGwil.LocationGwil.X + graphicsOffsetGwil.X)
                {
                    if (e.Y >= controlGwil.LocationGwil.Y + graphicsOffsetGwil.Y &&
                         e.Y <= controlGwil.LocationGwil.Y + controlGwil.SizeGwil.Height + graphicsOffsetGwil.Y)
                    {
                        //raise the mouse up event
                        controlGwil.MouseUpRaiseGwil(this, e);
                    }
                    else
                    {
                        //if mouse is down or mouse is entered, but the mouse is not actualy there reset to properties
                        if (controlGwil.mouseDownGwil == true || controlGwil.mouseEnteredGwil == true)
                        {
                            controlGwil.mouseDownGwil = false;
                            controlGwil.mouseEnteredGwil = false;
                        }
                    }
                }
                else
                {
                    //if mouse is down or mouse is entered, but the mouse is not actualy there reset to properties
                    if (controlGwil.mouseDownGwil == true || controlGwil.mouseEnteredGwil == true)
                    {
                        controlGwil.mouseDownGwil = false;
                        controlGwil.mouseEnteredGwil = false;
                    }
                }
            }
        }

        private void frmMainGwil_Resize(object sender, EventArgs e)
        {
            if (lastKnowSizeGwil.Width != Size.Width || lastKnowSizeGwil.Height != Size.Height)
            {
                double resizerWidthGwil = Size.Width / (double)lastKnowSizeGwil.Width;
                double resizerHeightGwil = Size.Height / (double)lastKnowSizeGwil.Height;
                foreach (csBasicControlGwil controlGwil in controlsGwil)
                {
                    System.Diagnostics.Debug.WriteLine(controlGwil.SizeGwil + "    " + new SizeF(
                        (float)(controlGwil.SizeGwil.Width * resizerWidthGwil),
                        (float)(controlGwil.SizeGwil.Height * resizerHeightGwil)).ToString());
                    controlGwil.SizeGwil = new SizeF(
                        (float)(controlGwil.SizeGwil.Width * resizerWidthGwil),
                        (float)(controlGwil.SizeGwil.Height * resizerHeightGwil));
                }
                System.Diagnostics.Debug.WriteLine("end of loop");
                System.Diagnostics.Debug.WriteLine(resizerWidthGwil);
                this.Invalidate();
                lastKnowSizeGwil = Size;
            }
        }

        private void tmrKeepDrawingGwil_Tick(object sender, EventArgs e)
        {
            //force an screen update
            this.Invalidate();
        }

        #endregion Methods
    }
}