using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yumeTakusan.ContentManagment
{
    /// <summary>
    /// Stores content of an indeterminate type
    /// </summary>
    public sealed class Content
    {
        /// <summary>
        /// Creates the content
        /// </summary>
        /// <param name="T">type of content</param>
        /// <param name="_Content">content, boxed to an object</param>
        /// <param name="Identifier">String uniquely identifying this content</param>
        /// <param name="Tags">the string tags for it</param>
        public Content(Type T, object _Content, string Identifier, string[] Tags = null)
        {
            this.T = T;
            this._Content = _Content;
            this.Identifier = Identifier;
            this.Tags = Tags ?? new string[0];
        }

        /// <summary>
        /// THe type of the content
        /// </summary>
        public Type T { get; private set; }

        /// <summary>
        /// The content
        /// </summary>
        public object _Content { get; private set; }

        /// <summary>
        /// string uniquely identifying this content
        /// </summary>
        public string Identifier { get; private set; }

        /// <summary>
        /// The tags for the content
        /// </summary>
        public string[] Tags { get; private set; }

    }
}
