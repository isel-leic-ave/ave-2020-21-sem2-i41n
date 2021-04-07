using System;
using Logger;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p = new Point(7, 9);
            Student s1 = new Student(154134, "Ze Manel", 5243, "ze");
            Student s2 = new Student(235474, "Maria Joana", 2356, "maria");
            Student s3 = new Student(761354, "Jaquina Ambrosia", 9872, "joaquina");
            Account a = new Account(1300);
            Student [] arr = {s1, s2, s3};
            Log log = new Log();
            log.Info(p);
            log.Info(arr);
            log.Info(a);
        }
    }
}
