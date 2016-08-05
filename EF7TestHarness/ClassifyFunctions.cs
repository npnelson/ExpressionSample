using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CoreTestHarness
{
    public static class ClassifyFunctions
    {      
        public static Expression<Func<TestModel, bool>> ContainsDescription(params string[] keywords)
        {
            var predicate = PredicateBuilder.False<TestModel>();
            foreach (var itm in keywords)
            {            
                predicate = predicate.Or(x => x.Description.ToUpper().Contains(itm));
            }
            return predicate;
        }
    }
}
