using System.Collections;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace CompServiceApplication.Models
{
    public class CreateTaskViewModel
    {
        public int taskorderid { get; set; }
        public DateTime startdate { get; set; }
        public string problemdescription { get; set; }
        public int userid { get; set; }
        public int deviceid { get; set; }
        public IFormFileCollection? visualflow { get; set; }
    }
}
