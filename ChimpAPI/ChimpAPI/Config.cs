using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChimpAPI
{
    class Config
    {
        public Config(string apiKey, string AccountEmail, string AccountPassword, string replyToAddress)
        {
            string[] key = apiKey.Split('-');
            API_KEY = key[0].Substring(4);
            SERVER = key[1];
            Email = AccountEmail;
            Password = AccountPassword;
            ReplyToAddress = replyToAddress;
        }

        internal static string API_KEY { get; private set; }
        internal static string SERVER { get; private set; }

        internal static string Email { get; set; }
        internal static string Password { get; set; }

        internal static string ReplyToAddress { get; set; }
    }
}
