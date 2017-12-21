﻿using System;
using System.Collections.Generic;

namespace DragRacerGwil.Controls
{
    public class csControlListGwil : List<csBasicControlGwil>
    {
        #region Methods

        /// <summary>
        /// Adds item to the list
        /// </summary>
        /// <param name="itemGwil">The item to add to the list if it doesn't exist yet</param>
        public new void Add(csBasicControlGwil itemGwil)
        {
            //if the name does not exist, add item to the list, else throw an exception
            if (GetByNameGwil(itemGwil.NameGwil) == null)
                this.Insert(Count, itemGwil);
            else
                throw new csItemHasNameThatExististGwil();
        }

        /// <summary>
        /// Adds the items to the list
        /// </summary>
        /// <param name="itemGwil">The items to add to the list</param>
        /// <returns>The items that where already in the list</returns>
        public List<csBasicControlGwil> AddRange(csBasicControlGwil[] itemsGwil)
        {
            List<csBasicControlGwil> alreadExistingItemsGwil = new List<csBasicControlGwil>();
            //loop through the list and insert each item to the list of which the name doesn't already exists(when it does add it to the return list)
            foreach (csBasicControlGwil itemGwil in itemsGwil)
                if (GetByNameGwil(itemGwil.NameGwil) == null)
                    this.Insert(Count, itemGwil);
                else
                    alreadExistingItemsGwil.Add(itemGwil);
            //return items that are already by name in the list
            return alreadExistingItemsGwil;
        }

        /// <summary>
        /// Get an item in the list by its name
        /// </summary>
        /// <param name="nameGwil">The name of the control to return</param>
        /// <returns>The matched control, or null when not found</returns>
        public csBasicControlGwil GetByNameGwil(string nameGwil)
        {
            //loop through all the items in the list and match for names, if found than return that item
            for (int indexGwil = Count - 1; indexGwil > 0; indexGwil--)
                if (this[indexGwil].NameGwil == nameGwil)
                    return this[indexGwil];

            //if no match found return null
            return null;
        }

        #endregion Methods
    }

    /// <summary>
    /// The custom class for the exception that shows that the name is the same for 2 items in the list
    /// </summary>
    public class csItemHasNameThatExististGwil : Exception
    {
        #region Properties

        /// <summary>
        /// Override the message so it show the correct one now
        /// </summary>
        public override string Message => "The item has a name that is already used in this list. Please use an other.";

        #endregion Properties
    }

    /// <summary>
    /// An class that modify's the exception to contain a list of item on which it has errors
    /// </summary>
    public class csItemsHaveNameThatExististGwil : Exception
    {
        #region Fields
        private List<csBasicControlGwil> errorOnListGwil = new List<csBasicControlGwil>();

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Creates an new instance of this type of error
        /// </summary>
        /// <param name="erroredOnItemsGwil">A list that contains the items that it error ed on</param>
        public csItemsHaveNameThatExististGwil(List<csBasicControlGwil> erroredOnItemsGwil)
        {
            //set the list
            errorOnListGwil = erroredOnItemsGwil;
        }

        #endregion Constructors

        #region Properties

        ///<summary>
        ///Return the list as read-only
        ///</summary>
        public List<csBasicControlGwil> ErroredOnListGwil { get => errorOnListGwil; }

        /// <summary>
        /// Override the message so it show the correct one now
        /// </summary>
        public override string Message => "The item has a name that is already used in this list. Please use an other.";

        #endregion Properties
    }
}