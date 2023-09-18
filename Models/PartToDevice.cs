using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompServiceApplication.Models
{
    public class PartToDevice
	{
		[Key]
		public int parttodevice { get; set; }

        [Column(TypeName ="integer")]
        public int partid { get; set; }

        [Column(TypeName ="integer")]
        public int deviceid { get; set; }
    }
}
