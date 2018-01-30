using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FacebookAutomationTest
{
    /// <summary>
    /// Helper class to generate emails
    /// </summary>
    public static class EmailGenerator
    {
        /// <summary>
        /// Generates an email in acceptable format
        /// </summary>
        /// <returns>email as string</returns>
        public static string GenerateRandomEmail()
        {
            string guid = Guid.NewGuid().ToString();
            string emailTemplate = guid.Substring(0, 8) + guid.Substring(guid.Length - 12, 12) + guid.Substring(10, 4) + guid.Substring(16, 4) + "@email.com";
            return Regex.Replace(emailTemplate, @"[\d-]", string.Empty); 
        }
    }
}
