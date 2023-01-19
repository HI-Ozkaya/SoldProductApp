namespace SoldProductApp.Data.Model
{
    public class Return
    {
        public int Id { get; set; }
        public string RMACode { get; set; }
        public DateTime ReturnDate { get; set; }
        public string CargoCode { get; set; }

        private static int LastId = 1;
        public Return(string cargoCode/*, string rmaCode*/)
        {
            Id = LastId;
            //RMACode = rmaCode;
            ReturnDate = DateTime.Now;
            CargoCode = cargoCode;
            LastId = LastId + 1;
        }
    }
}