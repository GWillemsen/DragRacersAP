using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DragRacerGwil.Controls
{
    public class csPanelGwil : csBasicControlGwil
    {
        #region Fields
        private csControlListGwil obChildsGwil = new csControlListGwil();
        private bool hidesOnOutsideClickGwil = false;
        #endregion Fields

        #region Constructors

        /// <summary>
        /// Creates an new basic panel class
        /// </summary>
        public csPanelGwil()
        {
            //basics of control
            BasicControlFullResetGwil();
            AddEventHandlers();
        }

        /// <summary>
        /// Creates an new basic panel class
        /// </summary>
        /// <param name="a_NameGwil">The name of the panel</param>
        public csPanelGwil(string a_NameGwil)
        {
            //basics of control
            BasicControlFullResetGwil();
            AddEventHandlers();

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
            //basics of control
            BasicControlFullResetGwil();
            AddEventHandlers();
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
            //basics of control
            BasicControlFullResetGwil();
            AddEventHandlers();
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
            //basics of control
            BasicControlFullResetGwil();
            AddEventHandlers();
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
        public csPanelGwil(string a_NameGwil, PointF a_LocationGwil, Size a_SizeGwil, Color a_BackgroundColorGwil, List<csBasicControlGwil> a_ChildsGwil)
        {
            //basics of control
            BasicControlFullResetGwil();
            AddEventHandlers();
            //make everything default except the text, size, location and background color
            mouseDownGwil = false;
            mouseEnteredGwil = false;
            changedSinceDrawGwil = false;
            BackgroundColorGwil = a_BackgroundColorGwil;
            LocationGwil = a_LocationGwil;
            NameGwil = a_NameGwil;
            SizeGwil = a_SizeGwil;
            obChildsGwil = new csControlListGwil(a_ChildsGwil);
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
            //basics of control
            BasicControlFullResetGwil();
            AddEventHandlers();
            //make everything default except the text, size, location and background color
            mouseDownGwil = false;
            mouseEnteredGwil = false;
            changedSinceDrawGwil = false;
            BackgroundColorGwil = a_BackgroundColorGwil;
            LocationGwil = a_LocationGwil;
            NameGwil = a_NameGwil;
            SizeGwil = a_SizeGwil;
            obChildsGwil =  new csControlListGwil(a_ChildsGwil.ToList());
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// The controls in the panel as an list
        /// </summary>
        public csControlListGwil ChildsListGwil
        {
            get => obChildsGwil;
            set => obChildsGwil = value;
        }

        /// <summary>
        /// If this boolean is true the control will set visibility to false when there was a mouse click outside this control
        /// </summary>
        public bool HidesWhenClickedOutsideControlGwil
        {
            //get and set the boolean
            get => hidesOnOutsideClickGwil;
            set => hidesOnOutsideClickGwil = value;
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Draws the panel and its components
        /// </summary>
        /// <param name="obGrGwil">The graphic to draw on</param>
        /// <param name="forceRedrawGwil">Force a redraw weather necessary or not</param>
        public override void DrawGwil(Graphics obGrGwil, bool forceRedrawGwil = false)
        {
            if (changedSinceDrawGwil == true || forceRedrawGwil == true && Visible == true)
            {
                //sort the child's on index
                obChildsGwil.Sort(new csSorter());

                //create graphics objects for the drawing
                Bitmap obThePanelGwil = new Bitmap((int)SizeGwil.Width, ((int)SizeGwil.Height));
                Graphics obPanelGrGwil = Graphics.FromImage(obThePanelGwil);

                //clear the bitmap with the background color
                obPanelGrGwil.Clear(BackgroundColorGwil);
                //draw each individual control on the graphics
                foreach (csBasicControlGwil obChildGwil in obChildsGwil)
                    obChildGwil.DrawGwil(obPanelGrGwil, true);

                //draw the panel on the graphics
                obGrGwil.DrawImage(obThePanelGwil, LocationGwil.X, LocationGwil.Y, SizeGwil.Width, SizeGwil.Height);
                //dispose of the local graphics and image
                obPanelGrGwil.Dispose();
                obThePanelGwil.Dispose();
                base.DrawGwil(obGrGwil);
                changedSinceDrawGwil = false;
            }
        }

        /// <summary>
        /// Add the event handlers to this control
        /// </summary>
        private void AddEventHandlers()
        {
            //add the event handlers to the correct event
            OnClickGwil += MouseClick;
            OnMouseDownGwil += MouseDown;
            OnMouseMoveGwil += MouseMove;
            OnMouseUpGwil += MouseUp;
            OnMouseLeaveGwil += MouseLeave;
        }

        /// <summary>
        /// Sends click event to control if mouse clicked on it
        /// </summary>
        /// <param name="obSender">The parent control</param>
        /// <param name="eGwil">The mouse event args</param>
        private void MouseClick(object obSender, System.EventArgs eGwil)
        {
            //convert the event args to correct format
            MouseEventArgs obOldEventArgsGwil = (MouseEventArgs)eGwil;
            MouseEventArgs obMouseEventGwil = new MouseEventArgs(obOldEventArgsGwil.Button, obOldEventArgsGwil.Clicks,
                (int)(obOldEventArgsGwil.X - LocationGwil.X), (int)(obOldEventArgsGwil.Y - LocationGwil.Y), obOldEventArgsGwil.Delta);

            //control to preform click on
            csBasicControlGwil obClickControlGwil = null;
            foreach (csBasicControlGwil obControlGwil in obChildsGwil)
            {
                //check if the mouse is in the control bounds
                if (obMouseEventGwil.X >= obControlGwil.LocationGwil.X &&
                    obMouseEventGwil.X <= obControlGwil.SizeGwil.Width + obControlGwil.LocationGwil.X)
                {
                    if (obMouseEventGwil.Y >= obControlGwil.LocationGwil.Y &&
                         obMouseEventGwil.Y <= obControlGwil.LocationGwil.Y + obControlGwil.SizeGwil.Height)
                    {
                        //check if the new control is closer to the 0 index than the last one
                        if ((obClickControlGwil == null || obControlGwil.Z_indexGwil < obClickControlGwil.Z_indexGwil) && obControlGwil.Visible == true)
                            obClickControlGwil = obControlGwil;
                    }
                }
            }
            
            //raise the controls click event
            obClickControlGwil?.ClickGwil(obSender, obMouseEventGwil);
        }

        /// <summary>
        /// Sends mouse down event to control if mouse hovers over it and presses the mouse on it
        /// </summary>
        /// <param name="obSender">The parent control</param>
        /// <param name="eGwil">The mouse event args</param>
        private void MouseDown(object obSender, System.EventArgs eGwil)
        {
            //convert the event args to correct format
            MouseEventArgs obOldEventArgsGwil = (MouseEventArgs)eGwil;
            MouseEventArgs obMouseEventGwil = new MouseEventArgs(obOldEventArgsGwil.Button, obOldEventArgsGwil.Clicks,
                (int)(obOldEventArgsGwil.X - LocationGwil.X), (int)(obOldEventArgsGwil.Y - LocationGwil.Y), obOldEventArgsGwil.Delta);

            //control to preform mouseDown on
            csBasicControlGwil obMouseDownControlGwil = null;

            foreach (csBasicControlGwil obControlGwil in obChildsGwil)
            {
                //check if mouse is in the control
                if (obMouseEventGwil.X >= obControlGwil.LocationGwil.X &&
                    obMouseEventGwil.X <= obControlGwil.SizeGwil.Width + obControlGwil.LocationGwil.X)
                {
                    if (obMouseEventGwil.Y >= obControlGwil.LocationGwil.Y &&
                         obMouseEventGwil.Y <= obControlGwil.LocationGwil.Y + obControlGwil.SizeGwil.Height)
                    {
                        //if the mouseDown control is not null and the z index is higher(further to the background)
                        if ((obMouseDownControlGwil == null || obControlGwil.Z_indexGwil < obMouseDownControlGwil.Z_indexGwil) && obControlGwil.Visible == true)
                            obMouseDownControlGwil = obControlGwil;
                    }
                    else
                    {
                        //if mouse is down or mouse is entered, but the mouse is not actually there reset to properties
                        if (obControlGwil.mouseDownGwil == true || obControlGwil.mouseEnteredGwil == true)
                        {
                            obControlGwil.mouseDownGwil = false;
                            obControlGwil.mouseEnteredGwil = false;
                        }
                    }
                }
                else
                {
                    //if mouse is down or mouse is entered, but the mouse is not actually there reset to properties
                    if (obControlGwil.mouseDownGwil == true || obControlGwil.mouseEnteredGwil == true)
                    {
                        obControlGwil.mouseDownGwil = false;
                        obControlGwil.mouseEnteredGwil = false;
                    }
                }
            }

            //raise the mouse down event
            obMouseDownControlGwil?.MouseDownRaiseGwil(obSender, obMouseEventGwil);
        }

        /// <summary>
        /// Sends mouse moved event to the control the mouse moved in(or when it moves in/out raises
        /// those events too)
        /// </summary>
        /// <param name="obSender">The parent control</param>
        /// <param name="eGwil">The mouse event args</param>
        private void MouseMove(object obSender, System.EventArgs eGwil)
        {
            //convert the event args to correct format
            MouseEventArgs obOldEventArgsGwil = (MouseEventArgs)eGwil;
            MouseEventArgs obMouseEventGwil = new MouseEventArgs(obOldEventArgsGwil.Button, obOldEventArgsGwil.Clicks,
                (int)(obOldEventArgsGwil.X - LocationGwil.X), (int)(obOldEventArgsGwil.Y - LocationGwil.Y), obOldEventArgsGwil.Delta);

            //the control to preform the event on
            csBasicControlGwil obMouseMoveControlGwil = null;

            //loop through all controls
            foreach (csBasicControlGwil obControlGwil in obChildsGwil)
            {
                //check if mouse is with the current control
                if (obMouseEventGwil.X >= obControlGwil.LocationGwil.X &&
                    obMouseEventGwil.X <= obControlGwil.SizeGwil.Width + obControlGwil.LocationGwil.X)
                {
                    if (obMouseEventGwil.Y >= obControlGwil.LocationGwil.Y &&
                         obMouseEventGwil.Y <= obControlGwil.LocationGwil.Y + obControlGwil.SizeGwil.Height)
                    {
                        if ((obMouseMoveControlGwil == null || obControlGwil.Z_indexGwil < obMouseMoveControlGwil.Z_indexGwil) && obControlGwil.Visible == true)
                        {
                            obMouseMoveControlGwil = obControlGwil;
                        }
                    }
                    else if (obControlGwil.mouseEnteredGwil == true)
                        //otherwise raise leave events
                        obControlGwil.MouseLeaveGwil(obSender, obMouseEventGwil);
                }
                else
                {
                    if (obControlGwil.mouseEnteredGwil == true)
                        //otherwise raise leave events
                        obControlGwil.MouseLeaveGwil(obSender, obMouseEventGwil);
                }

                //check if the control has detected that is should redraw
                if (obControlGwil.changedSinceDrawGwil == true)
                    changedSinceDrawGwil = true;//set the boolean to true so the form will invalidate
            }

            //if the mouse was not in the control before, raise the entered event first
            if (obMouseMoveControlGwil?.mouseEnteredGwil == false)
                obMouseMoveControlGwil?.MouseEnterRaiseGwil(obSender, obMouseEventGwil);
            //if so click a move event
            obMouseMoveControlGwil?.MouseMoveRaiseGwil(obSender, obMouseEventGwil);
        }

        /// <summary>
        /// Sends mouse up event to the control if the mouse was pressed down
        /// </summary>
        /// <param name="obSender">The parent control</param>
        /// <param name="eGwil">The mouse event args</param>
        private void MouseUp(object obSender, System.EventArgs eGwil)
        {
            //convert the event args to correct format
            MouseEventArgs obOldEventArgsGwil = (MouseEventArgs)eGwil;
            MouseEventArgs obMouseEventGwil = new MouseEventArgs(obOldEventArgsGwil.Button, obOldEventArgsGwil.Clicks,
                (int)(obOldEventArgsGwil.X - LocationGwil.X), (int)(obOldEventArgsGwil.Y - LocationGwil.Y), obOldEventArgsGwil.Delta);

            foreach (csBasicControlGwil obControlGwil in obChildsGwil)
            {
                ////check if mouse is in the control
                //if (e.X >= controlGwil.LocationGwil.X &&
                //    e.X <= controlGwil.SizeGwil.Width + controlGwil.LocationGwil.X)
                //{
                //    if (e.Y >= controlGwil.LocationGwil.Y &&
                //         e.Y <= controlGwil.LocationGwil.Y + controlGwil.SizeGwil.Height)
                //    {
                //        //raise the mouse up event
                //        controlGwil.MouseUpRaiseGwil(this, e);
                //    }
                //    else
                //    {
                //        //if mouse is down or mouse is entered, but the mouse is not actually there reset to properties
                //        if (controlGwil.mouseDownGwil == true || controlGwil.mouseEnteredGwil == true)
                //        {
                //            controlGwil.mouseDownGwil = false;
                //            controlGwil.mouseEnteredGwil = false;
                //        }
                //    }
                //}
                //else
                //{
                //    //if mouse is down or mouse is entered, but the mouse is not actually there reset to properties
                //    if (controlGwil.mouseDownGwil == true || controlGwil.mouseEnteredGwil == true)
                //    {
                //        controlGwil.mouseDownGwil = false;
                //        controlGwil.mouseEnteredGwil = false;
                //    }
                //}
                if (obControlGwil.mouseDownGwil == true)
                    //raise the mouse up event
                    obControlGwil.MouseUpRaiseGwil(obSender, obMouseEventGwil);

                if (obMouseEventGwil.X < obControlGwil.LocationGwil.X && obMouseEventGwil.X > obControlGwil.SizeGwil.Width + obControlGwil.LocationGwil.X)
                    //raise the mouse left event
                    obControlGwil.MouseLeaveGwil(obSender, obMouseEventGwil);

                if (obMouseEventGwil.Y < obControlGwil.LocationGwil.Y && obMouseEventGwil.Y > obControlGwil.LocationGwil.Y + obControlGwil.SizeGwil.Height)
                    //raise the mouse left event
                    obControlGwil.MouseLeaveGwil(obSender, obMouseEventGwil);
            }
        }

        /// <summary>
        /// Raises the mouse leave events of the controls if the mouse left that control
        /// </summary>
        /// <param name="obSender">The parent control</param>
        /// <param name="eGwil">The mouse event args</param>
        private void MouseLeave(object obSender, System.EventArgs eGwil)
        {
            //convert the event args to correct format
            MouseEventArgs obOldEventArgsGwil = (MouseEventArgs)eGwil;
            MouseEventArgs obMouseEventGwil = new MouseEventArgs(obOldEventArgsGwil.Button, obOldEventArgsGwil.Clicks,
                (int)(obOldEventArgsGwil.X - LocationGwil.X), (int)(obOldEventArgsGwil.Y - LocationGwil.Y), obOldEventArgsGwil.Delta);

            //loops through all controls and raises the mouse leave event if it thinks the mouse was in it
            foreach (csBasicControlGwil obControlGwil in obChildsGwil)
            {
                if(obControlGwil.mouseEnteredGwil == true)
                    obControlGwil.MouseLeaveGwil(obSender, obMouseEventGwil);
            }
        }
        #endregion Methods
    }
}