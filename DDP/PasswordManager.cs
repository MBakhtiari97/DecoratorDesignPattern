using System.Security.Cryptography;
using System.Text;
namespace DecoratorDesignPattern.DDP;
public static class PasswordManager
{
    public static string HashUserPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < bytes.Length / 4; i++)
                builder.Append(bytes[i].ToString("x4"));
            return builder.ToString();
        }
    }
}
