﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPx.Presentation
{
    [View]
    public interface IDeleteView
    {
        event EventHandler Cancel;
        event EventHandler Save;
    }

    [View]
    public interface IDeleteView<TEntity> : IDeleteView
    {

    }
}