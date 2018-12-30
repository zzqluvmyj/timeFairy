using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timeFairy
{
    public class DelegateClass
    {
        public delegate void delegateMinute(TimeSpan m,Thing thing);
        public delegate void delegateThing(Thing thing);
    }
}
