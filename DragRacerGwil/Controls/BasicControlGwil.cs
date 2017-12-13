using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
namespace DragRacerGwil.Controls
{
    public class csBasicControlGwil
    {
        public event EventHandler OnClickGwil;
        public event EventHandler OnMouseDownGwil;
        public event EventHandler OnMouseUpGwil;
        public event EventHandler OnMouseMoveGwil;
        public event EventHandler OnMouseLeaveGwil;
        public bool mouseDownGwil = false;
        public bool mouseEnteredGwil = false;
        public bool changedSinceDrawGwil = false;

        private string nameGwil = "";
        private Size sizeGwil = new System.Drawing.Size(0, 0);
        private Point locationGwil = new Point(0, 0);
        private List<csBasicControlGwil> controlsGwil = new List<csBasicControlGwil>();

        /// <summary>
        /// Name of the control
        /// </summary>
        public string Name
        {
            get => nameGwil;//return the name
            set
            {
                //the the new name is diffente than say the control changed
                if (nameGwil != value)
                    changedSinceDrawGwil = true;
                nameGwil = value;//update the name value
            }
        }

        /// <summary>
        /// Size of the control
        /// </summary>
        public Size Size
        {
            get => sizeGwil;//returns the size
            set
            {
                //if the size changed than sya the control chaged
                if (sizeGwil != value)
                    changedSinceDrawGwil = true;
                sizeGwil = value;//update the size value
            }
        }

        /// <summary>
        /// Location on wich to draw on
        /// </summary>
        public Point Location
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
        /// Childs if it has any
        /// </summary>
        public List<csBasicControlGwil> Childs
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
        /// Draw the control
        /// </summary>
        /// <param name="grGwil">Graphics to draw the button on</param>
        public virtual void DrawGwil(Graphics grGwil) { }
        
        /// <summary>
        /// Raise the event that the button is clicked
        /// </summary>
        /// <param name="senderGwil">The sender of the event</param>
        /// <param name="eGwil">The extra info of the event</param>
        public void ClickGwil(object senderGwil, System.Windows.Forms.MouseEventArgs eGwil)
        {
            OnClickGwil?.Invoke(senderGwil, eGwil);//raise the eventhandler if is not null
        }


        /// <summary>
        /// Raise the event that the mouse on the button changed to down
        /// </summary>
        /// <param name="senderGwil">The sender of the event</param>
        /// <param name="eGwil">The extra info of the event</param>
        public void MouseDownRaiseGwil(object senderGwil, System.Windows.Forms.MouseEventArgs eGwil)
        {
            mouseDownGwil = true;//say the mousebutton is down
            OnMouseDownGwil?.Invoke(senderGwil, eGwil);//raise the event handler if it not null
        }

        /// <summary>
        /// Raise the event that the mouse on the button changed to up
        /// </summary>
        /// <param name="senderGwil">The sender of the event</param>
        /// <param name="eGwil">The extra info of the event</param>
        public void MouseUpRaiseGwil(object senderGwil, System.Windows.Forms.MouseEventArgs eGwil)
        {
            mouseDownGwil = false;//say the mouse if not down
            OnMouseUpGwil?.Invoke(senderGwil, eGwil);//raise the eventhandler if it is not null
        }

        /// <summary>
        /// Raise the event that the button was moved
        /// </summary>
        /// <param name="senderGwil">The sender of the event</param>
        /// <param name="eGwil">The extra info of the event</param>
        public void MouseMoveRaiseGwil(object senderGwil, System.Windows.Forms.MouseEventArgs eGwil)
        {
            this.mouseEnteredGwil = true;//say the mouse is in the control
            OnMouseMoveGwil?.Invoke(senderGwil, eGwil);//raise the mouse moved event if it is not null
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
    }
}