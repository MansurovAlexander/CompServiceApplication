using System.ComponentModel.DataAnnotations.Schema;

namespace CompServiceApplication.Models
{
    public class WareHouseViewModel
    {
        public List<int> partid { get; set; }
        public string manufacturer { get; set; }
        public string partname { get; set; }
        public int partscount { get; set; }
        public decimal partcost { get; set; }
        public int workid { get; set; }
    }
}
