using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompServiceApplication.Models
{
    public class Visualflow
	{
		[Key]
		public int visualflowid { get; set; }

        [NotMapped]
        [Column(TypeName = "bit varying")]
        public byte[] visualflow { get; set; }

        [Column(TypeName ="integer")]
        public int taskorderid { get; set; }
    }
}
