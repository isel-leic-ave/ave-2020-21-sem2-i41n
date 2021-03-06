using System;
using System.Reflection;
using System.Text;

namespace Logger
{
    public class Log
    {
        public void Info(Object target) {
            StringBuilder builder = new StringBuilder();
            builder.Append(target.GetType().Name);
            builder.Append("{");
            /**
             * Get information of members to log
             */
            builder.Append(LogMembers(target));
            /**
             * Finish output formatting
             */
            if(builder.Length != 0) builder.Length-= 2;
            builder.Append("}");
            /**
             * Print to Console
             */
            Console.WriteLine(builder.ToString());
        }
        public string LogMembers(Object target) {
            StringBuilder builder = new StringBuilder();
            // Inspect Fields
            foreach(MemberInfo m in target.GetType().GetMembers()) {
                if(ShoudlLog(m)) {
                    builder.Append(m.Name);
                    builder.Append(':');
                    builder.Append(GetValue(m, target));
                    builder.Append(", ");
                }
            }
            return builder.ToString();
        }
        private bool ShoudlLog(MemberInfo m)
        {
            return (m.MemberType == MemberTypes.Field) 
                || (m.MemberType == MemberTypes.Method 
                    && ((MethodInfo) m).GetParameters().Length == 0);
        }

        private object GetValue(MemberInfo m, object target)
        {
            switch(m.MemberType) {
                case MemberTypes.Field:
                    return ((FieldInfo) m).GetValue(target);
                case MemberTypes.Method:
                    return ((MethodInfo) m).Invoke(target, null);
                default:
                    throw new InvalidOperationException("Member should not be logged!");
            }
        }
    }
}
