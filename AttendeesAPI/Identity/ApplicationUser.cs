using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AttendeesAPI.Identity {
    public class ApplicationUser : IdentityUser {
        public ApplicationUser() {

        }

        [MaxLength(100)]
        public string Address { get; set; } = null!;
    }
}