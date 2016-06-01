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
    public class CardResponse
    {
        public string Result { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
        public string UserID { get; set; }
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


            var checksumString = string.Format("{0}|{1}|{2}|{3}|{4}", secretKey, this.Token, this.UserID, this.Result, this.Message);

            SHA256Managed sha = new SHA256Managed();
            return string.Equals(sha.ComputeHash(Encoding.UTF8.GetBytes(checksumString)).Select(h => h.ToString("X2")).Aggregate((i, j) => i + j), this.Checksum, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}