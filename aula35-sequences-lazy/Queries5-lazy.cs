using System;
using System.Collections;
using System.Text;
using System.IO;
using System.Collections.Generic;

class Queries5 {

    static IEnumerable Lines(string path)
    {
        string line;
        IList res = new ArrayList();
        using(StreamReader file = new StreamReader(path)) // <=> try-with resources do Java >= 7
        {
            while ((line = file.ReadLine()) != null)
            {
                res.Add(line);
            }
        }
        return res;
    }
     
    static IEnumerable Convert(IEnumerable src, FunctionDelegate mapper) {
        return new ConvertEnumerable(src, mapper);
    }
    
    static IEnumerable Filter(IEnumerable src, PredicateDelegate pred) {
        return new FilterEnumerable(src, pred);
    }    

    static IEnumerable Distinct(IEnumerable src) {
        HashSet<object> set = new HashSet<object>();
        foreach (object item in src)
        {
            set.Add(item); // It is added only if it does not already exist in the set
        }
        return set;
    }    
    
    /**
     * Representa o domínio e o cliente App
     */
 
    static void Main()
    {    
        IEnumerable names = 
            Distinct(
                Convert(             // Seq<String>
                    Filter(          // Seq<Student>
                        Filter(      // Seq<Student>
                            Convert( // Seq<Student> 
                                Lines("isel-AVE-2021.txt"),
                                Student.Parse),  // Seq<String>
                            std => ((Student) std).Number > 47000), 
                        std => ((Student) std).Name.StartsWith("D")),
                    std => ((Student) std).Name.Split(" ")[0]));
    
        foreach(object l in names)
            Console.WriteLine(l);
    }
    static string FirstName(object student) {
        return ((Student) student).Name.Split(" ")[0];
    }
}


