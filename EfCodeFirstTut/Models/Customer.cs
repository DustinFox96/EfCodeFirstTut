using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EfCodeFirstTut.Models {
    public class Customer {
        public int Id { get; set; } // Primary key
        [StringLength(10), Required] // this is put here to help C# to talk to SQL // and the Required means it can't be null.
        public string Code { get; set; } // Must be unique value
        [StringLength(50), Required]
        public String Name { get; set; }
        public bool IsNational { get; set; } // is our customer out of country? default is no
        [Column(TypeName = "decimal(9,2)")]
        public decimal Sales { get; set; }
        public DateTime Created { get; set; } // datetime our customer was created

        public Customer() { }


    }
}
