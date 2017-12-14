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
        private List<csBasicControlGwil> controlsGwil = new List<csBasicControlGwil>();
        private Point locationGwil = new Point(0, 0);
        private string nameGwil = "";
        private Size sizeGwil = new System.Drawing.Size(0, 0);

        #endregion Fields

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

            set => backgroundColorGwil = value;//set the new background color
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
        /// Location on which to draw on 
        /// </summary>
        public Point LocationGwil
        {
            get => locationGwil;//returns the location

            set
            {
                //of the location has changed say the control has changed
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
                //The new name is different than say the control changed
                if (nameGwil != value)
                    changedSinceDrawGwil = true;
                nameGwil = value;//update the name value
            }
        }

        /// <summary>
        /// Size of the control 
        /// </summary>
        public Size SizeGwil
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

        /// <summary>Raise the event that the button is clicked</summary>
        /// <param name="senderGwil">The sender of the event</param>
        /// <param name="eGwil">The extra info of the event</param>
        public void ClickGwil(object senderGwil, System.Windows.Forms.MouseEventArgs eGwil)
        {
            OnClickGwil?.Invoke(senderGwil, eGwil);//raise the event handler if is not null
        }

        /// <summary>
        /// Draw the control 
        /// </summary>
        /// <param name="grGwil">
        /// Graphics to draw the button on 
        /// </param>
        public virtual void DrawGwil(Graphics grGwil) { }

        /// <summary>
        /// Raise the event that the mouse on the button changed to down 
        /// </summary>
        /// <param name="senderGwil">
        /// The sender of the event 
        /// </param>
        /// <param name="eGwil">
        /// The extra info of the event 
        /// </param>
        public void MouseDownRaiseGwil(object senderGwil, System.Windows.Forms.MouseEventArgs eGwil)
        {
            mouseDownGwil = true;//say the mouse button is down
            OnMouseDownGwil?.Invoke(senderGwil, eGwil);//raise the event handler if it not null
        }

        /// <summary>
        /// Raise the event that the button left the control 
        /// </summary>
        /// <param name="senderGwil">
        /// The sender of the event 
        /// </param>
        /// <param name="eGwil">
        /// The extra info of the event 
        /// </param>
        public void MouseLeaveGwil(object senderGwil, System.Windows.Forms.MouseEventArgs eGwil)
        {
            mouseEnteredGwil = false;//say the mouse is not in the control
            OnMouseLeaveGwil?.Invoke(senderGwil, eGwil);//raise the mouse left event if it is not null
        }

        /// <summary>
        /// Raise the event that the button was moved 
        /// </summary>
        /// <param name="senderGwil">
        /// The sender of the event 
        /// </param>
        /// <param name="eGwil">
        /// The extra info of the event 
        /// </param>
        public void MouseMoveRaiseGwil(object senderGwil, System.Windows.Forms.MouseEventArgs eGwil)
        {
            mouseEnteredGwil = true;//say the mouse is in the control
            OnMouseMoveGwil?.Invoke(senderGwil, eGwil);//raise the mouse moved event if it is not null
        }

        /// <summary>
        /// Raise the event that the mouse on the button changed to up 
        /// </summary>
        /// <param name="senderGwil">
        /// The sender of the event 
        /// </param>
        /// <param name="eGwil">
        /// The extra info of the event 
        /// </param>
        public void MouseUpRaiseGwil(object senderGwil, System.Windows.Forms.MouseEventArgs eGwil)
        {
            mouseDownGwil = false;//say the mouse if not down
            OnMouseUpGwil?.Invoke(senderGwil, eGwil);//raise the event handler if it is not null
        }

        #endregion Methods
    }
}