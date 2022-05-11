using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class CoupenCode
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public decimal Amount { get; set; }
    }
}
