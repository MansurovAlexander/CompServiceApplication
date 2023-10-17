using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompServiceApplication.Models
{
    public class UsedPart
	{
		[Key]
		public int usedpartid { get; set; }

        [Column(TypeName ="integer")]
        public int usedpartscount { get; set; }

        [Column(TypeName = "money")]
        public decimal totalcost { get; set; }

        [Column(TypeName ="integer")]
        public int partid { get; set; }
        public int workid { get; set; }
    }
}
