using System;
using System.Collections.Generic;
using System.Text;

namespace Ccshis.Information.Email
{
    public interface IEmailSender
    {
        void Send(List<string> receivers, EmaiInformation information);
    }
}
