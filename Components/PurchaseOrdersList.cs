using CompServiceApplication.Interfaces;
using CompServiceApplication.Models;
using CompServiceApplication.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompServiceApplication.Components
{
	public class PurchaseOrdersList : ViewComponent
	{
		private readonly IPurchaseOrderRepository _purchaseOrderRepository;
		private readonly IPartToOrderRepository _partToOrderRepository;
		private readonly IUserRepository _userRepository;
		public PurchaseOrdersList(IPurchaseOrderRepository purchaseOrderRepository, IPartToOrderRepository partToOrderRepository, IUserRepository userRepository)
		{
			_purchaseOrderRepository = purchaseOrderRepository;
			_partToOrderRepository = partToOrderRepository;
			_userRepository = userRepository;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var purchaseOrders=_purchaseOrderRepository.GetAllUnconfirmed().Result;
			List<PurchaseOrderViewModel> purchaseOrderViewModels = new();
			foreach(var purchaseOrder in purchaseOrders)
			{
				PurchaseOrderViewModel temp = new();
				temp.purchaseorderid = purchaseOrder.purchaseorderid;
				temp.ordereduser = _userRepository.GetUserDataByID(purchaseOrder.ordereduserid);
				temp.dateoforder= purchaseOrder.dateoforder;
				temp.status = purchaseOrder.status;
				temp.statuschangedate = purchaseOrder.statuschangedate;
				if (purchaseOrder.confirmeduserid != null)
				{
					temp.confirmeduser = _userRepository.GetUserDataByID(purchaseOrder.confirmeduserid);
				}
                temp.partsToOrder = new SelectList(from u in _partToOrderRepository.GetDataByPurchaseOrderID(purchaseOrder.purchaseorderid)
                                             select new
                                               {
                                                   UserID = u,
                                                   UserData = u
                                               },
                "UserID",
                "UserData",
                null);
                purchaseOrderViewModels.Add(temp);
			}
			return View("WorkPanel\\PurchaseOrderList.cshtml", purchaseOrderViewModels);
		}
	}
}
