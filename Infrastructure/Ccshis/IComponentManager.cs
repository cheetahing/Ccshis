using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Ccshis
{
    public interface IComponentManager
    {
        void RegisterAssembly(Assembly assembly);
    }
}
