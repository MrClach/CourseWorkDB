using API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spp3.Data.Models
{
    public partial class Customer
    {
        public int CuId { get; set; }

        public string firstName {  get; set; }

        public string secondName { get; set; }

        public string? patrynomic { get; set; } = null;

        public string? gender { get; set; } = null!;

        public int? age { get; set; } = null;

        public string? adress { get; set; } = null;

        public string phoneNumber { get; set; }

        public virtual BonusCard? BonusCard { get; set; }

        public virtual ICollection<Deal>? Deals { get; set; }

        public override string ToString()
        {
            return string.Format("Phone:{0}", phoneNumber);
        }
    }
}
