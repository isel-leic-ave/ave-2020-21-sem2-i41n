using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Logger
{
    public class Log
    {
        private readonly IPrinter printer;
        private readonly Dictionary<Type, List<MemberInfo>> members = new Dictionary<Type, List<MemberInfo>>();

        public Log(IPrinter p )
        {
            printer = p;
        }

        public Log() : this(new ConsolePrinter())
        {
            
        }
        public void Info(Object target) {
            // option 1: String output = typeof(IEnumerable).IsAssignableFrom(target.GetType())
            // option 2: String output = target is IEnumerable
            // option 3
            IEnumerable seq = target as IEnumerable;
            String output = seq != null
                ? Inspect(seq)
                : Inspect(target);
            printer.Print(output);
        }

        public string Inspect(IEnumerable seq) {
            StringBuilder builder = new StringBuilder();
            builder.Append("Array of: ");
            builder.Append("\n");
            foreach(object item in seq) {
                builder.Append("\t");
                builder.Append(Inspect(item));
                builder.Append("\n");
            }
            return builder.ToString();
        }
        public string Inspect(Object target) {
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
            builder.Append("}");
            return builder.ToString();
        }
        public string LogMembers(Object target) {
            StringBuilder builder = new StringBuilder();
            // Inspect Fields
            foreach(MemberInfo m in GetMembers(target.GetType())) {
                builder.Append(m.Name);
                builder.Append(':');
                builder.Append(GetValue(m, target));
                builder.Append(", ");
            }
            if(builder.Length != 0) builder.Length-= 2;
            return builder.ToString();
        }

        private IEnumerable<MemberInfo> GetMembers(Type t)
        {
            // First check if exist in members dictionary
            List<MemberInfo> ms;
            if(!members.TryGetValue(t, out ms)) {
                ms = new List<MemberInfo>();
                foreach(MemberInfo m in t.GetMembers()) {
                    if(ShoudlLog(m)) {
                        ms.Add(m);
                    }
                }
                members.Add(t, ms);
            }
            return ms;
        }

        private bool ShoudlLog(MemberInfo m)
        {   
            ///
            /// Check if ToLog annotation exists
            /// 
            if(!Attribute.IsDefined(m,typeof (ToLogAttribute))) return false;
            ///
            /// Check if is a field or parameterless method
            /// 
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

        private class ConsolePrinter : IPrinter
        {
            public void Print(string output)
            {
                Console.WriteLine(output);
            }
        }
    }
}
