using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFrameworkDemoHakan.Models.Entities
{
    public partial class Fruit
    {
        public int Id { get; set; }
        public string FruitType { get; set; }
        public string FruitName { get; set; }
        public decimal? PricePerKg { get; set; }
    }
}
