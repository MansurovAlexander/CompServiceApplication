using CompServiceApplication.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CompServiceApplication.Controllers
{
    public class Manager : Controller
    {
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;
        public Manager(IPurchaseOrderRepository purchaseOrderRepository)
        {
            _purchaseOrderRepository = purchaseOrderRepository;
        }

        public async Task<IActionResult> ConfirmPurchaseOrder(int purchaseOrderID)
        {
            var purchaseOrder=_purchaseOrderRepository.GetByID(purchaseOrderID).Result;
            purchaseOrder.confirmeduserid = int.Parse(User.Identity.Name);
            purchaseOrder.status = "Подтвержден";
            purchaseOrder.statuschangedate = DateTime.Now;
            await _purchaseOrderRepository.Update(purchaseOrder);
            return View("\\CreatePanel");
        }
        public async Task<IActionResult> DenyPurchaseOrder(int purchaseOrderID)
        {
            var purchaseOrder = _purchaseOrderRepository.GetByID(purchaseOrderID).Result;
            purchaseOrder.confirmeduserid = int.Parse(User.Identity.Name);
            purchaseOrder.status = "Отказано";
            purchaseOrder.statuschangedate = DateTime.Now;
            await _purchaseOrderRepository.Update(purchaseOrder);
            return View("\\CreatePanel");
        }
        public IActionResult CreatePanel()
        {
            return View();
        }
        public IActionResult AlterPanel()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
