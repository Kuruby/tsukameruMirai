using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yumeTakusan.Input.Patching
{
    internal class PastPresent<T>
    {
        public PastPresent(T initialvalue = default(T))
        {

        }

        private T present;
        public T Present {
            get => present;
            set
            {
                Past = present;
                present = value;
            }

        }

        public T Past { get; private set; }

    }
}
