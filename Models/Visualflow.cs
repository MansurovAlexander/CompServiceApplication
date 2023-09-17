using System.ComponentModel.DataAnnotations;

namespace CompServiceApplication.Models
{
    public class Visualflow
	{
		[Key]
		public int VisualFlowID { get; set; }
        public byte[] VisualFlow { get; set; }
        public int TaskOrderID { get; set; }
    }
}
