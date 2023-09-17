using CompServiceApplication.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore;
namespace CompServiceApplication
{
    public class AppDatabaseContext:DbContext
    {
        public DbSet<Device> Devices {  get; set; }
        public DbSet<InWork> InWorks { get; set; }
		public DbSet<PartToDevice> PartToDevices { get; set; }
		public DbSet<PartToOrder> PartToOrders { get; set; }
		public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
		public DbSet<RepairInWork> RepairInWorks { get; set; }
		public DbSet<RepairType> RepairTypes { get; set; }
		public DbSet<TaskOrder> TaskOrders { get; set; }
		public DbSet<UsedPart> UsedParts { get; set; }
		public DbSet<UsedPartsInWork> UsedPartsInWorks { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<UserInWork> UserInWorks { get; set; }
		public DbSet<UserType> UserTypes { get; set; }
		public DbSet<Visualflow> Visualflows { get; set; }
		public DbSet<Warehouse> Warehouses { get; set; }
		public AppDatabaseContext(DbContextOptions<AppDatabaseContext> options):base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
