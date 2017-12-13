using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragRacerGwil.Controls
{
    public class csButtonGwil : csBasicControlGwil
    {
        private Color backgroundColorGwil = Color.LightGray;
        private Color foregroundColorGwil = Color.Black;
        private Brush drawBrushGwil = new SolidBrush(Color.Gray);
        private string contentGwil = "";
        private Font fontGwil = new Font("Times New Roman", 11);

        public csButtonGwil()
        {
            //add events for the redraw of the button
            OnMouseDownGwil += (senderGwil, eGwil) => {
                changedSinceDrawGwil = true;
            };
            OnMouseUpGwil += (senderGwil, eGwil) => {
                changedSinceDrawGwil = true;
            };
            OnMouseMoveGwil += (senderGwil, eGwil) => {
                changedSinceDrawGwil = true;
            };
            OnMouseLeaveGwil += (senderGwil, eGwil) => {
                changedSinceDrawGwil = true;
            };
        }
        
        /// <summary>
        /// The font to use when drawing the text
        /// </summary>
        public Font Font
        {
            get => fontGwil;//returns the current font
            set => fontGwil = value;//sets the new font
        }

        /// <summary>
        /// The backgroundcolor use for the button
        /// </summary>
        public Color BackgroundColor {
            get => backgroundColorGwil;//returns the currrent background color
            set => backgroundColorGwil = value;//set the new background color
        }

        /// <summary>
        /// The color the text in the button
        /// </summary>
        public Color ForegroundColor
        {
            get => foregroundColorGwil;//returns the text color
            set => foregroundColorGwil = value;//sets the text color
        }

        /// <summary>
        /// The text in the button
        /// </summary>
        public string Text
        {
            get => contentGwil;//returns the text in the button
            set => contentGwil = value;//sets the text in the button
        }

        /// <summary>
        /// The brush used to draw the 
        /// </summary>
        public Brush DrawingBrush
        {
            get => drawBrushGwil;//returns the drawing brush
            set => drawBrushGwil = value;//sets the drawing brush
        }

        public override void DrawGwil(Graphics grGwil)
        {
            if (changedSinceDrawGwil == true) {
                System.Diagnostics.Debug.WriteLine(mouseDownGwil + "  " + mouseEnteredGwil);
                if (mouseEnteredGwil && mouseDownGwil == false) {
                    //create an array with the corners of the rectagle
                    Point[] cornersGwil = new Point[] {
                        Location,
                        new Point(Location.X + Size.Width, Location.Y),
                        new Point(Location.X + Size.Width, Location.Y + Size.Height),
                        new Point(Location.X, Location.Y + Size.Height)
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
                    pathBrushGwil.CenterPoint = new Point((Location.X + Size.Width) / 2, (Location.Y + Size.Height) / 2);
                    //draw the rectangle
                    grGwil.FillRectangle(pathBrushGwil, new Rectangle(Location, Size));
                }
                else if (mouseDownGwil)
                {                    
                    //create an array with the corners of the rectagle
                    Point[] cornersGwil = new Point[] {
                        Location,
                        new Point(Location.X + Size.Width, Location.Y),
                        new Point(Location.X + Size.Width, Location.Y + Size.Height),
                        new Point(Location.X, Location.Y + Size.Height)
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
                    pathBrushGwil.CenterPoint = new Point((Location.X + Size.Width) / 2, (Location.Y + Size.Height) / 2);
                    //draw the rectangle
                    grGwil.FillRectangle(pathBrushGwil, new Rectangle(Location, Size));
                }
                else
                    //just draw a straight forward rectangle with basic color
                    grGwil.FillRectangle(drawBrushGwil, new Rectangle(Location, Size));
                //measure how many lines and charactors wil fit in the button
                int charsCountGwil = 0;
                int linesGwil = 0;
                grGwil.MeasureString(contentGwil, Font, Size, StringFormat.GenericDefault, out charsCountGwil, out linesGwil);
                //create new string to fit the content that will fit in it
                string drawingContentGwil = contentGwil.Substring(0, charsCountGwil - 1);
                //draw the string
                grGwil.DrawString(drawingContentGwil, Font, new SolidBrush(foregroundColorGwil), new Rectangle(Location, Size));
                changedSinceDrawGwil = false;
            }
        }

    }
}
