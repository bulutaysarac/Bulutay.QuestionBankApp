namespace Bulutay.QuestionBankApp.Front.HttpRequestHelpers
{
    public static class QBApiLinks
    {
        private const string ROOT = "http://localhost:5817/api";
        public const string CATEGORIES = $"{ROOT}/categories";
        public const string DEPARTMENTS = $"{ROOT}/departments";
        public const string LECTURES = $"{ROOT}/lectures";
        public const string USERS = $"{ROOT}/users";
        public const string ROLES = $"{ROOT}/roles";
        public const string QUESTIONS = $"{ROOT}/questions";
        public const string OPTIONS = $"{ROOT}/options";
    }
}
