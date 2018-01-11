using System;
using System.Drawing;

namespace DragRacerGwil.Controls
{
    public class csLabelGwil : csBasicControlGwil, IDisposable
    {
        #region Fields

        // Flag: Has Dispose already been called?
        private bool disposed = false;

        private Color foregroundColorGwil = Color.Black;
        private string obContentGwil = "";
        private Brush obDrawBrushGwil = new SolidBrush(Color.Gray);
        private Font obFontGwil = new Font("Times New Roman", 11);

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Creates an new label
        /// </summary>
        public csLabelGwil()
        {
            BasicControlFullResetGwil();
            obContentGwil = NameGwil;
            obDrawBrushGwil = new SolidBrush(Color.Gray);
            foregroundColorGwil = Color.Black;
        }

        /// <summary>
        /// Creates an new label
        /// </summary>
        /// <param name="a_NameGwil">The name of the label</param>
        /// <param name="a_LocationGwil">The location of the label</param>
        /// <param name="a_ControlSizeGwil">The size of the label</param>
        public csLabelGwil(string a_NameGwil, Point a_LocationGwil, Size a_ControlSizeGwil)
        {
            BasicControlFullResetGwil();
            LocationGwil = a_LocationGwil;
            NameGwil = a_NameGwil;
            SizeGwil = a_ControlSizeGwil;
        }

        /// <summary>
        /// Creates an new label
        /// </summary>
        /// <param name="a_NameGwil">The name of the label</param>
        /// <param name="a_LocationGwil">The location of the label</param>
        /// <param name="a_ControlSizeGwil">The size of the label</param>
        /// <param name="a_ContentGwil">The text of the label</param>
        public csLabelGwil(string a_NameGwil, Point a_LocationGwil, Size a_ControlSizeGwil, string a_Content)
        {
            BasicControlFullResetGwil();
            LocationGwil = a_LocationGwil;
            NameGwil = a_NameGwil;
            ContentGwil = a_Content;
            SizeGwil = a_ControlSizeGwil;
        }

        /// <summary>
        /// Creates an new label
        /// </summary>
        /// <param name="a_NameGwil">The name of the label</param>
        /// <param name="a_LocationGwil">The location of the label</param>
        /// <param name="a_ControlSizeGwil">The size of the label</param>
        /// <param name="a_ContentGwil">The text of the label</param>
        /// <param name="a_TextColorGwil">The color of the text</param>
        public csLabelGwil(string a_NameGwil, Point a_LocationGwil, Size a_ControlSizeGwil, string a_ContentGwil, Color a_TextColorGwil)
        {
            BasicControlFullResetGwil();
            LocationGwil = a_LocationGwil;
            NameGwil = a_NameGwil;
            ContentGwil = a_ContentGwil;
            foregroundColorGwil = a_TextColorGwil;
            SizeGwil = a_ControlSizeGwil;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// The brush used to draw the text
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
            get => obContentGwil;//returns the text in the button
            set => obContentGwil = value;//sets the text in the button
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Free all occupied resources
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Draws the label on the graphics
        /// </summary>
        /// <param name="grGwil">The graphic to draw on</param>
        /// <param name="forceRedrawGwil">Force a redraw weather necessary or not</param>
        public override void DrawGwil(Graphics grGwil, bool forceRedrawGwil = false)
        {
            if (changedSinceDrawGwil == true || forceRedrawGwil == true && Visible == true)
            {
                //just draw a straight forward rectangle with basic color
                grGwil.FillRectangle(obDrawBrushGwil, new RectangleF(LocationGwil, SizeGwil));

                //measure how many lines and characters will fit in the button
                grGwil.MeasureString(obContentGwil, FontGwil, SizeGwil, StringFormat.GenericDefault, out int charsCountGwil, out int linesGwil);

                //create new string to fit the content that will fit in it
                string obDrawingContentGwil = obContentGwil.Substring(0, charsCountGwil);

                //draw the string
                grGwil.DrawString(obDrawingContentGwil, FontGwil, new SolidBrush(foregroundColorGwil), new RectangleF(LocationGwil, SizeGwil));
                changedSinceDrawGwil = false;
                base.DrawGwil(grGwil);
            }
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                //Free managed objects
                obFontGwil.Dispose();
                obDrawBrushGwil.Dispose();
            }

            // Free any unmanaged objects here.
            disposed = true;
        }

        #endregion Methods
    }
}