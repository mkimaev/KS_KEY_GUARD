using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace Key_Guard_KS
{
    public class MailHelper : IMailSenderSMTP
    {
        public string HostSMTP => "smtp.gmail.com";
        public string LoginSMTP => "ks.key.guard@gmail.com";
        public string PasswordIMAP => "A192837465!";
        public int Port => 587;
        public bool Ssl { get => true; set { } }
        public string TempBody { get; set; }
        public string KeyName { get; set; }

        public MailHelper() {}

        public void SendMail(string To, string bodyParameter, string typeOperation)
        {
            MailMessage message1 = new MailMessage(new MailAddress(LoginSMTP, "KS_KEY_GUARD"), new MailAddress(To));
            message1.Subject = "Ключ " + KeyName + " был " + typeOperation;
            message1.Body = bodyParameter;
            message1.IsBodyHtml = true;
            message1.BodyEncoding = Encoding.UTF8;

            SmtpClient smtp1 = new SmtpClient(HostSMTP, Port);
            smtp1.Credentials = new NetworkCredential(LoginSMTP, PasswordIMAP);
            smtp1.EnableSsl = Ssl;

            smtp1.Send(message1);


        }
    }
}