using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompServiceApplication.Models
{
    public class InWork
    {
        [Key]
        public int WorkID { get; set; }

        [Column(TypeName = "text")]
        public string WorkStageDescription { get; set; } = string.Empty;

        public int TaskOrderID { get; set; }
    }
}
