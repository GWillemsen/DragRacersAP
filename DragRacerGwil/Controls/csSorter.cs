using System.Collections.Generic;

namespace DragRacerGwil.Controls
{
    public class csSorter : IComparer<csBasicControlGwil>
    {
        #region Methods

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