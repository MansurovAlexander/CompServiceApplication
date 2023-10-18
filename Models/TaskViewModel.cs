namespace CompServiceApplication.Models
{
	public class TaskViewModel
	{
		public int taskorderid { get; set; }
		public DateTime createdate { get; set; }
		public string problemdescription { get; set; }
		public string devicedescription { get; set; }
		public string? lastworker {  get; set; }
		public string? clientdata { get; set; }
		public List<string> images { get; set; }
		public bool taken { get; set; }
	}
}
