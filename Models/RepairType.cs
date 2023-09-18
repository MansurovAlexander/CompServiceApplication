using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompServiceApplication.Models
{
    public class RepairType
	{
		[Key]
		public int repairtypeid { get; set; }

        [Column(TypeName ="text")]
        public string repairdescription { get; set; }

        [Column(TypeName = "money")]
        public decimal repairprice { get; set; }
    }
}
