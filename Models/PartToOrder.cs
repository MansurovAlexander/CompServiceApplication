using System.ComponentModel.DataAnnotations;

namespace CompServiceApplication.Models
{
    public class PartToOrder
	{
		[Key]
		public int PartToOrderID { get; set; }
        public int PurchaseOrderID { get; set; }
        public int PartID { get; set; }
        public int PartsCount { get; set; }
        public decimal TotalCost { get; set; }
    }
}
