using System.ComponentModel.DataAnnotations;

namespace WebLab2.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderLines = new HashSet<OrderLine>();

        }
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }
        public virtual User? User {get ; set; }
        public virtual ICollection<OrderLine>? OrderLines { get; set; }
    }
}
