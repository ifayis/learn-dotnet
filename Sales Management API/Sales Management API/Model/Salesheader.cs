namespace Sales_Management_API.Model
{
    public class Salesheader
    {
            public int Id { get; set; }
            public string CustomerName { get; set; }
            public DateTime Date { get; set; }
            public decimal TotalAmount { get; set; }

            public ICollection<Salesdetail> SalesDetails { get; set; }
    }
}
