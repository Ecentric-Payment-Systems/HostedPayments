using EcentricHPP.Enum;
using EcentricHPP.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace EcentricHPP.Models
{
    public class PaymentResponse
    {

        public string TransactionID { get; set; }
        public string MerchantReference { get; set; }
        public string Result { get; set; }
        public string FailureMessage { get; set; }
        public long Amount { get; set; }
        public bool isValidChecksum
        {
            get
            {
                return validateChecksum();
            }
        }

        public string Checksum { get; set; }

        private bool validateChecksum()
        {
            var MerchantID = ConfigHelper.GetConfiguration(Config.MerchantID);
            var secretKey = ConfigHelper.GetConfiguration(Config.MerchantSecret);


            var transactionID = string.IsNullOrEmpty(this.TransactionID) ? string.Empty : this.TransactionID;
            var checksumString = string.Format("{0}|{1}|{2}|{3}|{4}|{5}", secretKey, transactionID, this.MerchantReference, this.Result, this.FailureMessage, this.Amount);

            SHA256Managed sha = new SHA256Managed();
            return string.Equals(sha.ComputeHash(Encoding.UTF8.GetBytes(checksumString)).Select(h => h.ToString("X2")).Aggregate((i, j) => i + j), this.Checksum, StringComparison.InvariantCultureIgnoreCase);
        }

    }
}