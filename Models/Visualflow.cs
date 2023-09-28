using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompServiceApplication.Models
{
    public class Visualflow
	{
		[Key]
		public int visualflowid { get; set; }

        [Column(TypeName ="integer")]
        public int taskorderid { get; set; }

		[Column(TypeName = "bytea")]
		public byte[] visualflow { get; set; }

		[Column(TypeName = "text")]
		public string imageextension { get; set; }
	}
}
