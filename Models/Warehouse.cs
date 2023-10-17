using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompServiceApplication.Models
{
    public class Warehouse
	{
		[Key]
		public int partid { get; set; }

        [Column(TypeName = "character varying(50)")]
        public string manufacturer { get; set; }

        [Column(TypeName = "text")]
        public string partname { get; set; }

        [Column(TypeName ="integer")]
        public int partscount { get; set; }

        [Column(TypeName = "money")]
        public decimal partcost { get; set; }
    }
}
