using System.ComponentModel.DataAnnotations;

namespace WebLab2.Models
{
    public partial class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string? ImageAdress { get; set; }
        public string Type { get; set; }
        public virtual ICollection<OrderLine>? OrderLines { get; set; }

    }
}
