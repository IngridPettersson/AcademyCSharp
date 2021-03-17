using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstHakan.Models
{
    class CustomerAddress
    {
        public int Id { get; set; }
        public string StreetCityZip { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
