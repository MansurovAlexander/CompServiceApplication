using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompServiceApplication.Models
{
    public class RepairType
	{
		[Key]
		public int repairid { get; set; }

        [Column(TypeName ="text")]
        public string repairdescription { get; set; }

        [Column(TypeName = "money")]
        public decimal repaircost { get; set; }
    }
}
