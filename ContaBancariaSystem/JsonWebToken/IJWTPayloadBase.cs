﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JsonWebToken
{
    public interface IJWTPayloadBase
    {
        long exp { get; set; }
    }
}
