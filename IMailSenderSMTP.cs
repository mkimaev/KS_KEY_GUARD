using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Key_Guard_KS
{
    interface IMailSenderSMTP
    {
        string HostSMTP { get; }
        string LoginSMTP { get; }
        string PasswordIMAP { get; }
        int Port { get; }
        bool Ssl { get; set; }
        void SendMail(string to, string body, string typeOperation);
    }
}
