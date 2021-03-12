﻿using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFrameworkDemoHakan.Models.Entities
{
    public partial class P2a
    {
        public int Id { get; set; }
        public int PersonsId { get; set; }
        public int AddressesId { get; set; }

        public virtual Address Addresses { get; set; }
        public virtual Person Persons { get; set; }
    }
}
