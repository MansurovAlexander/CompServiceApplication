using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompServiceApplication.Models
{
    public class PartToDevice
	{
		public int parttodeviceid { get; set; }
        public int partid { get; set; }
        public int deviceid { get; set; }
    }
}
