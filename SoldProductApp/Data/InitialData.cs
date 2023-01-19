using Microsoft.EntityFrameworkCore;
using SoldProductApp.Data.Model;
using System.Runtime.CompilerServices;

namespace SoldProductApp.Data
{
    public static class InitialData
    {
        public static void Seed(this ModelBuilder mb)
        {
            var orders = new List<Order> {
                new Order("Plate"),
                new Order("Fork"),
                new Order("Knife"),
                new Order("Glass"),
                new Order("Kitchen Set")
                };

            // Seed Orders
            mb.Entity<Order>().HasData(orders);

            // Seed Returns - Based On Ordered Product
            /*mb.Entity<Return>().HasData(new Return(orders[0].CargoCode));
            mb.Entity<Return>().HasData(new Return(orders[1].CargoCode));
            mb.Entity<Return>().HasData(new Return(orders[2].CargoCode));
            mb.Entity<Return>().HasData(new Return(orders[3].CargoCode));*/
        }
    }
}
