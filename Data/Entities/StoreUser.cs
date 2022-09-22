using Microsoft.AspNetCore.Identity;

namespace DungeonForceWoW.Data.Entities
{
    public class StoreUser : IdentityUser
    {
        public string Username { get; set; }
        public string Email { get; set; }           
    }
}
