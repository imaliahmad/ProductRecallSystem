using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace BOL
{
    [Table("Products")]
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }


      

        [ForeignKey("Manufactureres")]
        public int ManufacturerId { get; set; }
        public virtual Manufactureres Manufactureres { get; set; }

        public virtual IEnumerable<Recalls> Recalls { get; set; }

    }
}
