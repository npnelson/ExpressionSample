using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTestHarness
{
    public class TestDbContext : DbContext
    {

        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
        {
     
        }
        public DbSet<TestModel> TestModels { get; set; }
       
   
    }
}
