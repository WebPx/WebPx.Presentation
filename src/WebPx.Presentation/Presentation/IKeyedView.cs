﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPx.Presentation
{
    public interface IKeyedView<TKey>
    {
        TKey Id { get; set; }
    }
}
