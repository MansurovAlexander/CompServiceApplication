using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompServiceApplication.Models
{
    public class User
	{
		[Key]
		public int userid { get; set; }

        [Column(TypeName = "character varying(50)")]
        public string lastname { get; set; }

        [Column(TypeName = "character varying(50)")]
        public string firstname { get; set; }

        [Column(TypeName = "character varying(50)")]
        public string middlename { get; set; }

        [Column(TypeName = "Date")]
        public DateTime dateofbirth { get; set; }

        [Column(TypeName = "character varying(11)")]
        public string phonenumber { get; set; }

        [Column(TypeName = "character varying(4)")]
        public string passseries { get; set; }

        [Column(TypeName = "character varying(6)")]
        public string passnum { get; set; }

        [Column(TypeName = "character varying(50)")]
        public string userlogin { get; set; }

        [Column(TypeName = "varchar(64)")]
        public string userpassword { get; set; }

        [Column(TypeName ="integer")]
        public int usertypeid { get; set; }

    }
}
