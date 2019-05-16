using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ccshis.Information.Email
{
    public interface IEmailSender
    {
        Task SendAsync(List<string> receivers, EmaiInformation information);
    }
}
