using System.ComponentModel.DataAnnotations;

namespace CompServiceApplication.Models
{
    public class TaskOrder
	{
		[Key]
		public int TaskOrderID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ProblemDescription { get; set; }
        public decimal? FinallyCost { get; set; }
        public int UserID { get; set; }
        public int DeviceID { get; set; }
    }
}
