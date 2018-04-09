using System.Security.Cryptography;
using System.Text;

namespace TokenGenerator
{
    public static class TokenValueGenerator
    {
        /// <summary>
        /// Generate the md5 hash code for the input string
        /// </summary>
        /// <param name="inputStr"></param>
        /// <returns></returns>
        public static string GenerateToken(string inputStr)
        {
            if (string.IsNullOrWhiteSpace(inputStr))
                return string.Empty;

            return GetMd5Hash(inputStr);
        }

        /// <summary>
        /// Get the md5 hash code for the input string
        /// </summary>
        /// <param name="inputStr"></param>
        /// <returns></returns>
        private static string GetMd5Hash(string inputStr)
        {
            using (MD5 md5 = new MD5CryptoServiceProvider())
            {
                var md5Value = md5.ComputeHash(Encoding.UTF8.GetBytes(inputStr));

                var sBuilder = new StringBuilder();

                foreach (var value in md5Value)
                {
                    sBuilder.Append(value.ToString("x2"));
                }

                return sBuilder.ToString();
            }
        }
    }
}
