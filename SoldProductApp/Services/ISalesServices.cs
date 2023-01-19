using SoldProductApp.Data;
using SoldProductApp.Data.Model;

namespace SoldProductApp.Services
{
    public interface ISalesServices
    {
        // Return all orders
        IEnumerable<Order> GetAllOrders();

        // Return all returns
        IEnumerable<Return> GetAllReturns();

        // Create new Order
        bool CreateOrder(string pName);

        // Create new Return
        bool CreateReturn(string rmaCode);

        // Get Order by RMA Code
        GetOrderVM GetRMADataByRMACode(string rmaCode);
    }
}
