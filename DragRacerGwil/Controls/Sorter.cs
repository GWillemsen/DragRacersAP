using System.Collections.Generic;

namespace DragRacerGwil.Controls
{
    public class Sorter : IComparer<csBasicControlGwil>
    {
        #region Methods

        public int Compare(csBasicControlGwil x, csBasicControlGwil y)
        {
            if (x.Z_indexGwil > y.Z_indexGwil)
                return 1;
            else if (x.Z_indexGwil == y.Z_indexGwil)
                return 0;
            else if (x.Z_indexGwil < y.Z_indexGwil)
                return -1;
            return 0;
        }

        #endregion Methods
    }
}