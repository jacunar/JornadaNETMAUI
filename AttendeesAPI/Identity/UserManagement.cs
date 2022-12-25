using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AttendeesAPI.Identity {
    public class UserManagement {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserManagement(UserManager<ApplicationUser> userManager)
            => _userManager = userManager;

        public async Task<(bool created, IEnumerable<string> errors)> CreateUser(NewUserDTO user) {
            ApplicationUser newUser = new() {
                UserName = user.UserName,
                Address = user.Address,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };

            var created = await _userManager.CreateAsync(newUser, user.Password);

            if (created.Succeeded)
                return (true, null!);
            else
                return (false, created.Errors.Select(e => e.Description));
        }

        public async Task<(bool success, ApplicationUser user, string error)> ValidateUserCredentials(LoginCredentialsDTO loginCredentials) {
            var applicationUser = await _userManager.FindByNameAsync(loginCredentials.UserName);

            if(applicationUser is not null) {
                var success = _userManager.PasswordHasher.VerifyHashedPassword(
                    applicationUser, applicationUser.PasswordHash, loginCredentials.Password);

                return success == PasswordVerificationResult.Success ?
                    (true, applicationUser, null!) :
                    (false, null!, "Usuario o contraseña incorrectos");
            } else 
                return (false, null!, "Usuario o contraseña incorrectos");
        }
    }
}