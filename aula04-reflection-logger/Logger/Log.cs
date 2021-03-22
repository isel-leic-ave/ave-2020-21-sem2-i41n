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
            builder.Append(LogFields(target));
            builder.Append(LogParameterlessMethods(target));
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
        public string LogFields(Object target) {
            StringBuilder builder = new StringBuilder();
            // Inspect Fields
            foreach(FieldInfo f in target.GetType().GetFields()) {
                builder.Append(f.Name);
                builder.Append(':');
                builder.Append(f.GetValue(target));
                builder.Append(", ");
            }
            return builder.ToString();
        }
        public string LogParameterlessMethods(Object target) {
            StringBuilder builder = new StringBuilder();
            // Inspect Fields
            foreach(MethodInfo m in target.GetType().GetMethods()) {
                if(m.GetParameters().Length == 0) {
                    builder.Append(m.Name);
                    builder.Append(':');
                    builder.Append(m.Invoke(target, null));
                    builder.Append(", ");
                }
            }
            return builder.ToString();
        }
    }
}
