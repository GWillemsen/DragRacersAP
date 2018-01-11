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

        private bool alreadyClosedItGwil = false;

        //offset of the graphics on the screen
        private Point graphicsOffsetGwil = new Point(0, 0);

        private Size lastKnowSizeGwil = new Size(0, 0);
        private csControlListGwil obRacersListGwil = new csControlListGwil();
        private int placeOfRacer = 1;
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
                    xPosGwil -= 1F;
                    if (xPosGwil <= 0)
                        downGwil = false;
                }
                else
                {
                    xPosGwil += 1F; ;
                    if (xPosGwil >= 200)
                        downGwil = true;
                }
            }

            MessageHelperGwil.LogMessage("Creating objects for the layout with their properties", true);

            #region menu strip
            //creating a new menu strip
            csPanelGwil obPanelGwil = new csPanelGwil("msrMainGwil", new PointF(3, 3), new Size(this.Width - 10, 26), Color.Red);

            #region File menu
            //create the file panel
            csPanelGwil obFileOptionsPanelGwil = new csPanelGwil("pnlFileOptionsGwil", new PointF(3, 30), new Size(80, 80));
            obFileOptionsPanelGwil.HidesWhenClickedOutsideControlGwil = true;

            //create new buttons
            csButtonGwil obFileButtonGwil = new csButtonGwil("btnFileGwil", new Point(3, 3), new Size(50, 20), "File");
            csButtonGwil obAboutGwil = new csButtonGwil("btnAboutGwil", new PointF(3, 3), new Size(70, 20), "About");
            csButtonGwil obLocateBtnGwil = new csButtonGwil("btnLocateGwil", new PointF(3, 27), new Size(70, 20), "Location");
            csButtonGwil obExitBtnGwil = new csButtonGwil("btnExitGwil", new PointF(3, 53), new Size(70, 20), "Exit");

            #region file button
            MessageHelperGwil.LogMessage("Adding the click event for the file options visibility panel and adding the button the menu strip", true);
            //add the on click event
            obFileButtonGwil.OnClickGwil += (senderGwil, argGwil) =>
            {
                csPanelGwil obFilePanelGwil = (csPanelGwil)obControlsGwil.GetByNameGwil("pnlFileOptionsGwil");
                if (obFilePanelGwil != null)
                {
                    obFilePanelGwil.Visible = !obFilePanelGwil.Visible;
                    if (obFilePanelGwil.changedSinceDrawGwil == true)
                        this.Invalidate();
                }
                if (obFilePanelGwil.Visible == true)
                    MessageHelperGwil.LogMessage("Opening file tab");
                else
                    MessageHelperGwil.LogMessage("Closing file tab");
            };
            //add it to the controls
            obPanelGwil.ChildsListGwil.Add(obFileButtonGwil);

            #endregion file button

            MessageHelperGwil.LogMessage("Creating the click events for the about, location and exit button also adding them to the fileOptionsPanel", true);

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
                if (MessageBox.Show("The location of the application is: " + Application.StartupPath + "\n\n Do you want to open this location in file explorer?", "Location", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    System.Diagnostics.Process obApplicationPathGwil = new System.Diagnostics.Process();
                    obApplicationPathGwil.StartInfo.FileName = Application.StartupPath;
                    obApplicationPathGwil.Start();
                }
            };
            obFileOptionsPanelGwil.ChildsListGwil.Add(obLocateBtnGwil);

            #endregion Location button

            #region Exit button
            obExitBtnGwil.OnClickGwil += (senderGwil, argsGwil) =>
            {
                if (MessageBox.Show("Are you sure you want to exit the game?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    MessageHelperGwil.LogMessage("Exiting game.");
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

            MessageHelperGwil.LogMessage("Preparing the file options panel to be adding to control list and adding it to it", true);
            //prepare the file options panel and add to the control list
            obFileOptionsPanelGwil.Visible = false;
            obControlsGwil.Add(obFileOptionsPanelGwil);

            #endregion File menu

            MessageHelperGwil.LogMessage("Adding the menu strip to the control list", true);
            obControlsGwil.Add(obPanelGwil);

            #endregion menu strip

            #region racing panel
            MessageHelperGwil.LogMessage("Creating race main view panel", true);
            //the main panel for the race
            csPanelGwil obRacerPanelGwil = new csPanelGwil("pnlRaceOverviewGwil", new PointF(30, 80), new Size(this.Width - 10, this.Height - 30));
            obRacerPanelGwil.Z_indexGwil = 2;

            MessageHelperGwil.LogMessage("Creating the race panel with its racers", true);

            //create an new panel, add 4 racers to it and add it to the form
            csPanelGwil obRacersGwil = new csPanelGwil("pnlRacersGwil", new PointF(100, 0), new Size(400, 300));

            #region racers
            obRacersGwil.BackgroundColorGwil = Color.Red;

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
                obRacersGwil.ChildsListGwil.Add(racerGwil);
                MessageHelperGwil.LogMessage("Created racer " + racerGwil.ToString(), true);
                System.Threading.Thread.Sleep(30);
            }
            obRacersListGwil = obRacersGwil.ChildsListGwil;

            obRacerPanelGwil.ChildsListGwil.Add(obRacersGwil);

            #endregion racers

            #region racer start
            //creating the start/stop race button
            csButtonGwil obRaceStartStopGwil = new csButtonGwil("btnStartStopGwil", new PointF(10, 200), new Size(80, 26));

            obRaceStartStopGwil.OnClickGwil += (senderGwil, argsGwil) =>
            {
                if (tmrKeepEmRacingGwil.Enabled == false)
                {
                    MessageHelperGwil.LogMessage("Starting race...");
                    obRaceStartStopGwil.ContentGwil = "Racing";
                    foreach (csDragRacerGwil obRacerGwil in obRacersGwil.ChildsListGwil)
                    {
                        obRacerGwil.ResetRacerToStartGwil(trackGwil[0], new PointF(0, 0));
                        obRacerGwil.CreateRandomSpeedGwil();
                        obRacerGwil.StartRaceGwil();
                        MessageHelperGwil.LogMessage("Reset racer: " + obRacerGwil.RacerNameGwil, true);
                        System.Threading.Thread.Sleep(30);
                    }
                    placeOfRacer = 1;
                    tmrKeepEmRacingGwil.Enabled = true;
                    MessageHelperGwil.LogMessage("Started race");
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
            MessageHelperGwil.AddMessageFilterGwil(this);
            frmSerialMonitor serialMGwil = new frmSerialMonitor();
            MessageHelperGwil.SetSerialMonitorGwil(serialMGwil);
            MessageHelperGwil.LogMessage("Created message logger and windows message filter to intercept form leave events", true);
        }

        private void frmMainGwil_MouseClick(object sender, MouseEventArgs e)
        {
            //control to preform click on
            csBasicControlGwil obControlToClickGwil = null;
            List<csButtonGwil> obMouseDoesntNeedClickingThisGwil = new List<csButtonGwil>();

            //bool to check if we need to invalidate the form
            bool invalidateFormGwil = false;

            MessageHelperGwil.LogMessage("Created void publics for the need of check control weather they were are candidate for clicking and click the winner", true);
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
                        MessageHelperGwil.LogMessage("Control " + obControlGwil.NameGwil + " is under the mouse. Preform check based on z-index for clicking on it", true);
                        //if z index is lower than make it the new object to preform on
                        if (obControlToClickGwil == null || obControlToClickGwil.Z_indexGwil > obControlGwil.Z_indexGwil)
                            obControlToClickGwil = obControlGwil;
                    }
                    else
                        MessageHelperGwil.LogMessage("Control " + obControlGwil.NameGwil + " was check for mouse click, this control was not in bounds", true);
                }
                else
                    MessageHelperGwil.LogMessage("Control " + obControlGwil.NameGwil + " was check for mouse click, this control was not in bounds", true);

                //if the control needs to redraw set the redraw bool to true
                if (obControlGwil.changedSinceDrawGwil == true)
                {
                    invalidateFormGwil = true;
                    MessageHelperGwil.LogMessage("Control " + obControlGwil.NameGwil + " change since last draw so make sure its updates on next draw", true);
                }
            }

            //raise the controls click event
            if (obControlToClickGwil?.Visible == true)
            {
                obControlToClickGwil?.ClickGwil(this, e);
                MessageHelperGwil.LogMessage("Clicking on control: " + obControlToClickGwil.NameGwil, true);
            }

            //if the loop said that there was a need to invalidate the form than do so
            if (invalidateFormGwil == true)
            {
                this.Invalidate();
                MessageHelperGwil.LogMessage("Invalidating the form", true);
            }
        }

        private void frmMainGwil_MouseDown(object sender, MouseEventArgs e)
        {
            //control to preform mouse down on
            csBasicControlGwil obDownEventGwil = null;
            //bool the check if we need to invalidate the form
            bool invalidateFormGwil = false;

            MessageHelperGwil.LogMessage("Loop through all control check if mouse down press event should be raised on it", true);
            foreach (csBasicControlGwil obControlGwil in obControlsGwil)
            {
                //check if mouse is in the control
                if (e.X >= obControlGwil.LocationGwil.X + graphicsOffsetGwil.X &&
                    e.X <= obControlGwil.SizeGwil.Width + obControlGwil.LocationGwil.X + graphicsOffsetGwil.X)
                {
                    if (e.Y >= obControlGwil.LocationGwil.Y + graphicsOffsetGwil.Y &&
                         e.Y <= obControlGwil.LocationGwil.Y + obControlGwil.SizeGwil.Height + graphicsOffsetGwil.Y)
                    {
                        MessageHelperGwil.LogMessage("The control: " + obControlGwil.NameGwil + " is under the mouse", true);
                        //if z index is lower than make it the new object to preform on
                        if (obDownEventGwil == null || obDownEventGwil.Z_indexGwil > obControlGwil.Z_indexGwil)
                        {
                            MessageHelperGwil.LogMessage("The control: " + obControlGwil.NameGwil + "is closer to the mouse than: " + obDownEventGwil?.NameGwil + ", so using the new one", true);
                            obDownEventGwil = obControlGwil;                            
                        }
                    }
                    else if (obControlGwil.mouseDownGwil == true || obControlGwil.mouseEnteredGwil == true)
                    {
                        //if mouse is down or mouse is entered, but the mouse is not actually there reset to properties
                        if (obControlGwil.mouseDownGwil == true) obControlGwil.MouseUpRaiseGwil(this,e);
                        if (obControlGwil.mouseEnteredGwil == true) obControlGwil.MouseLeaveGwil(this, e);
                        MessageHelperGwil.LogMessage("Control though mouse entered it but is actually not, reseted that properties", true);
                    }                    
                }
                else if (obControlGwil.mouseDownGwil == true || obControlGwil.mouseEnteredGwil == true)
                {
                    //if mouse is down or mouse is entered, but the mouse is not actually there reset to properties
                    if (obControlGwil.mouseDownGwil == true) obControlGwil.MouseUpRaiseGwil(this, e);
                    if (obControlGwil.mouseEnteredGwil == true) obControlGwil.MouseLeaveGwil(this, e);
                    MessageHelperGwil.LogMessage("Control though mouse entered it but is actually not, reseted that properties", true);
                }

                //check if the control change since last draw, otherwise set bool for update to true
                if (obControlGwil.changedSinceDrawGwil == true)
                {
                    invalidateFormGwil = true;
                    MessageHelperGwil.LogMessage("Control " + obControlGwil.NameGwil + " change since last draw so make sure its updates on next draw", true);
                }
            }

            //raise the mouse down event
            obDownEventGwil?.MouseDownRaiseGwil(this, e);
            if (obDownEventGwil != null)
                MessageHelperGwil.LogMessage("Raise the mouse down event on the control: " + obDownEventGwil.NameGwil, true);
            else
                MessageHelperGwil.LogMessage("Found no control under the mouse", true);

            //if the controls changed, invalidate the form
            if (invalidateFormGwil == true)
            {
                this.Invalidate();
                MessageHelperGwil.LogMessage("Invalidating the form", true);
            }
        }

        private void frmMainGwil_MouseMove(object sender, MouseEventArgs e)
        {
            //boolean the use when we want the invalidate our form
            bool invalidateFormGwil = false;

            //object to preform move on
            csBasicControlGwil obMoveControlGwil = null;
            MessageHelperGwil.LogMessage("Checking control if the mouse move should be raised in their control", true);
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
                            MessageHelperGwil.LogMessage("The control: " + obControlGwil.NameGwil + " is under the mouse", true);
                            //if z index is lower than make it the new object to preform on
                            if (obMoveControlGwil == null || obMoveControlGwil.Z_indexGwil > obControlGwil.Z_indexGwil)
                                obMoveControlGwil = obControlGwil;
                        }
                        else if (obControlGwil.mouseEnteredGwil == true)
                        {
                            //otherwise raise leave events
                            obControlGwil.MouseLeaveGwil(sender, e);
                            MessageHelperGwil.LogMessage("The control: " + obControlGwil.NameGwil + "thought the mouse was in the control, raised the mouse leave event", true);
                        }
                    }
                    else
                    {
                        if (obControlGwil.mouseEnteredGwil == true)
                        {
                            //otherwise raise leave events
                            obControlGwil.MouseLeaveGwil(sender, e);
                            MessageHelperGwil.LogMessage("The control: " + obControlGwil.NameGwil + "thought the mouse was in the control, raised the mouse leave event", true);
                        }
                    }

                    //check if the control change since last draw, otherwise set bool for update to true
                    if (obControlGwil.changedSinceDrawGwil == true)
                    {
                        invalidateFormGwil = true;
                        MessageHelperGwil.LogMessage("Control " + obControlGwil.NameGwil + " change since last draw so make sure its updates on next draw", true);
                    }
                }
                else
                {
                    if (obControlGwil.mouseEnteredGwil == true)
                    {
                        //otherwise raise leave events
                        obControlGwil.MouseLeaveGwil(sender, e);
                        MessageHelperGwil.LogMessage("The control: " + obControlGwil.NameGwil + "thought the mouse was in the control, raised the mouse leave event", true);
                    }
                }
            }

            //if the mouse was not in the control before, raise the entered event first
            if (obMoveControlGwil?.mouseEnteredGwil == false)
            {
                MessageHelperGwil.LogMessage("The control: " + obMoveControlGwil.NameGwil + "did not know the mouse inside its bound, raising the mouse enter event of the control", true);
                obMoveControlGwil.MouseEnterRaiseGwil(sender, e);
            }
            //if so click a move event
            obMoveControlGwil?.MouseMoveRaiseGwil(this, e);
            if (obMoveControlGwil != null)
                MessageHelperGwil.LogMessage("Raise the mouse move event on the control: " + obMoveControlGwil.NameGwil, true);
            else
                MessageHelperGwil.LogMessage("Found no control under the mouse that can be clicked on", true);

            //if the controls changed, invalidate the form
            if (invalidateFormGwil == true)
            {
                this.Invalidate();
                MessageHelperGwil.LogMessage("Invalidating the form", true);
            }
        }

        private void frmMainGwil_MouseUp(object sender, MouseEventArgs e)
        {
            //bool the check if we need to redraw the form
            bool invalidateFormGwil = false;

            foreach (csBasicControlGwil obControlGwil in obControlsGwil)
            {
                //check if mouse is in the control
                if (e.X >= obControlGwil.LocationGwil.X + graphicsOffsetGwil.X &&
                    e.X <= obControlGwil.SizeGwil.Width + obControlGwil.LocationGwil.X + graphicsOffsetGwil.X)
                {
                    if (e.Y >= obControlGwil.LocationGwil.Y + graphicsOffsetGwil.Y &&
                         e.Y <= obControlGwil.LocationGwil.Y + obControlGwil.SizeGwil.Height + graphicsOffsetGwil.Y)
                    {
                        if (obControlGwil.mouseDownGwil == true)
                        {
                            //raise the mouse up event
                            obControlGwil.MouseUpRaiseGwil(this, e);
                            MessageHelperGwil.LogMessage("The control " + obControlGwil.NameGwil + " thought the mouse was down, raised the mouse up event", true);
                        }
                    }
                    else if (obControlGwil.mouseDownGwil == true || obControlGwil.mouseEnteredGwil == true)
                    {
                        //if mouse is down or mouse is entered, but the mouse is not actually there reset to properties
                        if (obControlGwil.mouseDownGwil == true) obControlGwil.MouseUpRaiseGwil(this, e);
                        if (obControlGwil.mouseEnteredGwil == true) obControlGwil.MouseLeaveGwil(this, e);
                        MessageHelperGwil.LogMessage("Control though mouse entered it but is actually not, reseted that properties", true);
                    }
                }
                else if (obControlGwil.mouseDownGwil == true || obControlGwil.mouseEnteredGwil == true)
                {
                    //if mouse is down or mouse is entered, but the mouse is not actually there reset to properties
                    if (obControlGwil.mouseDownGwil == true) obControlGwil.MouseUpRaiseGwil(this, e);
                    if (obControlGwil.mouseEnteredGwil == true) obControlGwil.MouseLeaveGwil(this, e);
                    MessageHelperGwil.LogMessage("Control though mouse entered it but is actually not, reseted that properties", true);
                }

                //check if the control change since last draw, otherwise set bool for update to true
                if (obControlGwil.changedSinceDrawGwil == true)
                {
                    invalidateFormGwil = true;
                    MessageHelperGwil.LogMessage("Control " + obControlGwil.NameGwil + " change since last draw so make sure its updates on next draw", true);
                }
            }

            //if the controls changed, invalidate the form
            if (invalidateFormGwil == true)
            {
                this.Invalidate();
                MessageHelperGwil.LogMessage("Invalidating the form", true);
            }
        }

        private void frmMainGwil_Resize(object sender, EventArgs e)
        {
            if (lastKnowSizeGwil.Width != Size.Width || lastKnowSizeGwil.Height != Size.Height)
            {
                MessageHelperGwil.LogMessage("The size of the form change, resizing controls", true);
                double resizerWidthGwil = Size.Width / (double)lastKnowSizeGwil.Width;
                double resizerHeightGwil = Size.Height / (double)lastKnowSizeGwil.Height;
                foreach (csBasicControlGwil obControlGwil in obControlsGwil)
                {
                    if (obControlGwil.AutoResizeGwil == true)
                    {
                        MessageHelperGwil.LogMessage("Resizing control: " + obControlGwil.NameGwil + " with multipliers: " + Math.Round(resizerWidthGwil, 2) + ":" + Math.Round(resizerHeightGwil, 2) + "(width:height)", true);
                        obControlGwil.SizeGwil = new SizeF(
                            (float)(obControlGwil.SizeGwil.Width * resizerWidthGwil),
                            (float)(obControlGwil.SizeGwil.Height * resizerHeightGwil));
                    }
                }
                MessageHelperGwil.LogMessage("Invalidating form so controls appear");
                this.Invalidate();
                lastKnowSizeGwil = Size;
            }
        }

        private void tmrKeepEmRacingGwil_Tick(object sender, EventArgs e)
        {
            MessageHelperGwil.LogMessage("Timer tick", false);
            int obControlsCountGwil = 0;
            bool updateScreenGwil = false;
            //checking controls for racers to move across the track
            CheckChildsForRaceGwil(obControlsGwil, ref obControlsCountGwil, ref updateScreenGwil);
            if (updateScreenGwil == true)
                Invalidate();
            //int racerCountGwil = 0;
            bool allRacersFinished = true;
            //move the racers across the track and check if they finished
            foreach (csDragRacerGwil obRacerGwil in obRacersListGwil)
            {
               // obRacerGwil.DoMovementGwil(trackGwil, new Point(racerCountGwil++ * 50, 0));
                //if the racer finished, and we did not know before that it finished,
                //let it know tat we know it finished but also and end the race. And finally log that the racer crossed the finish
                if (obRacerGwil.KnowIsFinished == false && obRacerGwil.FinishedGwil == true)
                {
                    obRacerGwil.KnowIsFinished = true;
                    obRacerGwil.EndRaceGwil(ref placeOfRacer);
                    MessageHelperGwil.LogMessage(string.Format("Racer {0} has ended as {1} with as total racing time {2}", obRacerGwil.RacerNameGwil, placeOfRacer, obRacerGwil.TimeRacedGwil.ToString()));
                    placeOfRacer++;
                }

                if (obRacerGwil.FinishedGwil == false)
                    allRacersFinished = false;
            }
            if (allRacersFinished == true)
            {
                tmrKeepEmRacingGwil.Enabled = false;
                csButtonGwil obRaceBtnGwil = (csButtonGwil)obControlsGwil.GetByNameGwil("btnStartStopGwil");
                obRaceBtnGwil.ContentGwil = "Start";
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
                foreach (csBasicControlGwil obControlGwil in obParentControlGwil)
                {
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
                            if (obRacerGwil.KnowIsFinished == false && obRacerGwil.FinishedGwil == true)
                            {
                                obRacerGwil.KnowIsFinished = true;
                                obRacerGwil.EndRaceGwil(ref placeOfRacer);
                                MessageHelperGwil.LogMessage(string.Format("Racer {0} has ended as {1} with as total racing time {2}", obRacerGwil.RacerNameGwil, placeOfRacer, obRacerGwil.TimeRacedGwil.ToString()));
                                placeOfRacer++;
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