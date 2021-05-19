using System;

namespace aula25_methods
{

    class Person
    {
        public Person(String name)
        {
        }

        public virtual void Print() { // Java the virtual is implicit
            Console.WriteLine("I am a Person");
        }

        public void Foo() {} // Instance method Non virtual <=> Java final method
    }

    class Student : Person
    {
        public Student(string name) : base(name)
        {
        }

        public override void Print() { // Java the override is implicit
            Console.WriteLine("I am a Student");
        }

        /// <summary>
        ///  Cannot override inherited member 'Person.Foo()' because it is not marked virtual, abstract
        /// </summary>
        // public override void Foo() {}
    }


    public struct Point {
        public int x;
        public  int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        /// <summary>
        ///  Structs cannot contain explicit parameterless constructors
        /// </summary>
        // public Point() { this.x = 77; this.y= 99;}

        public void Bar() {}
    }

    class Triangle {
        Point p1, p2, p3; // 3 instances of Point in-place 
    }

    class Program
    {

        public static void Print(Person p) {
            p.Print();
        }

        static void Main(string[] args)
        {
            Person p  = new Person("ignored"); // => new => instantiates => newobj
            Point pt = new Point();   // => new => initializes => initobj
            Console.WriteLine(pt.x);
            Triangle t = new Triangle(); 

            Object o = pt; // => box => !!!! overhead = newobj

            Point pt2 = new Point(5, 7);   // => new => initializes => call Point::ctor()

            Print(p);
            Print(new Student("none"));

            p.Print(); // callvirt Person::Print()
            p.Foo();   // callvirt Person::Foo()
            
            // pt = null; // Value type variables CANNOT be assigned with NULL
            pt.Bar(); // call Point::Bar()
        }
    }
}
