using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mail.Application.Helper
{
    public static class Constants
    {
        public const string BASE_URL = "https://localhost:7164/api/";
        public const string MESSAGE_URL = BASE_URL+ "Message";
        public const string USER_URL = BASE_URL + "User";
        public const string ACCOUNT_URL = BASE_URL + "Account";
        public const string ACCOUNT_REGISTRATION_URL = ACCOUNT_URL + "/registration";
        public const string ACCOUNT_LOGIN_URL = ACCOUNT_URL + "/login";
    }
}
