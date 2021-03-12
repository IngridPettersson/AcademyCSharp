using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFrameworkDemoHakan.Models.Entities
{
    public partial class Person
    {
        public Person()
        {
            ContactDetails = new HashSet<ContactDetail>();
            P2as = new HashSet<P2a>();
        }

        public int Id { get; set; }
        public string Personnr { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? YearOfBirth { get; set; }

        public virtual ICollection<ContactDetail> ContactDetails { get; set; }
        public virtual ICollection<P2a> P2as { get; set; }
    }
}
