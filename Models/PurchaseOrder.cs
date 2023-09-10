namespace CompServiceApplication.Models
{
    public class PurchaseOrder
    {
        public int PurchaseOrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public DateTime StatusChangeDate { get; set; }
        public int UserID { get; set; }
    }
}
