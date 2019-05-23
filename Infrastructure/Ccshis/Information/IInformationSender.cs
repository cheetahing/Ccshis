using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ccshis.Information
{
    public interface IInformationSenderService
    {
        Task SendAsync<T>(List<string> receivers, T information) where T:IInformation;
        Task SendAsync<T>(string oneReceiver, T information);
    }
}
