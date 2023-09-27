namespace CompServiceApplication.Models
{
	public class TaskViewModel
	{
		public int taskorderid { get; set; }
		public DateTime createdate { get; set; }
		public string problemdescription { get; set; }
		public string? lastworker {  get; set; }
		public List<IFormFile> images { get; set; }
	}
}
