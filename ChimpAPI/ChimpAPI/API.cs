
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChimpAPI
{
    public class API
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="LoadFromConfig">Ignores Optional Params and loads the config from api.ini</param>
        /// <param name="apiKey">Api key for the mail chimp account</param>
        /// <param name="AccountEmail">Email of the mail chimp account</param>
        /// <param name="AccountPassword">Password of the mail chimp account</param>
        /// <param name="ReplyToEmail">Reply to email for the mailchimp account</param>
        public API(bool LoadFromConfig, string apiKey = null, string AccountEmail = null, string AccountPassword = null, string ReplyToEmail = null)
        {
            Logger.Log("Started ChimpAPI", Logger.Severity.Debug);
            if (LoadFromConfig)
            {
                LDConfig();
            }
            else
            {
                if (CheckValidKey(apiKey))
                {
                    new Config(apiKey, AccountEmail, AccountPassword, ReplyToEmail);
                }              
            }
        }
        //"8355a301d8" 
        /// <summary>
        /// Executes a API command on a passing the resulting JsonObject To the Callback Function.
        /// </summary>
        /// <param name="cmd">the command to run</param>
        /// <param name="cb">Function Pointer to callback</param>
        /// <param name="_params">parameters needed by commands</param>
        /// <returns></returns>
        public bool ExecCommand(Commands cmd, Func<object, bool> cb, object[] _params = null)
        {
            return Core.CommandMgr.ExecuteCommand(cmd.ToString(), cb, _params);
        }

        //Loads the Config File (api.ini)
        private static void LDConfig()
        {
            string path = Application.StartupPath + @"\api.ini";
            if (!File.Exists(path))
            {
                using(var fs = File.Create(path))
                {
                    string ini_text = "Key=\nEmail=\nPassword=\nReplyToEmail=\n";
                    fs.Write(Encoding.Default.GetBytes(ini_text), 0, ini_text.Length);
                    Logger.Log("new Config File Created, Please update the settings and try again.", Logger.Severity.Error);
                    Process.Start(path);
                }

            }
            else
            {
                var cfg = File.ReadAllLines(path);
                if (CheckValidKey(cfg[0]))
                {
                    new Config(cfg[0], cfg[1], cfg[2], cfg[3]);
                }
            }
        }

        //Ensures the provided api key is the valid format.
        private static bool CheckValidKey(string key)
        {
            if (key.Contains("-"))
            {
                return true;
            }
            else
            {
                Logger.Log("Invalid ApiKey Format.", Logger.Severity.Error);
                return false;
            }
        }

        /// <summary>
        /// This method will update both mailchimp and the local DB for all subed users.
        /// </summary>
        /// <param name="data">MemberList Json Object</param>
        /// <returns></returns>
        
        /// <summary>
        /// This Will send out a Email to all defined emails.
        /// </summary>
        /// <param name="Message">Body of the Email</param>
        /// <param name="Subject">Subject of the Email</param>
        /// <param name="Recipients">a List of email recipiets (*FORMAT*)user@gmail.com</param>
       
        public enum Commands
        {
            GetLists,
            GetMembers,
            AddMember
        }
    }
}
