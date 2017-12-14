using System.Drawing;

namespace DragRacerGwil.Controls
{
    public class csLabelGwil : csBasicControlGwil
    {
        #region Fields

        private string contentGwil = "";
        private Brush drawBrushGwil = new SolidBrush(Color.Gray);
        private Font fontGwil = new Font("Times New Roman", 11);
        private Color foregroundColorGwil = Color.Black;

        #endregion Fields

        public csLabelGwil()
        {
            contentGwil = NameGwil;
            drawBrushGwil = new SolidBrush(Color.Gray);
            foregroundColorGwil = Color.Black;
        }

        public csLabelGwil(string a_NameGwil, Point a_LocationGwil)
        {
            FullResetGwil();
            LocationGwil = a_LocationGwil;
        }

        #region Properties

        /// <summary>
        /// The brush used to draw the text
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
        /// The color the text in the label
        /// </summary>
        public Color ForegroundColorGwil
        {
            get => foregroundColorGwil;//returns the text color
            set => foregroundColorGwil = value;//sets the text color
        }

        /// <summary>
        /// The text in the label
        /// </summary>
        public string TextGwil
        {
            get => contentGwil;//returns the text in the button
            set => contentGwil = value;//sets the text in the button
        }

        #endregion Properties

        #region Methods

        public override void DrawGwil(Graphics grGwil)
        {
            if (changedSinceDrawGwil == true)
            {
                //just draw a straight forward rectangle with basic color
                grGwil.FillRectangle(drawBrushGwil, new RectangleF(LocationGwil, SizeGwil));

                //measure how many lines and characters will fit in the button
                int charsCountGwil = 0;
                int linesGwil = 0;
                grGwil.MeasureString(contentGwil, FontGwil, SizeGwil, StringFormat.GenericDefault, out charsCountGwil, out linesGwil);

                //create new string to fit the content that will fit in it
                string drawingContentGwil = contentGwil.Substring(0, charsCountGwil - 1);

                //draw the string
                grGwil.DrawString(drawingContentGwil, FontGwil, new SolidBrush(foregroundColorGwil), new RectangleF(LocationGwil, SizeGwil));
                changedSinceDrawGwil = false;
            }
        }

        #endregion Methods
    }
}