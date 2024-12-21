namespace VSureB2b_Reports.Models
{
    public class RFQResponseModel
    {
        public string Period { get; set; }
        public string Type { get; set; }
        public int TotalRFQs { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
