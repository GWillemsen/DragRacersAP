using System.Drawing;

namespace DragRacerGwil.Controls
{
    /// <summary>
    /// The event in case of an resize occurred
    /// </summary>
    internal class csResizeEventgwil : System.EventArgs
    {
        #region Fields
        private SizeF currentOldSize = new SizeF(0, 0);
        private double hScaleGwil = 0.0D;
        private SizeF newSizeGwil = new SizeF(0, 0);
        private SizeF oldSizeGwil = new SizeF(0, 0);
        private int parentHeightGwil = 0;
        private int parentWidth = 0;
        private double vScaleGwil = 0.0D;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Creates an new resize event
        /// </summary>
        /// <param name="verticalScaleGwil">The vertical scale of the resize</param>
        /// <param name="horizontalScaleGwil">The horizontal scale of the resize</param>
        /// <param name="oldParentSizeGwil">The old parent size</param>
        /// <param name="newParentSizeGwil">The new parent size</param>
        /// <param name="parentFullHeightGwil">The full height of the parent</param>
        /// <param name="parentFullWidthGwil">The full width of the parent</param>
        /// <param name="currentOldSizeGwil">The old size of the current control</param>
        public csResizeEventgwil(double verticalScaleGwil, double horizontalScaleGwil, SizeF oldParentSizeGwil, SizeF newParentSizeGwil, int parentFullWidthGwil, int parentFullHeightGwil, SizeF currentOldSizeGwil)
        {
            //set the vars from parameters to privates
            vScaleGwil = verticalScaleGwil;
            hScaleGwil = horizontalScaleGwil;
            oldSizeGwil = oldParentSizeGwil;
            newSizeGwil = newParentSizeGwil;
            parentWidth = parentFullWidthGwil;
            parentHeightGwil = parentFullHeightGwil;
            currentOldSize = currentOldSizeGwil;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// The full height in pixels of the parent
        /// </summary>
        public int FullHeightParentGwil
        {
            get => parentHeightGwil;//return value
        }

        /// <summary>
        /// The full width in pixels of the parent
        /// </summary>
        public int FullWidthParentGwil
        {
            get => parentWidth;//return value
        }

        /// <summary>
        /// The multiplier for the new vertical size
        /// </summary>
        public double HorizontalScaleGwil
        {
            get => hScaleGwil;//return the value
        }

        /// <summary>
        /// The new size of the parent after the resizing
        /// </summary>
        public SizeF NewParentSizeGwil
        {
            get => newSizeGwil;//return the value
        }

        /// <summary>
        /// The old size of the parent before the resizing
        /// </summary>
        public SizeF OldParentSizeGwil
        {
            get => oldSizeGwil;//return the value
        }

        /// <summary>
        /// The old size of the control to which this event argument was send
        /// </summary>
        public SizeF OldSizeOfCurrentControlGwil
        {
            get => currentOldSize;//return value
        }

        /// <summary>
        /// The multiplier for the new vertical size
        /// </summary>
        public double VerticalScaleGwil
        {
            get => vScaleGwil;//return the value
        }

        #endregion Properties
    }
}