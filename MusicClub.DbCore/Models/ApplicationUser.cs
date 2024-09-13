using Microsoft.AspNetCore.Identity;

namespace MusicClub.DbCore.Models
{
    public class ApplicationUser : IdentityUser
    {
        public required int PersonId { get; set; }
        public Person? Person { get; set; }
    }
}
