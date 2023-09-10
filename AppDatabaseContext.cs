using CompServiceApplication.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore;
namespace CompServiceApplication
{
    public class AppDatabaseContext:DbContext
    {
        public DbSet<Device> Devices => Set<Device>();
        public DbSet<InWork> InWorks => Set<InWork>();
        public DbSet<PartToDevice> PartToDevices => Set<PartToDevice>();
        public DbSet<PartToOrder> PartToOrders => Set<PartToOrder>();
        public DbSet<PurchaseOrder> PurchaseOrders => Set<PurchaseOrder>();
        public DbSet<RepairInWork> RepairInWorks => Set<RepairInWork>();
        public DbSet<RepairType> RepairTypes => Set<RepairType>();
        public DbSet<TaskOrder> TaskOrders => Set<TaskOrder>();
        public DbSet<UsedPart> UsedParts => Set<UsedPart>();
        public DbSet<UsedPartsInWork> UsedPartsInWorks => Set<UsedPartsInWork>();
        public DbSet<User> Users => Set<User>();
        public DbSet<UserInWork> UserInWorks => Set<UserInWork>();
        public DbSet<UserType> UserTypes => Set<UserType>();
        public DbSet<Visualflow> Visualflows => Set<Visualflow>();
        public DbSet<Warehouse> Warehouses => Set<Warehouse>();
        public AppDatabaseContext(DbContextOptions<AppDatabaseContext> options):base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
