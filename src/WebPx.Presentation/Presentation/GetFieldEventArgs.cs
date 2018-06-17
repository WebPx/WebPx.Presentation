using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebPx.Presentation
{
    public sealed class GetFieldEventArgs<TValue>
    {
        public GetFieldEventArgs()
        {

        }

        public GetFieldEventArgs(string fieldName)
        {
            this.FieldName = fieldName;
        }

        public string FieldName { get; private set; }

        public TValue Value { get; set; }
    }
}
