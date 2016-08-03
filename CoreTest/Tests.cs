using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using ExpressionTest;
using Microsoft.EntityFrameworkCore;

namespace CoreTest
{
    public class Tests
    {
        [Fact]
        public async Task Test()
        {
            var mappingList = new List<ModelTypeMapping>();
            mappingList.Add(new ModelTypeMapping { ModelType = "A", ModelSynonym = "MR" });
            mappingList.Add(new ModelTypeMapping { ModelType = "B", ModelSynonym = "CT" });
            var modelType = new TestModel { ModelType = "MR", ModelDescription = "DescriptionA" };

            var context = new TestDbContext();
            context.TestModels.Add(modelType);
           await context.SaveChangesAsync();
            var result = await context.TestModels.Where(TestClass.IsBodyStudy(mappingList)).ToListAsync();

        }
    }
}
