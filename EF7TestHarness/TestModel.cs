using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTestHarness
{  
    public class TestModel
    {       
        [Key]
        [Required]
        [MaxLength(36)]
        public string RowKey { get; set; }
               
        [MaxLength(200)]
        public string Description { get; set; }    
    }
}
