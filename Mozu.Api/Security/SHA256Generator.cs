using System;
using System.Security.Cryptography;
using System.Text;

namespace Mozu.Api.Security
{
    public class SHA256Generator
    {
        public static string GetHash(string secretKey,string date, string body)
        {
            byte[] hashArray;
            using (var encryptor = new SHA256Managed())
            {
                var payloadByteArray = Encoding.UTF8.GetBytes(string.Concat(secretKey,secretKey));
                var payload = string.Concat(Convert.ToBase64String(encryptor.ComputeHash(payloadByteArray)), date, body);
                payloadByteArray = Encoding.UTF8.GetBytes(payload);
                hashArray = encryptor.ComputeHash(payloadByteArray);
            }
            var hash = Convert.ToBase64String(hashArray);
            return hash;
        }
    }
}
