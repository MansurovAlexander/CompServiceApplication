﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CompServiceApplication.Models
{
    public class CreateTaskViewModel
    {
        public int taskorderid { get; set; }
        public DateTime createdate { get; set; }
        public string problemdescription { get; set; }
        public int userid { get; set; }
        public int deviceid { get; set; }

        [Display(Name = "Выберите файл")]
        [DataType(DataType.Upload)]
        public IFormFileCollection visualflow { get; set; }
    }
}