namespace OrderAPI.Models
{
    public class ItemsResponse:  ItemsRequest
    {    
        public double Subtotal { get; set; }
        public double VatPercentaje { get; set; }
        public double TotalWithVat { get; set; }
    }
}
