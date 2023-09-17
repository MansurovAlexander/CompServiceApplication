using System.ComponentModel.DataAnnotations;

namespace CompServiceApplication.Models
{
    public class Warehouse
	{
		[Key]
		public int PartID { get; set; }
        public string Manufacturer { get; set; }
        public string PartName { get; set; }
        public int PartsCount { get; set; }
        public decimal PartPrice { get; set; }
    }
}
