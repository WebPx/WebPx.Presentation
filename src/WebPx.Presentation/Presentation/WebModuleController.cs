﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPx.Presentation
{
    public class WebModuleController : ModuleController, IModuleController
    {
        public WebModuleController()
        {

        }

        public ApplicationController Owner { get; set; }
    }
}
