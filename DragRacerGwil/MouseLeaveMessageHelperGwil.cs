﻿using DragRacerGwil.Controls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DragRacerGwil
{
    public static class MessageHelperGwil
    {
        #region Fields

        //weather the filter is initialized
        private static bool initedGwil = false;

        //the message filter/listener
        private static MouseLeaveMessageFilterGwil obMessageFilterGwil = new MouseLeaveMessageFilterGwil();

        #endregion Fields

        #region Methods

        /// <summary>
        /// Add the form to the watch list if is not null
        /// </summary>
        /// <param name="obParentFormGwil">The form to add</param>
        public static void AddMessageFilterGwil(Form obParentFormGwil)
        {
            if (initedGwil == false)
            {
                initedGwil = true;
                Application.AddMessageFilter(obMessageFilterGwil);
            }

            //add the form to the watch list if it is not null
            if (obParentFormGwil != null && obMessageFilterGwil.obTargetFormsGwil.Contains(obParentFormGwil) == false)
            {
                obMessageFilterGwil.obTargetFormsGwil.Add(obParentFormGwil);
                obParentFormGwil.FormClosed += (obSenderGwil, obEGwil) =>
                 {
                     RemoveFormFromList((Form)obSenderGwil);
                 };
            }
        }

        /// <summary>
        /// Log the message to the set serial monitor(if it is set) and also to the debugger
        /// </summary>
        /// <param name="messageToLogGwil">The message to send to the monitor and debugger</param>
        public static void LogMessage(string messageToLogGwil, bool extensiveLogItem = false)
        {
            if (obMessageFilterGwil.obFrmSerialMonitorGwil != null && extensiveLogItem == false)
                obMessageFilterGwil.obFrmSerialMonitorGwil.LogMessageGwil(messageToLogGwil);
            System.Diagnostics.Debug.WriteLine(messageToLogGwil);
        }

        /// <summary>
        /// Remove the given form from the watch list
        /// </summary>
        /// <param name="form">Form the remove</param>
        public static void RemoveFormFromList(Form form)
        {
            if (obMessageFilterGwil.obTargetFormsGwil.Contains(form) == true)
                obMessageFilterGwil.obTargetFormsGwil.Remove(form);
        }

        /// <summary>
        /// Sets this form as the serial monitor, if it is not null Waring, the log function must
        /// have LogMessageGwil as name
        /// </summary>
        /// <param name="obSerialMonitorGwil">The serial monitor</param>
        public static void SetSerialMonitorGwil(Form obSerialMonitorGwil)
        {
            //set the serial monitor if the parameter is not null
            if (obSerialMonitorGwil != null)
                obMessageFilterGwil.obFrmSerialMonitorGwil = obSerialMonitorGwil;
        }

        #endregion Methods
    }

    internal class MouseLeaveMessageFilterGwil : IMessageFilter
    {
        #region Constructors

        public MouseLeaveMessageFilterGwil()
        {
            obTargetFormsGwil = new List<dynamic>();
        }

        #endregion Constructors

        #region Properties

        //serialMonitor
        internal dynamic obFrmSerialMonitorGwil { get; set; }

        //list of form to update on message
        internal List<dynamic> obTargetFormsGwil { get; set; }

        #endregion Properties

        #region Methods

        public bool PreFilterMessage(ref Message m)
        {
            //check the message if it is for us
            if (m.Msg == 0x02A3 /*WM_MOUSELEAVE*/)
            {
                foreach (dynamic obTargetGwil in obTargetFormsGwil)
                {
                    try
                    {
                        //raise mouse leave events on all controls that think the mouse is still there
                        foreach (csBasicControlGwil obControlGwil in obTargetGwil.obControlsGwil)
                        {
                            if (obControlGwil.mouseEnteredGwil == true)
                            {
                                obControlGwil.MouseLeaveGwil(obTargetGwil, new MouseEventArgs(MouseButtons.None, 0, -1, -1, 0));
                                obFrmSerialMonitorGwil?.LogMessageGwil("Raised mouse leave event on: " + obControlGwil.NameGwil);
                            }
                        }
                    }
                    catch (Exception obExGwil)
                    {
                        System.Diagnostics.Debug.WriteLine("A error occurred while trying to raise the event that the mouse left the form. Details: " + obExGwil.ToString());
                        obFrmSerialMonitorGwil?.LogMessageGwil("A error occurred while trying to raise the event that the mouse left the form. Details: " + obExGwil.ToString());
                    }
                }
            }

            return false;
        }

        #endregion Methods
    }
}