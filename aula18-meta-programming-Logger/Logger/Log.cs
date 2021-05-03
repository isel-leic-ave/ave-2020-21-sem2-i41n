using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Logger
{
    public class Log : AbstractLog
    {
        public Log()
        {
        }

        public Log(IPrinter p) : base(p)
        {
        }

        

        public override IEnumerable<IGetter> GetMembers(Type t)
        {
            // First check if exist in members dictionary
            List<IGetter> ms;
            if(!members.TryGetValue(t, out ms)) {
                ms = new List<IGetter>();
                foreach(MemberInfo m in t.GetMembers()) {
                    IGetter getter = null; 
                    if(ShoudlLog(m, out getter)) {
                        ms.Add(getter);
                    }
                }
                members.Add(t, ms);
            }
            return ms;
        }
    }
}
