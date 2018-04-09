//-----------------------------------------------------------------------------
//   Copyright @2013 Rockwell Automation, Inc. All Rights Reserved.
//   This program is the proprietary property of Rockwell Automation Inc.
//   and it shall not be reproduced, distributed or used in any way without the 
//   approval of an authorized company official.  This program is an unpublished
//   work subject to Trade Secret and Copyright protection.  All rights to this
//   program are reserved to Rockwell Automation Inc
// <Revision History>
// 12-Aug-2013      Paddy Lu        Added for generating the module token
// </Revision History>
//-----------------------------------------------------------------------
using System.Security.Cryptography;
using System.Text;

namespace RA.CCW.TokenGenerator
{
    public static class TokenGenerator
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
