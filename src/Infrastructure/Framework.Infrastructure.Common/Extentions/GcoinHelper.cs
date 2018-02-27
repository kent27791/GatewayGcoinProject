using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Web;

namespace Framework.Infrastructure.Common.Extentions
{
    public static class GcoinHelper
    {
        public static string GetAuth(string noPhone, string noApi)
        {
            return SecurityHelper.GetBase64Encode($"{noPhone}:{noApi}");
        }

        public static string GetNonce()
        {
            return ((int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds).ToString();
        }

        public static string GetSignature<T>(T obj, string path, string secretKey)
        {
            return SecurityHelper.GetHash_HMAC_SHA512(secretKey, $"{path}{GetQueryString<T>(obj)}{SecurityHelper.GetHash_SHA256(GetNonce())}");
        }

        public static string GetUri<T>(T obj, string domain, string path)
        {
            return $"{domain}{path}{GetQueryString<T>(obj)}";
        }

        public static HttpResponseMessage SendGcoin()
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.Method = HttpMethod.Get;
            request.RequestUri = new Uri("");
            //request.Headers.TryAddWithoutValidation("Authorization", GetAuth()); //ABTPay use no scheme. it's not true for technology.
            request.Headers.Add("X-Nonce", GetNonce());
            //request.Headers.Add("X-Signature", GetSignature());
            HttpClient client = new HttpClient();
            return client.SendAsync(request).Result;
        }

        public static string GetQueryString<T>(T obj)
        {
            StringBuilder data = new StringBuilder();
            Type type = obj.GetType();
            var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.IsDefined(typeof(JsonPropertyAttribute)))
                .OrderBy(p => p.GetCustomAttribute<JsonPropertyAttribute>().Order);
            //var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance).OrderBy(p => p.GetCustomAttribute<JsonPropertyAttribute>().Order);
            foreach (PropertyInfo prop in props)
            {
                var jsonAttr = prop.GetCustomAttribute<JsonPropertyAttribute>();
                var key = jsonAttr.PropertyName;
                var value = prop.GetValue(obj);
                if (value != null)
                {
                    data.Append(key + "=" + HttpUtility.UrlEncode(Convert.ToString(value)) + "&");
                }
            }
            //remove trailing & from string
            if (data.Length > 0)
                data.Remove(data.Length - 1, 1);

            return data.ToString();
        }
    }
}
