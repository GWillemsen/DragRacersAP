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
        public List<PointF> newTrackGwil = new List<PointF>(6000000);

        //list of controls to draw
        private static csControlListGwil obControlsGwil = new csControlListGwil();

        //offset of the graphics on the screen
        private Point graphicsOffsetGwil = new Point(0, 0);

        private Size lastKnowSizeGwil = new Size(0, 0);
        private PointF[] trackGwil = new PointF[2000];

        #endregion Fields

        #region Constructors

        public frmMainGwil()
        {
            //initialize the normal form items
            InitializeComponent();
            double xPosGwil = 0;
            bool downGwil = false;
            //generate the track
            for (int trackNumberPointGwil = 0; trackNumberPointGwil < trackGwil.Length; trackNumberPointGwil++)
            {
                trackGwil[trackNumberPointGwil] = new PointF((float)xPosGwil, (float)trackNumberPointGwil / 10);
                if (downGwil == true)
                {
                    xPosGwil -= 0.3F;
                    if (xPosGwil <= 0)
                        downGwil = false;
                }
                else
                {
                    xPosGwil += 0.3F; ;
                    if (xPosGwil >= 200)
                        downGwil = true;
                }
            }

            #region buttons

            csButtonGwil fileButtonGwil = new csButtonGwil("btnFileGwil", new Size(100, 50), new Point(3, 3), "File");
            fileButtonGwil.OnClickGwil += (senderGwil, argGwil) =>
            {
                int dragracerCountGwil = 0;
                foreach (csDragRacerGwil racerGwil in ((csPanelGwil)obControlsGwil.GetByNameGwil("pnlRacersGwil")).ChildsListGwil)
                {
                    racerGwil.ResetRacerToStartGwil(trackGwil[0], new PointF(dragracerCountGwil++ * 50, 0));
                    racerGwil.StartRaceGwil();
                    racerGwil.CreateRandomSpeedGwil();
                    System.Threading.Thread.Sleep(30);
                }
                tmrKeepEmRacingGwil.Enabled = true;
            };
            obControlsGwil.Add(fileButtonGwil);

            #endregion buttons

            #region racers

            //start the timer for a regular form update
            tmrKeepDrawingGwil.Enabled = false;
            tmrKeepEmRacingGwil.Enabled = true;
            //create an new panel, add 4 racers to it and add it to the form
            csPanelGwil mainPanelGwil = new csPanelGwil("pnlRacersGwil", new PointF(100, 0), new Size(400, 300));
            mainPanelGwil.BackgroundColorGwil = Color.Red;
            System.Security.Cryptography.RandomNumberGenerator rndGwil = System.Security.Cryptography.RandomNumberGenerator.Create();
            for (int dragracerCountGwil = 0; dragracerCountGwil < 4; dragracerCountGwil++)
            {
                var racerGwil = new csDragRacerGwil(dragracerCountGwil.ToString(), new PointF(dragracerCountGwil * 50, 0), new Size(40, 40), Color.Red);
                racerGwil.CreateRandomSpeedGwil();
                //create random colors
                //using cryptography random to avoid repeating numbers

                byte[] newColorGwil = new byte[4];
                rndGwil.GetBytes(newColorGwil);
                Color rndColor = Color.FromArgb(255, newColorGwil[1], newColorGwil[2], newColorGwil[3]);// rnd.Next(0, byte.MaxValue + 1), rnd.Next(0, byte.MaxValue + 1), rnd.Next(0, byte.MaxValue + 1));
                racerGwil.BackgroundColorGwil = rndColor;
                racerGwil.StartRaceGwil();
                mainPanelGwil.ChildsListGwil.Add(racerGwil);
                System.Threading.Thread.Sleep(30);
            }
            obControlsGwil.Add(mainPanelGwil);

            #endregion racers
        }

        #endregion Constructors

        #region Methods

        protected override void OnPaint(PaintEventArgs e)
        {
            //create an new graphics object from the existing e.graphics
            Graphics grGwil = e.Graphics;
            grGwil.Clear(this.BackColor);//clear it with the set background color of the form
            foreach (csBasicControlGwil controlGwil in obControlsGwil)
            {
                //calculate mouse position and check if mouse is in control than leave the control
                Point currentPosMouseGwil = new Point(MousePosition.X - this.Location.X, MousePosition.Y - this.Location.Y);
                if ((currentPosMouseGwil.X > Width || currentPosMouseGwil.Y > Height) && controlGwil.mouseEnteredGwil)
                    controlGwil.MouseLeaveGwil(this, new MouseEventArgs(MouseButtons.None, 0, currentPosMouseGwil.X, currentPosMouseGwil.Y, 0));
                //also if it thinks the mouse is down than tell it otherwise
                if ((currentPosMouseGwil.X > Width || currentPosMouseGwil.Y > Height) && controlGwil.mouseDownGwil)
                    controlGwil.MouseUpRaiseGwil(this, new MouseEventArgs(MouseButtons.None, 0, currentPosMouseGwil.X, currentPosMouseGwil.Y, 0));
                //force draw the control on the graphic
                controlGwil.DrawGwil(grGwil, true);
            }
            /*send message to the original on-paint that it can do its job
             * (we are first and than the original on-paint(that handles toolbox items etc.)
             * will do its run
             */
        }

        private void CheckChildsGwil(List<csBasicControlGwil> parentControlGwil, ref int controlCountGwil, ref bool updateScreenGwil, csPanelGwil parentGwil = null)
        {
            if (parentControlGwil != null)
            {
                foreach (csBasicControlGwil controlGwil in parentControlGwil)
                {
                    if (controlGwil != null)
                    {
                        Type typeOfControlGwil = controlGwil.GetType();
                        if (typeOfControlGwil == typeof(csDragRacerGwil))
                        {
                            csDragRacerGwil racerGwil = ((csDragRacerGwil)controlGwil);
                            racerGwil.DoMovementGwil(trackGwil, new Point(controlCountGwil * 50, 0));

                            controlCountGwil++;
                            if (racerGwil.KnowIsFinished == false && racerGwil.FinishedGwil == true)
                            {
                                racerGwil.KnowIsFinished = true;
                                racerGwil.EndRaceGwil();
                                System.Diagnostics.Debug.WriteLine(racerGwil.TimeRacedGwil);
                            }
                        }
                        else if (typeOfControlGwil == typeof(csPanelGwil))
                        {
                            CheckChildsGwil(((csPanelGwil)controlGwil).ChildsListGwil, ref controlCountGwil, ref updateScreenGwil, (csPanelGwil)controlGwil);
                        }
                        if (controlGwil.changedSinceDrawGwil == true)
                            updateScreenGwil = true;
                    }
                }
            }
        }

        private void frmMainGwil_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (csBasicControlGwil controlGwil in obControlsGwil)
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
            foreach (csBasicControlGwil controlGwil in obControlsGwil)
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
                        //if mouse is down or mouse is entered, but the mouse is not actually there reset to properties
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
            foreach (csBasicControlGwil controlGwil in obControlsGwil)
            {
                //check if mouse is with the current control
                if (e.X >= controlGwil.LocationGwil.X + graphicsOffsetGwil.X &&
                    e.X <= controlGwil.SizeGwil.Width + controlGwil.LocationGwil.X + graphicsOffsetGwil.X)
                {
                    if (e.Y >= controlGwil.LocationGwil.Y + graphicsOffsetGwil.Y &&
                         e.Y <= controlGwil.LocationGwil.Y + controlGwil.SizeGwil.Height + graphicsOffsetGwil.Y)
                    {
                        //if the mouse was not in the control before, raise the entered event first
                        if (controlGwil.mouseEnteredGwil == false)
                            controlGwil.MouseEnterRaiseGwil(sender, e);
                        //if so click a move event
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
                    somethingChangedGwil = true;//set our boolean to true so the form will invalidate
            }

            //if we changed something invalidate the form
            if (somethingChangedGwil == true)
                this.Invalidate();
        }

        private void frmMainGwil_MouseUp(object sender, MouseEventArgs e)
        {
            foreach (csBasicControlGwil controlGwil in obControlsGwil)
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
                foreach (csBasicControlGwil controlGwil in obControlsGwil)
                {
                    controlGwil.SizeGwil = new SizeF(
                        (float)(controlGwil.SizeGwil.Width * resizerWidthGwil),
                        (float)(controlGwil.SizeGwil.Height * resizerHeightGwil));
                }
                this.Invalidate();
                lastKnowSizeGwil = Size;
            }
        }

        private void tmrKeepDrawingGwil_Tick(object sender, EventArgs e)
        {
            //force an screen update
            this.Invalidate();
        }

        private void tmrKeepEmRacingGwil_Tick(object sender, EventArgs e)
        {
            int controlsCountGwil = 0;
            bool updateScreenGwil = false;
            CheckChildsGwil(obControlsGwil, ref controlsCountGwil, ref updateScreenGwil);
            if (updateScreenGwil == true)
                this.Invalidate();
        }

        #endregion Methods
    }
}