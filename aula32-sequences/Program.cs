using System;
using System.Collections;
using System.Text;
using System.IO;


class App {

    Student student;

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
     
    static IEnumerable ConvertToStudents(IEnumerable lines) {
        IList res = new ArrayList();
        foreach(object line in lines)
            res.Add(Student.Parse((string) line)); 
        return res;
    }
    
    static IEnumerable ConvertToFirstName(IEnumerable stds) {
        IList res = new ArrayList();
        foreach(object std in stds)
            res.Add(((Student) std).Name.Split(" ")[0]); 
        return res;
    }
    
    static IEnumerable FilterWithNumberGreaterThan(IEnumerable stds, int nr) {
        IList res = new ArrayList();
        foreach(object std in stds)
            if(((Student) std).Number > nr)
                res.Add(std); 
        return res;
    }
    
    static IEnumerable FilterNameStartsWith(IEnumerable stds, String prefix) {
        IList res = new ArrayList();
        foreach(object std in stds)
            if(((Student) std).Name.StartsWith(prefix))
                res.Add(std); 
        return res;
    }
    
    /**
     * Representa o domínio e o cliente App
     */
 
    static void Main()
    {
        IEnumerable names = 
            ConvertToFirstName(                  // Seq<String>
                FilterNameStartsWith(            // Seq<Student>
                    FilterWithNumberGreaterThan( // Seq<Student>
                        ConvertToStudents(       // Seq<Student> 
                            Lines("isel-AVE-2021.txt")),  // Seq<String>
                        47000), 
                    "D")
                );
    
        foreach(object l in names)
            Console.WriteLine(l);
    }
}
