using HClHackactnWithAngular.Server.Model;

namespace HClHackactnWithAngular.Server.Validation;

public interface IAuthValidation
{
    (bool IsValid, string ErrorMessage) ValidateLoginRequest(LoginRequest request);
}