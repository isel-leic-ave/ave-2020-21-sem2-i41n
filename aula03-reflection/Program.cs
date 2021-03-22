using System;
using System.Reflection;

namespace TCP02
{
    class Program
    {
        static void Main(string[] args)
        {
            //Carregar dinamicamente os metadados da DLL. Usa caminho absoluto
            //Assembly fileToRead = Assembly.LoadFile("D:\\Particular\\ISEL\\Ano 2 Sem 4\\AVE\\GIT\\AVE_homework\\TPC02\\RestSharp.dll");
            Assembly fileToRead = Assembly.LoadFrom("RestSharp.dll");

            //Tipoe e Metodos
            foreach (Type type in fileToRead.GetTypes())
            {
                Console.WriteLine(type.Name);

                foreach (MethodInfo method in type.GetMethods())
                {
                    Console.WriteLine("\t" + method.Name);
                }
            } 
        }
    }
}
/* 
    Assembly    --> loadFrom()     GetTypes()   
    Type        --> GetMethods()   GetFields()  GetField(string)

    .net System.Reflection
    e.g: obj.GetType().GetMethod("hello").Invoke(foo, null)
         obj.GetType().GetMethod("hello").GetParameters())
*/