﻿using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DragRacerGwil.Controls
{
    public class csPanelGwil : csBasicControlGwil
    {
        #region Fields
        private csControlListGwil obChildsGwil = new csControlListGwil();

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
            obChildsGwil = new csControlListGwil(a_ChildsGwil.ToList());
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
                obPanelGrGwil.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
                obPanelGrGwil.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low;
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
            OnResizeGwil += ResizeFormGwil;
        }

        /// <summary>
        /// Sends click event to control if mouse clicked on it
        /// </summary>
        /// <param name="obSenderGwil">The parent control</param>
        /// <param name="eGwil">The mouse event args</param>
        private void MouseClick(object obSenderGwil, System.EventArgs eGwil)
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
            obClickControlGwil?.ClickGwil(obSenderGwil, obMouseEventGwil);

            if (obClickControlGwil?.changedSinceDrawGwil == true)
                changedSinceDrawGwil = true;
        }

        /// <summary>
        /// Sends mouse down event to control if mouse hovers over it and presses the mouse on it
        /// </summary>
        /// <param name="obSenderGwil">The parent control</param>
        /// <param name="eGwil">The mouse event args</param>
        private void MouseDown(object obSenderGwil, System.EventArgs eGwil)
        {
            //convert the event args to correct format
            MouseEventArgs obOldEventArgsGwil = (MouseEventArgs)eGwil;
            MouseEventArgs obMouseEventGwil = new MouseEventArgs(obOldEventArgsGwil.Button, obOldEventArgsGwil.Clicks,
                (int)(obOldEventArgsGwil.X - LocationGwil.X), (int)(obOldEventArgsGwil.Y - LocationGwil.Y), obOldEventArgsGwil.Delta);

            //control to preform mouseDown on
            csBasicControlGwil obMouseDownControlGwil = null;

            //bool to check if we need to invalidate
            bool invalidateControlGwil = false;

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
                //check if we need to invalidate the control
                if (obControlGwil.changedSinceDrawGwil == true)
                    invalidateControlGwil = true;
            }

            //raise the mouse down event
            obMouseDownControlGwil?.MouseDownRaiseGwil(obSenderGwil, obMouseEventGwil);

            //invalidate control if we need to
            if (invalidateControlGwil == true)
                changedSinceDrawGwil = true;
        }

        /// <summary>
        /// Raises the mouse leave events of the controls if the mouse left that control
        /// </summary>
        /// <param name="obSenderGwil">The parent control</param>
        /// <param name="eGwil">The mouse event args</param>
        private void MouseLeave(object obSenderGwil, System.EventArgs eGwil)
        {
            //convert the event args to correct format
            MouseEventArgs obOldEventArgsGwil = (MouseEventArgs)eGwil;
            MouseEventArgs obMouseEventGwil = new MouseEventArgs(obOldEventArgsGwil.Button, obOldEventArgsGwil.Clicks,
                (int)(obOldEventArgsGwil.X - LocationGwil.X), (int)(obOldEventArgsGwil.Y - LocationGwil.Y), obOldEventArgsGwil.Delta);

            //bool to check weather something changed
            bool invalidateControlGwil = false;

            //loops through all controls and raises the mouse leave event if it thinks the mouse was in it
            foreach (csBasicControlGwil obControlGwil in obChildsGwil)
            {
                if (obControlGwil.mouseEnteredGwil == true)
                    obControlGwil.MouseLeaveGwil(obSenderGwil, obMouseEventGwil);
                if (obControlGwil.changedSinceDrawGwil == true)
                    invalidateControlGwil = true;
            }

            //invalidate control if we need to
            if (invalidateControlGwil == true)
                changedSinceDrawGwil = true;
        }

        /// <summary>
        /// Sends mouse moved event to the control the mouse moved in(or when it moves in/out raises
        /// those events too)
        /// </summary>
        /// <param name="obSenderGwil">The parent control</param>
        /// <param name="eGwil">The mouse event args</param>
        private void MouseMove(object obSenderGwil, System.EventArgs eGwil)
        {
            //convert the event args to correct format
            MouseEventArgs obOldEventArgsGwil = (MouseEventArgs)eGwil;
            MouseEventArgs obMouseEventGwil = new MouseEventArgs(obOldEventArgsGwil.Button, obOldEventArgsGwil.Clicks,
                (int)(obOldEventArgsGwil.X - LocationGwil.X), (int)(obOldEventArgsGwil.Y - LocationGwil.Y), obOldEventArgsGwil.Delta);

            //the control to preform the event on
            csBasicControlGwil obMouseMoveControlGwil = null;

            //boolean to check if we need to invalidate the form
            bool invalidateControlGwil = false;

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
                        obControlGwil.MouseLeaveGwil(obSenderGwil, obMouseEventGwil);
                }
                else
                {
                    if (obControlGwil.mouseEnteredGwil == true)
                        //otherwise raise leave events
                        obControlGwil.MouseLeaveGwil(obSenderGwil, obMouseEventGwil);
                }

                //check if the control has detected that is should redraw
                if (obControlGwil.changedSinceDrawGwil == true)
                    invalidateControlGwil = true;//set the boolean to true so the form will invalidate
            }

            //if the mouse was not in the control before, raise the entered event first
            if (obMouseMoveControlGwil?.mouseEnteredGwil == false)
                obMouseMoveControlGwil?.MouseEnterRaiseGwil(obSenderGwil, obMouseEventGwil);
            //if so click a move event
            obMouseMoveControlGwil?.MouseMoveRaiseGwil(obSenderGwil, obMouseEventGwil);

            //if the mousemove control changed since the last draw invalidate parent control
            if (obMouseMoveControlGwil?.changedSinceDrawGwil == true)
                changedSinceDrawGwil = true;

            //invalidate control if we need to
            if (invalidateControlGwil == true)
                changedSinceDrawGwil = true;
        }

        /// <summary>
        /// Sends mouse up event to the control if the mouse was pressed down
        /// </summary>
        /// <param name="obSenderGwil">The parent control</param>
        /// <param name="eGwil">The mouse event args</param>
        private void MouseUp(object obSenderGwil, System.EventArgs eGwil)
        {
            //convert the event args to correct format
            MouseEventArgs obOldEventArgsGwil = (MouseEventArgs)eGwil;
            MouseEventArgs obMouseEventGwil = new MouseEventArgs(obOldEventArgsGwil.Button, obOldEventArgsGwil.Clicks,
                (int)(obOldEventArgsGwil.X - LocationGwil.X), (int)(obOldEventArgsGwil.Y - LocationGwil.Y), obOldEventArgsGwil.Delta);

            //bool to check weather we need to invalidate the control
            bool invalidateControlGwil = false;

            foreach (csBasicControlGwil obControlGwil in obChildsGwil)
            {
                if (obControlGwil.mouseDownGwil == true)
                    //raise the mouse up event
                    obControlGwil.MouseUpRaiseGwil(obSenderGwil, obMouseEventGwil);

                if (obMouseEventGwil.X < obControlGwil.LocationGwil.X && obMouseEventGwil.X > obControlGwil.SizeGwil.Width + obControlGwil.LocationGwil.X)
                    //raise the mouse left event
                    obControlGwil.MouseLeaveGwil(obSenderGwil, obMouseEventGwil);

                if (obMouseEventGwil.Y < obControlGwil.LocationGwil.Y && obMouseEventGwil.Y > obControlGwil.LocationGwil.Y + obControlGwil.SizeGwil.Height)
                    //raise the mouse left event
                    obControlGwil.MouseLeaveGwil(obSenderGwil, obMouseEventGwil);
                if (obControlGwil.changedSinceDrawGwil == true)
                    invalidateControlGwil = true;
            }

            //invalidate control if we need to
            if (invalidateControlGwil == true)
                changedSinceDrawGwil = true;
        }

        /// <summary>
        /// Resize child controls on a form resize
        /// </summary>
        /// <param name="obSenderGwil">The sender of the event</param>
        /// <param name="eGwil">The event arguments</param>
        private void ResizeFormGwil(object obSenderGwil, System.EventArgs eGwil)
        {
            csResizeEventgwil obArgumentsGwil = (csResizeEventgwil)eGwil;
            //loop through all controls and resize them
            for (int indexControlsGwil = 0; indexControlsGwil < obChildsGwil.Count; indexControlsGwil++)
            {
                //first set the auto resize and than the form widths because this way the form widths override the auto resize
                csBasicControlGwil obControlGwil = obChildsGwil[indexControlsGwil];
                SizeF oldSizeOfControlGwil = obControlGwil.SizeGwil;
                if (obControlGwil.AutoResizeHeightGwil == true && obControlGwil.AutoResizeWidthGwil == true)
                {
                    obControlGwil.SizeGwil = new SizeF(
                        (float)(obControlGwil.SizeGwil.Width * obArgumentsGwil.HorizontalScaleGwil),
                        (float)(obControlGwil.SizeGwil.Height * obArgumentsGwil.VerticalScaleGwil));
                }
                else
                {
                    if (obControlGwil.AutoResizeWidthGwil == true)
                    {
                        obControlGwil.SizeGwil = new SizeF(
                            (float)(obControlGwil.SizeGwil.Width * obArgumentsGwil.HorizontalScaleGwil), obControlGwil.SizeGwil.Height);
                    }

                    if (obControlGwil.AutoResizeHeightGwil == true)
                    {
                        obControlGwil.SizeGwil = new SizeF(
                            obControlGwil.SizeGwil.Width, (float)(obControlGwil.SizeGwil.Height * obArgumentsGwil.VerticalScaleGwil));
                    }
                }

                //set the to form heights
                if (obControlGwil.IsFormHeightGwil == true && obControlGwil.IsFormWidthGwil == true)
                {
                    obControlGwil.SizeGwil = new SizeF(
                        obArgumentsGwil.FullWidthParentGwil - obControlGwil.SubstractFromFormWidthGwil,
                        obArgumentsGwil.FullHeightParentGwil - obControlGwil.SubstractFromFormHeightGwil);
                }
                else
                {
                    if (obControlGwil.IsFormHeightGwil == true)
                        obControlGwil.SizeGwil = new SizeF(
                            obControlGwil.SizeGwil.Width,
                            obArgumentsGwil.FullHeightParentGwil - obControlGwil.SubstractFromFormHeightGwil);

                    if (obControlGwil.IsFormWidthGwil == true)
                        obControlGwil.SizeGwil = new SizeF(
                            obArgumentsGwil.FullWidthParentGwil - obControlGwil.SubstractFromFormWidthGwil,
                            obControlGwil.SizeGwil.Height);
                }
                csResizeEventgwil toRaiseGwil = new csResizeEventgwil(obArgumentsGwil.VerticalScaleGwil, obArgumentsGwil.HorizontalScaleGwil,
                    obArgumentsGwil.OldSizeOfCurrentControlGwil, SizeGwil, (int)SizeGwil.Width, (int)SizeGwil.Height, oldSizeOfControlGwil);
                obControlGwil.RaiseResizeEventGwil(this, toRaiseGwil);
            }
        }

        #endregion Methods
    }
}