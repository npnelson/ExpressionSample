using CoreTestHarness;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This test was run with SQL 2016 localDB.  Make sure you have it installed.  Alternatively, you could change the connection string in the code to point to a SQL database");
            Console.WriteLine("Press <Enter> to run test");
            Console.ReadLine();
            var context = new TestDbContext("Server=(localdb)\\mssqllocaldb;Database=TestDBContext;Trusted_Connection=True;Connection Timeout=5");
            context.Database.Delete();
            context.Database.CreateIfNotExists();           
            context.TestModels.Add(new TestModel { RowKey = "1", Description = "TEST" });
            context.SaveChanges();          
            for (var counter = 1; counter <= 26; counter++)
            {
                var sw = new Stopwatch();
                sw.Start();
                var descriptionString = Enumerable.Range(1, counter).Select(x => $"T{x.ToString()}|").Aggregate((x, y) => x + y); //Creates search terms like T1|T2|T3|....Tcounter                        
                var recs = context.TestModels.Where(ClassifyFunctions.ContainsDescription(descriptionString.Split('|'))).ToList();
                sw.Stop();
                Console.WriteLine($"TermCount {counter} in {sw.ElapsedMilliseconds} ms");
            }
            Console.ReadLine();
        }
    }
}
