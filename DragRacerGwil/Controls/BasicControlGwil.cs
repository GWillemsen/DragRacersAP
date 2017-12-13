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
            get => nameGwil;
            set
            {
                if (nameGwil != value)
                    changedSinceDrawGwil = true;
                nameGwil = value;
            }
        }

        /// <summary>
        /// Size of the control
        /// </summary>
        public Size Size
        {
            get => sizeGwil;
            set
            {
                if (sizeGwil != value)
                    changedSinceDrawGwil = true;
                sizeGwil = value;
            }
        }

        /// <summary>
        /// Location on wich to draw on
        /// </summary>
        public Point Location
        {
            get => locationGwil;
            set
            {
                if (locationGwil != value)
                    changedSinceDrawGwil = true;
                locationGwil = value;
            }
        }

        /// <summary>
        /// Possible childs
        /// </summary>
        public csBasicControlGwil[] Childs
        {
            get => controlsGwil.ToArray();
            set
            {
                if (controlsGwil != value.ToList())
                    changedSinceDrawGwil = true;
                controlsGwil = value.ToList();
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
            OnClickGwil?.Invoke(senderGwil, eGwil);
        }


        /// <summary>
        /// Raise the event that the mouse on the button changed to down
        /// </summary>
        /// <param name="senderGwil">The sender of the event</param>
        /// <param name="eGwil">The extra info of the event</param>
        public void MouseDownRaiseGwil(object senderGwil, System.Windows.Forms.MouseEventArgs eGwil)
        {
            mouseDownGwil = true;
            OnMouseDownGwil?.Invoke(senderGwil, eGwil);
        }

        /// <summary>
        /// Raise the event that the mouse on the button changed to up
        /// </summary>
        /// <param name="senderGwil">The sender of the event</param>
        /// <param name="eGwil">The extra info of the event</param>
        public void MouseUpRaiseGwil(object senderGwil, System.Windows.Forms.MouseEventArgs eGwil)
        {
            mouseDownGwil = false;
            OnMouseUpGwil?.Invoke(senderGwil, eGwil);
        }

        /// <summary>
        /// Raise the event that the button was moved
        /// </summary>
        /// <param name="senderGwil">The sender of the event</param>
        /// <param name="eGwil">The extra info of the event</param>
        public void MouseMoveRaiseGwil(object senderGwil, System.Windows.Forms.MouseEventArgs eGwil)
        {
            this.mouseEnteredGwil = true;
            OnMouseMoveGwil?.Invoke(senderGwil, eGwil);
        }

        /// <summary>
        /// Raise the event that the button left the control
        /// </summary>
        /// <param name="senderGwil">The sender of the event</param>
        /// <param name="eGwil">The extra info of the event</param>
        public void MouseLeaveGwil(object senderGwil, System.Windows.Forms.MouseEventArgs eGwil)
        {
            mouseEnteredGwil = false;
            OnMouseLeaveGwil?.Invoke(senderGwil, eGwil);
        }
    }
}