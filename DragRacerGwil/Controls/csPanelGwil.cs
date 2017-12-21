using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace DragRacerGwil.Controls
{
    public class csPanelGwil : csBasicControlGwil
    {
        #region Fields
        private System.Collections.Generic.List<csBasicControlGwil> childsGwil = new System.Collections.Generic.List<csBasicControlGwil>();

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Creates an new basic panel class
        /// </summary>
        public csPanelGwil()
        {
            BasicControlFullResetGwil();
        }

        /// <summary>
        /// Creates an new basic panel class
        /// </summary>
        /// <param name="a_NameGwil">The name of the panel</param>
        public csPanelGwil(string a_NameGwil)
        {
            BasicControlFullResetGwil();
            //make everything default except the text
            mouseDownGwil = false;
            mouseEnteredGwil = false;
            changedSinceDrawGwil = false;
            NameGwil = a_NameGwil;
        }

        /// <summary>
        /// Creates an new basic panel class
        /// </summary>
        /// <param name="a_NameGwil">The name of the panel</param>
        /// <param name="a_LocationGwil">The new location of the panel</param>
        public csPanelGwil(string a_NameGwil, PointF a_LocationGwil)
        {
            BasicControlFullResetGwil();
            //make everything default except the text and location
            mouseDownGwil = false;
            mouseEnteredGwil = false;
            changedSinceDrawGwil = false;
            LocationGwil = a_LocationGwil;
            NameGwil = a_NameGwil;
        }

        /// <summary>
        /// Creates an new basic panel class
        /// </summary>
        /// <param name="a_NameGwil">The name of the panel</param>
        /// <param name="a_LocationGwil">The new location of the panel</param>
        /// <param name="a_SizeGwil">The new size of the panel</param>
        public csPanelGwil(string a_NameGwil, PointF a_LocationGwil, Size a_SizeGwil)
        {
            BasicControlFullResetGwil();
            //make everything default except the text, size and location
            mouseDownGwil = false;
            mouseEnteredGwil = false;
            changedSinceDrawGwil = false;
            LocationGwil = a_LocationGwil;
            NameGwil = a_NameGwil;
            SizeGwil = a_SizeGwil;
        }

        /// <summary>
        /// Creates an new basic panel class
        /// </summary>
        /// <param name="a_NameGwil">The name of the panel</param>
        /// <param name="a_LocationGwil">The new location of the panel</param>
        /// <param name="a_SizeGwil">The new size of the panel</param>
        /// <param name="a_BackgroundColorGwil">The background color of the panel</param>
        public csPanelGwil(string a_NameGwil, PointF a_LocationGwil, Size a_SizeGwil, Color a_BackgroundColorGwil)
        {
            BasicControlFullResetGwil();
            //make everything default except the text, size, location and background color
            mouseDownGwil = false;
            mouseEnteredGwil = false;
            changedSinceDrawGwil = false;
            BackgroundColorGwil = a_BackgroundColorGwil;
            LocationGwil = a_LocationGwil;
            NameGwil = a_NameGwil;
            SizeGwil = a_SizeGwil;
        }

        /// <summary>
        /// Creates an new basic panel class
        /// </summary>
        /// <param name="a_NameGwil">The name of the panel</param>
        /// <param name="a_LocationGwil">The new location of the panel</param>
        /// <param name="a_SizeGwil">The new size of the panel</param>
        /// <param name="a_BackgroundColorGwil">The background color of the panel</param>
        /// <param name="a_ChildsGwil">The list of controls in the panel</param>
        public csPanelGwil(string a_NameGwil, PointF a_LocationGwil, Size a_SizeGwil, Color a_BackgroundColorGwil, System.Collections.Generic.List<csBasicControlGwil> a_ChildsGwil)
        {
            BasicControlFullResetGwil();
            //make everything default except the text, size, location and background color
            mouseDownGwil = false;
            mouseEnteredGwil = false;
            changedSinceDrawGwil = false;
            BackgroundColorGwil = a_BackgroundColorGwil;
            LocationGwil = a_LocationGwil;
            NameGwil = a_NameGwil;
            SizeGwil = a_SizeGwil;
            childsGwil = a_ChildsGwil;
        }

        /// <summary>
        /// Creates an new basic panel class
        /// </summary>
        /// <param name="a_NameGwil">The name of the panel</param>
        /// <param name="a_LocationGwil">The new location of the panel</param>
        /// <param name="a_SizeGwil">The new size of the panel</param>
        /// <param name="a_BackgroundColorGwil">The background color of the panel</param>
        /// <param name="a_ChildsGwil">The list of controls in the panel</param>
        public csPanelGwil(string a_NameGwil, PointF a_LocationGwil, Size a_SizeGwil, Color a_BackgroundColorGwil, csBasicControlGwil[] a_ChildsGwil)
        {
            BasicControlFullResetGwil();
            //make everything default except the text, size, location and background color
            mouseDownGwil = false;
            mouseEnteredGwil = false;
            changedSinceDrawGwil = false;
            BackgroundColorGwil = a_BackgroundColorGwil;
            LocationGwil = a_LocationGwil;
            NameGwil = a_NameGwil;
            SizeGwil = a_SizeGwil;
            childsGwil = a_ChildsGwil.ToList();
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// The controls in the panel as an list
        /// </summary>
        public List<csBasicControlGwil> ChildsListGwil
        {
            get => childsGwil;
            set => childsGwil = value;
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Draws the panel and its components
        /// </summary>
        /// <param name="grGwil">The graphics to draw on</param>
        public override void DrawGwil(Graphics grGwil)
        {
            //sort the child's on index
            childsGwil.Sort(new csSorter());

            //create graphics objects for the drawing
            Bitmap thePanelGwil = new Bitmap((int)SizeGwil.Width, (int)SizeGwil.Height);
            Graphics panelGrGwil = Graphics.FromImage(thePanelGwil);
            //clear the bitmap with the background color
            panelGrGwil.Clear(BackgroundColorGwil);
            //draw each individual control on the graphics
            foreach (csBasicControlGwil childGwil in childsGwil)
                childGwil.DrawGwil(panelGrGwil);

            //draw the panel on the graphics
            grGwil.DrawImage(thePanelGwil, LocationGwil.X, LocationGwil.Y, SizeGwil.Width, SizeGwil.Height);
            base.DrawGwil(grGwil);
        }

        #endregion Methods
    }
}