using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompServiceApplication.Models
{
    public class PartToDevice
	{
		[Key]
		public int parttodevice { get; set; }
        public int partid { get; set; }
        public int deviceid { get; set; }
    }
}
