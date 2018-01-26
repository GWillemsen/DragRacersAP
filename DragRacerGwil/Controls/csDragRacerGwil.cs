using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DragRacerGwil.Controls
{
    public class csDragRacerGwil : csBasicControlGwil
    {
        #region Fields
        private Bitmap backgroundImageGwil = new Bitmap(1, 1);
        private DateTime endOfRaceGwil = new DateTime();
        private int finishPositionGwil = 0;
        private bool knowItsFinishedGwil = false;
        private Font obFontGwil = new Font("Times New Roman", 8);
        private string obRacerNameGwil = "";
        private bool passedHalfWayGwil = false;
        private bool reachedFinishGwil = false;
        private double speedGwil = 1;
        private DateTime startOfRaceGwil = new DateTime();
        private double traveldRouteGwil = 0;
        private int winsGwil = 0;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Creates an new basic drag racer class
        /// </summary>
        public csDragRacerGwil()
        {
            //do a full reset
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
        /// The position at which this racer has finished(1th, 2nd etc)
        /// </summary>
        public int FinishPositionGwil
        {
            //set or get the place the racer has
            get => finishPositionGwil;
            set => finishPositionGwil = value;
        }

        /// <summary>
        /// The font to use when drawing the text
        /// </summary>
        public Font FontGwil
        {
            get => obFontGwil;//returns the current font
            set => obFontGwil = value;//sets the new font
        }

        /// <summary>
        /// The new background image of the racer
        /// </summary>
        public Bitmap ImageGwil
        {
            get => backgroundImageGwil;//returns the background image
            set
            {
                //create an new bitmap with current racer size to put as background to minimize GPU overhead when drawing the form
                Bitmap obNewBmpGwil = new Bitmap(
                    ((int)SizeGwil.Width < 0) ? -((int)SizeGwil.Width) : (int)SizeGwil.Width,
                    ((int)SizeGwil.Height < 0) ? -((int)SizeGwil.Height) : (int)SizeGwil.Height);
                var destRectGwil = new Rectangle(0, 0, obNewBmpGwil.Width, obNewBmpGwil.Height);

                using (var obGraphicsGwil = Graphics.FromImage(obNewBmpGwil))
                {
                    //set quality to highest result
                    obGraphicsGwil.CompositingMode = CompositingMode.SourceCopy;
                    obGraphicsGwil.CompositingQuality = CompositingQuality.HighQuality;
                    obGraphicsGwil.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    obGraphicsGwil.SmoothingMode = SmoothingMode.HighQuality;
                    obGraphicsGwil.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    //resize the image and draw it
                    obGraphicsGwil.DrawImage(value, destRectGwil, 0, 0, value.Width, value.Height, GraphicsUnit.Pixel);
                }
                //set the resized image as background
                backgroundImageGwil = obNewBmpGwil;
            }
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
            get => obRacerNameGwil;//returns the racer name
            set
            {
                //check if we need to redraw on next update
                if (obRacerNameGwil != value)
                    changedSinceDrawGwil = true;
                obRacerNameGwil = value;
            }
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

        /// <summary>
        /// The number of wins the racer has
        /// </summary>
        public int WinsGwil
        {
            get => winsGwil; //returns the number of wins;
            set => winsGwil = value;//set the number of wins
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Creates an random speed for the current racer
        /// </summary>
        /// <param name="obOptionalPublicRandomGwil">
        /// The random to use in case the use of a public static(shared vb) is preferred
        /// </param>
        public void CreateRandomSpeedGwil(Random obOptionalPublicRandomGwil = null)
        {
            //check if we need to use the pulic random
            if (obOptionalPublicRandomGwil == null)
            {
                //create random class
                System.Random obRndGwil = new System.Random();
                //get a new random for the speed
                speedGwil = (obRndGwil.Next(100, 560) / 10);
                //speedGwil = ((obRndGwil.NextDouble() * 60) * 2);
            }
            else
            {
                //use the public random
                //speedGwil = ((obOptionalPublicRandomGwil.NextDouble() * 60) * 2);
                speedGwil = (obOptionalPublicRandomGwil.Next(100, 560) / 10);
            }
        }

        /// <summary>
        /// Move the racer further
        /// </summary>
        public void DoMovementGwil(PointF[] tracsGwil, Point offset)
        {
            if (FinishedGwil == false)
            {
                //move the drag racer the speed across the track
                traveldRouteGwil += speedGwil;
                if (traveldRouteGwil < tracsGwil.Length)
                {
                    changedSinceDrawGwil = true;
                    LocationGwil = new PointF(tracsGwil[(int)traveldRouteGwil].X + offset.X, tracsGwil[(int)traveldRouteGwil].Y + offset.Y);
                }
                else
                    reachedFinishGwil = true;

                if (traveldRouteGwil > tracsGwil.Length / 2 && passedHalfWayGwil == false)
                {
                    passedHalfWayGwil = true;
                    CreateRandomSpeedGwil();
                    csMessageHelperGwil.LogMessage("Creating new speed for racer: " + obRacerNameGwil, false);
                }
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

                //check if location needs to be calculated first and thus calculate the new size
                PointF drawLocGwil = LocationGwil;
                SizeF drawSizeGwil = SizeGwil;
                if (SizeGwil.Height < 0)
                {
                    drawLocGwil = new PointF(LocationGwil.X + SizeGwil.Width, LocationGwil.Y);
                    drawSizeGwil = new SizeF(-drawSizeGwil.Width, drawSizeGwil.Height);
                }

                if (SizeGwil.Height < 0)
                {
                    drawLocGwil = new PointF(drawLocGwil.X, drawLocGwil.Y + SizeGwil.Height);
                    drawSizeGwil = new SizeF(drawSizeGwil.Width, -drawSizeGwil.Height);
                }

                // draw a rectangle with color on the graphics as the racer
                obGrGwil.FillRectangle(new SolidBrush(BackgroundColorGwil), new RectangleF(drawLocGwil, drawSizeGwil));
                //obGrGwil.FillRectangle(new SolidBrush(BackgroundColorGwil), new RectangleF(drawLocGwil, drawSizeGwil));
                obGrGwil.DrawImage(backgroundImageGwil, drawLocGwil.X, drawLocGwil.Y, drawSizeGwil.Width, drawSizeGwil.Height);
                obGrGwil.DrawString(obRacerNameGwil, FontGwil, new SolidBrush(Color.Black), new PointF(drawLocGwil.X, drawLocGwil.Y + drawSizeGwil.Height));

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
            passedHalfWayGwil = false;
        }

        /// <summary>
        /// Set the start time of the racer
        /// </summary>
        public void StartRaceGwil()
        {
            //sets the start time of the race
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