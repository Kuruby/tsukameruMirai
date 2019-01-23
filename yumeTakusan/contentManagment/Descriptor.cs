using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yumeTakusan.ContentManagment
{
    /// <summary>
    /// Describes how content is stored and what it is.
    /// </summary>
    public struct Descriptor
    {
        /// <summary>
        /// Type of the content as stored
        /// </summary>
        public string Datatype;

        /// <summary>
        /// Type of the content as loaded
        /// </summary>
        public string Type;

        /// <summary>
        /// Relative location where the content is located
        /// </summary>
        public string Path;

        /// <summary>
        /// What the content is called
        /// </summary>
        public string Identifier;
        
        /// <summary>
        /// The locale that the content has (if any)
        /// </summary>
        public string Locale;

        /// <summary>
        /// Creates a content descriptor
        /// </summary>
        /// <param name="Datatype">Type of content on disk</param>
        /// <param name="Type">Type of content as loaded</param>
        /// <param name="Path">Relative location "on disk" of content</param>
        /// <param name="Identifier">What the content is called</param>
        /// <param name="Locale">Locale (if any) of the content</param>
        public Descriptor(string Datatype, string Type, string Path, string Identifier, string Locale = null)
        {
            this.Datatype = Datatype;
            this.Type = Type;
            this.Path = Path;
            this.Identifier = Identifier;
            this.Locale = Locale ?? "neutral";
        }
    }

}
