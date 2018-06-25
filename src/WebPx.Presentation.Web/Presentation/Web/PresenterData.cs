using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPx.Presentation.Web
{
    class PresenterData : IPresenterData
    {
        public PresenterData(PresentationData source)
        {
            _control = source;
            _source = source;
        }

        private PresentationData _control;
        private IStateBag _source;

        public object this[string key]
        {
            get
            {
                return _source.Data[key];
            }
            set
            {
                _source.Data[key] = value;
            }
        }

        public PresentationData Control
        {
            get
            {
                return _control;
            }
        }
    }
}
