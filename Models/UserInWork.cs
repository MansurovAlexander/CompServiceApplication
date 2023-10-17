using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompServiceApplication.Models
{
    public class UserInWork
	{
		[Key]
		public int userinworkid { get; set; }

        [Column(TypeName ="integer")]
        public int userid { get; set; }

        [Column(TypeName ="integer")]
        public int workid { get; set; }

        [Column(TypeName = "date")]
        public DateTime startdate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? enddate { get; set; }
    }
}
