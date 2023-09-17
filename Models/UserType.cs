using System.ComponentModel.DataAnnotations;

namespace CompServiceApplication.Models
{
    public class UserType
	{
		[Key]
		public int UserTypeID { get; set; }
        public string UserTypeName { get; set; }
    }
}
