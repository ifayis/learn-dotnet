namespace Sales_Management_API.DTOs
{
    public class CreateSalesHeaderDto
    {
        public string CustomerName { get; set; }
        public DateTime Date { get; set; }

        public List<CreateSalesDetailDto> Details { get; set; }
    }
}
