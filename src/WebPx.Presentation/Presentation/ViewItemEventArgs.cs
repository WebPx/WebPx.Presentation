using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace WebPx.Presentation
{
    public class ViewItemEventArgs<TEntity> : EventArgs
    {
        public ViewItemEventArgs()
        {

        }

        public TEntity Item { get; set; }

        private bool _success = false;

        [DefaultValue(false)]
        public bool Success
        {
            get { return _success; }
            set { _success = value; }
        }

    }
}
