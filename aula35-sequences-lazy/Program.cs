using System;
using System.Collections;

public class Program
{

    static void Main()
    {
        Console.WriteLine("-------------Running stream pipeline Eagerly ------------------------------");
        IEnumerator names = Queries4.Run().GetEnumerator();
        // foreach(object l in names) Console.WriteLine(l);
        Console.ReadLine();
        names.MoveNext();
        Console.WriteLine("The first Student with D and number greater than 47000 is " + names.Current);

        Console.WriteLine("-------------Running stream pipeline Lazily ------------------------------");
        names = Queries5.Run().GetEnumerator();
        // foreach(object l in names) Console.WriteLine(l);
        Console.ReadLine();
        names.MoveNext();
        Console.WriteLine("The first Student with D and number greater than 47000 is " + names.Current);
    }
}