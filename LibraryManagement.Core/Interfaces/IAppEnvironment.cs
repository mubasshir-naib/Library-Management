﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Core.Interfaces
{
    public interface IAppEnvironment
    {
        string WebRootPath { get; }
        string ContentRootPath { get; }
    }
}
