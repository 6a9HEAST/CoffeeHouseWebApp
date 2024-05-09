using Microsoft.AspNetCore.Identity;
namespace WebLab2.Models
{
    public class User:IdentityUser<int>
    {
        public virtual ICollection<Order> Orders{ get; set; }
    }
}
