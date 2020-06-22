using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Json;
namespace ChimpAPI.Core
{
    class CommandMgr
    {
        //list_id 8355a301d8
        internal static Dictionary<string, Command> Commands = new Dictionary<string, Command>()
        {
            {"GetLists", new Command("GET", "lists", typeof(JsonObjects.Lists.ListObjects))},
            {"GetMembers", new Command("GET", "lists/ID/members", typeof(JsonObjects.Members.MembersList)) },
            {"AddMember", new Command("POST", "lists/ID/members/", typeof(JsonObjects.ModifyMember.Member)) }
        };
        /// <summary>
        /// Executes a command from the dictionary above.
        /// </summary>
        /// <param name="name">Name of the command</param>
        /// <param name="Callback">Callback to where the data gets manipulated</param>
        /// <param name="optional_params">Parameters for Query Strings or to fix GetMembers cmd</param>
        /// <returns></returns>
        internal static bool ExecuteCommand(string name, Func<object, bool> Callback, object[] optional_params = null)
        {
            var cmd = Commands.Where(x => x.Key == name).FirstOrDefault().Value;

            if (cmd.JsonType == typeof(JsonObjects.Lists.ListObjects))
            {
                return Callback(cmd.Execute<JsonObjects.Lists.ListObjects>());
            }
            else if (cmd.JsonType == typeof(JsonObjects.Members.MembersList))
            {
               if (optional_params != null)
                {
                    cmd.RequestUri = cmd.RequestUri.Replace("ID", optional_params[0].ToString());
                    return Callback(cmd.Execute<JsonObjects.Members.MembersList>());
                }
                else
                {
                    Logger.Log("Command: " + name + " Requires Optional Paramters. (ListID)", Logger.Severity.Error);
                }
            }
            else if(cmd.JsonType == typeof(JsonObjects.ModifyMember.Member))
            {
                if (optional_params != null)
                {
                    cmd.RequestUri = cmd.RequestUri.Replace("ID", optional_params[0].ToString());
                    cmd.data = optional_params[1];
                    return Callback(cmd.Execute<object>());
                }
                else
                {
                    Logger.Log("Command: " + name + " Requires Optional Paramters. (ID, MemberData)", Logger.Severity.Error);
                }
            }
            return false;
        }
    }
}
