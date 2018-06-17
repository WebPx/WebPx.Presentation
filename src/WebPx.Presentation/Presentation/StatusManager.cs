using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPx.Presentation
{
    internal class StatusManager
    {
        public StatusManager()
        {

        }

        private List<StatusMessage> _list = new List<StatusMessage>();

        public void Add(StatusMessage message)
        {
            _list.Add(message);
        }

        public StatusMessage[] GetMessages()
        {
            return _list.ToArray();
        }

        public void Reset()
        {
            _list.Clear();
        }
    }

}
