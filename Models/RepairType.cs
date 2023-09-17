using System.ComponentModel.DataAnnotations;

namespace CompServiceApplication.Models
{
    public class RepairType
	{
		[Key]
		public int RepairTypeID { get; set; }
        public string RepairDescription { get; set; }
        public decimal RepairPrice { get; set; }
    }
}
