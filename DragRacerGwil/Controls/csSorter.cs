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
        /// <param name="obControlAGwil">Control 1</param>
        /// <param name="obControlBGwil">Control 2</param>
        /// <returns></returns>
        public int Compare(csBasicControlGwil obControlAGwil, csBasicControlGwil obControlBGwil)
        {
            if (obControlAGwil.Z_indexGwil > obControlBGwil.Z_indexGwil)
                return 1;
            else if (obControlAGwil.Z_indexGwil < obControlBGwil.Z_indexGwil)
                return -1;
            else
                return 0;
        }

        #endregion Methods
    }
}