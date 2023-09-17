using System.ComponentModel.DataAnnotations;

namespace CompServiceApplication.Models
{
    public class RepairInWork
	{
		[Key]
		public int RepairInWorkID { get; set; }
        public int RepairID { get; set; }
        public int WorkID { get; set; }
    }
}
