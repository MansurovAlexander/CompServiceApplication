using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompServiceApplication.Models
{
    public class UserType
	{
		[Key]
		public int usertypeid { get; set; }

        [Column(TypeName = "character varying(50)")]
        public string usertypename { get; set; }
    }
}
