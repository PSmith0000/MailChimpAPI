using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChimpAPI;
using ChimpAPI.Utils;
namespace Tester
{
    class Program
    {
       

        static void Main(string[] args)
        {
            Logger.NewLogEvent += Logger_NewLogEvent;
            API api = new API(true);

            


            if (api.ExecCommand(API.Commands.GetMembers, DataOpt, new object[] { "8355a301d8" }))
            {
                Console.WriteLine("Command Executed Successfully.");
            }

            
            
            Console.Read();
        }

        private static void Logger_NewLogEvent(object sender, EventArgs e)
        {
            Console.WriteLine((e as Log).Message);
        }

       
        static bool DataOpt(object data)
        {

            var result = (data as ChimpAPI.Core.JsonObjects.Members.MembersList);
            result.Members.ToList().ForEach(x =>
            {
                Console.WriteLine(x.EmailAddress);
            });
            return true;
        }

    }
}
