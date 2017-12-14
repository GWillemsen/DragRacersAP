using System.Drawing;

namespace DragRacerGwil.Controls
{
    /// <summary>
    /// The basis class for a click able button
    /// </summary>
    public class csButtonGwil : csBasicControlGwil
    {
        #region Fields

        private Color backgroundColorGwil = Color.LightGray;
        private string contentGwil = "";
        private Brush drawBrushGwil = new SolidBrush(Color.Gray);
        private Font fontGwil = new Font("Times New Roman", 11);
        private Color foregroundColorGwil = Color.Black;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Creates an new button with no text in it nor will it does anything when click on. Hover
        /// and mouse down effect are incorporated
        /// </summary>
        public csButtonGwil()
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
            get => contentGwil;//returns the text in the button            
            set => contentGwil = value;//sets the text in the button
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Draws the button on the specified graphics 
        /// </summary>
        /// <param name="grGwil">
        /// The graphics to draw on 
        /// </param>
        public override void DrawGwil(Graphics grGwil)
        {
            //check if we need to redraw
            if (changedSinceDrawGwil == true)
            {
                //check if mouse is in control but not down
                if (mouseEnteredGwil && mouseDownGwil == false)
                {
                    //create an array with the corners of the rectangle
                    Point[] cornersGwil = new Point[] {
                        LocationGwil,
                        new Point(LocationGwil.X + SizeGwil.Width, LocationGwil.Y),
                        new Point(LocationGwil.X + SizeGwil.Width, LocationGwil.Y + SizeGwil.Height),
                        new Point(LocationGwil.X, LocationGwil.Y + SizeGwil.Height)
                    };
                    //create new brush with the corners and center color
                    System.Drawing.Drawing2D.PathGradientBrush pathBrushGwil = new System.Drawing.Drawing2D.PathGradientBrush(cornersGwil);
                    pathBrushGwil.CenterColor = backgroundColorGwil;

                    //creating new color for surrounded colors
                    byte redNewValGwil = backgroundColorGwil.R;
                    byte greenNewValGwil = backgroundColorGwil.G;
                    byte blueNewValGwil = backgroundColorGwil.B;
                    redNewValGwil = (byte)((redNewValGwil / 1.1 < 1) ? 0 : redNewValGwil / 1.1);
                    greenNewValGwil = (byte)((greenNewValGwil / 1.1 < 1) ? 0 : greenNewValGwil / 1.1);
                    blueNewValGwil = (byte)((blueNewValGwil / 1.1 < 1) ? 0 : blueNewValGwil / 1.1);
                    pathBrushGwil.SurroundColors = new Color[] { Color.FromArgb(backgroundColorGwil.A, redNewValGwil, greenNewValGwil, blueNewValGwil) };

                    //set and calculate center point for the gradient
                    pathBrushGwil.CenterPoint = new Point((LocationGwil.X + SizeGwil.Width) / 2, (LocationGwil.Y + SizeGwil.Height) / 2);
                    //draw the rectangle
                    grGwil.FillRectangle(pathBrushGwil, new Rectangle(LocationGwil, SizeGwil));
                }
                //if it is entered and down
                else if (mouseEnteredGwil && mouseDownGwil)
                {
                    //create an array with the corners of the rectangle
                    Point[] cornersGwil = new Point[] {
                        LocationGwil,
                        new Point(LocationGwil.X + SizeGwil.Width, LocationGwil.Y),
                        new Point(LocationGwil.X + SizeGwil.Width, LocationGwil.Y + SizeGwil.Height),
                        new Point(LocationGwil.X, LocationGwil.Y + SizeGwil.Height)
                    };
                    //create new brush with the corners and center color
                    System.Drawing.Drawing2D.PathGradientBrush pathBrushGwil = new System.Drawing.Drawing2D.PathGradientBrush(cornersGwil);
                    pathBrushGwil.CenterColor = backgroundColorGwil;

                    //creating new color for surrounded colors
                    byte redNewValGwil = backgroundColorGwil.R;
                    byte greenNewValGwil = backgroundColorGwil.G;
                    byte blueNewValGwil = backgroundColorGwil.B;
                    redNewValGwil = (byte)((redNewValGwil / 2 < 1) ? 0 : redNewValGwil / 2);
                    greenNewValGwil = (byte)((greenNewValGwil / 2 < 1) ? 0 : greenNewValGwil / 2);
                    blueNewValGwil = (byte)((blueNewValGwil / 2 < 1) ? 0 : blueNewValGwil / 2);
                    pathBrushGwil.SurroundColors = new Color[] { Color.FromArgb(backgroundColorGwil.A, redNewValGwil, greenNewValGwil, blueNewValGwil) };

                    //set and calculate center point for the gradient
                    pathBrushGwil.CenterPoint = new Point((LocationGwil.X + SizeGwil.Width) / 2, (LocationGwil.Y + SizeGwil.Height) / 2);
                    //draw the rectangle
                    grGwil.FillRectangle(pathBrushGwil, new Rectangle(LocationGwil, SizeGwil));
                }
                //all other situation irrelevant
                else
                    //just draw a straight forward rectangle with basic color
                    grGwil.FillRectangle(drawBrushGwil, new Rectangle(LocationGwil, SizeGwil));

                //measure how many lines and characters will fit in the button
                grGwil.MeasureString(contentGwil, FontGwil, SizeGwil, StringFormat.GenericDefault, out int charsCountGwil, out int linesGwil);
                //create new string to fit the content that will fit in it
                string drawingContentGwil = contentGwil.Substring(0, charsCountGwil - 1);
                //draw the string
                grGwil.DrawString(drawingContentGwil, FontGwil, new SolidBrush(foregroundColorGwil), new Rectangle(LocationGwil, SizeGwil));
                //note that the we update to the most recent changes
                changedSinceDrawGwil = false;
            }
        }

        #endregion Methods

    }
}