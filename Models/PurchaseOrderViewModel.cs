using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompServiceApplication.Models
{
	public class PurchaseOrderViewModel
	{
		public int purchaseorderid { get; set; }
		public DateTime dateoforder { get; set; }
		public string status { get; set; }
		public DateTime? statuschangedate { get; set; }
		public string ordereduser { get; set; }
		public string? confirmeduser { get; set; }
		public SelectList partsToOrder { get; set; }
	}
}
