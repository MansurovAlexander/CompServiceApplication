using System.ComponentModel.DataAnnotations;

namespace CompServiceApplication.Models
{
    public class PartToDevice
	{
		[Key]
		public int PartToDeviceID { get; set; }
        public int PartID { get; set; }
        public int DeviceID { get; set; }
    }
}
