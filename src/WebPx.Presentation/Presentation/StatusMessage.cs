using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WebPx.Presentation
{
    public sealed class StatusMessage
    {
        public StatusMessage()
        {

        }

        public StatusType StatusType { get; set; }

        public ContentType ContentType { get; set; }

        public string Content { get; set; }
    }
}
