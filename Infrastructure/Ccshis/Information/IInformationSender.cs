using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ccshis.Information
{
    public interface IInformationSender
    {
        Task SendAsync<T>(List<string> receivers, T information) where T:IInformation;
    }
}
