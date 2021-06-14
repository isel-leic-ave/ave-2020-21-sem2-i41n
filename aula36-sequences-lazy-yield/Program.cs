using System;
using System.Collections;

public class Program
{

    static IEnumerable Numbers() {

        Console.WriteLine("Iteration started...");

        yield return 11;

        yield return 17;

        yield return 23;
    }


    static void Main()
    {
        /*
        Console.WriteLine("-------------Running stream pipeline Eagerly ------------------------------");
        IEnumerator names = Queries4.Run().GetEnumerator();
        // foreach(object l in names) Console.WriteLine(l);
        Console.ReadLine();
        names.MoveNext();
        Console.WriteLine("The first Student with D and number greater than 47000 is " + names.Current);
        */

        Console.WriteLine("-------------Running stream pipeline Lazily ------------------------------");
        IEnumerable names = Queries6.Run();
        foreach(object l in names) Console.WriteLine(l);
        
        // Console.ReadLine();
        // names.MoveNext();
        // Console.WriteLine("The first Student with D and number greater than 47000 is " + names.Current);
        

        // IEnumerator nrs  = Numbers().GetEnumerator();
        // Console.WriteLine(nrs.MoveNext());
        // Console.WriteLine(nrs.Current);
        // Console.WriteLine(nrs.MoveNext());
        // Console.WriteLine(nrs.Current);
        // Console.WriteLine(nrs.Current);
        // Console.WriteLine(nrs.MoveNext());
        // Console.WriteLine(nrs.Current);
        // Console.WriteLine(nrs.MoveNext());
    }
}