using System.ComponentModel.DataAnnotations;

namespace VSureB2b_Reports.Models
{
    public class RFQRequestModel
    {
        [Required]
        public string Period { get; set; }    // Required: 'MTD' or 'YTD'

        [Required]
        public string Type { get; set; }      // Required: 'Total', 'Motor', or 'Non Motor'

        public int? Year { get; set; }        // Optional: Year input (hidden unless provided)

        public DateTime? Date { get; set; }   // Optional: Date input (hidden unless provided)
    }
}
