using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XArbete.Web.Utils.Services
{
    public class WebOptions
    {
        public EmailServiceValues EmailServiceValues { get; set; }

    }
    public class EmailServiceValues
    {
        public string Host { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public string SenderAddress { get; set; }
        public string SenderText { get; set; }
    }
}
