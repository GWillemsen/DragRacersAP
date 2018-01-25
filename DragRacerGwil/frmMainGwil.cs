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
        private PointF[] trackGwil = new PointF[3900];

        #endregion Fields

        #region Constructors

        public frmMainGwil()
        {
            csMessageHelperGwil.AddMessageFilterGwil(this);
            //initialize the normal form items
            InitializeComponent();
            //create the track
            CreateTrackGwil(1.0);

            csMessageHelperGwil.LogMessage("Creating objects for the layout with their properties", true);


            #region menu strip
            //creating a new menu strip with buttons in it
            csPanelGwil obPanelGwil = new csPanelGwil("msrMainGwil", new PointF(0, 0), new Size(this.Width - 10, 26), Color.MediumVioletRed);
            csButtonGwil obSerialMonitorGwil = new csButtonGwil("btnSerialMonitorGwil", new PointF(55, 3), new Size(50, 20), "Serial");
            //set resize property's
            obPanelGwil.AutoResizeHeightGwil = false;
            obPanelGwil.AutoResizeWidthGwil = false;
            obPanelGwil.IsFormWidthGwil = true;
            obPanelGwil.SubstractFromFormWidthGwil = 20;

            #region File menu
            //create the file panel
            csPanelGwil obFileOptionsPanelGwil = new csPanelGwil("pnlFileOptionsGwil", new PointF(3, 27), new Size(80, 80));
            //set resize property's
            obFileOptionsPanelGwil.AutoResizeHeightGwil = false;
            obFileOptionsPanelGwil.AutoResizeWidthGwil = false;

            //create new buttons
            csButtonGwil obFileButtonGwil = new csButtonGwil("btnFileGwil", new Point(3, 3), new Size(50, 20), "File");
            csButtonGwil obAboutGwil = new csButtonGwil("btnAboutGwil", new PointF(3, 3), new Size(70, 20), "About");
            csButtonGwil obLocateBtnGwil = new csButtonGwil("btnLocateGwil", new PointF(3, 27), new Size(70, 20), "Location");
            csButtonGwil obExitBtnGwil = new csButtonGwil("btnExitGwil", new PointF(3, 53), new Size(70, 20), "Exit");


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
                    csMessageHelperGwil.LogMessage("Opening file tab", false);
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

            #region Serial monitor
            obSerialMonitorGwil.OnClickGwil += (obSenderGwil, obArgGwl) =>
            {
                frmSerialMonitor obSerialGwil = ((frmSerialMonitor)csMessageHelperGwil.GetSerialMonitorGwil());
                if (obSerialGwil.IsShownGwil == false)
                {
                    csMessageHelperGwil.LogMessage("Opening serial monitor");
                    ((frmSerialMonitor)csMessageHelperGwil.GetSerialMonitorGwil()).ShowFormGwil();
                }
                else
                {
                    csMessageHelperGwil.LogMessage("Closing serial monitor");
                    csMessageHelperGwil.GetSerialMonitorGwil().Close();
                }
            };
            obPanelGwil.ChildsListGwil.Add(obSerialMonitorGwil);

            #endregion Serial monitor



            //log init of menu strip and add the control to the control list
            csMessageHelperGwil.LogMessage("Adding the menu strip to the control list", true);
            obControlsGwil.Add(obPanelGwil);

            #endregion menu strip

            #region racing panel
            csMessageHelperGwil.LogMessage("Creating race main view panel", true);
            //the main panel for the race
            csPanelGwil obRacerPanelGwil = new csPanelGwil("pnlRaceOverviewGwil", new PointF(3, 52), new Size(this.Width - 22, this.Height - 70));
            obRacerPanelGwil.Z_indexGwil = 2;

            //set resize property's
            obRacerPanelGwil.IsFormWidthGwil = true;
            obRacerPanelGwil.IsFormHeightGwil = true;
            obRacerPanelGwil.SubstractFromFormHeightGwil = 70;
            obRacerPanelGwil.SubstractFromFormWidthGwil = 22;

            csMessageHelperGwil.LogMessage("Creating the race panel with its racers", true);
            
            //create an new panel, add 4 racers to it and add it to the form
            csPanelGwil obRacersGwil = new csPanelGwil("pnlRacersGwil", new PointF(0, 0), new Size(600, 230));

            #region race circuit
            csPanelGwil obFinishLinePanel = new csPanelGwil("pnlFinishLineGwil", new PointF(420, 0), new Size(60, 300));
            obFinishLinePanel.BackgroundImageGwil = new Bitmap(Bitmap.FromFile("..//..//img//finishline.jpg"));
            obFinishLinePanel.BackgroundColorGwil = Color.Black;
            obFinishLinePanel.AutoResizeHeightGwil = false;
            obFinishLinePanel.AutoResizeWidthGwil = false;
            obFinishLinePanel.Z_indexGwil = 1;
            
            #endregion

            #region racers

            // use the RNG from crypto to make it more random.
            System.Security.Cryptography.RandomNumberGenerator obRndGwil = System.Security.Cryptography.RandomNumberGenerator.Create();
            for (int dragracerCountGwil = 0; dragracerCountGwil < 4; dragracerCountGwil++)
            {
                //create new label that belongs to a certain label with the name, correct color and a font
                csLabelGwil obRacerLabel = new csLabelGwil("lblRacer" + dragracerCountGwil + "DataGwil", new Point(100, 230 + (dragracerCountGwil * 22)), new Size(500, 20));
                obRacerLabel.BackgroundColorGwil = Color.Transparent;
                obRacerLabel.TextGwil = "";
                obRacerLabel.FontGwil = new Font("Times New Roman", 8);
                //add the label to the control list
                obRacerPanelGwil.ChildsListGwil.Add(obRacerLabel);

                var obRacerGwil = new csDragRacerGwil("dragRacer" + dragracerCountGwil.ToString() + "Gwil", new PointF(dragracerCountGwil * 35, 0), new Size(-30, -30), Color.Red);
                obRacerGwil.CreateRandomSpeedGwil(obRndGwil);

                //create random colors using cryptography random to avoid repeating numbers and pseudo random generators(long story)
                byte[] newColorGwil = new byte[4];
                obRndGwil.GetBytes(newColorGwil);
                Color rndColor = Color.FromArgb(255, newColorGwil[1], newColorGwil[2], newColorGwil[3]);
                obRacerGwil.BackgroundColorGwil = rndColor;
                obRacerGwil.Z_indexGwil = 0;
                obRacersGwil.ChildsListGwil.Add(obRacerGwil);
                csMessageHelperGwil.LogMessage("Created racer " + obRacerGwil.ToString(), true);
                System.Threading.Thread.Sleep(20);
            }

            obRacersListGwil = obRacersGwil.ChildsListGwil.Clone();
            obRacersGwil.ChildsListGwil.Add(obFinishLinePanel);
            obRacersGwil.Z_indexGwil = 0;
            obRacerPanelGwil.ChildsListGwil.Add(obRacersGwil);;

            #endregion racers

            #region racer start
            //creating the start/stop race button
            csButtonGwil obRaceStartStopGwil = new csButtonGwil("btnStartStopGwil", new PointF(10, 270), new Size(80, 26), "Start race");

            obRaceStartStopGwil.OnClickGwil += (senderGwil, obArgGwil) =>
            {
                if (tmrKeepEmRacingGwil.Enabled == false)
                {
                    csMessageHelperGwil.LogMessage("Starting race...", false);
                    obRaceStartStopGwil.ContentGwil = "Racing";
                    int racerCountGwil = 1;
                    foreach (csDragRacerGwil obRacerGwil in obRacersListGwil)
                    {
                        obRacerGwil.ResetRacerToStartGwil(trackGwil[0], new PointF(0, 0));
                        obRacerGwil.CreateRandomSpeedGwil(obRndGwil);
                        obRacerGwil.StartRaceGwil();
                        csLabelGwil obRacerLabelGwil = (csLabelGwil)obControlsGwil.GetByNameGwil("lblRacer" + (racerCountGwil++ - 1) + "DataGwil");
                        if (obRacerLabelGwil != null)
                            obRacerLabelGwil.TextGwil = "";
                        csMessageHelperGwil.LogMessage("Reset racer: " + obRacerGwil.RacerNameGwil, true);
                        System.Threading.Thread.Sleep(30);
                    }
                    placeOfRacerGwil = 1;
                    tmrKeepEmRacingGwil.Enabled = true;
                    csMessageHelperGwil.LogMessage("Started race", false);
                }
            };

            obRaceStartStopGwil.AutoResizeHeightGwil = false;
            obRaceStartStopGwil.AutoResizeWidthGwil = false;

            #endregion racer start

            obRacerPanelGwil.ChildsListGwil.Add(obRaceStartStopGwil);
            obControlsGwil.Add(obRacerPanelGwil);


            #endregion racing panel

            #region Racer options
            csMessageHelperGwil.LogMessage("Creating race options panel", true);
            //the main panel for the race
            csPanelGwil optionsPanelGwil = new csPanelGwil("pnlRacerOptionsGwil", new PointF(3, 52), new Size(this.Width - 22, this.Height - 70));
            optionsPanelGwil.Z_indexGwil = 3;
            optionsPanelGwil.Visible = false;

            //set resize property's
            optionsPanelGwil.IsFormWidthGwil = true;
            optionsPanelGwil.IsFormHeightGwil = true;
            optionsPanelGwil.SubstractFromFormHeightGwil = 70;
            optionsPanelGwil.SubstractFromFormWidthGwil = 22;

            #region racer 1 options
            //create the panel with options for racer 1
            csPanelGwil obOptionsRacer1Gwil = new csPanelGwil("pnlRacer1Gwil", new PointF(3, 10), new Size(100,100));
            obOptionsRacer1Gwil.BackgroundColorGwil = obRacersListGwil[0].BackgroundColorGwil;
            obOptionsRacer1Gwil.Z_indexGwil = 1;

            csButtonGwil obChangeColorRacer1Gwil = new csButtonGwil("buttonChangeColorR1Gwil", new PointF(3,80), new Size(94, 18), "Color");
            obChangeColorRacer1Gwil.OnClickGwil += (obSenderGwil, argsGwil) =>
            {
                csMessageHelperGwil.LogMessage("Show color options for racer" + obRacersListGwil[0].NameGwil);
                //creating new color choosing dialog
                ColorDialog cldNewColorGwil = new ColorDialog();
                cldNewColorGwil.Color = obRacersListGwil[0].BackgroundColorGwil;
                //show dialog and the return result is oke than set the new color to the racer and options panel
                if (cldNewColorGwil.ShowDialog() == DialogResult.OK)
                {
                    obRacersListGwil[0].BackgroundColorGwil = cldNewColorGwil.Color;
                    obOptionsRacer1Gwil.BackgroundColorGwil = cldNewColorGwil.Color;
                    csMessageHelperGwil.LogMessage("The new color for racer " + obRacersListGwil[0].NameGwil + " is color: " + cldNewColorGwil.Color.Name);
                }
                else
                    csMessageHelperGwil.LogMessage("Canceled new color chosing for racer" + obRacersListGwil[0].NameGwil);

                //release memory objects from color dialog
                cldNewColorGwil.Dispose();
            };

            csButtonGwil obImgChoserR1Gwil = new csButtonGwil("btnChoseBackImgR1Gwil", new PointF(2, 55), new Size(94, 20), "Image");
            obImgChoserR1Gwil.OnClickGwil += (obSenderGwil, argsGwil) =>
            {
                csMessageHelperGwil.LogMessage("Choosing new image for racer" + obRacersListGwil[0].NameGwil);
                //create new open file dialog and set its filters
                OpenFileDialog fldImageChoserGwil = new OpenFileDialog();
                fldImageChoserGwil.Filter = "Images|*.png;*.jpg;*.jpeg;*.bmp;*.gif|All files|*.*";
                if(fldImageChoserGwil.ShowDialog() == DialogResult.OK)
                {
                    ((csDragRacerGwil)obRacersListGwil[0]).ImageGwil = new Bitmap(Image.FromFile(fldImageChoserGwil.FileName));
                    csMessageHelperGwil.LogMessage("The new image is set for racer: " + obRacersListGwil[0].NameGwil);
                }
                else
                    csMessageHelperGwil.LogMessage("Canceled choosing new image" + obRacersListGwil[0].NameGwil);
            };

            csBasicControlGwil obNameEditorR1Gwil = new csButtonGwil("btnChooseNewNameR1Gwil", new PointF(2, 30), new Size(94, 20), "Edit name");
            obNameEditorR1Gwil.OnClickGwil += (obSenderGwil, argGwil) =>
            {
                //create a message box like interface that ask for a input which is returned to the string and later set as the new racer name;
                string obNewNameGwil = Microsoft.VisualBasic.Interaction.InputBox("What is the name of this racer:", "Edit name", ((csDragRacerGwil)obRacersListGwil[0]).RacerNameGwil);
                csMessageHelperGwil.LogMessage("The racer with the old name: " + ((csDragRacerGwil)obRacersListGwil[0]).RacerNameGwil + " changed its name to: " + obNewNameGwil);
                ((csDragRacerGwil)obRacersListGwil[0]).RacerNameGwil = obNewNameGwil;
            };

            //add the buttons and panel to the control list of their parent
            obOptionsRacer1Gwil.ChildsListGwil.Add(obNameEditorR1Gwil);
            obOptionsRacer1Gwil.ChildsListGwil.Add(obImgChoserR1Gwil);
            obOptionsRacer1Gwil.ChildsListGwil.Add(obChangeColorRacer1Gwil);
            optionsPanelGwil.ChildsListGwil.Add(obOptionsRacer1Gwil);

            #endregion

            #region racer 2 options
            csPanelGwil obOptionsRacer2Gwil = new csPanelGwil("pnlRacer2Gwil", new PointF(110, 10), new Size(100, 100));
            obOptionsRacer2Gwil.BackgroundColorGwil = obRacersListGwil[1].BackgroundColorGwil;
            obOptionsRacer2Gwil.Z_indexGwil = 1;
            csButtonGwil obChangeColorRacer2Gwil = new csButtonGwil("buttonChangeColorR2Gwil", new PointF(3, 80), new Size(94, 18), "Color");
            obChangeColorRacer2Gwil.OnClickGwil += (obSenderGwil, argsGwil) =>
            {
                csMessageHelperGwil.LogMessage("Show color options for racer" + obRacersListGwil[1].NameGwil);
                //creating new color choosing dialog
                ColorDialog cldNewColorGwil = new ColorDialog();
                cldNewColorGwil.Color = obRacersListGwil[1].BackgroundColorGwil;
                //show dialog and the return result is oke than set the new color to the racer and options panel
                if (cldNewColorGwil.ShowDialog() == DialogResult.OK)
                {
                    obRacersListGwil[1].BackgroundColorGwil = cldNewColorGwil.Color;
                    obOptionsRacer2Gwil.BackgroundColorGwil = cldNewColorGwil.Color;
                    csMessageHelperGwil.LogMessage("The new color for racer " + obRacersListGwil[1].NameGwil + " is color: " + cldNewColorGwil.Color.Name);
                }
                else
                    csMessageHelperGwil.LogMessage("Canceled new color choosing for racer" + obRacersListGwil[1].NameGwil);
                //release memory objects from color dialog
                cldNewColorGwil.Dispose();
            };

            csButtonGwil obImgChoserR2Gwil = new csButtonGwil("btnChoseBackImgR2Gwil", new PointF(2, 55), new Size(94, 20), "Image");
            obImgChoserR2Gwil.OnClickGwil += (obSenderGwil, argsGwil) =>
            {
                csMessageHelperGwil.LogMessage("Choosing new image for racer" + obRacersListGwil[0].NameGwil);
                //create new open file dialog and set its filters
                OpenFileDialog fldImageChoserGwil = new OpenFileDialog();
                fldImageChoserGwil.Filter = "Images|*.png;*.jpg;*.jpeg;*.bmp;*.gif|All files|*.*";
                if (fldImageChoserGwil.ShowDialog() == DialogResult.OK)
                {
                    ((csDragRacerGwil)obRacersListGwil[1]).ImageGwil = new Bitmap(Image.FromFile(fldImageChoserGwil.FileName));
                    csMessageHelperGwil.LogMessage("The new image is set for racer: " + obRacersListGwil[1].NameGwil);
                }
                else
                    csMessageHelperGwil.LogMessage("Canceled choosing new image" + obRacersListGwil[1].NameGwil);
            };

            csBasicControlGwil obNameEditorR2Gwil = new csButtonGwil("btnChooseNewNameR2Gwil", new PointF(2, 30), new Size(94, 20), "Edit name");
            obNameEditorR2Gwil.OnClickGwil += (obSenderGwil, argGwil) =>
            {
                //create a message box like interface that ask for a input which is returned to the string and later set as the new racer name;
                string obNewNameGwil = Microsoft.VisualBasic.Interaction.InputBox("What is the name of this racer:", "Edit name", ((csDragRacerGwil)obRacersListGwil[1]).RacerNameGwil);
                csMessageHelperGwil.LogMessage("The racer with the old name: " + ((csDragRacerGwil)obRacersListGwil[1]).RacerNameGwil + " changed its name to: " + obNewNameGwil);
                ((csDragRacerGwil)obRacersListGwil[1]).RacerNameGwil = obNewNameGwil;
            };

            //add the buttons and panel to the control list of their parent
            obOptionsRacer2Gwil.ChildsListGwil.Add(obNameEditorR2Gwil);
            obOptionsRacer2Gwil.ChildsListGwil.Add(obImgChoserR2Gwil);
            obOptionsRacer2Gwil.ChildsListGwil.Add(obChangeColorRacer2Gwil);
            optionsPanelGwil.ChildsListGwil.Add(obOptionsRacer2Gwil);

            #endregion

            #region racer 3 options

            csPanelGwil obOptionsRacer3Gwil = new csPanelGwil("pnlRacer3Gwil", new PointF(3, 115), new Size(100, 100));
            obOptionsRacer3Gwil.BackgroundColorGwil = obRacersListGwil[2].BackgroundColorGwil;
            obOptionsRacer3Gwil.Z_indexGwil = 1;
            csButtonGwil obChangeColorRacer3Gwil = new csButtonGwil("buttonChangeColorR3Gwil", new PointF(3, 80), new Size(94, 18), "Color");
            obChangeColorRacer3Gwil.OnClickGwil += (obSenderGwil, argsGwil) =>
            {
                csMessageHelperGwil.LogMessage("Show color options for racer" + obRacersListGwil[2].NameGwil);
                //creating new color choosing dialog
                ColorDialog cldNewColorGwil = new ColorDialog();
                cldNewColorGwil.Color = obRacersListGwil[1].BackgroundColorGwil;
                //show dialog and the return result is oke than set the new color to the racer and options panel
                if (cldNewColorGwil.ShowDialog() == DialogResult.OK)
                {
                    obRacersListGwil[2].BackgroundColorGwil = cldNewColorGwil.Color;
                    obOptionsRacer3Gwil.BackgroundColorGwil = cldNewColorGwil.Color;
                    csMessageHelperGwil.LogMessage("The new color for racer " + obRacersListGwil[2].NameGwil + " is color: " + cldNewColorGwil.Color.Name);
                }
                else
                    csMessageHelperGwil.LogMessage("Canceled new color choosing for racer" + obRacersListGwil[2].NameGwil);
                //release memory objects from color dialog
                cldNewColorGwil.Dispose();
            };

            csButtonGwil obImgChoserR3Gwil = new csButtonGwil("btnChoseBackImgR3Gwil", new PointF(2, 55), new Size(94, 20), "Image");
            obImgChoserR3Gwil.OnClickGwil += (obSenderGwil, argsGwil) =>
            {
                csMessageHelperGwil.LogMessage("Choosing new image for racer" + obRacersListGwil[0].NameGwil);
                //create new open file dialog and set its filters
                OpenFileDialog fldImageChoserGwil = new OpenFileDialog();
                fldImageChoserGwil.Filter = "Images|*.png;*.jpg;*.jpeg;*.bmp;*.gif|All files|*.*";
                if (fldImageChoserGwil.ShowDialog() == DialogResult.OK)
                {
                    ((csDragRacerGwil)obRacersListGwil[2]).ImageGwil = new Bitmap(Image.FromFile(fldImageChoserGwil.FileName));
                    csMessageHelperGwil.LogMessage("The new image is set for racer: " + obRacersListGwil[2].NameGwil);
                }
                else
                    csMessageHelperGwil.LogMessage("Canceled choosing new image" + obRacersListGwil[2].NameGwil);
            };

            csBasicControlGwil obNameEditorR3Gwil = new csButtonGwil("btnChooseNewNameR3Gwil", new PointF(2, 30), new Size(94, 20), "Edit name");
            obNameEditorR3Gwil.OnClickGwil += (obSenderGwil, argGwil) =>
            {
                //create a message box like interface that ask for a input which is returned to the string and later set as the new racer name;
                string obNewNameGwil = Microsoft.VisualBasic.Interaction.InputBox("What is the name of this racer:", "Edit name", ((csDragRacerGwil)obRacersListGwil[2]).RacerNameGwil);
                csMessageHelperGwil.LogMessage("The racer with the old name: " + ((csDragRacerGwil)obRacersListGwil[2]).RacerNameGwil + " changed its name to: " + obNewNameGwil);
                ((csDragRacerGwil)obRacersListGwil[2]).RacerNameGwil = obNewNameGwil;
            };

            //add the buttons and panel to the control list of their parent
            obOptionsRacer3Gwil.ChildsListGwil.Add(obNameEditorR3Gwil);
            obOptionsRacer3Gwil.ChildsListGwil.Add(obImgChoserR3Gwil);
            obOptionsRacer3Gwil.ChildsListGwil.Add(obChangeColorRacer3Gwil);
            optionsPanelGwil.ChildsListGwil.Add(obOptionsRacer3Gwil);
            #endregion

            #region racer 4 options

            csPanelGwil obOptionsRacer4Gwil = new csPanelGwil("pnlRacer4Gwil", new PointF(110, 115), new Size(100, 100));
            obOptionsRacer4Gwil.BackgroundColorGwil = obRacersListGwil[3].BackgroundColorGwil;
            obOptionsRacer4Gwil.Z_indexGwil = 1;
            csButtonGwil obChangeColorRacer4Gwil = new csButtonGwil("buttonChangeColorR3Gwil", new PointF(3, 80), new Size(94, 18), "Color");
            obChangeColorRacer4Gwil.OnClickGwil += (obSenderGwil, argsGwil) =>
            {
                csMessageHelperGwil.LogMessage("Show color options for racer" + obRacersListGwil[3].NameGwil);
                //creating new color choosing dialog
                ColorDialog cldNewColorGwil = new ColorDialog();
                cldNewColorGwil.Color = obRacersListGwil[3].BackgroundColorGwil;
                //show dialog and the return result is oke than set the new color to the racer and options panel
                if (cldNewColorGwil.ShowDialog() == DialogResult.OK)
                {
                    obRacersListGwil[3].BackgroundColorGwil = cldNewColorGwil.Color;
                    obOptionsRacer4Gwil.BackgroundColorGwil = cldNewColorGwil.Color;
                    csMessageHelperGwil.LogMessage("The new color for racer " + obRacersListGwil[3].NameGwil + " is color: " + cldNewColorGwil.Color.Name);
                }
                else
                    csMessageHelperGwil.LogMessage("Canceled new color choosing for racer" + obRacersListGwil[3].NameGwil);
                //release memory objects from color dialog
                cldNewColorGwil.Dispose();
            };

            csButtonGwil obImgChoserR4Gwil = new csButtonGwil("btnChoseBackImgR4Gwil", new PointF(2, 55), new Size(94, 20), "Image");
            obImgChoserR4Gwil.OnClickGwil += (obSenderGwil, argsGwil) =>
            {
                csMessageHelperGwil.LogMessage("Choosing new image for racer" + obRacersListGwil[0].NameGwil);
                //create new open file dialog and set its filters
                OpenFileDialog fldImageChoserGwil = new OpenFileDialog();
                fldImageChoserGwil.Filter = "Images|*.png;*.jpg;*.jpeg;*.bmp;*.gif|All files|*.*";
                if (fldImageChoserGwil.ShowDialog() == DialogResult.OK)
                {
                    ((csDragRacerGwil)obRacersListGwil[3]).ImageGwil = new Bitmap(Image.FromFile(fldImageChoserGwil.FileName));
                    csMessageHelperGwil.LogMessage("The new image is set for racer: " + obRacersListGwil[3].NameGwil);
                }
                else
                    csMessageHelperGwil.LogMessage("Canceled choosing new image" + obRacersListGwil[3].NameGwil);
            };

            csBasicControlGwil obNameEditorR4Gwil = new csButtonGwil("btnChooseNewNameR4Gwil", new PointF(2, 30), new Size(94, 20), "Edit name");
            obNameEditorR4Gwil.OnClickGwil += (obSenderGwil, argGwil) =>
            {
                //create a message box like interface that ask for a input which is returned to the string and later set as the new racer name;
                string obNewNameGwil = Microsoft.VisualBasic.Interaction.InputBox("What is the name of this racer:", "Edit name", ((csDragRacerGwil)obRacersListGwil[3]).RacerNameGwil);
                csMessageHelperGwil.LogMessage("The racer with the old name: " + ((csDragRacerGwil)obRacersListGwil[3]).RacerNameGwil + " changed its name to: " + obNewNameGwil);
                ((csDragRacerGwil)obRacersListGwil[3]).RacerNameGwil = obNewNameGwil;
            };

            //add the buttons and panel to the control list of their parent
            obOptionsRacer4Gwil.ChildsListGwil.Add(obNameEditorR4Gwil);
            obOptionsRacer4Gwil.ChildsListGwil.Add(obImgChoserR4Gwil);
            obOptionsRacer4Gwil.ChildsListGwil.Add(obChangeColorRacer4Gwil);
            optionsPanelGwil.ChildsListGwil.Add(obOptionsRacer4Gwil);


            #endregion

            obControlsGwil.Add(optionsPanelGwil);

            #endregion

            #region tab control
            //create a button that shows the racer panel instead of the options panel
            csButtonGwil obBtnRacePanel = new csButtonGwil("btnShowRaceGwil", new PointF(3, 28), new Size(50, 20), "Race");
            obBtnRacePanel.OnClickGwil += (obSenderGwil, argsGwil) =>
            {
                //search for the 2 panels in the control list
                csPanelGwil obRacerPanelSearchGwil = (csPanelGwil)obControlsGwil.GetByNameGwil("pnlRaceOverviewGwil");
                csPanelGwil obOptionsPanelSearchGwil = (csPanelGwil)obControlsGwil.GetByNameGwil("pnlRacerOptionsGwil");
                //set the racer panels visibility to true if the search result isn't null
                if (obRacerPanelGwil != null)
                    obRacerPanelGwil.Visible = true;

                //set the racer options panels visibility to false if the search result isn't null
                if (obOptionsPanelSearchGwil != null)
                    obOptionsPanelSearchGwil.Visible = false;
            };
            obBtnRacePanel.Z_indexGwil = 2;
            obControlsGwil.Add(obBtnRacePanel);

            csButtonGwil obBtnOptionsPanel = new csButtonGwil("btnShowOptionsGwil", new PointF(65, 28), new Size(50, 20), "Options");
            obBtnOptionsPanel.OnClickGwil += (obSenderGwil, argsGwil) =>
            {
                //search for the 2 panels in the control list
                csPanelGwil obRacerPanelSearchGwil = (csPanelGwil)obControlsGwil.GetByNameGwil("pnlRaceOverviewGwil");
                csPanelGwil obOptionsPanelSearchGwil = (csPanelGwil)obControlsGwil.GetByNameGwil("pnlRacerOptionsGwil");
                //set the racer panels visibility to true if the search result isn't null
                if (obRacerPanelGwil != null)
                    obRacerPanelGwil.Visible = false;

                //set the racer options panels visibility to false if the search result isn't null
                if (obOptionsPanelSearchGwil != null)
                    obOptionsPanelSearchGwil.Visible = true;
            };
            obBtnOptionsPanel.Z_indexGwil = 2;
            obControlsGwil.Add(obBtnOptionsPanel);
            #endregion
            
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
             */

            base.OnPaint(e);
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
                            obRacerGwil.DoMovementGwil(trackGwil, new Point(0, controlCountGwil * 50));

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
                                if (obRacerLabelGwil != null)
                                    obRacerLabelGwil.TextGwil = string.Format("Racer {0} has ended as {1} with racing time {2}:{3} seconds:milliseconds", obRacerGwil.RacerNameGwil, placeOfRacerGwil, Math.Floor(obRacerGwil.TimeRacedGwil.TotalSeconds), obRacerGwil.TimeRacedGwil.Milliseconds);
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

        /// <summary>
        /// Creates the track for the racers
        /// </summary>
        /// <param name="scaleGwil">The scale to original size form</param>
        private void CreateTrackGwil(double scaleGwil = 1.0)
        {
            double xPosGwil = 0;
            //generate the track
            int extraSpacingGwil = (int)(35 * (scaleGwil));
            for (int trackNumberPointGwil = 0; trackNumberPointGwil < trackGwil.Length; trackNumberPointGwil += 1)
            {
                trackGwil[trackNumberPointGwil] = new PointF(extraSpacingGwil + (float)((trackNumberPointGwil / 8) * scaleGwil), extraSpacingGwil + (float)xPosGwil);


            }
            //List<PointF> obNewTrackGwil = new List<PointF>();
            //for(float angleGwil = 0; angleGwil < 360; angleGwil += 0.1F)
            //{
            //    obNewTrackGwil.Add(PointOnCircle(50, angleGwil, new PointF(100, 60)));
            //}
            //trackGwil = obNewTrackGwil.ToArray();
        }

        public static PointF PointOnCircle(float radius, float angleInDegrees, PointF origin)
        {
            // Convert from degrees to radians via multiplication by PI/180        
            float x = (float)(radius * Math.Cos(angleInDegrees * Math.PI / 180F)) + origin.X;
            float y = (float)(radius * Math.Sin(angleInDegrees * Math.PI / 180F)) + origin.Y;

            return new PointF(x, y);
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
                        if ((obControlToClickGwil == null || obControlToClickGwil.Z_indexGwil > obControlGwil.Z_indexGwil ) && obControlGwil.Visible == true)
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
                        //if z index is lower than make it the new object to preform on
                        if (obDownEventGwil == null || obDownEventGwil.Z_indexGwil > obControlGwil.Z_indexGwil)
                            obDownEventGwil = obControlGwil;
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
                //loop through all controls and resize them
                for (int indexControlsGwil = 0; indexControlsGwil < obControlsGwil.Count; indexControlsGwil++)
                {
                    //first set the auto resize and than the form widths because this way the form widths override the auto resize
                    csBasicControlGwil obControlGwil = obControlsGwil[indexControlsGwil];
                    SizeF oldSizeCurrentControlGwil = obControlGwil.SizeGwil;
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
                                (float)(obControlGwil.SizeGwil.Width * resizerWidthGwil), obControlGwil.SizeGwil.Height);
                        }

                        if (obControlGwil.AutoResizeHeightGwil == true)
                        {
                            obControlGwil.SizeGwil = new SizeF(
                                obControlGwil.SizeGwil.Width, (float)(obControlGwil.SizeGwil.Height * resizerHeightGwil));
                        }
                    }

                    //set the to form heights
                    if (obControlGwil.IsFormHeightGwil == true && obControlGwil.IsFormWidthGwil == true)
                    {
                        obControlGwil.SizeGwil = new SizeF(
                            this.Width - obControlGwil.SubstractFromFormWidthGwil,
                            this.Height - obControlGwil.SubstractFromFormHeightGwil);
                    }
                    else
                    {
                        if (obControlGwil.IsFormHeightGwil == true)
                            obControlGwil.SizeGwil = new SizeF(
                                obControlGwil.SizeGwil.Width,
                                this.Height - obControlGwil.SubstractFromFormHeightGwil);

                        if (obControlGwil.IsFormWidthGwil == true)
                            obControlGwil.SizeGwil = new SizeF(
                                this.Width - obControlGwil.SubstractFromFormWidthGwil,
                                obControlGwil.SizeGwil.Height);
                    }
                    csResizeEventgwil resizingEventGwil = new csResizeEventgwil(
                        resizerWidthGwil, resizerHeightGwil, lastKnowSizeGwil, Size, Width, Height, oldSizeCurrentControlGwil);
                    obControlGwil.RaiseResizeEventGwil(this, resizingEventGwil);
                }

                //redraw the form
                this.Invalidate();

                //calc new the new timer tick
                double newSizeFormGwil = Size.Width * Size.Height;
                double standartSizeFormGwil = 400000;
                double multiplyerGwil = ((standartSizeFormGwil / newSizeFormGwil) * 10);
                tmrKeepEmRacingGwil.Interval = (int)((10D * multiplyerGwil) / 10);

                try
                {
                    //create an new track wich is scaled
                    double racerGrewScaleGwil = (obRacersListGwil[0].SizeGwil.Width / 70);
                    CreateTrackGwil(-racerGrewScaleGwil);
                }
                catch (Exception exGwil)
                {
                    csMessageHelperGwil.LogMessage(exGwil.ToString(), true, Color.Red.ToArgb());
                }

                //set the last size to new value
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

        #endregion Methods
    }
}