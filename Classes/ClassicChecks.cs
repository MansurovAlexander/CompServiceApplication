using System.Text.RegularExpressions;

namespace CompServiceApplication.Classes
{
    public static class ClassicChecks
    {
        public static bool IsValidDate(DateTime date)
        {
            return true;
        }
        public static bool ValidatePhoneNumber(string phoneNumber)
        {
            Regex regex = new Regex(@"^(\+[0-9]{11})$");
            if (regex.IsMatch(phoneNumber))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
