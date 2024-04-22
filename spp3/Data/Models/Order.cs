using spp3.Data.Models;

namespace API.Data.Models
{
    public partial class Order
    {
        public int orId { get; set; }
        public string orderStatus { get; set; }
        public int quantity { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Supplier>? Suppliers { get; set; }
    }
}
