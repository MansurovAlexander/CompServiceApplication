using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompServiceApplication.Models
{
    public class Device
    {
        [Key]
        public int DeviceID { get; set; }

        [Column(TypeName = "text")]
        public string Manufacturer { get; set; } = string.Empty;

		[Column(TypeName = "text")]
		public string DeviceDescription { get; set; } = string.Empty;

		[Column(TypeName = "text")]
		public string SerialNumber { get; set; } = string.Empty;
	}
}
