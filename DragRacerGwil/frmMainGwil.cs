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
        public List<PointF> obNewTrackGwil = new List<PointF>(6000000);

        //list of controls to draw
        public csControlListGwil obControlsGwil = new csControlListGwil();

        //offset of the graphics on the screen
        private Point graphicsOffsetGwil = new Point(0, 0);

        private Size lastKnowSizeGwil = new Size(0, 0);
        private PointF[] trackGwil = new PointF[2000];

        #endregion Fields

        #region Constructors

        public frmMainGwil()
        {
            MessageHelperGwil.AddMessageFilterGwil(this);
            //initialize the normal form items
            InitializeComponent();
            double xPosGwil = 0;
            bool downGwil = false;
            //generate the track
            for (int trackNumberPointGwil = 0; trackNumberPointGwil < trackGwil.Length; trackNumberPointGwil += 1)
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
            #region menu strip

            #region File menu
            //create the file panel
            csPanelGwil obFileOptionsPanelGwil = new csPanelGwil("pnlFileOptionsGwil", new PointF(3, 25), new Size(80, 80));

            //create new buttons
            csButtonGwil obFileButtonGwil = new csButtonGwil("btnFileGwil", new Point(3, 3), new Size(50, 20), "File");
            csButtonGwil obAboutGwil = new csButtonGwil("btnAboutGwil", new PointF(3, 3), new Size(70, 20), "About");
            csButtonGwil obLocateBtnGwil = new csButtonGwil("btnLocateGwil", new PointF(3, 27), new Size(70, 20), "Location");
            csButtonGwil obExitBtnGwil = new csButtonGwil("btnExitGwil", new PointF(3, 53), new Size(70, 20), "Exit");

            #region file button
            //add the on click event
            obFileButtonGwil.OnClickGwil += (senderGwil, argGwil) =>
            {
                csPanelGwil obFilePanelGwil = (csPanelGwil)obControlsGwil.GetByNameGwil("pnlFileOptionsGwil");
                if (obFilePanelGwil != null)
                {
                    obFilePanelGwil.Visible = !obFilePanelGwil.Visible;
                    this.Invalidate();
                }
            };
            //add it to the controls
            obControlsGwil.Add(obFileButtonGwil);

            #endregion file button

            #region about button
            obAboutGwil.OnClickGwil += (senderGwil, argGwil) => 
            {
                string obAboutTextGwil = "The is a simple game ";
                MessageHelperGwil.LogMessage("Show the about message box with the text: " + obAboutTextGwil);
                MessageBox.Show(obAboutTextGwil);
            };
            obFileOptionsPanelGwil.ChildsListGwil.Add(obAboutGwil);
            #endregion about button

            #region Location button
            obLocateBtnGwil.OnClickGwil += (senderGwil, argGwil) =>
            {
                MessageHelperGwil.LogMessage("The location of the application is: " + Application.StartupPath);
                if(MessageBox.Show("The location of the application is: " + Application.StartupPath + "\n\n Do you want to open this location in file explorer?", "Location", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    System.Diagnostics.Process obApplicationPathGwil = new System.Diagnostics.Process();
                    obApplicationPathGwil.StartInfo.FileName = Application.StartupPath;
                    obApplicationPathGwil.Start();
                }
            };
            obFileOptionsPanelGwil.ChildsListGwil.Add(obLocateBtnGwil);
            #endregion

            #region Exit button
            obExitBtnGwil.OnClickGwil += (senderGwil, argsGwil) =>
            {
                if(MessageBox.Show("Are you sure you want to exit the game?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    tmrKeepEmRacingGwil.Enabled = false;
                    obControlsGwil.Clear();
                    this.Invalidate();
                    Application.Exit();
                }
            };
            obFileOptionsPanelGwil.ChildsListGwil.Add(obExitBtnGwil);
            #endregion

            //prepare the file options panel and add to the control list
            obFileOptionsPanelGwil.Visible = false;
            obControlsGwil.Add(obFileOptionsPanelGwil);

            #endregion File menu

            #endregion
            #region racers


            //create an new panel, add 4 racers to it and add it to the form
            csPanelGwil obMainRacerPanelGwil = new csPanelGwil("pnlRacersGwil", new PointF(100, 0), new Size(400, 300));
            obMainRacerPanelGwil.BackgroundColorGwil = Color.Red;

            // use the RNG from crypto to make it more random.
            System.Security.Cryptography.RandomNumberGenerator obRndGwil = System.Security.Cryptography.RandomNumberGenerator.Create();
            for (int dragracerCountGwil = 0; dragracerCountGwil < 4; dragracerCountGwil++)
            {
                var racerGwil = new csDragRacerGwil("dragRacer" + dragracerCountGwil.ToString(), new PointF(dragracerCountGwil * 50, 0), new Size(40, 40), Color.Red);
                racerGwil.CreateRandomSpeedGwil();
                //create random colors using cryptography random to avoid repeating numbers
                byte[] newColorGwil = new byte[4];
                obRndGwil.GetBytes(newColorGwil);
                Color rndColor = Color.FromArgb(255, newColorGwil[1], newColorGwil[2], newColorGwil[3]);// rnd.Next(0, byte.MaxValue + 1), rnd.Next(0, byte.MaxValue + 1), rnd.Next(0, byte.MaxValue + 1));
                racerGwil.BackgroundColorGwil = rndColor;
                racerGwil.StartRaceGwil();
                obMainRacerPanelGwil.ChildsListGwil.Add(racerGwil);
                System.Threading.Thread.Sleep(30);
            }
            obControlsGwil.Add(obMainRacerPanelGwil);

            #endregion racers
        }

        #endregion Constructors

        #region Methods

        protected override void OnPaint(PaintEventArgs e)
        {
            //create an new graphics object from the existing e.graphics
            Graphics obGrGwil = e.Graphics;
            obGrGwil.Clear(this.BackColor);//clear it with the set background color of the form
            foreach (csBasicControlGwil obControlGwil in obControlsGwil)
            {
                //calculate mouse position and check if mouse is in control than leave the control
                Point currentPosMouseGwil = new Point(MousePosition.X - this.Location.X, MousePosition.Y - this.Location.Y);
                if ((currentPosMouseGwil.X > Width || currentPosMouseGwil.Y > Height) && obControlGwil.mouseEnteredGwil)
                    obControlGwil.MouseLeaveGwil(this, new MouseEventArgs(MouseButtons.None, 0, currentPosMouseGwil.X, currentPosMouseGwil.Y, 0));
                //also if it thinks the mouse is down than tell it otherwise
                if ((currentPosMouseGwil.X > Width || currentPosMouseGwil.Y > Height) && obControlGwil.mouseDownGwil)
                    obControlGwil.MouseUpRaiseGwil(this, new MouseEventArgs(MouseButtons.None, 0, currentPosMouseGwil.X, currentPosMouseGwil.Y, 0));
                //force draw the control on the graphic if it is visible
                if(obControlGwil.Visible == true)
                    obControlGwil.DrawGwil(obGrGwil, true);
            }
            /*send message to the original on-paint that it can do its job
             * (we are first and than the original on-paint(that handles toolbox items etc.)
             * will do its run
             */
            base.OnPaint(e);
        }

        private void CheckChildsGwil(List<csBasicControlGwil> obParentControlGwil, ref int controlCountGwil, ref bool updateScreenGwil, csPanelGwil obParentGwil = null)
        {
            if (obParentControlGwil != null)
            {
                foreach (csBasicControlGwil obControlGwil in obParentControlGwil)
                {
                    if (obControlGwil != null)
                    {
                        Type obTypeOfControlGwil = obControlGwil.GetType();
                        if (obTypeOfControlGwil == typeof(csDragRacerGwil))
                        {
                            csDragRacerGwil obRacerGwil = ((csDragRacerGwil)obControlGwil);
                            obRacerGwil.DoMovementGwil(trackGwil, new Point(controlCountGwil * 50, 0));

                            controlCountGwil++;
                            if (obRacerGwil.KnowIsFinished == false && obRacerGwil.FinishedGwil == true)
                            {
                                obRacerGwil.KnowIsFinished = true;
                                obRacerGwil.EndRaceGwil();
                                System.Diagnostics.Debug.WriteLine(obRacerGwil.TimeRacedGwil);
                            }
                        }
                        else if (obTypeOfControlGwil == typeof(csPanelGwil))
                        {
                            CheckChildsGwil(((csPanelGwil)obControlGwil).ChildsListGwil, ref controlCountGwil, ref updateScreenGwil, (csPanelGwil)obControlGwil);
                        }
                        if (obControlGwil.changedSinceDrawGwil == true)
                            updateScreenGwil = true;
                    }
                }
            }
        }

        private void frmMainGwil_MouseClick(object sender, MouseEventArgs e)
        {
            //control to preform click on
            csBasicControlGwil obControlToClickGwil = null;

            foreach (csBasicControlGwil obControlGwil in obControlsGwil)
            {
                //check if the mouse is in the control bounds
                if (e.X >= obControlGwil.LocationGwil.X + graphicsOffsetGwil.X &&
                    e.X <= obControlGwil.SizeGwil.Width + obControlGwil.LocationGwil.X + graphicsOffsetGwil.X)
                {
                    if (e.Y >= obControlGwil.LocationGwil.Y + graphicsOffsetGwil.Y &&
                         e.Y <= obControlGwil.LocationGwil.Y + obControlGwil.SizeGwil.Height + graphicsOffsetGwil.Y)
                    {
                        //if z index is lower than make it the new object to preform on
                        if (obControlToClickGwil == null || obControlToClickGwil.Z_indexGwil > obControlGwil.Z_indexGwil)
                            obControlToClickGwil = obControlGwil;
                    }
                }
            }

            //raise the controls click event
            if (obControlToClickGwil?.Visible == true)
                obControlToClickGwil?.ClickGwil(this, e);
        }

        private void frmMainGwil_MouseDown(object sender, MouseEventArgs e)
        {
            //control to preform mouse down on
            csBasicControlGwil obDownEventGwil = null;

            foreach (csBasicControlGwil obControlGwil in obControlsGwil)
            {
                //check if mouse is in the control
                if (e.X >= obControlGwil.LocationGwil.X + graphicsOffsetGwil.X &&
                    e.X <= obControlGwil.SizeGwil.Width + obControlGwil.LocationGwil.X + graphicsOffsetGwil.X)
                {
                    if (e.Y >= obControlGwil.LocationGwil.Y + graphicsOffsetGwil.Y &&
                         e.Y <= obControlGwil.LocationGwil.Y + obControlGwil.SizeGwil.Height + graphicsOffsetGwil.Y)
                    {
                        //if z index is lower than make it the new object to preform on
                        if (obDownEventGwil == null || obDownEventGwil.Z_indexGwil > obControlGwil.Z_indexGwil)
                            obDownEventGwil = obControlGwil;
                    }
                    else
                    {
                        //if mouse is down or mouse is entered, but the mouse is not actually there reset to properties
                        if (obControlGwil.mouseDownGwil == true || obControlGwil.mouseEnteredGwil == true)
                        {
                            obControlGwil.mouseDownGwil = false;
                            obControlGwil.mouseEnteredGwil = false;
                        }
                    }
                }
                else
                {
                    //if mouse is down or mouse is entered, but the mouse is not actually there reset to properties
                    if (obControlGwil.mouseDownGwil == true || obControlGwil.mouseEnteredGwil == true)
                    {
                        obControlGwil.mouseDownGwil = false;
                        obControlGwil.mouseEnteredGwil = false;
                    }
                }
            }

            //raise the mouse down event
            obDownEventGwil?.MouseDownRaiseGwil(this, e);
        }

        private void frmMainGwil_MouseMove(object sender, MouseEventArgs e)
        {
            //boolean the use when we want the invalidate our form
            bool somethingChangedGwil = false;

            //object to preform move on
            csBasicControlGwil obMoveControlGwil = null;

            //loop through all controls
            foreach (csBasicControlGwil obControlGwil in obControlsGwil)
            {
                //check if mouse is with the current control
                if (e.X >= obControlGwil.LocationGwil.X + graphicsOffsetGwil.X &&
                    e.X <= obControlGwil.SizeGwil.Width + obControlGwil.LocationGwil.X + graphicsOffsetGwil.X)
                {
                    if (e.Y >= obControlGwil.LocationGwil.Y + graphicsOffsetGwil.Y &&
                         e.Y <= obControlGwil.LocationGwil.Y + obControlGwil.SizeGwil.Height + graphicsOffsetGwil.Y)
                    {
                        //if z index is lower than make it the new object to preform on
                        if (obMoveControlGwil == null || obMoveControlGwil.Z_indexGwil > obControlGwil.Z_indexGwil)
                            obMoveControlGwil = obControlGwil;
                    }
                    else if (obControlGwil.mouseEnteredGwil == true)
                        //otherwise raise leave events
                        obControlGwil.MouseLeaveGwil(sender, e);
                }
                else
                {
                    if (obControlGwil.mouseEnteredGwil == true)
                        //otherwise raise leave events
                        obControlGwil.MouseLeaveGwil(sender, e);
                }

                //check if the control has detected that is should redraw
                if (obControlGwil.changedSinceDrawGwil == true)
                    somethingChangedGwil = true;//set our boolean to true so the form will invalidate
            }

            //if the mouse was not in the control before, raise the entered event first
            if (obMoveControlGwil?.mouseEnteredGwil == false)
                obMoveControlGwil.MouseEnterRaiseGwil(sender, e);
            //if so click a move event
            obMoveControlGwil?.MouseMoveRaiseGwil(this, e);

            //if we changed something invalidate the form
            if (somethingChangedGwil == true)
                this.Invalidate();
        }

        private void frmMainGwil_MouseUp(object sender, MouseEventArgs e)
        {
            foreach (csBasicControlGwil obControlGwil in obControlsGwil)
            {
                //check if mouse is in the control
                if (e.X >= obControlGwil.LocationGwil.X + graphicsOffsetGwil.X &&
                    e.X <= obControlGwil.SizeGwil.Width + obControlGwil.LocationGwil.X + graphicsOffsetGwil.X)
                {
                    if (e.Y >= obControlGwil.LocationGwil.Y + graphicsOffsetGwil.Y &&
                         e.Y <= obControlGwil.LocationGwil.Y + obControlGwil.SizeGwil.Height + graphicsOffsetGwil.Y)
                    {
                        //raise the mouse up event
                        obControlGwil.MouseUpRaiseGwil(this, e);
                    }
                    else
                    {
                        //if mouse is down or mouse is entered, but the mouse is not actually there reset to properties
                        if (obControlGwil.mouseDownGwil == true || obControlGwil.mouseEnteredGwil == true)
                        {
                            obControlGwil.mouseDownGwil = false;
                            obControlGwil.mouseEnteredGwil = false;
                        }
                    }
                }
                else
                {
                    //if mouse is down or mouse is entered, but the mouse is not actually there reset to properties
                    if (obControlGwil.mouseDownGwil == true || obControlGwil.mouseEnteredGwil == true)
                    {
                        obControlGwil.mouseDownGwil = false;
                        obControlGwil.mouseEnteredGwil = false;
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
                foreach (csBasicControlGwil obControlGwil in obControlsGwil)
                {
                    if (obControlGwil.AutoResizeGwil == true)
                    {
                        obControlGwil.SizeGwil = new SizeF(
                            (float)(obControlGwil.SizeGwil.Width * resizerWidthGwil),
                            (float)(obControlGwil.SizeGwil.Height * resizerHeightGwil));
                    }
                }
                this.Invalidate();
                lastKnowSizeGwil = Size;
            }
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

        private void frmMainGwil_Load(object sender, EventArgs e)
        {
            MessageHelperGwil.AddMessageFilterGwil(this);
            frmSerialMonitor serialMGwil = new frmSerialMonitor();
            MessageHelperGwil.SetSerialMonitorGwil(serialMGwil);
            serialMGwil.Show();
        }
    }
}