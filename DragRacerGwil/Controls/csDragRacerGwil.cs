using System;
using System.Drawing;

namespace DragRacerGwil.Controls
{
    public class csDragRacerGwil : csBasicControlGwil
    {
        #region Fields

        private string racerNameGwil;
        private double speedGwil = 1;
        private double traveldRouteGwil = 0;
        private bool reachedFinshGwil = false;
        private TimeSpan startOfRaceGwil = new TimeSpan();
        private TimeSpan endOfRaceGwil = new TimeSpan();
        #endregion Fields

        #region Constructors

        /// <summary>
        /// Creates an new basic drag racer class
        /// </summary>
        public csDragRacerGwil()
        {
            FullResetGwil();
        }

        /// <summary>
        /// Creates an new basic drag racer class
        /// </summary>
        /// <param name="a_NameGwil">The name of the drag racer</param>
        public csDragRacerGwil(string a_NameGwil)
        {
            FullResetGwil();
            //make everything default except the text
            mouseDownGwil = false;
            mouseEnteredGwil = false;
            changedSinceDrawGwil = false;
            NameGwil = a_NameGwil;
        }

        /// <summary>
        /// Creates an new basic drag racer class
        /// </summary>
        /// <param name="a_NameGwil">The name of the drag racer</param>
        /// <param name="a_LocationGwil">The new location of the drag racer</param>
        public csDragRacerGwil(string a_NameGwil, PointF a_LocationGwil)
        {
            FullResetGwil();
            //make everything default except the text and location
            mouseDownGwil = false;
            mouseEnteredGwil = false;
            changedSinceDrawGwil = false;
            NameGwil = a_NameGwil;
            LocationGwil = a_LocationGwil;
        }

        /// <summary>
        /// Creates an new basic drag racer class
        /// </summary>
        /// <param name="a_NameGwil">The name of the drag racer</param>
        /// <param name="a_LocationGwil">The new location of the drag racer</param>
        /// <param name="a_SizeGwil">The new size of the drag racer</param>
        public csDragRacerGwil(string a_NameGwil, PointF a_LocationGwil, Size a_SizeGwil)
        {
            FullResetGwil();
            //make everything default except the text, size and location
            mouseDownGwil = false;
            mouseEnteredGwil = false;
            changedSinceDrawGwil = false;
            NameGwil = a_NameGwil;
            LocationGwil = a_LocationGwil;
            SizeGwil = a_SizeGwil;
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
            FullResetGwil();
            //make everything default except the text, size, location and background color
            mouseDownGwil = false;
            mouseEnteredGwil = false;
            changedSinceDrawGwil = false;
            NameGwil = a_NameGwil;
            LocationGwil = a_LocationGwil;
            SizeGwil = a_SizeGwil;
            BackgroundColorGwil = a_BackgroundColorGwil;
        }

        #endregion Constructors

        #region Properties

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
        /// indication weather the racer has reached the finish
        /// </summary>
        public bool FinishedGwil
        {
            get => reachedFinshGwil;//return true if finished
        }

        public TimeSpan TimeRacedGwil
        {
            //read-only, the time the racer raced
            get => endOfRaceGwil - startOfRaceGwil;            
        }
        #endregion Properties

        #region Methods

        /// <summary>
        /// Reset racer to the start 
        /// </summary>
        /// <param name="startPointGwil"></param>
        /// <param name="offset"></param>
        public void ResetRacerToStartGwil( PointF startPointGwil, PointF offsetGwil)
        {
            LocationGwil = new PointF() { X = startPointGwil.X + offsetGwil.X, Y = startPointGwil.Y + offsetGwil.Y }; //reset the location of the racer
            reachedFinshGwil = false;//reset the finished boolean
            //reset the time when the race started and stopped
            startOfRaceGwil = new TimeSpan();
            endOfRaceGwil = new TimeSpan();
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
        /// Creates an random speed for the current racer
        /// </summary>
        public void CreateRandomSpeedGwil()
        {
            //create random class
            System.Random rndGwil = new System.Random();
            //get a new random for the speed
            speedGwil = rndGwil.NextDouble() * 10;

        }

        /// <summary>
        /// Draws the racer on the graphics
        /// </summary>
        /// <param name="grGwil">The graphic to draw on</param>
        public override void DrawGwil(Graphics grGwil)
        {
            //draw a rectangle with color on the graphics as the racer 
            grGwil.FillRectangle(new SolidBrush(BackgroundColorGwil), new RectangleF(LocationGwil, SizeGwil));
            base.DrawGwil(grGwil);
        }
        #endregion Methods
    }
}