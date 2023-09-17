using System.ComponentModel.DataAnnotations;

namespace CompServiceApplication.Models
{
    public class UsedPart
	{
		[Key]
		public int UsedPartID { get; set; }
        public int UsedPartCount { get; set; }
        public decimal UsedPartPrice { get; set; }
        public int PartID { get; set; }
    }
}
