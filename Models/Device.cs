using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompServiceApplication.Models
{
    public class Device
    {
        [Key]
        public int deviceid { get; set; }

        [Column(TypeName = "text")]
        public string manufacturer { get; set; } = string.Empty;

		[Column(TypeName = "text")]
		public string devicedescription { get; set; } = string.Empty;

		[Column(TypeName = "text")]
		public string model { get; set; } = string.Empty;
	}
}
