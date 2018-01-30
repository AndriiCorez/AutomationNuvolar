using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UILayerFramework.Pages.LoginSignupPage;

namespace FacebookAutomationTest
{
    /// <summary>
    /// Helper class to work with Gender enumerator
    /// </summary>
    public static class GenderHelper
    {
        /// <summary>
        /// Selects Gender enumerator value in accordance to input parameter
        /// </summary>
        /// <param name="genderValue"></param>
        /// <returns>Returns Gender enumerator</returns>
        public static Gender GetGender(string genderValue)
        {
            if (genderValue.ToUpper().Equals("F"))
                return Gender.Female;
            else if (genderValue.ToUpper().Equals("M"))
                return Gender.Male;
            else if (genderValue.Equals(string.Empty))
                return Gender.None;

            throw new Exception("Unknown gender value specified, should be M or F, but was:" + genderValue);
        }
    }
}
