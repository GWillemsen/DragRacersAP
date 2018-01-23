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
        public csControlListGwil obControlsGwil = new csControlListGwil();
        public List<PointF> obNewTrackGwil = new List<PointF>(6000000);
        
        //offset of the graphics on the screen
        private Point graphicsOffsetGwil = new Point(0, 0);
        private Size lastKnowSizeGwil = new Size(0, 0);
        private csControlListGwil obRacersListGwil = new csControlListGwil();
        private int placeOfRacerGwil = 1;
        private PointF[] trackGwil = new PointF[4000];
        
        #endregion Fields

        #region Constructors

        public frmMainGwil()
        {
            csMessageHelperGwil.AddMessageFilterGwil(this);
            //initialize the normal form items
            InitializeComponent();
            double xPosGwil = 0;
            bool downGwil = false;
            //generate the track
            for (int trackNumberPointGwil = 0; trackNumberPointGwil < trackGwil.Length; trackNumberPointGwil += 1)
            {
                trackGwil[trackNumberPointGwil] = new PointF((float)xPosGwil, (float)trackNumberPointGwil / 40);
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
                //trackGwil[trackNumberPointGwil] = new PointF((float)trackNumberPointGwil / 10, 20);
            }

            csMessageHelperGwil.LogMessage("Creating objects for the layout with their properties", true);

            #region menu strip
            //creating a new menu strip
            csPanelGwil obPanelGwil = new csPanelGwil("msrMainGwil", new PointF(0, 0), new Size(this.Width - 10, 26), Color.Red);
            obPanelGwil.AutoResizeHeightGwil = false;
            #region File menu
            //create the file panel
            csPanelGwil obFileOptionsPanelGwil = new csPanelGwil("pnlFileOptionsGwil", new PointF(3, 27), new Size(80, 80));
            obFileOptionsPanelGwil.HidesWhenClickedOutsideControlGwil = true;

            //create new buttons
            csButtonGwil obFileButtonGwil = new csButtonGwil("btnFileGwil", new Point(3, 3), new Size(50, 20), "File");
            csButtonGwil obSerialMonitorGwil = new csButtonGwil("btnSerialMonitorGwil", new PointF(55, 3), new Size(50, 20), "Serial");
            csButtonGwil obAboutGwil = new csButtonGwil("btnAboutGwil", new PointF(3, 3), new Size(70, 20), "About");
            csButtonGwil obLocateBtnGwil = new csButtonGwil("btnLocateGwil", new PointF(3, 27), new Size(70, 20), "Location");
            csButtonGwil obExitBtnGwil = new csButtonGwil("btnExitGwil", new PointF(3, 53), new Size(70, 20), "Exit");

            #region Serial monitor
            obSerialMonitorGwil.OnClickGwil += (obSenderGwil, obArgGwl) =>
            {
                csMessageHelperGwil.GetSerialMonitorGwil().Show();
            };
            obPanelGwil.ChildsListGwil.Add(obSerialMonitorGwil);
            #endregion

            #region file button
            csMessageHelperGwil.LogMessage("Adding the click event for the file options visibility panel and adding the button the menu strip", true);
            //add the on click event
            obFileButtonGwil.OnClickGwil += (senderGwil, obArgGwil) =>
            {
                csPanelGwil obFilePanelGwil = (csPanelGwil)obControlsGwil.GetByNameGwil("pnlFileOptionsGwil");
                if (obFilePanelGwil != null)
                {
                    obFilePanelGwil.Visible = !obFilePanelGwil.Visible;
                    if (obFilePanelGwil.changedSinceDrawGwil == true)
                        this.Invalidate();
                }
                if (obFilePanelGwil.Visible == true)
                    csMessageHelperGwil.LogMessage("Opening file tab",false);
                else
                    csMessageHelperGwil.LogMessage("Closing file tab", false);
            };
            
            //add it to the controls
            obPanelGwil.ChildsListGwil.Add(obFileButtonGwil);

            #endregion file button

            csMessageHelperGwil.LogMessage("Creating the click events for the about, location and exit button also adding them to the fileOptionsPanel", true);

            #region about button
            obAboutGwil.OnClickGwil += (obSenderGwil, obArgGwil) =>
            {
                //create the message string, log it, show it
                string obAboutTextGwil = "The is a simple game ";
                csMessageHelperGwil.LogMessage("Show the about message box with the text: " + obAboutTextGwil, false);
                MessageBox.Show(obAboutTextGwil);

                //close the file panel button again and draw the form again
                obFileOptionsPanelGwil.Visible = false;
                if (obFileOptionsPanelGwil.changedSinceDrawGwil == true)
                    this.Invalidate();
            };
            obFileOptionsPanelGwil.ChildsListGwil.Add(obAboutGwil);

            #endregion about button

            #region Location button
            obLocateBtnGwil.OnClickGwil += (senderGwil, obArgGwil) =>
            {
                csMessageHelperGwil.LogMessage("The location of the application is: " + Application.StartupPath, false);
                if (MessageBox.Show("The location of the application is: " + Application.StartupPath + "\n\n Do you want to open this location in file explorer?", "Location", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    System.Diagnostics.Process obApplicationPathGwil = new System.Diagnostics.Process();
                    obApplicationPathGwil.StartInfo.FileName = Application.StartupPath;
                    obApplicationPathGwil.Start();
                }
                //close the file panel button again and draw the form again
                obFileOptionsPanelGwil.Visible = false;
                if (obFileOptionsPanelGwil.changedSinceDrawGwil == true)
                    this.Invalidate();
            };
            obFileOptionsPanelGwil.ChildsListGwil.Add(obLocateBtnGwil);

            #endregion Location button

            #region Exit button
            obExitBtnGwil.OnClickGwil += (senderGwil, obArgGwil) =>
            {
                if (MessageBox.Show("Are you sure you want to exit the game?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    csMessageHelperGwil.LogMessage("Exiting game.", false);
                    //clearing the controls for a safe shutdown
                    tmrKeepEmRacingGwil.Enabled = false;
                    obControlsGwil.Clear();
                    //force an new draw update(which results in a empty screen)
                    Invalidate();
                    //exit the application
                    Application.Exit();
                }
            };

            obFileOptionsPanelGwil.ChildsListGwil.Add(obExitBtnGwil);

            #endregion Exit button

            csMessageHelperGwil.LogMessage("Preparing the file options panel to be adding to control list and adding it to it", true);
            //prepare the file options panel and add to the control list
            obFileOptionsPanelGwil.Visible = false;
            obControlsGwil.Add(obFileOptionsPanelGwil);

            #endregion File menu

            #region
            #endregion
            csMessageHelperGwil.LogMessage("Adding the menu strip to the control list", true);
            obControlsGwil.Add(obPanelGwil);

            #endregion menu strip

            #region racing panel
            csMessageHelperGwil.LogMessage("Creating race main view panel", true);
            //the main panel for the race
            csPanelGwil obRacerPanelGwil = new csPanelGwil("pnlRaceOverviewGwil", new PointF(3, 28), new Size(this.Width - 22, this.Height - 70));
            obRacerPanelGwil.Z_indexGwil = 2;

            csMessageHelperGwil.LogMessage("Creating the race panel with its racers", true);

            //create an new panel, add 4 racers to it and add it to the form
            csPanelGwil obRacersGwil = new csPanelGwil("pnlRacersGwil", new PointF(100, 0), new Size(400, 200));
            
            #region racers
            obRacersGwil.BackgroundColorGwil = Color.Red;

            // use the RNG from crypto to make it more random.
            System.Security.Cryptography.RandomNumberGenerator obRndGwil = System.Security.Cryptography.RandomNumberGenerator.Create();
            for (int dragracerCountGwil = 0; dragracerCountGwil < 4; dragracerCountGwil++)
            {
                csLabelGwil obRacerLabel = new csLabelGwil("lblRacer" + dragracerCountGwil + "DataGwil", new Point(100, 210 + (dragracerCountGwil * 22)), new Size(500, 20));
                obRacerLabel.BackgroundColorGwil = Color.Transparent;
                obRacerLabel.TextGwil = "hello s";
                obRacerLabel.FontGwil = new Font("Times New Roman", 8);
                obRacerPanelGwil.ChildsListGwil.Add(obRacerLabel);

                var obRacerGwil = new csDragRacerGwil("dragRacer" + dragracerCountGwil.ToString() + "Gwil", new PointF(dragracerCountGwil * 50, 0), new Size(40, 40), Color.Red);
                obRacerGwil.CreateRandomSpeedGwil();
                //create random colors using cryptography random to avoid repeating numbers
                byte[] newColorGwil = new byte[4];
                obRndGwil.GetBytes(newColorGwil);
                Color rndColor = Color.FromArgb(255, newColorGwil[1], newColorGwil[2], newColorGwil[3]);// rnd.Next(0, byte.MaxValue + 1), rnd.Next(0, byte.MaxValue + 1), rnd.Next(0, byte.MaxValue + 1));
                obRacerGwil.BackgroundColorGwil = rndColor;
                obRacersGwil.ChildsListGwil.Add(obRacerGwil);
                csMessageHelperGwil.LogMessage("Created racer " + obRacerGwil.ToString(), true);
                System.Threading.Thread.Sleep(30);
            }
            obRacersListGwil = obRacersGwil.ChildsListGwil;
            obRacerPanelGwil.ChildsListGwil.Add(obRacersGwil);

            #endregion racers

            #region racer start
            //creating the start/stop race button
            csButtonGwil obRaceStartStopGwil = new csButtonGwil("btnStartStopGwil", new PointF(10, 200), new Size(80, 26), "Start race");

            obRaceStartStopGwil.OnClickGwil += (senderGwil, obArgGwil) =>
            {
                if (tmrKeepEmRacingGwil.Enabled == false)
                {
                    csMessageHelperGwil.LogMessage("Starting race...", false);
                    obRaceStartStopGwil.ContentGwil = "Racing";
                    foreach (csDragRacerGwil obRacerGwil in obRacersGwil.ChildsListGwil)
                    {
                        obRacerGwil.ResetRacerToStartGwil(trackGwil[0], new PointF(0, 0));
                        obRacerGwil.CreateRandomSpeedGwil();
                        obRacerGwil.StartRaceGwil();
                        csMessageHelperGwil.LogMessage("Reset racer: " + obRacerGwil.RacerNameGwil, true);
                        System.Threading.Thread.Sleep(30);
                    }
                    placeOfRacerGwil = 1;
                    tmrKeepEmRacingGwil.Enabled = true;
                    csMessageHelperGwil.LogMessage("Started race", false);
                }
            };

            #endregion racer stats

            obRacerPanelGwil.ChildsListGwil.Add(obRaceStartStopGwil);
            obControlsGwil.Add(obRacerPanelGwil);

            #endregion racing panel
        }

        #endregion Constructors

        #region Methods

        protected override void OnPaint(PaintEventArgs e)
        {
            //create an new graphics object from the existing e.graphics
            Graphics obGrGwil = e.Graphics;
            obGrGwil.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
            obGrGwil.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low;
            
            obGrGwil.Clear(this.BackColor);//clear it with the set background color of the form

            obControlsGwil.Sort(new csSorter());
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
                if (obControlGwil.Visible == true)
                    obControlGwil.DrawGwil(obGrGwil, true);
            }
            /*send message to the original on-paint that it can do its job
             * (we are first and than the original on-paint(that handles toolbox items etc.)
             * will do its run
             */

            base.OnPaint(e);
        }

        private void frmMainGwil_Load(object sender, EventArgs e)
        {
            csMessageHelperGwil.AddMessageFilterGwil(this);
            frmSerialMonitor serialMGwil = new frmSerialMonitor();
            csMessageHelperGwil.SetSerialMonitorGwil(serialMGwil);
            csMessageHelperGwil.LogMessage("Created message logger and windows message filter to intercept form leave events", true);
        }

        private void frmMainGwil_MouseClick(object sender, MouseEventArgs e)
        {
            //control to preform click on
            csBasicControlGwil obControlToClickGwil = null;
            List<csButtonGwil> obMouseDoesntNeedClickingThisGwil = new List<csButtonGwil>();

            //bool to check if we need to invalidate the form
            bool invalidateFormGwil = false;

            csMessageHelperGwil.LogMessage("Created void publics for the need of check control weather they were are candidate for clicking and click the winner", true);
            foreach (csBasicControlGwil obControlGwil in obControlsGwil)
            {
                //check if the mouse is in the control bounds
                //and check that if the control should hide when click outside the control and it is visible that we hide it again
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
                //if the control needs to redraw set the redraw bool to true
                if (obControlGwil.changedSinceDrawGwil == true)
                    invalidateFormGwil = true;
            }

            //raise the controls click event
            if (obControlToClickGwil?.Visible == true)
            {
                obControlToClickGwil?.ClickGwil(this, e);
                csMessageHelperGwil.LogMessage("Clicking on control: " + obControlToClickGwil.NameGwil, true);
            }

            //if the loop said that there was a need to invalidate the form than do so
            if (invalidateFormGwil == true)
            {
                this.Invalidate();
            }
        }

        private void frmMainGwil_MouseDown(object sender, MouseEventArgs e)
        {
            //control to preform mouse down on
            csBasicControlGwil obDownEventGwil = null;
            //bool the check if we need to invalidate the form
            bool invalidateFormGwil = false;

            csMessageHelperGwil.LogMessage("Loop through all control check if mouse down press event should be raised on it", true);
            for(int indexControlsGwil=0; indexControlsGwil < obControlsGwil.Count; indexControlsGwil++)
            {
                csBasicControlGwil obControlGwil = obControlsGwil[indexControlsGwil];
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
                    else if (obControlGwil.mouseDownGwil == true || obControlGwil.mouseEnteredGwil == true)
                    {
                        //if mouse is down or mouse is entered, but the mouse is not actually there reset to properties
                        if (obControlGwil.mouseDownGwil == true) obControlGwil.MouseUpRaiseGwil(this,e);
                        if (obControlGwil.mouseEnteredGwil == true) obControlGwil.MouseLeaveGwil(this, e);                        
                    }                    
                }
                else if (obControlGwil.mouseDownGwil == true || obControlGwil.mouseEnteredGwil == true)
                {
                    //if mouse is down or mouse is entered, but the mouse is not actually there reset to properties
                    if (obControlGwil.mouseDownGwil == true) obControlGwil.MouseUpRaiseGwil(this, e);
                    if (obControlGwil.mouseEnteredGwil == true) obControlGwil.MouseLeaveGwil(this, e);
                }

                //check if the control change since last draw, otherwise set bool for update to true
                if (obControlGwil.changedSinceDrawGwil == true)
                    invalidateFormGwil = true;
            }

            //raise the mouse down event
            obDownEventGwil?.MouseDownRaiseGwil(this, e);
            //if the controls changed, invalidate the form
            if (invalidateFormGwil == true)
                this.Invalidate();
        }

        private void frmMainGwil_MouseMove(object sender, MouseEventArgs e)
        {
            //boolean the use when we want the invalidate our form
            bool invalidateFormGwil = false;
            //object to preform move on
            csBasicControlGwil obMoveControlGwil = null;
            //loop through all controls
            for (int controlIndexGwil = 0; controlIndexGwil < obControlsGwil.Count; controlIndexGwil++)
            {
                csBasicControlGwil obControlGwil = obControlsGwil[controlIndexGwil];
                if (obControlGwil.Visible == true)
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

                    //check if the control change since last draw, otherwise set bool for update to true
                    if (obControlGwil.changedSinceDrawGwil == true)
                        invalidateFormGwil = true;
                }
                else
                {
                    if (obControlGwil.mouseEnteredGwil == true)
                        //otherwise raise leave events
                        obControlGwil.MouseLeaveGwil(sender, e);
                }
            }

            //if the mouse was not in the control before, raise the entered event first
            if (obMoveControlGwil?.mouseEnteredGwil == false)
                obMoveControlGwil.MouseEnterRaiseGwil(sender, e);
            //if so click a move event
            obMoveControlGwil?.MouseMoveRaiseGwil(this, e);

            //if the controls changed, invalidate the form
            if (invalidateFormGwil == true)
                this.Invalidate();
        }

        private void frmMainGwil_MouseUp(object sender, MouseEventArgs e)
        {
            //bool the check if we need to redraw the form
            bool invalidateFormGwil = false;

            csMessageHelperGwil.LogMessage("Preforming mouse up event if mouse needs to be released", true);

            for (int indexControlsGwil = 0; indexControlsGwil < obControlsGwil.Count; indexControlsGwil++)
            {
                csBasicControlGwil obControlGwil = obControlsGwil[indexControlsGwil];
                //check if mouse is in the control
                if (e.X >= obControlGwil.LocationGwil.X + graphicsOffsetGwil.X &&
                    e.X <= obControlGwil.SizeGwil.Width + obControlGwil.LocationGwil.X + graphicsOffsetGwil.X)
                {
                    if (e.Y >= obControlGwil.LocationGwil.Y + graphicsOffsetGwil.Y &&
                         e.Y <= obControlGwil.LocationGwil.Y + obControlGwil.SizeGwil.Height + graphicsOffsetGwil.Y)
                    {
                        if (obControlGwil.mouseDownGwil == true)
                            //raise the mouse up event
                            obControlGwil.MouseUpRaiseGwil(this, e);
                            
                    }
                    else if (obControlGwil.mouseDownGwil == true || obControlGwil.mouseEnteredGwil == true)
                    {
                        //if mouse is down or mouse is entered, but the mouse is not actually there reset to properties
                        if (obControlGwil.mouseDownGwil == true) obControlGwil.MouseUpRaiseGwil(this, e);
                        if (obControlGwil.mouseEnteredGwil == true) obControlGwil.MouseLeaveGwil(this, e);
                    }
                }
                else if (obControlGwil.mouseDownGwil == true || obControlGwil.mouseEnteredGwil == true)
                {
                    //if mouse is down or mouse is entered, but the mouse is not actually there reset to properties
                    if (obControlGwil.mouseDownGwil == true) obControlGwil.MouseUpRaiseGwil(this, e);
                    if (obControlGwil.mouseEnteredGwil == true) obControlGwil.MouseLeaveGwil(this, e);
                }

                //check if the control change since last draw, otherwise set bool for update to true
                if (obControlGwil.changedSinceDrawGwil == true)
                    invalidateFormGwil = true;
            }

            //if the controls changed, invalidate the form
            if (invalidateFormGwil == true)
                this.Invalidate();
        }

        private void frmMainGwil_Resize(object sender, EventArgs e)
        {
            if (lastKnowSizeGwil.Width != Size.Width || lastKnowSizeGwil.Height != Size.Height)
            {
                csMessageHelperGwil.LogMessage("The size of the form change, resizing controls", true);
                double resizerWidthGwil = Size.Width / (double)lastKnowSizeGwil.Width;
                double resizerHeightGwil = Size.Height / (double)lastKnowSizeGwil.Height;
                for (int indexControlsGwil = 0; indexControlsGwil < obControlsGwil.Count; indexControlsGwil++)
                {
                    csBasicControlGwil obControlGwil = obControlsGwil[indexControlsGwil];
                    if (obControlGwil.AutoResizeHeightGwil == true && obControlGwil.AutoResizeWidthGwil == true)
                    {
                        obControlGwil.SizeGwil = new SizeF(
                            (float)(obControlGwil.SizeGwil.Width * resizerWidthGwil),
                            (float)(obControlGwil.SizeGwil.Height * resizerHeightGwil));
                    }
                    else
                    {
                        if (obControlGwil.AutoResizeWidthGwil == true)
                        {
                            obControlGwil.SizeGwil = new SizeF(
                                (float)(obControlGwil.SizeGwil.Width * resizerWidthGwil),obControlGwil.SizeGwil.Height);
                        }

                        if (obControlGwil.AutoResizeHeightGwil == true)
                        {
                            obControlGwil.SizeGwil = new SizeF(
                                obControlGwil.SizeGwil.Width, (float)(obControlGwil.SizeGwil.Height * resizerHeightGwil));
                        }
                    }
                }
                this.Invalidate();
                double newSizeFormGwil = Size.Width * Size.Height;
                double standartSizeFormGwil = 400000;
                double multiplyerGwil = ((standartSizeFormGwil / newSizeFormGwil ) * 10);
                tmrKeepEmRacingGwil.Interval = (int)((10D * multiplyerGwil) / 10  );
                

                lastKnowSizeGwil = Size;
            }
        }

        private void tmrKeepEmRacingGwil_Tick(object sender, EventArgs e)
        {
            csMessageHelperGwil.LogMessage("Timer tick", true);
            int obControlsCountGwil = 0;
            bool updateScreenGwil = false;
            //checking controls for racers to move across the track
            CheckChildsForRaceGwil(obControlsGwil, ref obControlsCountGwil, ref updateScreenGwil);
            if (updateScreenGwil == true)
                Invalidate();
            //count racers finished
            int racersFinishedGwil = 0;
            //move the racers across the track and check if they finished
            foreach (csDragRacerGwil obRacerGwil in obRacersListGwil)
            {
               // obRacerGwil.DoMovementGwil(trackGwil, new Point(racerCountGwil++ * 50, 0));
                //if the racer finished, and we did not know before that it finished,
                //let it know tat we know it finished but also and end the race. And finally log that the racer crossed the finish

                if (obRacerGwil.FinishedGwil == true)
                    racersFinishedGwil++;
            }
            if (racersFinishedGwil == obRacersListGwil.Count)
            {
                csMessageHelperGwil.LogMessage("Race has ended.", false);
                tmrKeepEmRacingGwil.Enabled = false;
                csButtonGwil obRaceBtnGwil = (csButtonGwil)obControlsGwil.GetByNameGwil("btnStartStopGwil");
                obRaceBtnGwil.ContentGwil = "Start race";
            }
        }

        /// <summary>
        /// Loop through all controls and sub control of the control list and find the racers to
        /// preform the MakeMove() on
        /// </summary>
        /// <param name="obParentControlGwil">The parent control list to check for child's</param>
        /// <param name="controlCountGwil">The integer that counts the total child's found</param>
        /// <param name="updateScreenGwil">The boolean if we need to invalidate the form once done</param>
        /// <param name="obParentGwil">(Optional)The parent control from which the control is</param>
        private void CheckChildsForRaceGwil(List<csBasicControlGwil> obParentControlGwil, ref int controlCountGwil, ref bool updateScreenGwil, csPanelGwil obParentGwil = null)
        {
            //check if parent control is not null
            if (obParentControlGwil != null)
            {
                for (int indexControlsGwil = 0; indexControlsGwil < obParentControlGwil.Count; indexControlsGwil++)
                {
                    csBasicControlGwil obControlGwil = obParentControlGwil[indexControlsGwil];
                    //check if current control is not null
                    if (obControlGwil != null)
                    {
                        //check if the type of the control if a racer, panel or something else
                        Type obTypeOfControlGwil = obControlGwil.GetType();
                        if (obTypeOfControlGwil == typeof(csDragRacerGwil))
                        {
                            //if its a racer make call the DoMovementGwil()
                            csDragRacerGwil obRacerGwil = ((csDragRacerGwil)obControlGwil);
                            obRacerGwil.DoMovementGwil(trackGwil, new Point(controlCountGwil * 50, 0));

                            controlCountGwil++;
                            //if the racer finished, and we did not know before that it finished,
                            //let it know tat we know it finished but also and end the race. And finally log that the racer crossed the finish
                            if (obRacerGwil.KnowIsFinishedGwil == false && obRacerGwil.FinishedGwil == true)
                            {
                                obRacerGwil.KnowIsFinishedGwil = true;
                                obRacerGwil.EndRaceGwil();
                                obRacerGwil.FinishPositionGwil = placeOfRacerGwil;
                                csMessageHelperGwil.LogMessage(string.Format("Racer {0} has ended as {1} with as total racing time {2} seconds", obRacerGwil.RacerNameGwil, placeOfRacerGwil, Math.Floor(obRacerGwil.TimeRacedGwil.TotalSeconds)));
                                csLabelGwil obRacerLabelGwil = (csLabelGwil)obControlsGwil.GetByNameGwil("lblRacer" + (placeOfRacerGwil - 1) + "DataGwil");
                                if(obRacerLabelGwil != null)
                                    obRacerLabelGwil.TextGwil = string.Format("Racer {0} has ended as {1} with racing time {2} seconds", obRacerGwil.RacerNameGwil, placeOfRacerGwil , Math.Floor(obRacerGwil.TimeRacedGwil.TotalSeconds));
                                placeOfRacerGwil++;
                            }
                        }
                        else if (obTypeOfControlGwil == typeof(csPanelGwil))
                        {
                            //if the type is a panel than check the child's of the panel
                            CheckChildsForRaceGwil(((csPanelGwil)obControlGwil).ChildsListGwil, ref controlCountGwil, ref updateScreenGwil, (csPanelGwil)obControlGwil);
                        }
                        //if we changed something during the check so the control requires and draw update make the parent control know
                        if (obControlGwil.changedSinceDrawGwil == true)
                            updateScreenGwil = true;
                    }
                }
            }
        }

        #endregion Methods
    }
}