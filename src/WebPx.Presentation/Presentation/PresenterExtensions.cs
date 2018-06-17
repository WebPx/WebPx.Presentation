using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPx.Presentation
{
    public static class PresenterExtensions
    {
        public static ViewResult<TEntity> TryInvoke<TEntity>(this ViewItemEventHandler<TEntity> theEvent, object sender, TEntity original = default(TEntity))
        {
            var result = default(TEntity);
            bool success = false;
            if (theEvent != null)
            {
                var args = new ViewItemEventArgs<TEntity>();
                if (!object.Equals(original, default(TEntity)))
                    args.Item = original;
                theEvent(sender, args);
                success = args.Success;
                result = args.Item;
            }
            return new ViewResult<TEntity>(result, success);
        }

        public static TValue TryInvoke<TValue>(this GetFieldEventHandler<TValue> theEvent, object sender, string fieldName = null, TValue defaultValue = default(TValue))
        {
            var result = defaultValue;
            if (theEvent != null)
            {
                var args = new GetFieldEventArgs<TValue>(fieldName);
                theEvent(sender, args);
                result = args.Value;
            }
            return result;
        }
    }
}
