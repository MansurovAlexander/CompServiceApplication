using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompServiceApplication.Models
{
    public class PurchaseOrder
	{
		[Key]
		public int purchaseorderid { get; set; }

        [Column(TypeName = "date")]
        public DateTime dateoforder { get; set; }

        [Column(TypeName = "text")]
        public string status { get; set; }

        [Column(TypeName = "date")]
        public DateTime statuschangedate { get; set; }

        [Column(TypeName ="integer")]
        public int ordereduserid { get; set; }
        public int? confirmeduserid { get; set; }
    }
}
