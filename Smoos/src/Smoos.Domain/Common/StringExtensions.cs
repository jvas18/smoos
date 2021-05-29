using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Domain.Common
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;


    namespace Smoos.CrossCutting.Extensions
    {
        public static class StringExtensions
        {
            public static string FormatPhone(this string value)
            {
                if (string.IsNullOrEmpty(value)) return value;

                var number = Regex.Replace(value, @"[^0-9]", "");

                value = number.Length == 10
                    ? Convert.ToUInt64(number).ToString(@"00\-00000000")
                    : number.Length == 11
                        ? Convert.ToUInt64(number).ToString(@"00\-000000000")
                        : value;

                return value;
            }

            public static string ToNumber(this string value) =>
                string.IsNullOrWhiteSpace(value?.Trim())
                    ? ""
                    : Regex.Replace(value, @"[^0-9]", "");


            public static string ToBase64Hash(this string value)
            {
                using (var hashData = SHA256.Create())
                {
                    var data = hashData.ComputeHash(Encoding.ASCII.GetBytes(value));
                    return Convert.ToBase64String(data);
                }
            }

            public static string ToSha256(this string value)
            {
                using (var hashData = SHA256.Create())
                {
                    var hash = new StringBuilder();

                    foreach (var theByte in hashData.ComputeHash(Encoding.ASCII.GetBytes(value)))
                    {
                        hash.Append(theByte.ToString("x2"));
                    }

                    return hash.ToString();
                }
            }

            public static string FormatCpfCnpj(this string value)
            {
                var result = "";

                if (string.IsNullOrWhiteSpace(value)) return result;

                var number = value.ToNumber();

                result = number.Length == 11
                    ? Convert.ToUInt64(number).ToString(@"000\.000\.000\-00")
                    : number.Length == 14
                        ? Convert.ToUInt64(number).ToString(@"00\.000\.000\/0000\-00")
                        : result;

                return result;
            }

            public static string FromBase64(this string value) => Encoding.UTF8.GetString(Convert.FromBase64String(value));
            public static string ToBase64(this string value) => Convert.ToBase64String(Encoding.UTF8.GetBytes(value));
            public static string ReplaceSpecial(this string value) => Regex.Replace(value, @"[\\/]", "_");

            public static string ToBase64Key(this string value) => value.ToBase64().ReplaceSpecial();

            public static string RemoveSpaces(this string value)
            {
                value = value.Replace(" ", "").Trim();
                return value;
            }

            public static T ToEnum<T>(this string value)
            {
                return (T)Enum.Parse(typeof(T), value, true);
            }

            public static bool IsNull(this string value)
            {
                return string.IsNullOrWhiteSpace(value?.Trim());
            }

            public static string GenerateCode(this string value, int length)
            {
                var random = new Random();
                var characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                var result = new StringBuilder(length);
                for (int i = 0; i < length; i++)
                {
                    result.Append(characters[random.Next(characters.Length)]);
                }

                return result.ToString();
            }

            public static string OrderByPgsql(this string value,
                string sortField,
                string sortDir = "asc",
                string alias = null)
            {
                var fields = alias.IsNull()
                    ? string.Join(",", sortField.Split(",").Select(x => $@"""{x.Trim()}"" {sortDir}"))
                    : string.Join(",", sortField.Split(",").Select(x => $@"""{alias}"".""{x.Trim()}"" {sortDir}"));

                return $"order by {fields}";
            }

            public static string LimitRowsPgsql(this string value, int pageIndex, int pageSize) =>
                $"LIMIT {pageSize} OFFSET {(pageIndex - 1) * pageSize}";

            public static bool IsUrl(this string value)
            {
                const string pattern = @"^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$";
                if (value.Contains("http://localhost") || value.Contains("https://localhost")) return true;
                return Regex.IsMatch(value, pattern);
            }

            public static bool IsEmail(this string email) =>
                Regex.IsMatch(
                    email ?? "",
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase);


            public static string RemoveAccents(this string value)
            {
                Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                return Encoding.ASCII.GetString(Encoding.GetEncoding("Cyrillic").GetBytes(value));
            }

            public static string AddPath(this string url, string path) =>
                string.IsNullOrWhiteSpace(url) ? string.Empty : url.EndsWith("/") ? $"{url}{path}" : $"{url}/{path}";

            public static string AddPath(this string url, object path) => url.AddPath(path.ToString());

            public static string AddQueryStringParameter(this string url, string parameter, string value)
            {
                if (string.IsNullOrWhiteSpace(url)) return string.Empty;

                var builder = new UriBuilder(url);

                if (builder.Query.Length > 1)
                {
                    builder.Query = $"{builder.Query.Substring(1)}&{parameter}={value}";
                    return builder.Uri.ToString();
                }

                builder.Query = $"{parameter}={value}";

                return builder.Uri.ToString();
            }

            public static string AddQueryStringParameter(this string url, string parameter, object value) => url.AddQueryStringParameter(parameter, value.ToString());

            public static string UrlEncode(this string value) =>
                string.IsNullOrWhiteSpace(value)
                    ? string.Empty
                    : System.Net.WebUtility.UrlEncode(value);

            public static string UrlDecode(this string value) =>
                string.IsNullOrWhiteSpace(value)
                    ? string.Empty
                    : System.Net.WebUtility.UrlDecode(value);

            public static string FormattedElapsed(this TimeSpan timeSpan) => timeSpan.ToString("hh':'mm':'ss'.'fff");

            public static string GetExtension(this string fileName) => Path.GetExtension(fileName);

           
            public static string HandleContentType(this string fileName)
            {
                var extension = Path.GetExtension(fileName);

                if (extension.Equals(".js", StringComparison.OrdinalIgnoreCase))
                {
                    return "application/javascript";
                }

                if (extension.Equals(".png", StringComparison.OrdinalIgnoreCase))
                {
                    return "image/png";
                }

                if (extension.Equals(".svg", StringComparison.OrdinalIgnoreCase))
                {
                    return "image/svg+xml";
                }

                if (extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) ||
                    extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase))
                {
                    return "image/jpeg";
                }

                if (extension.Equals(".gif", StringComparison.OrdinalIgnoreCase))
                {
                    return "image/gif";
                }

                if (extension.Equals(".ico", StringComparison.OrdinalIgnoreCase))
                {
                    return "image/x-icon";
                }

                if (extension.Equals(".pdf", StringComparison.OrdinalIgnoreCase))
                {
                    return "application/pdf";
                }

                if (extension.Equals(".doc", StringComparison.OrdinalIgnoreCase))
                {
                    return "application/msword";
                }

                if (extension.Equals(".docx", StringComparison.OrdinalIgnoreCase))
                {
                    return "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                }

                return "application/octet-stream";
            }
        }
    }

}
