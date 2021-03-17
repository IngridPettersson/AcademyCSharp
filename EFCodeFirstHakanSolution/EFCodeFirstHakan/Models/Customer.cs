using System.Collections;
using System.Collections.Generic;

namespace EFCodeFirstHakan.Models
{
    class Customer
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<CustomerAddress> CustomerAddresses { get; set; }
    }
}