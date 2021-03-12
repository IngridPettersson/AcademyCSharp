using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFrameworkDemoHakan.Models.Entities
{
    public partial class AddressBook
    {
        public string Personnummer { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public string Gata { get; set; }
        public string Stad { get; set; }
        public string Postnummer { get; set; }
        public string Kontakttyp { get; set; }
        public string Kontaktinfo { get; set; }
    }
}
