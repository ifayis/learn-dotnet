namespace Sales_Management_API.DTOs
{
    public class CreateSalesDetailDto
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
