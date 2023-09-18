using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompServiceApplication.Models
{
    public class InWork
    {
        [Key]
        public int workid { get; set; }

        [Column(TypeName = "text")]
        public string workstagedescription { get; set; } = string.Empty;

        [Column(TypeName ="integer")]
        public int taskorderid { get; set; }
    }
}
