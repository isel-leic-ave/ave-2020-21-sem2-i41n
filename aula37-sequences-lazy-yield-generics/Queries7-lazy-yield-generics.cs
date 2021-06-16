using System;
using System.Collections;
using System.Text;
using System.IO;
using System.Collections.Generic;

class Queries7 {

    static IEnumerable<String> Lines(string path)
    {
        string line;
        using(StreamReader file = new StreamReader(path)) // <=> try-with resources do Java >= 7
        {
            while ((line = file.ReadLine()) != null)
            {
                yield return line;
            }
        }
    }
     
    static IEnumerable<R> Convert<T, R>(IEnumerable<T> src, Func<T, R> mapper) {
        foreach(T item in src)
            yield return mapper(item); 
    }

    static IEnumerable<T> Limit<T>(IEnumerable<T> src, int size) {
        foreach(T item in src){
            if(size-- <= 0) yield break;
            yield return item;
        }
    }

    static IEnumerable<T> Filter<T>(IEnumerable<T> src, Predicate<T> pred) {
        foreach(T item in src)
            if(pred(item))
                yield return item; 
    }    

    static IEnumerable<T> Distinct<T>(IEnumerable<T> src) {
        HashSet<T> set = new HashSet<T>();
        foreach (T item in src)
        {
            if(set.Add(item)) // It is added only if it does not already exist in the set
                yield return item;
        }
    }    
    
    /**
     * Representa o domínio e o cliente App
     */
 
    public static IEnumerable<String> Run()
    {      

        

        IEnumerable<String> names = 
            Limit(
                Distinct(
                    Convert<Student, String>(             // Seq<String>
                        Filter<Student>(          // Seq<Student>
                            Filter<Student>(      // Seq<Student>
                                Convert<String, Student>( // Seq<Student> 
                                    Lines("isel-AVE-2021.txt"),
                                    line => Student.Parse(line)),  // Seq<String>
                                std => std.Number > 27000),
                            std => std.Name.StartsWith("P")),
                        std => std.Name.Split(" ")[0])
                    ),
                3); // Select the top 3 elements
        return names;
    }
    
}


