using System.Collections.Generic;

namespace DragRacerGwil.Controls
{
    /// <summary>
    /// The sorter for sorting the list of controls
    /// </summary>
    public class csSorter : IComparer<csBasicControlGwil>
    {
        #region Methods

        /// <summary>
        /// Compare the control on the z-index
        /// </summary>
        /// <param name="x">Control 1</param>
        /// <param name="y">Control 2</param>
        /// <returns></returns>
        public int Compare(csBasicControlGwil x, csBasicControlGwil y)
        {
            if (x.Z_indexGwil > y.Z_indexGwil)
                return 1;
            else if (x.Z_indexGwil < y.Z_indexGwil)
                return -1;
            else
                return 0;
        }

        #endregion Methods
    }
}