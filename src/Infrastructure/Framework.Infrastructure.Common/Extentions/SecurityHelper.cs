using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Framework.Infrastructure.Common.Extentions
{
    public static class SecurityHelper
    {
        public static string GetBase64Encode(string text)
        {
            var bytesText = Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(bytesText, 0, bytesText.Length);
        }
        public static string GetBase64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }
        public static string GetHash_SHA256(string input)
        {
            HashAlgorithm hashAlgorithm = new SHA256CryptoServiceProvider();
            byte[] byteValue = Encoding.UTF8.GetBytes(input);
            byte[] byteHash = hashAlgorithm.ComputeHash(byteValue);
            return Convert.ToBase64String(byteHash);
        }
        public static string GetHash_HMAC_SHA512(string key, string message)
        {
            var encoding = new UTF8Encoding();
            var byteKey = encoding.GetBytes(key);
            var byteMessage = encoding.GetBytes(message);
            HashAlgorithm hashAlgorithm = new HMACSHA512(byteKey);
            var byteHash = hashAlgorithm.ComputeHash(byteMessage);
            return BitConverter.ToString(byteHash).Replace("-", "").ToLower();
        }
    }
}
