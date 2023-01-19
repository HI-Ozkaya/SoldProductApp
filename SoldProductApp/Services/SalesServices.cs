using SoldProductApp.Data;
using SoldProductApp.Data.Model;

namespace SoldProductApp.Services
{
    public class SalesServices : ISalesServices
    {
        private readonly SalesContext _db;
        public SalesServices(SalesContext db)
        {
            _db= db;
        }

        public bool CreateOrder(string pName)
        {
            var order = new Order(pName);
            _db.Orders.Add(order);
            return 0 < _db.SaveChanges();
        }

        public bool CreateReturn(string rtaCode)
        {
            if (_db.Returns.Where(x => x.RMACode == rtaCode).FirstOrDefault() != null)
            {
                return false;
            }
            var rtrn = new Return(rtaCode/*, GetRMACode(rtaCode)*/);
            rtrn.RMACode = GetRMACode(rtaCode);
            _db.Returns.Add(rtrn);
            return 0 < _db.SaveChanges();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _db.Orders;
        }

        public IEnumerable<Return> GetAllReturns()
        {
            return _db.Returns;
        }

        private string GetRMACode(string rtaCode) 
        {
            return DateTime.Now.ToString("hh.mm.ss.ffffff").GetHashCode().ToString("x").ToUpper();
        }

        public GetOrderVM GetRMADataByRMACode(string rmaCode)
        {
            var rtrn = _db.Returns.FirstOrDefault(r => r.RMACode == rmaCode);
            var ordr = _db.Orders.FirstOrDefault(o => o.CargoCode == rtrn.CargoCode);
            var vm = new GetOrderVM()
            {
                Order = ordr,
                RMACode = rmaCode
            };
            return vm;
        }
    }
}
