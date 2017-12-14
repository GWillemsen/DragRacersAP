using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace DragRacerGwil.Controls
{
    public class csBasicControlGwil
    {
        #region Fields

        public bool changedSinceDrawGwil = false;
        public bool mouseDownGwil = false;
        public bool mouseEnteredGwil = false;
        private Color backgroundColorGwil = Color.LightGray;
        private string contentGwil = "";
        private List<csBasicControlGwil> controlsGwil = new List<csBasicControlGwil>();
        private PointF locationGwil = new PointF(0, 0);
        private string nameGwil = "";
        private SizeF sizeGwil = new SizeF(0, 0);

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Creates an new basic control class
        /// </summary>
        public csBasicControlGwil()
        {
            FullResetGwil();
        }

        /// <summary>
        /// Creates an new basic control class
        /// </summary>
        /// <param name="a_NameGwil">The name of the control</param>
        public csBasicControlGwil(string a_NameGwil)
        {
            //make everything default except the text
            contentGwil = "";
            mouseDownGwil = false;
            mouseEnteredGwil = false;
            changedSinceDrawGwil = false;
            backgroundColorGwil = Color.LightGray;
            controlsGwil = new List<csBasicControlGwil>();
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
            //make everything default except the text and location
            contentGwil = "";
            mouseDownGwil = false;
            mouseEnteredGwil = false;
            changedSinceDrawGwil = false;
            backgroundColorGwil = Color.LightGray;
            controlsGwil = new List<csBasicControlGwil>();
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
            //make everything default except the text, size and location
            contentGwil = "";
            mouseDownGwil = false;
            mouseEnteredGwil = false;
            changedSinceDrawGwil = false;
            backgroundColorGwil = Color.LightGray;
            controlsGwil = new List<csBasicControlGwil>();
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
            //make everything default except the text, size, location and background color
            contentGwil = "";
            mouseDownGwil = false;
            mouseEnteredGwil = false;
            changedSinceDrawGwil = false;
            backgroundColorGwil = a_BackgroundColorGwil;
            controlsGwil = new List<csBasicControlGwil>();
            locationGwil = a_LocationGwil;
            nameGwil = a_NameGwil;
            sizeGwil = a_SizeGwil;
        }

        #endregion Constructors

        #region Events

        public event EventHandler OnClickGwil;
        public event EventHandler OnMouseDownGwil;
        public event EventHandler OnMouseLeaveGwil;
        public event EventHandler OnMouseMoveGwil;
        public event EventHandler OnMouseUpGwil;

        #endregion Events

        #region Properties

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
        /// Child's if it has any
        /// </summary>
        public List<csBasicControlGwil> ChildsGwil
        {
            get => controlsGwil;//returns the controls in an array format
            set
            {
                //if the value is not the same than say the control has changed
                if (controlsGwil != value.ToList())
                    changedSinceDrawGwil = true;

                //replace the list
                controlsGwil = value;
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

        #endregion Properties

        #region Methods

        /// <summary>
        /// Raise the event that the button is clicked
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
        /// <param name="grGwil">Graphics to draw the button on</param>
        public virtual void DrawGwil(Graphics grGwil) { }

        /// <summary>
        /// Like the name says, do a reset on all objects
        /// </summary>
        public void FullResetGwil()
        {
            //make everything is default value
            mouseDownGwil = false;
            mouseEnteredGwil = false;
            changedSinceDrawGwil = false;
            backgroundColorGwil = Color.LightGray;
            controlsGwil = new List<csBasicControlGwil>();
            locationGwil = new PointF(0, 0);
            nameGwil = "";
            sizeGwil = new SizeF(0, 0);
        }

        /// <summary>
        /// Raise the event that the mouse on the button changed to down
        /// </summary>
        /// <param name="senderGwil">The sender of the event</param>
        /// <param name="eGwil">The extra info of the event</param>
        public void MouseDownRaiseGwil(object senderGwil, System.Windows.Forms.MouseEventArgs eGwil)
        {
            mouseDownGwil = true;//say the mouse button is down
            OnMouseDownGwil?.Invoke(senderGwil, eGwil);//raise the event handler if it not null
        }

        /// <summary>
        /// Raise the event that the button left the control
        /// </summary>
        /// <param name="senderGwil">The sender of the event</param>
        /// <param name="eGwil">The extra info of the event</param>
        public void MouseLeaveGwil(object senderGwil, System.Windows.Forms.MouseEventArgs eGwil)
        {
            mouseEnteredGwil = false;//say the mouse is not in the control
            OnMouseLeaveGwil?.Invoke(senderGwil, eGwil);//raise the mouse left event if it is not null
        }

        /// <summary>
        /// Raise the event that the button was moved
        /// </summary>
        /// <param name="senderGwil">The sender of the event</param>
        /// <param name="eGwil">The extra info of the event</param>
        public void MouseMoveRaiseGwil(object senderGwil, System.Windows.Forms.MouseEventArgs eGwil)
        {
            mouseEnteredGwil = true;//say the mouse is in the control
            OnMouseMoveGwil?.Invoke(senderGwil, eGwil);//raise the mouse moved event if it is not null
        }

        /// <summary>
        /// Raise the event that the mouse on the button changed to up
        /// </summary>
        /// <param name="senderGwil">The sender of the event</param>
        /// <param name="eGwil">The extra info of the event</param>
        public void MouseUpRaiseGwil(object senderGwil, System.Windows.Forms.MouseEventArgs eGwil)
        {
            mouseDownGwil = false;//say the mouse if not down
            OnMouseUpGwil?.Invoke(senderGwil, eGwil);//raise the event handler if it is not null
        }

        #endregion Methods
    }
}