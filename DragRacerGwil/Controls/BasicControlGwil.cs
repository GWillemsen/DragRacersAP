using System;
using System.Drawing;

namespace DragRacerGwil.Controls
{
    public class csBasicControlGwil
    {
        #region Fields
        public bool changedSinceDrawGwil = false;
        public bool mouseDownGwil = false;
        public bool mouseEnteredGwil = false;
        private bool allowAutoResizeGwil = false;
        private Color backgroundColorGwil = Color.LightGray;
        private string contentGwil = "";
        private bool hidesOnOutsideClickGwil = false;
        private PointF locationGwil = new PointF(0, 0);
        private string nameGwil = "";
        private SizeF sizeGwil = new SizeF(0, 0);
        private bool visibleGwil = true;
        private int zIndexGwil = 0;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Creates an new basic control class
        /// </summary>
        public csBasicControlGwil()
        {
            BasicControlFullResetGwil();
        }

        /// <summary>
        /// Creates an new basic control class
        /// </summary>
        /// <param name="a_NameGwil">The name of the control</param>
        public csBasicControlGwil(string a_NameGwil)
        {
            BasicControlFullResetGwil();
            //make everything default except the text
            contentGwil = "";
            mouseDownGwil = false;
            mouseEnteredGwil = false;
            changedSinceDrawGwil = false;
            backgroundColorGwil = Color.LightGray;
            locationGwil = new PointF(0, 0);
            nameGwil = a_NameGwil;
            sizeGwil = new SizeF(0, 0);
        }

        /// <summary>
        /// Creates an new basic control class
        /// </summary>
        /// <param name="a_NameGwil">The name of the control</param>
        /// <param name="a_LocationGwil">The new location of the control</param>
        public csBasicControlGwil(string a_NameGwil, PointF a_LocationGwil)
        {
            BasicControlFullResetGwil();
            //make everything default except the text and location
            contentGwil = "";
            mouseDownGwil = false;
            mouseEnteredGwil = false;
            changedSinceDrawGwil = false;
            backgroundColorGwil = Color.LightGray;
            locationGwil = a_LocationGwil;
            nameGwil = a_NameGwil;
            sizeGwil = new SizeF(0, 0);
        }

        /// <summary>
        /// Creates an new basic control class
        /// </summary>
        /// <param name="a_NameGwil">The name of the control</param>
        /// <param name="a_LocationGwil">The new location of the control</param>
        /// <param name="a_SizeGwil">The new size of the control</param>
        public csBasicControlGwil(string a_NameGwil, PointF a_LocationGwil, Size a_SizeGwil)
        {
            BasicControlFullResetGwil();
            //make everything default except the text, size and location
            contentGwil = "";
            mouseDownGwil = false;
            mouseEnteredGwil = false;
            changedSinceDrawGwil = false;
            backgroundColorGwil = Color.LightGray;
            locationGwil = a_LocationGwil;
            nameGwil = a_NameGwil;
            sizeGwil = a_SizeGwil;
        }

        /// <summary>
        /// Creates an new basic control class
        /// </summary>
        /// <param name="a_NameGwil">The name of the control</param>
        /// <param name="a_LocationGwil">The new location of the control</param>
        /// <param name="a_SizeGwil">The new size of the control</param>
        /// <param name="a_BackgroundColorGwil">The background color of the control</param>
        public csBasicControlGwil(string a_NameGwil, PointF a_LocationGwil, Size a_SizeGwil, Color a_BackgroundColorGwil)
        {
            BasicControlFullResetGwil();
            //make everything default except the text, size, location and background color
            contentGwil = "";
            mouseDownGwil = false;
            mouseEnteredGwil = false;
            changedSinceDrawGwil = false;
            backgroundColorGwil = a_BackgroundColorGwil;
            locationGwil = a_LocationGwil;
            nameGwil = a_NameGwil;
            sizeGwil = a_SizeGwil;
        }

        #endregion Constructors

        #region Events
        /// <summary>
        /// Gets raised when the control is clicked
        /// </summary>
        public event EventHandler OnClickGwil;
        /// <summary>
        /// Gets raised when the mouse button is down in the control
        /// </summary>
        public event EventHandler OnMouseDownGwil;
        /// <summary>
        /// Gets raised when the mouse enters this control
        /// </summary>
        public event EventHandler OnMouseEnterGwil;
        /// <summary>
        /// Gets raised when the mouse leaves this control
        /// </summary>
        public event EventHandler OnMouseLeaveGwil;
        /// <summary>
        /// Gets raised when the mouse moves around in the control
        /// </summary>
        public event EventHandler OnMouseMoveGwil;

        /// <summary>
        /// Gets raised when the mouse button is released
        /// </summary>
        public event EventHandler OnMouseUpGwil;

        #endregion Events

        #region Properties

        /// <summary>
        /// Weather the control will resize automatically with the parent control
        /// </summary>
        public bool AutoResizeGwil
        {
            get => allowAutoResizeGwil;
            set => allowAutoResizeGwil = value;
        }

        /// <summary>
        /// The background color use for the control
        /// </summary>
        public Color BackgroundColorGwil
        {
            get => backgroundColorGwil;//returns the current background color
            set
            {
                //if it is not the same value say it changed
                if (backgroundColorGwil != value)
                    changedSinceDrawGwil = true;
                backgroundColorGwil = value;//set the new background color
            }
        }

        /// <summary>
        /// The text content of the control(if it uses any)
        /// </summary>
        public string ContentGwil
        {
            get => contentGwil;//return the content
            set
            {
                //if it is not the same value say it changed
                if (contentGwil != value)
                    changedSinceDrawGwil = true;
                //update the value
                contentGwil = value;
            }
        }

        /// <summary>
        /// If this boolean is true the control will set visibility to false when there was a mouse
        /// click outside this control
        /// </summary>
        public bool HidesWhenClickedOutsideControlGwil
        {
            //get and set the boolean
            get => hidesOnOutsideClickGwil;
            set => hidesOnOutsideClickGwil = value;
        }

        /// <summary>
        /// Location on which to draw on
        /// </summary>
        public PointF LocationGwil
        {
            get => locationGwil;//returns the location
            set
            {
                //if the location has changed say the control has changed
                if (locationGwil != value)
                    changedSinceDrawGwil = true;
                locationGwil = value;//update the location
            }
        }

        /// <summary>
        /// Name of the control
        /// </summary>
        public string NameGwil
        {
            get => nameGwil;//return the name
            set
            {
                //if the new name is different than say the control changed
                if (nameGwil != value)
                    changedSinceDrawGwil = true;
                nameGwil = value;//update the name value
            }
        }

        /// <summary>
        /// Size of the control
        /// </summary>
        public SizeF SizeGwil
        {
            get => sizeGwil;//returns the size
            set
            {
                //if the size changed than say the control changed
                if (sizeGwil != value)
                    changedSinceDrawGwil = true;
                sizeGwil = value;//update the size value
            }
        }

        /// <summary>
        /// The visibility of the form
        /// </summary>
        public bool Visible
        {
            //sets or gets the boolean
            get => visibleGwil;
            set
            {
                //check if we need to redraw the control
                if (value != visibleGwil)
                    changedSinceDrawGwil = true;
                visibleGwil = value;
            }
        }

        /// <summary>
        /// The index of which the control layer is
        /// </summary>
        public int Z_indexGwil
        {
            get => zIndexGwil;
            set => zIndexGwil = value;
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Like the name says, do a reset on all objects
        /// </summary>
        public void BasicControlFullResetGwil()
        {
            //make everything is default value
            mouseDownGwil = false;
            mouseEnteredGwil = false;
            changedSinceDrawGwil = false;
            backgroundColorGwil = Color.LightGray;
            locationGwil = new PointF(0, 0);
            nameGwil = "";
            sizeGwil = new SizeF(0, 0);
        }

        /// <summary>
        /// Raise the event that the control is clicked
        /// </summary>
        /// <param name="senderGwil">The sender of the event</param>
        /// <param name="eGwil">The extra info of the event</param>
        public void ClickGwil(object senderGwil, System.Windows.Forms.MouseEventArgs eGwil)
        {
            OnClickGwil?.Invoke(senderGwil, eGwil);//raise the event handler if is not null
        }

        /// <summary>
        /// Draw the control
        /// </summary>
        /// <param name="grGwil">Graphics to draw the control on</param>
        public virtual void DrawGwil(Graphics grGwil, bool forceRedrawGwil = false) { }

        /// <summary>
        /// Raise the event that the mouse button is pressed down
        /// </summary>
        /// <param name="senderGwil">The sender of the event</param>
        /// <param name="argGwil">The extra info of the event</param>
        public void MouseDownRaiseGwil(object senderGwil, System.Windows.Forms.MouseEventArgs argGwil)
        {
            mouseDownGwil = true;//say the mouse button is down
            OnMouseDownGwil?.Invoke(senderGwil, argGwil);//raise the event handler if it not null
        }

        /// <summary>
        /// Raise the event that the mouse entered this control
        /// </summary>
        /// <param name="senderGwil"></param>
        /// <param name="argGwil"></param>
        public void MouseEnterRaiseGwil(object senderGwil, System.Windows.Forms.MouseEventArgs argGwil)
        {
            mouseEnteredGwil = true;//set to true, so it know the mouse has entered
            OnMouseEnterGwil?.Invoke(senderGwil, argGwil);//if the event handler is not null raise it
        }

        /// <summary>
        /// Raise the event that the mouse left the control
        /// </summary>
        /// <param name="senderGwil">The sender of the event</param>
        /// <param name="argGwil">The extra info of the event</param>
        public void MouseLeaveGwil(object senderGwil, System.Windows.Forms.MouseEventArgs argGwil)
        {
            mouseEnteredGwil = false;//say the mouse is not in the control
            OnMouseLeaveGwil?.Invoke(senderGwil, argGwil);//raise the mouse left event if it is not null
        }

        /// <summary>
        /// Raise the event that the mouse was moved
        /// </summary>
        /// <param name="senderGwil">The sender of the event</param>
        /// <param name="argGwil">The extra info of the event</param>
        public void MouseMoveRaiseGwil(object senderGwil, System.Windows.Forms.MouseEventArgs argGwil)
        {
            OnMouseMoveGwil?.Invoke(senderGwil, argGwil);//raise the mouse moved event if it is not null
        }

        /// <summary>
        /// Raise the event that the button of the mouse was released
        /// </summary>
        /// <param name="senderGwil">The sender of the event</param>
        /// <param name="argGwil">The extra info of the event</param>
        public void MouseUpRaiseGwil(object senderGwil, System.Windows.Forms.MouseEventArgs argGwil)
        {
            mouseDownGwil = false;//say the mouse if not down
            OnMouseUpGwil?.Invoke(senderGwil, argGwil);//raise the event handler if it is not null
        }

        /// <summary>
        /// Converts the basic information of the control into an string
        /// </summary>
        /// <returns>Basic information formated in a string</returns>
        public override string ToString()
        {
            //creates the string of the objects
            return "{" + locationGwil + ", name=" + nameGwil + ", " + base.ToString() + "}";
        }

        #endregion Methods
    }
}