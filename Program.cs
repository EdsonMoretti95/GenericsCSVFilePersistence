using System;
using System.Text;


namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("** Creating Person List **");
            FilePersistence<Person> listPerson = new FilePersistence<Person>();

            Console.WriteLine("** Adding values to Person List **");
            listPerson.Values.Add(new Person { Name = "Edson", BirthDate = DateTime.Parse("31/12/1995"), HeightCM = 198, WeightKg = 82.5 });
            listPerson.Values.Add(new Person { Name = "Debora", BirthDate = DateTime.Parse("23/03/1994"), HeightCM = 170, WeightKg = 62.8 });

            Console.WriteLine("** Printing Person List **");
            listPerson.PrintValues();

            Console.WriteLine("** Saving Person List to File **");
            listPerson.SaveToFile(@"C:\Users\edson\source\Person.csv");

            Console.WriteLine("** Creating new Person List from File **");
            FilePersistence<Person> listPerson2 = new FilePersistence<Person>(@"C:\Users\edson\source\Person.csv");

            Console.WriteLine("** Printing new Person List from File **");
            listPerson2.PrintValues();
        }
    }
}
