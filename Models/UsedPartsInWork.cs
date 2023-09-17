using System.ComponentModel.DataAnnotations;

namespace CompServiceApplication.Models
{
    public class UsedPartsInWork
	{
		[Key]
		public int UsedPartsInWorkId { get; set; }
        public int UsedPartID { get; set; }
        public int WorkID { get; set; }
    }
}
