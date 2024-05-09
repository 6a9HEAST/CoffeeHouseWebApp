using Microsoft.AspNetCore.Identity;
namespace WebLab2.Models
{
    public class Role:IdentityRole<int>
    {

        public Role(string name)
        {
            this.Name = name;
        }
    }
}
