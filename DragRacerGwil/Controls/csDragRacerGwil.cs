using System;
using System.Drawing;

namespace DragRacerGwil.Controls
{
    public class csDragRacerGwil : csBasicControlGwil
    {
        #region Fields
        private DateTime endOfRaceGwil = new DateTime();
        private int finishPositionGwil = 0;
        private bool knowItsFinishedGwil = false;
        private string obRacerNameGwil = "";
        private bool reachedFinishGwil = false;
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
            obRacerNameGwil = a_NameGwil;
            reachedFinishGwil = false;
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
            obRacerNameGwil = a_NameGwil;
            reachedFinishGwil = false;
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
            obRacerNameGwil = a_NameGwil;
            reachedFinishGwil = false;
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
            obRacerNameGwil = a_NameGwil;
            reachedFinishGwil = false;
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
            obRacerNameGwil = a_RacerNameGwil;
            reachedFinishGwil = false;
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
            get => reachedFinishGwil;//return true if finished
        }

        /// <summary>
        /// The position at which this racer has finished
        /// </summary>
        public int FinishPositionGwil
        {
            get => finishPositionGwil;
            set => finishPositionGwil = value;
        }

        /// <summary>
        /// (Optional) Weather the parent control know it has reached the end
        /// </summary>
        public bool KnowIsFinishedGwil
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
            get => obRacerNameGwil;
            set => obRacerNameGwil = value;
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
        /// <param name="obOptionalPublicRandomGwil">The random to use in case the use of a public static(shared vb) is preferred</param>
        public void CreateRandomSpeedGwil(Random obOptionalPublicRandomGwil = null)
        {
            //check if we need to use the pulic random
            if (obOptionalPublicRandomGwil == null)
            {
                //create random class
                System.Random rndGwil = new System.Random();
                //get a new random for the speed
                speedGwil = rndGwil.Next(5, 56);
            }
            else
            {
                byte[] longDataGwil = new byte[8];
                obOptionalPublicRandomGwil.NextBytes(longDataGwil);
                ulong rawNumberGwil = BitConverter.ToUInt64(longDataGwil, 0);
                double scaleGwil = (double)(56 - 5) / UInt64.MaxValue;
                speedGwil = (5 + (rawNumberGwil * scaleGwil));                
            }
        }

        /// <summary>
        /// Creates an random speed for the current racer
        /// </summary>
        /// <param name="obOptionalPublicRandomGwil">The random to use in case the use of a public static(shared vb) is preferred</param>
        public void CreateRandomSpeedGwil(System.Security.Cryptography.RandomNumberGenerator obOptionalPublicRandomGwil)
        {
            //create the 8 bytes for the 64 bit ulong
            byte[] longDataGwil = new byte[8];
            obOptionalPublicRandomGwil.GetBytes(longDataGwil);
            //convert the 8 bytes to an ulong
            ulong rawNumberGwil = BitConverter.ToUInt64(longDataGwil, 0);
            //calc the scale for the conversion
            double scaleGwil = (double)(56 - 5) / UInt64.MaxValue;
            //set the new number
            speedGwil = (5 + (rawNumberGwil * scaleGwil));
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
                    reachedFinishGwil = true;
            }
        }

        /// <summary>
        /// Draws the racer on the graphics
        /// </summary>
        /// <param name="obGrGwil">The graphic to draw on</param>
        /// <param name="forceRedrawGwil">Force a redraw weather necessary or not</param>
        public override void DrawGwil(Graphics obGrGwil, bool forceRedrawGwil = false)
        {
            if (changedSinceDrawGwil == true || forceRedrawGwil == true && Visible == true)
            {
                //save settings graphics, than set our own
                var prevSettingInterGwil = obGrGwil.InterpolationMode;
                var prevSettingSmoothGwil = obGrGwil.SmoothingMode;
                obGrGwil.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                obGrGwil.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                //draw a rectangle with color on the graphics as the racer
                obGrGwil.FillRectangle(new SolidBrush(BackgroundColorGwil), new RectangleF(LocationGwil, SizeGwil));

                //put back the stored settings
                obGrGwil.InterpolationMode = prevSettingInterGwil;
                obGrGwil.SmoothingMode = prevSettingSmoothGwil;

                //call base.draw so the base has a chance to draw it self again
                base.DrawGwil(obGrGwil);

                //finish off drawing
                changedSinceDrawGwil = false;
            }
        }

        /// <summary>
        /// Set the end time of the racer
        /// </summary>
        public void EndRaceGwil()
        {
            //set end of race to now
            endOfRaceGwil = DateTime.Now;
        }

        /// <summary>
        /// Reset racer to the start
        /// </summary>
        /// <param name="startPointGwil">The point at which the race starts as a base point</param>
        /// <param name="offset">The amount of pixels the offset from the base point is</param>
        public void ResetRacerToStartGwil(PointF startPointGwil, PointF offsetGwil)
        {
            LocationGwil = new PointF() { X = startPointGwil.X + offsetGwil.X, Y = startPointGwil.Y + offsetGwil.Y }; //reset the location of the racer
            reachedFinishGwil = false;//reset the finished boolean
            //reset the time when the race started and stopped
            startOfRaceGwil = new DateTime();
            endOfRaceGwil = new DateTime();
            KnowIsFinishedGwil = false;
            traveldRouteGwil = 0;
        }

        /// <summary>
        /// Set the start time of the racer
        /// </summary>
        public void StartRaceGwil()
        {
            startOfRaceGwil = DateTime.Now;
        }

        /// <summary>
        /// Return the most important information show as a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "{" + string.Format("{0}, {1}; {3} at {2}", NameGwil, SpeedGwil, LocationGwil, SizeGwil) + "}";
        }

        #endregion Methods
    }
}