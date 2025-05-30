using System.Text.RegularExpressions;
using HClHackactnWithAngular.Server.Model;

namespace HClHackactnWithAngular.Server.Validation
{
    public class AuthValidation
    {
        public (bool IsValid, string ErrorMessage) ValidateLoginRequest(LoginRequest request)
        {
            // Check for null or empty values
            if (string.IsNullOrWhiteSpace(request.Username))
                return (false, "Username is required");

            if (string.IsNullOrWhiteSpace(request.Password))
                return (false, "Password is required");

            // Username validation: alphanumeric with allowed special characters, 3-50 chars
            if (!Regex.IsMatch(request.Username, @"^[a-zA-Z0-9._@-]{3,50}$"))
                return (false, "Username must be between 3-50 characters and contain only letters, numbers, and ._@-");

            // Password validation: at least 8 characters, with at least one uppercase, one lowercase, one number, and one special character
            if (request.Password.Length < 8)
                return (false, "Password must be at least 8 characters long");

            if (!Regex.IsMatch(request.Password, @"[A-Z]"))
                return (false, "Password must contain at least one uppercase letter");

            if (!Regex.IsMatch(request.Password, @"[a-z]"))
                return (false, "Password must contain at least one lowercase letter");

            if (!Regex.IsMatch(request.Password, @"[0-9]"))
                return (false, "Password must contain at least one number");

            if (!Regex.IsMatch(request.Password, @"[^a-zA-Z0-9]"))
                return (false, "Password must contain at least one special character");

            return (true, string.Empty);
        }
    }
}
