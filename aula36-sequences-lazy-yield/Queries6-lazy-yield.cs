using System;
using System.Collections;
using System.Text;
using System.IO;
using System.Collections.Generic;

class Queries6 {

    static IEnumerable Lines(string path)
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
     
    static IEnumerable Convert(IEnumerable src, FunctionDelegate mapper) {
        foreach(object item in src)
            yield return mapper(item); 
    }

    static IEnumerable Limit(IEnumerable src, int size) {
        foreach(object item in src){
            if(size-- <= 0) yield break;
            yield return item;
        }
    }

    static IEnumerable Filter(IEnumerable src, PredicateDelegate pred) {
        foreach(object item in src)
            if(pred(item))
                yield return item; 
    }    

    static IEnumerable Distinct(IEnumerable src) {
        HashSet<object> set = new HashSet<object>();
        foreach (object item in src)
        {
            if(set.Add(item)) // It is added only if it does not already exist in the set
                yield return item;
        }
    }    
    
    /**
     * Representa o domínio e o cliente App
     */
 
    public static IEnumerable Run()
    {      

        

        IEnumerable names = 
            Limit(
                Distinct(
                    Convert(             // Seq<String>
                        Filter(          // Seq<Student>
                            Filter(      // Seq<Student>
                                Convert( // Seq<Student> 
                                    Lines("isel-AVE-2021.txt"),
                                    Student.Parse),  // Seq<String>
                                std =>
                                {
                                    // Console.WriteLine("Filtering by Number....");
                                    return ((Student)std).Number > 27000;
                                }),
                            std =>
                            {
                                // Console.WriteLine("Filtering by Name .... with D");
                                return ((Student)std).Name.StartsWith("P");
                            }),
                        std =>
                        {
                            // Console.WriteLine("Converting to First Name....");
                            return ((Student)std).Name.Split(" ")[0];
                        })
                    ),
                3); // Select the top 3 elements
        return names;
    }
    static string FirstName(object student) {
        return ((Student) student).Name.Split(" ")[0];
    }
}


