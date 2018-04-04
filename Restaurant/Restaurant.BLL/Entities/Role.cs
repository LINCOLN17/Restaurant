using Microsoft.AspNetCore.Identity;

namespace Restaurant.BLL.Entities
{
    public class Role : IdentityRole<int>
    {
        public Role()
        { }
        public Role(string name) : base(name) { }
    }
}
