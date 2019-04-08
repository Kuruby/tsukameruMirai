using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yumeTakusan.Events
{
    /// <summary>
    /// Event handler for events with no data.
    /// </summary>
    public delegate void YTEventHandler();
    /// <summary>
    /// Event handler for events with eventargs data.
    /// </summary>
    /// <param name="E">Event arguments for the called function.</param>
    public delegate void YTEventHandlerE(EventArgs E);
    /// <summary>
    /// Event handler for events with object data.
    /// </summary>
    /// <param name="sender">The object that called the handler.</param>
    public delegate void YTEventHandlerO(object sender);
    /// <summary>
    /// Event handler for events with object and eventargs data.
    /// </summary>
    /// <param name="sender">The object that called the handler.</param>
    /// <param name="e">Event arguments for the called function.</param>
    public delegate void YTEventHandlerOE(object sender, EventArgs e);

    /// <summary>
    /// Handles a situation of whether to pass to the next handler or not
    /// </summary>
    /// <param name="sender">Event data sent</param>
    /// <returns>whether to send it to the next one.</returns>
    public delegate bool PassThroughHandler(object sender);
}
