using System.Security.Cryptography;
using System.Text;

namespace Project_02.Application.Security
{
    public class HashPassword
    {
        public static string EncodePasswordMd5(string pass)   
        {
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(pass);
            encodedBytes = md5.ComputeHash(originalBytes);
            return BitConverter.ToString(encodedBytes);
        }
    }
}
