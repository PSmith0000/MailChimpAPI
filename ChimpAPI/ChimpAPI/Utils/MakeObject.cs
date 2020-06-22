using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChimpAPI.Utils
{
    public class MakeObject
    {
        public static Core.JsonObjects.ModifyMember.Member MakeMember(string email, string status, string FNAME, string LNAME)
        {
            Core.JsonObjects.ModifyMember.Member mem = new Core.JsonObjects.ModifyMember.Member();
            Core.JsonObjects.ModifyMember.MergeFields merge = new Core.JsonObjects.ModifyMember.MergeFields();
            merge.Fname = FNAME;
            merge.Lname = LNAME;
            mem.EmailAddress = email;
            mem.Status = status;
            mem.MergeFields = merge;
            return mem;
        }
    }
}
