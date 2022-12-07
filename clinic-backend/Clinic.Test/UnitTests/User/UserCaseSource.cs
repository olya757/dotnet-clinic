namespace Clinic.Test;

public static class UserCaseSource
{
    public static string[] InvalidPasswords =
        {
            String.Empty,
            " ",
            new string(' ',10)
        };
}