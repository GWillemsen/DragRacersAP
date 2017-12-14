using System.Drawing;

namespace DragRacerGwil.Controls
{
    public class csLabelGwil : csBasicControlGwil
    {
        private Color foregroundColorGwil = Color.Black;
        private Brush drawBrushGwil = new SolidBrush(Color.Gray);
        private string contentGwil = "";
        private Font fontGwil = new Font("Times New Roman", 11);

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

        /// <summary>
        /// The brush used to draw the text
        /// </summary>
        public Brush DrawingBrushGwil
        {
            get => drawBrushGwil;//returns the drawing brush
            set => drawBrushGwil = value;//sets the drawing brush
        }

        public override void DrawGwil(Graphics grGwil)
        {
            if (changedSinceDrawGwil == true)
            {
                //just draw a straight forward rectangle with basic color
                grGwil.FillRectangle(drawBrushGwil, new Rectangle(LocationGwil, SizeGwil));

                //measure how many lines and characters will fit in the button
                int charsCountGwil = 0;
                int linesGwil = 0;
                grGwil.MeasureString(contentGwil, FontGwil, SizeGwil, StringFormat.GenericDefault, out charsCountGwil, out linesGwil);

                //create new string to fit the content that will fit in it
                string drawingContentGwil = contentGwil.Substring(0, charsCountGwil - 1);

                //draw the string
                grGwil.DrawString(drawingContentGwil, FontGwil, new SolidBrush(foregroundColorGwil), new Rectangle(LocationGwil, SizeGwil));
                changedSinceDrawGwil = false;
            }
        }
    }
}