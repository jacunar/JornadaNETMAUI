using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AttendeesAPI.Identity {
    public class IdentityContext : IdentityDbContext<ApplicationUser> {
        public IdentityContext(DbContextOptions options) : base(options) {

        }
    }
}