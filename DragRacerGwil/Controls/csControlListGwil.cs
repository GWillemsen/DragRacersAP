using System;
using System.Collections.Generic;

namespace DragRacerGwil.Controls
{
    // <summary>
    /// A list that filters items so it cannot contain 2 controls with the same name </summary>
    public class csControlListGwil : List<csBasicControlGwil>
    {
        #region Constructors

        /// <summary>
        /// Creates a new list that filters items so it cannot contain 2 controls with the same name
        /// </summary>
        public csControlListGwil() { }

        /// <summary>
        /// Creates a new list that filters items so it cannot contain 2 controls with the same name
        /// </summary>
        /// <param name="obBaseListGwil">The list to add the new list, double items will be dropped.</param>
        public csControlListGwil(List<csBasicControlGwil> obBaseListGwil)
        {
            this.AddRange(obBaseListGwil);
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Adds item to the list
        /// </summary>
        /// <param name="obItemGwil">The item to add to the list if it doesn't exist yet</param>
        public new void Add(csBasicControlGwil obItemGwil)
        {
            //if the name does not exist, add item to the list, else throw an exception
            if (GetByNameGwil(obItemGwil.NameGwil) == null)
                this.Insert(Count, obItemGwil);
            else
                throw new csItemHasNameThatExististGwil();
        }

        /// <summary>
        /// Adds the items to the list
        /// </summary>
        /// <param name="obItemsGwil">The items to add to the list</param>
        /// <returns>The items that where already in the list</returns>
        public List<csBasicControlGwil> AddRange(csBasicControlGwil[] obItemsGwil)
        {
            List<csBasicControlGwil> alreadExistingItemsGwil = new List<csBasicControlGwil>();
            //loop through the list and insert each item to the list of which the name doesn't already exists(when it does add it to the return list)
            foreach (csBasicControlGwil obItemGwil in obItemsGwil)
                if (GetByNameGwil(obItemGwil.NameGwil) == null)
                    this.Insert(Count, obItemGwil);
                else
                    alreadExistingItemsGwil.Add(obItemGwil);
            //return items that are already by name in the list
            return alreadExistingItemsGwil;
        }

        /// <summary>
        /// Creates an copy of the list without the referencing to the current one on the heap
        /// </summary>
        /// <returns></returns>
        public csControlListGwil Clone()
        {
            csControlListGwil obNewlistGwil = new csControlListGwil();
            foreach (csBasicControlGwil obBasicControlGwil in this)
                obNewlistGwil.Add(obBasicControlGwil);
            return obNewlistGwil;
        }

        /// <summary>
        /// Get an item in the list by its name
        /// </summary>
        /// <param name="obNameGwil">The name of the control to return</param>
        /// <returns>The matched control, or null when not found</returns>
        public csBasicControlGwil GetByNameGwil(string obNameGwil, bool obUseDeepSearch = true)
        {
            int countNumberGwil = Count;
            //loop through all the items in the list and match for names, if found than return that item
            for (int indexGwil = 0; indexGwil < countNumberGwil; indexGwil++)
            {
                if (this[indexGwil].NameGwil == obNameGwil)
                    return this[indexGwil];
                else if (obUseDeepSearch == true)
                {
                    if (this[indexGwil].GetType() == typeof(csPanelGwil))
                    {
                        object panelToScanGwil = this[indexGwil];
                        csBasicControlGwil obReturnResultGwil = ((csPanelGwil)panelToScanGwil).ChildsListGwil.GetByNameGwil(obNameGwil);
                        if (obReturnResultGwil != null)
                            return obReturnResultGwil;
                    }
                }
            }

            //if no match found return null
            return null;
        }

        /// <summary>
        /// Creates an list of all controls including its child items
        /// </summary>
        /// <param name="obParentControlGwil">
        /// The control the check for child's and add itself to the control list
        /// </param>
        /// <returns>The control it self and its child's</returns>
        public List<csBasicControlGwil> GetRawListOfAllControlGwil(csBasicControlGwil obParentControlGwil)
        {
            //create an return list and add parent control to it
            List<csBasicControlGwil> obReturnListGwil = new List<csBasicControlGwil>();//only return this item
            obReturnListGwil.Add(obParentControlGwil);
            //if the parent control is a panel, loop through the child's controls and add them to the returnList
            if (typeof(csPanelGwil) == obParentControlGwil.GetType())
            {
                for (int indexChildControlGwil = 0; indexChildControlGwil < ((csPanelGwil)obParentControlGwil).ChildsListGwil.Count; indexChildControlGwil++)
                    obReturnListGwil.AddRange(GetRawListOfAllControlGwil(((csPanelGwil)obParentControlGwil).ChildsListGwil[indexChildControlGwil]));
                return obReturnListGwil;
            }
            return obReturnListGwil;
        }

        #endregion Methods
    }

    /// <summary>
    /// The custom class for the exception that shows that the name is the same for 2 items in the list
    /// </summary>
    [Serializable]
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
    [Serializable]
    public class csItemsHaveNameThatExististGwil : Exception
    {
        #region Fields
        private List<csBasicControlGwil> obErrorOnListGwil = new List<csBasicControlGwil>();

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Creates an new instance of this type of error
        /// </summary>
        /// <param name="erroredOnItemsGwil">A list that contains the items that it error ed on</param>
        public csItemsHaveNameThatExististGwil(List<csBasicControlGwil> erroredOnItemsGwil)
        {
            //set the list
            obErrorOnListGwil = erroredOnItemsGwil;
        }

        #endregion Constructors

        #region Properties

        ///<summary>
        ///Return the list as read-only
        ///</summary>
        public List<csBasicControlGwil> ErroredOnListGwil { get => obErrorOnListGwil; }

        /// <summary>
        /// Override the message so it show the correct one now
        /// </summary>
        public override string Message => "The item has a name that is already used in this list. Please use an other.";

        #endregion Properties
    }
}