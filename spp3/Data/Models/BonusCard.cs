using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spp3.Data.Models
{
    public partial class BonusCard
    {
        public static int autoInc = 1;

        public int BcId { get; set; }

        public string number { get; set; }

        public float discount { get; set; }

        public int cuId { get; set; }

        public virtual Customer Customer { get; set; }

        public BonusCard()
        {
            this.number = String.Format("{0:0000000000000000}", autoInc++);
        }

        public BonusCard(float discount)
        {
            this.discount = discount;
        }

        public override string ToString()
        {
            return String.Format("number:{0}", number);
        }
    }
}
