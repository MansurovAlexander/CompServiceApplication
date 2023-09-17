using System.ComponentModel.DataAnnotations;

namespace CompServiceApplication.Models
{
    public class UserInWork
	{
		[Key]
		public int UserInWorkID { get; set; }
        public int UserID { get; set; }
        public int WorkID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
