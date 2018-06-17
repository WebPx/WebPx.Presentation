using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPx.Presentation
{
    public class PresenterResolverOld
    {
        static PresenterResolverOld()
        {

        }

        public virtual TService GetPresenter<TService>()
            where TService:class
        {

        }
    }
}
