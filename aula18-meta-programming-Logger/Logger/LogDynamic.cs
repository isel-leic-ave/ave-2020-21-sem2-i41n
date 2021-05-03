using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Logger
{
    public class LogDynamic : AbstractLog
    {
        public LogDynamic()
        {
        }

        public LogDynamic(IPrinter p) : base(p)
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
                        // 1. Create the class that implements IGetter for that member m in domain type t.
                        // 2. Instantiate the class created on 1.
                        // ms.Add(getter);
                    }
                }
                members.Add(t, ms);
            }
            return ms;
        }
    }
}
