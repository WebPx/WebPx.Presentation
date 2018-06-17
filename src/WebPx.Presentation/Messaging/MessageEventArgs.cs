using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPx.Messaging
{
    public class MessageEventArgs : EventArgs
    {
        public MessageEventArgs(string message)
        {
            this.Message = message;
        }

        public string Message { get; private set; }
    }

    public class MessageEventArgs<TEntity> : MessageEventArgs
    {
        public MessageEventArgs(TEntity instance, string message) : base(message)
        {
            this.Instance = instance;
        }

        public TEntity Instance { get; private set; }
    }
}
