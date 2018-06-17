using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebPx.Presentation
{
    public sealed class ViewResult<TEntity>
    {
        internal ViewResult(TEntity item, bool success)
        {
            this.Item = item;
            this.Success = success;
        }

        public TEntity Item { get; set; }

        public bool Success { get; set; }

        public static implicit operator bool(ViewResult<TEntity> item)
        {
            return item.Success;
        }

        public static implicit operator TEntity(ViewResult<TEntity> item)
        {
            return item.Item;
        }
    }
}
