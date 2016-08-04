using CoreTestHarness;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6TestHarness
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(string connectionString):base(connectionString)
        {

        }
        public DbSet<TestModel> TestModels { get; set; }
    }
}
