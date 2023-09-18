using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompServiceApplication.Models
{
    public class PartToOrder
	{
		[Key]
		public int parttoorderid { get; set; }

        [Column(TypeName ="integer")]
        public int purchaseorderid { get; set; }

        [Column(TypeName ="integer")]
        public int partid { get; set; }

        [Column(TypeName ="integer")]
        public int partscount { get; set; }

        [Column(TypeName = "money")]
        public decimal totalcost { get; set; }
    }
}
