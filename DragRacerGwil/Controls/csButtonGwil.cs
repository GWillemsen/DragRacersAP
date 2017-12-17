using System.Drawing;
using System.Drawing.Drawing2D;

namespace DragRacerGwil.Controls
{
    /// <summary>
    /// The basis class for a click able button
    /// </summary>
    public class csButtonGwil : csBasicControlGwil
    {
        #region Fields

        private static Color foregroundColorGwil = Color.Black;        
        private Brush drawBrushGwil = new SolidBrush(Color.Gray);
        private Font fontGwil = new Font("Times New Roman", 11);

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Creates an new button with no text in it nor will it does anything when click on. Hover
        /// and mouse down effect are incorporated
        /// </summary>
        public csButtonGwil()
        {
            FullResetGwil();
            foregroundColorGwil = Color.Black;
            drawBrushGwil = new SolidBrush(Color.Gray);

            //add events for the redraw of the button
            OnMouseDownGwil += (senderGwil, eGwil) =>
            {
                changedSinceDrawGwil = true;
            };
            OnMouseUpGwil += (senderGwil, eGwil) =>
            {
                changedSinceDrawGwil = true;
            };
            OnMouseMoveGwil += (senderGwil, eGwil) =>
            {
                changedSinceDrawGwil = true;
            };
            OnMouseLeaveGwil += (senderGwil, eGwil) =>
            {
                changedSinceDrawGwil = true;
            };
        }

        /// <summary>
        /// Creates an new button with event handlers for mouse down,up,move and leave
        /// </summary>
        /// <param name="a_LocationGwil">The location of the button</param>
        /// <param name="a_SizeGwil">The size of the button</param>
        /// <param name="a_Text">The text of the button</param>
        /// <param name="a_FontGwil">The font of the text</param>
        public csButtonGwil(Point a_LocationGwil, Size a_SizeGwil, string a_NameGwil, string a_Text = "", Font a_FontGwil = default(Font))
        {
            //add events for the redraw of the button
            OnMouseDownGwil += (senderGwil, eGwil) =>
            {
                changedSinceDrawGwil = true;
            };
            OnMouseUpGwil += (senderGwil, eGwil) =>
            {
                changedSinceDrawGwil = true;
            };
            OnMouseMoveGwil += (senderGwil, eGwil) =>
            {
                changedSinceDrawGwil = true;
            };
            OnMouseLeaveGwil += (senderGwil, eGwil) =>
            {
                changedSinceDrawGwil = true;
            };
            SizeGwil = a_SizeGwil;
            LocationGwil = a_LocationGwil;
            if (a_Text != "")
                ContentGwil = a_Text;
            if (a_FontGwil != null)
                fontGwil = a_FontGwil;
            NameGwil = a_NameGwil;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// The brush used to draw the
        /// </summary>
        public Brush DrawingBrushGwil
        {
            get => drawBrushGwil;//returns the drawing brush
            set => drawBrushGwil = value;//sets the drawing brush
        }

        /// <summary>
        /// The font to use when drawing the text
        /// </summary>
        public Font FontGwil
        {
            get => fontGwil;//returns the current font
            set => fontGwil = value;//sets the new font
        }

        /// <summary>
        /// The color the text in the button
        /// </summary>
        public Color ForegroundColorGwil
        {
            get => foregroundColorGwil;//returns the text color
            set => foregroundColorGwil = value;//sets the text color
        }

        /// <summary>
        /// The text in the button
        /// </summary>
        public string TextGwil
        {
            get => ContentGwil;//returns the text in the button
            set => ContentGwil = value;//sets the text in the button
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Draws the button on the specified graphics
        /// </summary>
        /// <param name="grGwil">The graphics to draw on</param>
        public override void DrawGwil(Graphics grGwil)
        {
            //check if we need to redraw
            if (changedSinceDrawGwil == true)
            {
                //check if mouse is in control but not down
                if (mouseEnteredGwil && mouseDownGwil == false)
                {
                    //create an array with the corners of the rectangle
                    PointF[] cornersGwil = new PointF[] {
                        LocationGwil,
                        new PointF(LocationGwil.X + SizeGwil.Width, LocationGwil.Y),
                        new PointF(LocationGwil.X + SizeGwil.Width, LocationGwil.Y + SizeGwil.Height),
                        new PointF(LocationGwil.X, LocationGwil.Y + SizeGwil.Height)
                    };
                    //create new brush with the corners and center color
                    PathGradientBrush pathBrushGwil = new PathGradientBrush(cornersGwil);
                    pathBrushGwil.CenterColor = BackgroundColorGwil;

                    //creating new color for surrounded colors
                    byte redNewValGwil = BackgroundColorGwil.R;
                    byte greenNewValGwil = BackgroundColorGwil.G;
                    byte blueNewValGwil = BackgroundColorGwil.B;
                    redNewValGwil = (byte)((redNewValGwil / 1.1 < 1) ? 0 : redNewValGwil / 1.1);
                    greenNewValGwil = (byte)((greenNewValGwil / 1.1 < 1) ? 0 : greenNewValGwil / 1.1);
                    blueNewValGwil = (byte)((blueNewValGwil / 1.1 < 1) ? 0 : blueNewValGwil / 1.1);
                    pathBrushGwil.SurroundColors = new Color[] { Color.FromArgb(BackgroundColorGwil.A, redNewValGwil, greenNewValGwil, blueNewValGwil) };

                    //set and calculate center point for the gradient
                    pathBrushGwil.CenterPoint = new PointF((LocationGwil.X + SizeGwil.Width) / 2, (LocationGwil.Y + SizeGwil.Height) / 2);
                    //draw the rectangle
                    grGwil.FillRectangle(pathBrushGwil, new RectangleF(LocationGwil, SizeGwil));
                }
                //if it is entered and down
                else if (mouseEnteredGwil && mouseDownGwil)
                {
                    //create an array with the corners of the rectangle
                    PointF[] cornersGwil = new PointF[] {
                        LocationGwil,
                        new PointF(LocationGwil.X + SizeGwil.Width, LocationGwil.Y),
                        new PointF(LocationGwil.X + SizeGwil.Width, LocationGwil.Y + SizeGwil.Height),
                        new PointF(LocationGwil.X, LocationGwil.Y + SizeGwil.Height)
                    };
                    //create new brush with the corners and center color
                    PathGradientBrush pathBrushGwil = new PathGradientBrush(cornersGwil);
                    pathBrushGwil.CenterColor = BackgroundColorGwil;

                    //creating new color for surrounded colors
                    byte redNewValGwil = BackgroundColorGwil.R;
                    byte greenNewValGwil = BackgroundColorGwil.G;
                    byte blueNewValGwil = BackgroundColorGwil.B;
                    redNewValGwil = (byte)((redNewValGwil / 2 < 1) ? 0 : redNewValGwil / 2);
                    greenNewValGwil = (byte)((greenNewValGwil / 2 < 1) ? 0 : greenNewValGwil / 2);
                    blueNewValGwil = (byte)((blueNewValGwil / 2 < 1) ? 0 : blueNewValGwil / 2);
                    pathBrushGwil.SurroundColors = new Color[] { Color.FromArgb(BackgroundColorGwil.A, redNewValGwil, greenNewValGwil, blueNewValGwil) };

                    //set and calculate center point for the gradient
                    pathBrushGwil.CenterPoint = new PointF((LocationGwil.X + SizeGwil.Width) / 2, (LocationGwil.Y + SizeGwil.Height) / 2);
                    //draw the rectangle
                    grGwil.FillRectangle(pathBrushGwil, new RectangleF(LocationGwil, SizeGwil));
                }
                //all other situation irrelevant
                else
                    //just draw a straight forward rectangle with basic color
                    grGwil.FillRectangle(drawBrushGwil, new RectangleF(LocationGwil, SizeGwil));

                //measure how many lines and characters will fit in the button
                grGwil.MeasureString(ContentGwil, FontGwil, SizeGwil, StringFormat.GenericDefault, out int charsCountGwil, out int linesGwil);
                //create new string to fit the content that will fit in it
                string drawingContentGwil = ContentGwil.Substring(0, (charsCountGwil - 1 >= 0) ? charsCountGwil - 1 : 0);
                //draw the string
                grGwil.DrawString(drawingContentGwil, FontGwil, new SolidBrush(foregroundColorGwil), new RectangleF(LocationGwil, SizeGwil));
                //note that the we update to the most recent changes
                changedSinceDrawGwil = false;
            }
        }

        #endregion Methods
    }
}