using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompServiceApplication.Models
{
    public class TaskOrder
	{
		[Key]
		public int taskorderid { get; set; }

        [Column(TypeName = "timestamp")]
        public DateTime createdate { get; set; }

        [Column(TypeName = "timestamp")]
        public DateTime? enddate { get; set; }

        [Column(TypeName = "text")]
        public string problemdescription { get; set; }

        [Column(TypeName = "money")]
        public decimal? finallycost { get; set; }

        [Column(TypeName ="integer")]
        public int userid { get; set; }

        [Column(TypeName ="integer")]
        public int deviceid { get; set; }
    }
}
