using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPx.Presentation
{
    public sealed class PageEventArgs : EventArgs
    {
        public PageEventArgs(int startRowIndex = 0, int maximumRows = 0)
        {
            this.StartRowIndex = startRowIndex;
            this.MaximumRows = maximumRows;
        }

        public int StartRowIndex { get; private set; }
        public int MaximumRows { get; private set; }

        private static readonly PageEventArgs Empty = new PageEventArgs();
    }
}
