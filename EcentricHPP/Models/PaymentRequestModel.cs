using EcentricHPP.Enum;
using EcentricHPP.Helpers;

namespace EcentricHPP.Models
{
    public class PaymentRequestModel
    {

        public PaymentRequestModel(double amount, string currency, string merchantReference, string transactionType, string userID)
        {
            //Amount should always be an integer
            this.Amount = (int)(amount * 100);
            this.Currency = currency;
            this.MerchantReference = merchantReference;
            this.TransactionType = transactionType;
            this.UserID = userID == null ? string.Empty : userID;
            this.MerchantID = ConfigHelper.GetConfiguration(Config.MerchantID);

            EncryptionHelper encryptionHelper = new EncryptionHelper(ConfigHelper.GetConfiguration(Config.MerchantSecret));
            this.Checksum = encryptionHelper.GetRequestChecksum(this.MerchantID, this.TransactionType, this.Amount, this.Currency, this.MerchantReference, this.UserID);
        }

        public string MerchantID { get; set; }

        public string TransactionType { get; set; }

        public int Amount { get; set; }

        public string Currency { get; set; }

        public string MerchantReference { get; set; }

        public string UserID { get; set; }

        public string Checksum { get; set; }

    }
}