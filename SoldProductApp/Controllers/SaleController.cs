using Microsoft.AspNetCore.Mvc;
using SoldProductApp.Data;
using SoldProductApp.Data.Model;
using SoldProductApp.Services;

namespace SoldProductApp.Controllers
{
    public class SaleController : Controller
    {
        private readonly ISalesServices _services;
        public SaleController(ISalesServices services)
        {
            _services= services;
        }

        /// <summary>
        /// Ürün Sipariş Etme ve İade işlemlerinin gerçekleştirildiği sayfa
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Sipariş edilen ürünlerin listelendiği sayfa
        /// </summary>
        /// <returns>Order List</returns>
        public IActionResult Orders()
        {
            return View(_services.GetAllOrders());
        }

        /// <summary>
        /// İade edilen ürünlerin listelendiği sayfa
        /// </summary>
        /// <returns>Return List</returns>
        public IActionResult Returns()
        {
            return View(_services.GetAllReturns());
        }

        /// <summary>
        /// Üürn adı ile sipariş oluşturma
        /// </summary>
        /// <param name="vM"></param>
        /// <returns>Orders Page</returns>
        public IActionResult AddOrder(StringVM vM)
        {
            _services.CreateOrder(vM.Str);
            return RedirectToAction("Orders");
        }

        /// <summary>
        /// Kargo kodu ile ürün iade etme
        /// </summary>
        /// <param name="vM"></param>
        /// <returns>Returns Page</returns>
        public IActionResult AddReturn(StringVM vM)
        {
            _services.CreateReturn(vM.Str);
            return RedirectToAction("Returns");
        }

        /// <summary>
        /// RMA Kodu ile iade edilen siparişe ulaşma
        /// </summary>
        /// <param name="rmaCode"></param>
        /// <returns>Order Page</returns>
        public IActionResult GetRMADataByRMACode(string rmaCode)
        {
            return View("Order", _services.GetRMADataByRMACode(rmaCode));
        }
    }
}
