using System.ComponentModel.DataAnnotations.Schema;

namespace CompServiceApplication.Models
{
    public class CreateUserViewModel
    {
        public string lastname { get; set; }
        public string firstname { get; set; }
        public string middlename { get; set; }
        public DateTime dateofbirth { get; set; }
        public string phonenumber { get; set; }
        public string passseries { get; set; }
        public string passnum { get; set; }
        public string userlogin { get; set; }
        public string userpassword { get; set; }
        public int usertypeid { get; set; }
        public List<UserType> userTypes { get; set; }
    }
}
