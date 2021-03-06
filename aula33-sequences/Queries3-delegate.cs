using System;
using System.Collections;
using System.Text;
using System.IO;


class App {

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
        IList res = new ArrayList();
        foreach(object item in src)
            // res.Add(mapper.Invoke(item)); 
            res.Add(mapper(item)); 
        return res;
    }
    
    static IEnumerable Filter(IEnumerable src, PredicateDelegate pred) {
        IList res = new ArrayList();
        foreach(object item in src)
            // if(pred.Invoke(item))
            if(pred(item))
                res.Add(item); 
        return res;
    }    
    
    /**
     * Representa o domínio e o cliente App
     */
 
    static void Main()
    {
        IEnumerable names = 
            Convert(             // Seq<String>
                Filter(          // Seq<Student>
                    Filter(      // Seq<Student>
                        Convert( // Seq<Student> 
                            Lines("isel-AVE-2021.txt"),
                            line => Student.Parse((string) line)),  // Seq<String>
                        std => ((Student) std).Number > 47000), 
                    std => ((Student) std).Name.StartsWith("D")),
                std => ((Student) std).Name.Split(" ")[0]);
    
        foreach(object l in names)
            Console.WriteLine(l);
    }
}


