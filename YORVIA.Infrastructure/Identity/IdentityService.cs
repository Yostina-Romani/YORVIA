using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
using YORVIA.Application.Abstractions.Authentication;
using YORVIA.Application.Features.Authentication.DTOs;

namespace YORVIA.Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {

        private readonly UserManager<ApplicationUser> _usermanager;
        public IdentityService(UserManager<ApplicationUser> userManager)
        {
            _usermanager = userManager;
        }
        public async Task<IdentityRegistrationResult> RegisterUserAsync(string username, string password, string email)
        {
            var user = new ApplicationUser
            {
                name = username,
                Email = email,
                UserName = email
            };

            var CreateResult = await _usermanager.CreateAsync(user, password);


            if (!CreateResult.Succeeded)
            {
                return new IdentityRegistrationResult
                {
                    succeeded = false,
                    Errors = MapIdentityErrors(CreateResult.Errors)
                };
            }

            var roleResult = await _usermanager.AddToRoleAsync(user, "User");
            if (!roleResult.Succeeded)
            {
                var deleteResult = await _usermanager.DeleteAsync(user);
                if (!deleteResult.Succeeded)
                {
                    throw new InvalidOperationException(
               "Role assignment failed, and user cleanup failed.");
                }

                return new IdentityRegistrationResult
                {
                    succeeded = false,
                    Errors = new Dictionary<string, string[]>
                    {
                        ["general"] = new[]
                        {
                            "We couldn't complete registration. Please try again."
                        }
                    }
                };

            }

            return new IdentityRegistrationResult
            {
                succeeded = true
            };


        }



        private static Dictionary<string, string[]> MapIdentityErrors(IEnumerable<IdentityError> identityErrors)
        {
            var errors = new Dictionary<string, List<string>>();
            foreach (var error in identityErrors)
            {
                string field;
                string message;

                switch (error.Code)
                {
                    case "DuplicateEmail":
                        field = "email";
                        message = "This email is already registered.";
                        break;
                    case "DuplicateUserName":
                        field = "username";
                        message = "This username is already taken.";
                        break;
                    case "InvalidEmail":
                        field = "email";
                        message = "please enter a valid email address";
                        break;

                    case "PasswordTooShort":
                    case "PasswordRequiresDigit":
                    case "PasswordRequiresLower":
                    case "PasswordRequiresUpper":
                    case "PasswordRequiresNonAlphanumeric":
                    case "PasswordRequiresUniqueChars":
                        field = "password";
                        message =
                            "Password does not meet the required security rules.";
                        break;

                    default:
                        field = "general";
                        message = "Some registration information is invalid.";
                        break;

                }
                if (!errors.ContainsKey(field))
                {
                    errors[field] = new List<string>();

                }
                if (!errors[field].Contains(message))
                {
                    errors[field].Add(message);
                }

            }

            return errors.ToDictionary(item => item.Key,
                item => item.Value.ToArray());
        }

    


        public async Task<IdentityLoginResult?> LoginUserAsync(string password, string email)
        {
            var user = await _usermanager.FindByEmailAsync(email);
            if (user == null)
            {
                return null;
                
            }
            var result = await _usermanager.CheckPasswordAsync(user, password);

            if (!result)
            {
                return null;

            }
            var roles = await _usermanager.GetRolesAsync(user);
            return new IdentityLoginResult
            {
                Email = user.Email!,
                UserId = user!.Id,
                Roles=roles
            };
        }

   
    }
}
