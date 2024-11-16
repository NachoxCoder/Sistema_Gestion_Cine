using System.Security.Cryptography;
using System.Text;

namespace Servicio
{
    public static class Encriptacion
    {
        public static string EncriptarPassword(string rawData)
        {
            byte[] encryted = Encoding.Unicode.GetBytes(rawData);
            string result = Convert.ToBase64String(encryted);
            return result;
        }

        public static string DesencriptarPassword(this string _passwordADesencriptar)
        {
            byte[] decryted = Convert.FromBase64String(_passwordADesencriptar);
            string result = Encoding.Unicode.GetString(decryted);
            return result;
        }
    }
}
