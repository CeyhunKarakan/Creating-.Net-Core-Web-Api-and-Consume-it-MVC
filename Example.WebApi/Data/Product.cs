using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.WebApi.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public DateTime createdDate { get; set; }
        public string ImagePath { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }  

    }
}
