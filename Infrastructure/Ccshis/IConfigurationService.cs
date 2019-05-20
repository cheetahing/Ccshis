﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ccshis
{
    public interface IConfigurationService
    {
        T Get<T>(string key) where T:ISetting;

        string Get(string key);
    }
}