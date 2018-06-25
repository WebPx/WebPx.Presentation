using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPx.Presentation
{
    public class PresentationDataProvider
    {
        public PresentationDataProvider()
        {

        }

        public virtual IPresenterData PresenterData
        {
            get
            {
                IPresenterData _presentarData = new PresenterDataStore();
                return _presentarData;
            }
        }

        class PresenterDataStore : IPresenterData
        {
            public PresenterDataStore()
            {
                _values = new Dictionary<string, object>();
            }

            private Dictionary<string, object> _values;

            public object this[string key]
            {
                get
                {
                    return _values[key];
                }
                set
                {
                    _values[key] = value;
                }
            }
        }
    }
}
