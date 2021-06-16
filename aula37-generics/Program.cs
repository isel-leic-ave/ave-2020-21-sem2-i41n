using System;

namespace aula37_generics
{
    class A<T> {

        public void Bar(string label, T arg) {

        }

        public R Zas<R>(T aux) where R : Point{
            return null;
        }
    }

    class Program
    {

        static int Foo<T>(int nr, String msg, T target) {
            return nr + msg.Length + target.GetHashCode();
        }

        static void Main(string[] args)
        {
            A<String> a1 = null;
            A<int> a2 =  null;
            A<Point> a3 =  null;

            Foo<Point>(78, "super", new Point());
        }
    }

    internal class Point
    {
    }
}
