using System.Net.Mail;

namespace Domain.Helpers;

public static class UtilsHelper
{
    public static bool ValidateEmail(string? email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        try
        {
            var mail = new MailAddress(email);

            return mail.Address == email;
        }
        catch
        {
            return false;
        }
    }
}