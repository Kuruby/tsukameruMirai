using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yumeTakusan.Interfaces
{
    /// <summary>
    /// Interface for classes needing a disposal flag
    /// </summary>
    interface IDisposalFlag
    {
        /// <summary>
        /// Whether the object is disposed
        /// </summary>
        bool disposed { get; }
    }
}
