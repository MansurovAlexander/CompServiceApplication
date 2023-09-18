using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompServiceApplication.Models
{
    public class UsedPart
	{
		[Key]
		public int usedpartid { get; set; }

        [Column(TypeName ="integer")]
        public int usedpartcount { get; set; }

        [Column(TypeName = "money")]
        public decimal usedpartprice { get; set; }

        [Column(TypeName ="integer")]
        public int partid { get; set; }
    }
}
