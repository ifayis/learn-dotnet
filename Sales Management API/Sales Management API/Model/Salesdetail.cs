namespace Sales_Management_API.Model
{
    public class Salesdetail
    {
          public int Id { get; set; }
          public int SalesHeaderId { get; set; }
          public string ProductName { get; set; }
          public int Quantity { get; set; }
          public decimal UnitPrice { get; set; }
          public decimal LineTotal { get; set; }

          public Salesheader SalesHeader { get; set; }
    }
}
