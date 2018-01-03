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
        private Brush obDrawBrushGwil = new SolidBrush(Color.Gray);
        private Font obFontGwil = new Font("Times New Roman", 11);

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Creates an new button with no text in it nor will it does anything when click on. Hover
        /// and mouse down effect are incorporated
        /// </summary>
        public csButtonGwil()
        {
            BasicControlFullResetGwil();
            foregroundColorGwil = Color.Black;
            obDrawBrushGwil = new SolidBrush(Color.Gray);

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
        public csButtonGwil(string a_NameGwil)
        {
            BasicControlFullResetGwil();
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

            //set the properties
            NameGwil = a_NameGwil;
        }

        /// <summary>
        /// Creates an new button with event handlers for mouse down,up,move and leave
        /// </summary>
        /// <param name="a_SizeGwil">The size of the button</param>
        /// <param name="a_NameGwil">The name of the label</param>
        public csButtonGwil(string a_NameGwil, PointF a_LocationGwil)
        {
            BasicControlFullResetGwil();
            //add events for the redraw of the button
            OnMouseDownGwil += (senderGwil, eGwil) => { changedSinceDrawGwil = true; };
            OnMouseUpGwil += (senderGwil, eGwil) => { changedSinceDrawGwil = true; };
            OnMouseMoveGwil += (senderGwil, eGwil) => { changedSinceDrawGwil = true; };
            OnMouseLeaveGwil += (senderGwil, eGwil) => { changedSinceDrawGwil = true; };

            //set the properties
            LocationGwil = a_LocationGwil;
            NameGwil = a_NameGwil;
        }

        /// <summary>
        /// Creates an new button with event handlers for mouse down,up,move and leave
        /// </summary>
        /// <param name="a_LocationGwil">The location of the button</param>
        /// <param name="a_SizeGwil">The size of the button</param>
        /// <param name="a_NameGwil">The name of the label</param>
        public csButtonGwil(string a_NameGwil, PointF a_LocationGwil, Size a_SizeGwil)
        {
            BasicControlFullResetGwil();
            //add events for the redraw of the button
            OnMouseDownGwil += (senderGwil, eGwil) => { changedSinceDrawGwil = true; };
            OnMouseUpGwil += (senderGwil, eGwil) => { changedSinceDrawGwil = true; };
            OnMouseMoveGwil += (senderGwil, eGwil) => { changedSinceDrawGwil = true; };
            OnMouseLeaveGwil += (senderGwil, eGwil) => { changedSinceDrawGwil = true; };

            //set the properties
            SizeGwil = a_SizeGwil;
            LocationGwil = a_LocationGwil;
            NameGwil = a_NameGwil;
        }

        /// <summary>
        /// Creates an new button with event handlers for mouse down,up,move and leave
        /// </summary>
        /// <param name="a_LocationGwil">The location of the button</param>
        /// <param name="a_SizeGwil">The size of the button</param>
        /// <param name="a_Text">The text of the button</param>
        /// <param name="a_NameGwil">The name of the label</param>
        public csButtonGwil(string a_NameGwil, PointF a_LocationGwil, Size a_SizeGwil, string a_Text)
        {
            BasicControlFullResetGwil();
            //add events for the redraw of the button
            OnMouseDownGwil += (senderGwil, eGwil) => { changedSinceDrawGwil = true; };
            OnMouseUpGwil += (senderGwil, eGwil) => { changedSinceDrawGwil = true; };
            OnMouseMoveGwil += (senderGwil, eGwil) => { changedSinceDrawGwil = true; };
            OnMouseLeaveGwil += (senderGwil, eGwil) => { changedSinceDrawGwil = true; };

            //set the properties
            SizeGwil = a_SizeGwil;
            LocationGwil = a_LocationGwil;
            ContentGwil = a_Text;
            NameGwil = a_NameGwil;
        }

        /// <summary>
        /// Creates an new button with event handlers for mouse down,up,move and leave
        /// </summary>
        /// <param name="a_LocationGwil">The location of the button</param>
        /// <param name="a_SizeGwil">The size of the button</param>
        /// <param name="a_Text">The text of the button</param>
        /// <param name="a_FontGwil">The font of the text</param>
        /// <param name="a_NameGwil">The name of the label</param>
        public csButtonGwil(string a_NameGwil, PointF a_LocationGwil, Size a_SizeGwil, string a_Text, Font a_FontGwil)
        {
            BasicControlFullResetGwil();
            //add events for the redraw of the button
            OnMouseDownGwil += (senderGwil, eGwil) => { changedSinceDrawGwil = true; };
            OnMouseUpGwil += (senderGwil, eGwil) => { changedSinceDrawGwil = true; };
            OnMouseMoveGwil += (senderGwil, eGwil) => { changedSinceDrawGwil = true; };
            OnMouseLeaveGwil += (senderGwil, eGwil) => { changedSinceDrawGwil = true; };

            //set the properties
            SizeGwil = a_SizeGwil;
            LocationGwil = a_LocationGwil;
            ContentGwil = a_Text;
            obFontGwil = a_FontGwil;
            NameGwil = a_NameGwil;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// The brush used to draw the
        /// </summary>
        public Brush DrawingBrushGwil
        {
            get => obDrawBrushGwil;//returns the drawing brush
            set => obDrawBrushGwil = value;//sets the drawing brush
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
        /// Draws the button on the graphics
        /// </summary>
        /// <param name="obGrGwil">The graphic to draw on</param>
        /// <param name="forceRedrawGwil">Force a redraw weather necessary or not</param>
        public override void DrawGwil(Graphics obGrGwil, bool forceRedrawGwil = false)
        {
            //check if we need to redraw
            if (changedSinceDrawGwil == true || forceRedrawGwil == true && Visible == true)
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
                    PathGradientBrush obPathBrushGwil = new PathGradientBrush(cornersGwil);
                    obPathBrushGwil.CenterColor = BackgroundColorGwil;

                    //creating new color for surrounded colors
                    byte redNewValGwil = BackgroundColorGwil.R;
                    byte greenNewValGwil = BackgroundColorGwil.G;
                    byte blueNewValGwil = BackgroundColorGwil.B;
                    redNewValGwil = (byte)((redNewValGwil / 1.1 < 1) ? 0 : redNewValGwil / 1.1);
                    greenNewValGwil = (byte)((greenNewValGwil / 1.1 < 1) ? 0 : greenNewValGwil / 1.1);
                    blueNewValGwil = (byte)((blueNewValGwil / 1.1 < 1) ? 0 : blueNewValGwil / 1.1);
                    obPathBrushGwil.SurroundColors = new Color[] { Color.FromArgb(BackgroundColorGwil.A, redNewValGwil, greenNewValGwil, blueNewValGwil) };

                    //set and calculate center PointF for the gradient
                    obPathBrushGwil.CenterPoint = new Point((int)((LocationGwil.X + SizeGwil.Width) / 2), (int)((LocationGwil.Y + SizeGwil.Height) / 2));
                    //draw the rectangle
                    obGrGwil.FillRectangle(obPathBrushGwil, new RectangleF(LocationGwil, SizeGwil));
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
                    PathGradientBrush obPathBrushGwil = new PathGradientBrush(cornersGwil);
                    obPathBrushGwil.CenterColor = BackgroundColorGwil;

                    //creating new color for surrounded colors
                    byte redNewValGwil = BackgroundColorGwil.R;
                    byte greenNewValGwil = BackgroundColorGwil.G;
                    byte blueNewValGwil = BackgroundColorGwil.B;
                    redNewValGwil = (byte)((redNewValGwil / 2 < 1) ? 0 : redNewValGwil / 2);
                    greenNewValGwil = (byte)((greenNewValGwil / 2 < 1) ? 0 : greenNewValGwil / 2);
                    blueNewValGwil = (byte)((blueNewValGwil / 2 < 1) ? 0 : blueNewValGwil / 2);
                    obPathBrushGwil.SurroundColors = new Color[] { Color.FromArgb(BackgroundColorGwil.A, redNewValGwil, greenNewValGwil, blueNewValGwil) };

                    //set and calculate center PointF for the gradient
                    obPathBrushGwil.CenterPoint = new Point((int)((LocationGwil.X + SizeGwil.Width) / 2), (int)((LocationGwil.Y + SizeGwil.Height) / 2));
                    //draw the rectangle
                    obGrGwil.FillRectangle(obPathBrushGwil, new RectangleF(LocationGwil, SizeGwil));
                }
                //all other situation irrelevant
                else
                    //just draw a straight forward rectangle with basic color
                    obGrGwil.FillRectangle(obDrawBrushGwil, new RectangleF(LocationGwil, SizeGwil));

                //measure how many lines and characters will fit in the button
                obGrGwil.MeasureString(ContentGwil, FontGwil, SizeGwil, StringFormat.GenericDefault, out int charsCountGwil, out int linesGwil);
                //create new string to fit the content that will fit in it
                string obDrawingContentGwil = ContentGwil.Substring(0, (charsCountGwil >= 0) ? charsCountGwil : 0);
                //draw the string
                obGrGwil.DrawString(obDrawingContentGwil, FontGwil, new SolidBrush(foregroundColorGwil), new RectangleF(LocationGwil, SizeGwil));
                //note that the we update to the most recent changes
                changedSinceDrawGwil = false;
                base.DrawGwil(obGrGwil);
            }
        }

        #endregion Methods
    }
}