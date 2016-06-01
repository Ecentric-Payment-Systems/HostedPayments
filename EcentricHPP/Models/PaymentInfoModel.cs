using System.ComponentModel.DataAnnotations;

namespace EcentricHPP.Models
{
    public class PaymentInfoModel
    {
        [Required]
        public string TransactionType { get; set; }

         [Required]
        public double Amount { get; set; }

         [Required]
        public string Currency { get; set; }

         [Required]
        public string UserID { get; set; }
    }
}