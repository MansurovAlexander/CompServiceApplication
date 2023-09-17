using System.ComponentModel.DataAnnotations;

namespace CompServiceApplication.Models
{
    public class User
	{
		[Key]
		public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string PassSeries { get; set; }
        public string PassNumber { get; set; }
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        public int UserTypeId { get; set; }

    }
}
