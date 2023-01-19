namespace SoldProductApp.Data.Model
{
    public class Order
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public DateTime OrderDate { get; set; }
        public string CargoCode { get; set; }

        private static int LastId=1;
        public Order(string productName)
        {
            Id= LastId;
            ProductName= productName;
            OrderDate= DateTime.Now;
            CargoCode = OrderDate.ToString("hh.mm.ss.ffffff").GetHashCode().ToString("x").ToUpper();
            LastId= LastId+1;
        }
    }
}
