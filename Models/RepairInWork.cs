using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompServiceApplication.Models
{
    public class RepairInWork
	{
		[Key]
		public int repairinworkid { get; set; }

        [Column(TypeName ="integer")]
        public int repairid { get; set; }

        [Column(TypeName ="integer")]
        public int workid { get; set; }
    }
}
