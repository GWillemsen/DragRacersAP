﻿using System;
using System.Drawing;

namespace DragRacerGwil.Controls
{
    public class csDragRacerGwil : csBasicControlGwil
    {
        #region Fields
        private DateTime endOfRaceGwil = new DateTime();
        private bool knowItsFinishedGwil = false;
        private string racerNameGwil = "";
        private bool reachedFinshGwil = false;
        private double speedGwil = 1;
        private DateTime startOfRaceGwil = new DateTime();

        private double traveldRouteGwil = 0;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Creates an new basic drag racer class
        /// </summary>
        public csDragRacerGwil()
        {
            BasicControlFullResetGwil();
        }

        /// <summary>
        /// Creates an new basic drag racer class
        /// </summary>
        /// <param name="a_NameGwil">The name of the control(not visible)</param>
        public csDragRacerGwil(string a_NameGwil)
        {
            BasicControlFullResetGwil();
            //make everything default except the text
            NameGwil = a_NameGwil;
            endOfRaceGwil = new DateTime();
            racerNameGwil = "";
            reachedFinshGwil = false;
            speedGwil = 1;
            startOfRaceGwil = new DateTime();
            traveldRouteGwil = 0;
            knowItsFinishedGwil = false;
        }

        /// <summary>
        /// Creates an new basic drag racer class
        /// </summary>
        /// <param name="a_NameGwil">The name of the drag racer</param>
        /// <param name="a_LocationGwil">The new location of the drag racer</param>
        public csDragRacerGwil(string a_NameGwil, PointF a_LocationGwil)
        {
            BasicControlFullResetGwil();
            //make everything default except the text and location
            mouseDownGwil = false;
            mouseEnteredGwil = false;
            changedSinceDrawGwil = false;
            NameGwil = a_NameGwil;
            LocationGwil = a_LocationGwil;
            endOfRaceGwil = new DateTime();
            racerNameGwil = "";
            reachedFinshGwil = false;
            speedGwil = 1;
            startOfRaceGwil = new DateTime();
            traveldRouteGwil = 0;
            knowItsFinishedGwil = false;
        }

        /// <summary>
        /// Creates an new basic drag racer class
        /// </summary>
        /// <param name="a_NameGwil">The name of the drag racer</param>
        /// <param name="a_LocationGwil">The new location of the drag racer</param>
        /// <param name="a_SizeGwil">The new size of the drag racer</param>
        public csDragRacerGwil(string a_NameGwil, PointF a_LocationGwil, Size a_SizeGwil)
        {
            BasicControlFullResetGwil();
            //make everything default except the text, size and location
            mouseDownGwil = false;
            mouseEnteredGwil = false;
            changedSinceDrawGwil = false;
            NameGwil = a_NameGwil;
            LocationGwil = a_LocationGwil;
            SizeGwil = a_SizeGwil;
            endOfRaceGwil = new DateTime();
            racerNameGwil = "";
            reachedFinshGwil = false;
            speedGwil = 1;
            startOfRaceGwil = new DateTime();
            traveldRouteGwil = 0;
            knowItsFinishedGwil = false;
        }

        /// <summary>
        /// Creates an new basic drag racer class
        /// </summary>
        /// <param name="a_NameGwil">The name of the drag racer</param>
        /// <param name="a_LocationGwil">The new location of the drag racer</param>
        /// <param name="a_SizeGwil">The new size of the drag racer</param>
        /// <param name="a_BackgroundColorGwil">The background color of the drag racer</param>
        public csDragRacerGwil(string a_NameGwil, PointF a_LocationGwil, Size a_SizeGwil, Color a_BackgroundColorGwil)
        {
            BasicControlFullResetGwil();
            //make everything default except the text, size, location and background color
            mouseDownGwil = false;
            mouseEnteredGwil = false;
            changedSinceDrawGwil = false;
            NameGwil = a_NameGwil;
            LocationGwil = a_LocationGwil;
            SizeGwil = a_SizeGwil;
            BackgroundColorGwil = a_BackgroundColorGwil;
            endOfRaceGwil = new DateTime();
            racerNameGwil = "";
            reachedFinshGwil = false;
            speedGwil = 1;
            startOfRaceGwil = new DateTime();
            traveldRouteGwil = 0;
            knowItsFinishedGwil = false;
        }

        /// <summary>
        /// Creates an new basic drag racer class
        /// </summary>
        /// <param name="a_NameGwil">The name of the drag racer</param>
        /// <param name="a_LocationGwil">The new location of the drag racer</param>
        /// <param name="a_SizeGwil">The new size of the drag racer</param>
        /// <param name="a_BackgroundColorGwil">The background color of the drag racer</param>
        /// <param name="a_RacerNameGwil">The name of the racer</param>
        public csDragRacerGwil(string a_NameGwil, PointF a_LocationGwil, Size a_SizeGwil, Color a_BackgroundColorGwil, string a_RacerNameGwil)
        {
            BasicControlFullResetGwil();
            //make everything default except the text, size, location and background color
            mouseDownGwil = false;
            mouseEnteredGwil = false;
            changedSinceDrawGwil = false;
            NameGwil = a_NameGwil;
            LocationGwil = a_LocationGwil;
            SizeGwil = a_SizeGwil;
            BackgroundColorGwil = a_BackgroundColorGwil;
            endOfRaceGwil = new DateTime();
            racerNameGwil = a_RacerNameGwil;
            reachedFinshGwil = false;
            speedGwil = 1;
            startOfRaceGwil = new DateTime();
            traveldRouteGwil = 0;
            knowItsFinishedGwil = false;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// indication weather the racer has reached the finish
        /// </summary>
        public bool FinishedGwil
        {
            get => reachedFinshGwil;//return true if finished
        }

        /// <summary>
        /// (Optional) Weather the parent control know it has reached the end
        /// </summary>
        public bool KnowIsFinished
        {
            //get or set the boolean
            get => knowItsFinishedGwil;
            set => knowItsFinishedGwil = value;
        }

        /// <summary>
        /// The name of the racer
        /// </summary>
        public string RacerNameGwil
        {
            get => racerNameGwil;
            set => racerNameGwil = value;
        }

        /// <summary>
        /// The speed at which the racer races
        /// </summary>
        public double SpeedGwil
        {
            get => speedGwil;
            set => speedGwil = value;
        }

        /// <summary>
        /// The time the racer spent racing
        /// </summary>
        public TimeSpan TimeRacedGwil
        {
            //read-only, the time the racer raced
            get => endOfRaceGwil - startOfRaceGwil;
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Creates an random speed for the current racer
        /// </summary>
        public void CreateRandomSpeedGwil()
        {
            //create random class
            System.Random rndGwil = new System.Random();
            //get a new random for the speed
            speedGwil = rndGwil.Next(5, 11);
        }

        /// <summary>
        /// Move the racer further
        /// </summary>
        public void DoMovementGwil(PointF[] tracsGwil, Point offset)
        {
            if (FinishedGwil == false)
            {
                traveldRouteGwil += speedGwil;
                if (traveldRouteGwil < tracsGwil.Length)
                {
                    changedSinceDrawGwil = true;
                    LocationGwil = new PointF(tracsGwil[(int)traveldRouteGwil].X + offset.X, tracsGwil[(int)traveldRouteGwil].Y + offset.Y);
                }
                else
                    reachedFinshGwil = true;
            }
        }

        /// <summary>
        /// Draws the racer on the graphics
        /// </summary>
        /// <param name="grGwil">The graphic to draw on</param>
        /// <param name="forceRedrawGwil">Force a redraw weather necessary or not</param>
        public override void DrawGwil(Graphics grGwil, bool forceRedrawGwil = false)
        {
            if (changedSinceDrawGwil == true || forceRedrawGwil == true && Visible == true)
            {
                //save settings graphics, than set our own
                var prevSettingInterGwil = grGwil.InterpolationMode;
                var prevSettingSmoothGwil = grGwil.SmoothingMode;
                grGwil.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                grGwil.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                //draw a rectangle with color on the graphics as the racer
                grGwil.FillRectangle(new SolidBrush(BackgroundColorGwil), new RectangleF(LocationGwil, SizeGwil));

                //put back the stored settings
                grGwil.InterpolationMode = prevSettingInterGwil;
                grGwil.SmoothingMode = prevSettingSmoothGwil;

                //call base.draw so the base has a chance to draw it self again
                base.DrawGwil(grGwil);

                //finish off drawing
                changedSinceDrawGwil = false;
            }
        }

        /// <summary>
        /// Set the end time of the racer
        /// </summary>
        public void EndRaceGwil()
        {
            endOfRaceGwil = DateTime.Now;
        }

        /// <summary>
        /// Reset racer to the start
        /// </summary>
        /// <param name="startPointGwil"></param>
        /// <param name="offset"></param>
        public void ResetRacerToStartGwil(PointF startPointGwil, PointF offsetGwil)
        {
            LocationGwil = new PointF() { X = startPointGwil.X + offsetGwil.X, Y = startPointGwil.Y + offsetGwil.Y }; //reset the location of the racer
            reachedFinshGwil = false;//reset the finished boolean
            //reset the time when the race started and stopped
            startOfRaceGwil = new DateTime();
            endOfRaceGwil = new DateTime();
            KnowIsFinished = false;
            traveldRouteGwil = 0;
        }

        /// <summary>
        /// Set the start time of the racer
        /// </summary>
        public void StartRaceGwil()
        {
            startOfRaceGwil = DateTime.Now;
        }

        #endregion Methods
    }
}