using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTestHarness
{

   
    public static class DbContextExtensions
    {
        public static void LogToConsole(this DbContext context)
        {
            var contextServices = ((IInfrastructure<IServiceProvider>)context).Instance;
            var loggerFactory = contextServices.GetRequiredService<ILoggerFactory>();
            loggerFactory.AddConsole(LogLevel.Trace);
        }

        public static DbContextOptions<TestDbContext> GetDbContextOptions()
        {
            var optionsBuilder = new DbContextOptionsBuilder<TestDbContext>();           
                optionsBuilder.UseSqlServer($"Server=(localdb)\\mssqllocaldb;Database=TestDBContext;Trusted_Connection=True;Connection Timeout=5");          
            return optionsBuilder.Options;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("This test was run with SQL 2016 localDB.  Make sure you have it installed.  Alternatively, you could change the connection string in the code to point to a SQL database");
            Console.WriteLine("Press <Enter> to run test");
            Console.ReadLine();
            var context = new TestDbContext(DbContextExtensions.GetDbContextOptions());
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
       //     context.LogToConsole();   uncomment this line if you want to see EF logging in console       
            context.TestModels.Add(new TestModel { RowKey = "1", Description = "TEST" });
            context.SaveChanges();
            var sw = new Stopwatch();
            for (var counter = 1; counter<=26; counter++)
            {
                sw.Start();
                var descriptionString = Enumerable.Range(1, counter).Select(x=>$"T{x.ToString()}|").Aggregate((x, y) =>x+y); //Creates search terms like T1|T2|T3|....Tcounter                        
                var recs = context.TestModels.Where(ClassifyFunctions.ContainsDescription(descriptionString.Split('|'))).ToList();
                sw.Stop();
                Console.WriteLine($"TermCount {counter} in {sw.ElapsedMilliseconds} ms");
            }
            Console.ReadLine();
        }
    }
}
