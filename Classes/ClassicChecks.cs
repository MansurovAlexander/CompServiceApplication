using System.Text.RegularExpressions;

namespace CompServiceApplication.Classes
{
    public static class ClassicChecks
    {
        public static bool IsValidDate(DateTime date)
        {
            if (DateTime.Compare(date, DateTime.UtcNow) < 100 && DateTime.Compare(date, DateTime.UtcNow)>=18 && date < DateTime.UtcNow)
                return true;
            else return false;
        }
        public static bool ValidatePhoneNumber(string phoneNumber)
        {
            Regex regex = new Regex("\\+?\\d{1,3}[- ]{0,1}[\\s\\.]{0,1}\\d{1,4}[- ]{0,1}\\d{1,4}[\\s]{0,1}\\d{2,4}");
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
