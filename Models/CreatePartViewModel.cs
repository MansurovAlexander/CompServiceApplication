using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CompServiceApplication.Models
{
    public class CreatePartViewModel
    {
        public int partid { get; set; }
        public string manufacturer { get; set; }
        public string partname { get; set; }
        public string partscount { get; set; }
        public string partcost { get; set; }
        public List<int> compatibleDevices { get; set; }
    }
}
