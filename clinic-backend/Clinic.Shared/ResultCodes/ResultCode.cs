using System.ComponentModel;

namespace Clinic.Shared.ResultCodes;

public enum ResultCode
{
    [Description("User not found.")]
    USER_NOT_FOUND = 001,
    [Description("Identity server error.")]
    IDENTITY_SERVER_ERROR = 002,
    [Description("Email or password is incorrect.")]
    EMAIL_OR_PASSWORD_IS_INCORRECT = 003
}