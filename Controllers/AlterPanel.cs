using CompServiceApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompServiceApplication.Controllers
{
    public class AlterPanel:Controller
    {
        AppDatabaseContext _db;
        public AlterPanel(AppDatabaseContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> AlterUser(User updatedUser)
        {
            _db.users.Update(updatedUser);
            await _db.SaveChangesAsync();
            return View("\\AlterPanel");
        }
        public async Task<IActionResult> AlterRepairType(RepairType updatedRepairType)
        {
            _db.repairtypes.Update(updatedRepairType);
            await _db.SaveChangesAsync();
            return View("\\AlterPanel");
        }
        public async Task<IActionResult> AlterDevice(Device updatedDevice)
        {
            _db.devices.Update(updatedDevice);
            await _db.SaveChangesAsync();
            return View("\\AlterPanel");
        }
    }
}
