using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QR_GEN.src
{
    class OTP
    {

        private static OTP a;

        private OTP(){}

        public bool Verify(string secret)
        {
            Regex r = new Regex("^[A-Z0-9]");
            if(r.IsMatch(secret))
            {
                return true;
            }
            return false;
        }

        public static OTP GetOTP()
        {
            if(a == null)
            {
                a = new OTP();
            }
            return a;
        }
    }
}
