using System;
using System.Collections;
using System.Text;
using System.IO;


class App2 {

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
     
    static IEnumerable Convert(IEnumerable src, Function mapper) {
        IList res = new ArrayList();
        foreach(object item in src)
            res.Add(mapper.Invoke(item)); 
        return res;
    }
    
    static IEnumerable Filter(IEnumerable src, Predicate pred) {
        IList res = new ArrayList();
        foreach(object item in src)
            if(pred.Invoke(item))
                res.Add(item); 
        return res;
    }    
    
    /**
     * Representa o domínio e o cliente App
     */
 
    static void Test()
    {
        IEnumerable names = 
            Convert(             // Seq<String>
                Filter(          // Seq<Student>
                    Filter(      // Seq<Student>
                        Convert( // Seq<Student> 
                            Lines("isel-AVE-2021.txt"),
                            new ToStudent()),  // Seq<String>
                        new FilterStudentNumberGreaterThan(47000)), 
                    new FilterStudentNameStartsWith("D")),
                new ToFirstName());
    
        foreach(object l in names)
            Console.WriteLine(l);
    }
}

internal class FilterStudentNameStartsWith : Predicate
{
    private string prefix;

    public FilterStudentNameStartsWith(string v)
    {
        this.prefix = v;
    }

    public bool Invoke(object item)
    {
        return ((Student) item).Name.StartsWith(prefix);
    }
}

internal class FilterStudentNumberGreaterThan : Predicate
{
    private int nr;

    public FilterStudentNumberGreaterThan(int v)
    {
        this.nr = v;
    }

    public bool Invoke(object item)
    {
        return ((Student) item).Number > nr;
    }
}

internal class ToStudent : Function
{
    public object Invoke(object item)
    {
        return Student.Parse((string) item);
    }
}

internal class ToFirstName : Function
{
    public object Invoke(object item)
    {
        return ((Student) item).Name.Split(" ")[0];
    }
}
