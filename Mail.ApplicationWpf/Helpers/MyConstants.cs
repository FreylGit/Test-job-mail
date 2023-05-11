namespace Mail.ApplicationWpf.Helper
{
    public static class MyConstants
    {
        public const string BASE_URL = "https://localhost:7164/api/";
        public const string MESSAGE_URL = BASE_URL + "Message";
        public const string MESSAGE_GET_MESSAGE_BY_ID_URL = MESSAGE_URL+ "/user/";
        public const string MESSAGE_POST_URL = MESSAGE_URL;
        public const string USER_URL = BASE_URL + "User";
        public const string ACCOUNT_URL = BASE_URL + "Account";
        public const string ACCOUNT_REGISTRATION_URL = ACCOUNT_URL + "/registration";
        public const string ACCOUNT_LOGIN_URL = ACCOUNT_URL + "/login";
    }
}
