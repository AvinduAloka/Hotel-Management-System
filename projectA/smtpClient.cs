using System;
using System.Net;
using System.Net.Mail;

namespace projectA
{
    internal class smtpClient
    {
        internal NetworkCredential Credentials;

        public SmtpDeliveryMethod DeliveryMethod { get; internal set; }
        public bool EnableSsl { get; internal set; }
        public int Port { get; internal set; }

        internal void Send(MailMessage message)
        {
            throw new NotImplementedException();
        }
    }
}