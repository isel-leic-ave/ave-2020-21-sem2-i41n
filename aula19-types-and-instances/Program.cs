using System;

namespace aula19_types_and_instances
{
    public class Person {}
    public class Student : Person {
        private readonly string name;
        private readonly int nr;
        public Student(string name, int nr)
        {
            this.name = name;
            this.nr = nr;
        }
    }

    public struct Shape {}
    // public struct Size : Shape { // !!!!! CANNOT do This!!!!
    public struct Size {
        public int height;
        public int weight;
    }


    class Program
    {
        // 
        // If this method receives an instance of a Value Type,
        // that instance will be boxed and then, after the method completion 
        // that instance will be cleaned by the GC.
        //
        static void Print(object o) {
            //....
        }
        static void Main(string[] args)
        {
            /*
             * Value Types
             */
            int n = 7;            // Value type built-in (primitive)
            Size s1 = new Size(); // Value Type user defined
            /*
             * Ref Types
             */
            string s = "isel";          // Reference type
            Student st = new Student("Ze Manel", 13876); // Ref Type user defined
            Object o = st; // Up cast, copying variables: ldloc.3; stloc.4;
            Student st2 = (Student) o; //Down cast; ldloc.4; castclass Student; stloc.5;
            Console.WriteLine(o);
            /*
             * Coercion
             */
            double d = n; // Coercion: ldloc.0; conv.r8; stloc.6;
            /*
             * Boxing and unboxing
             */
            object o2 = n;  // ldloc.0; box Int32; stloc.7;
            object o3 = s1; // ldloc.1; box Size; stloc.8;
            Int32 n2 = (int) o2; // ldloc.7; unbox.any; stloc.9
        }
    }
}
