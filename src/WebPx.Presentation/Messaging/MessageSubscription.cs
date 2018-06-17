using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPx.Messaging
{
    class MessageSubscription
    {
        public MessageSubscription(string eventName, MessageEventHandler handler)
        {
            this.EventName = eventName;
            this.Handler = handler;
        }

        public string EventName { get; set; }

        public MessageEventHandler Handler { get; set; }
    }
}
