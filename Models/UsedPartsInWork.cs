using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompServiceApplication.Models
{
    public class UsedPartsInWork
	{
		[Key]
		public int usedpartsinworkid { get; set; }

        [Column(TypeName ="integer")]
        public int usedpartid { get; set; }

        [Column(TypeName ="integer")]
        public int workid { get; set; }
    }
}
