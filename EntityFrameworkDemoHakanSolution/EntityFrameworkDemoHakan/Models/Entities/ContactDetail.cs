using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFrameworkDemoHakan.Models.Entities
{
    public partial class ContactDetail
    {
        public int Id { get; set; }
        public string ContactType { get; set; }
        public string ContactInfo { get; set; }
        public int? PersonsId { get; set; }

        public virtual Person Persons { get; set; }
    }
}
