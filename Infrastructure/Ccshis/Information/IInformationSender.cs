using System;
using System.Collections.Generic;
using System.Text;

namespace Ccshis.Information
{
    public interface IInformationSender
    {
        void Send<T>(List<string> receivers, T information) where T:IInformation;
    }
}
