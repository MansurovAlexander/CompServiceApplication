using CompServiceApplication.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore;
namespace CompServiceApplication
{
    public class AppDatabaseContext:DbContext
    {
        public DbSet<Device> devices {  get; set; }
        public DbSet<InWork> inworks { get; set; }
		public DbSet<PartToDevice> parttodevice { get; set; }
		public DbSet<PartToOrder> partstoorder { get; set; }
		public DbSet<PurchaseOrder> purchaseorder { get; set; }
		public DbSet<RepairInWork> repairinwork { get; set; }
		public DbSet<RepairType> repairtypes { get; set; }
		public DbSet<TaskOrder> taskorders { get; set; }
		public DbSet<UsedPart> usedparts { get; set; }
		public DbSet<UsedPartsInWork> usedpartsinwork { get; set; }
		public DbSet<User> users { get; set; }
		public DbSet<UserInWork> userinwork { get; set; }
		public DbSet<UserType> usertypes { get; set; }
		public DbSet<Visualflow> visualflows { get; set; }
		public DbSet<Warehouse> warehouse { get; set; }
		public AppDatabaseContext(DbContextOptions<AppDatabaseContext> options):base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
