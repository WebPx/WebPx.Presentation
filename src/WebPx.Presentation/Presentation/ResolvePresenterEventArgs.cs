﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebPx.Presentation
{
    public class ResolvePresenterEventArgs
    {
        public ResolvePresenterEventArgs(Type viewType)
        {
            ViewType = viewType;
        }

        public Type ViewType { get; private set; }

        public Type PresenterType { get; set; }
    }
}
