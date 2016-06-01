using EcentricHPP.Enum;
using EcentricHPP.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcentricHPP.Models
{
    public class WalletRequestModel
    {
        public WalletRequestModel(string userID)
        {
            this.UserID = userID;

            this.MerchantID = ConfigHelper.GetConfiguration(Config.MerchantID);
            this.Checksum = new EncryptionHelper(ConfigHelper.GetConfiguration(Config.MerchantSecret)).GetCardManageChecksum(this.MerchantID, this.UserID);
        }

        public string UserID { get; set; }

        public string MerchantID { get; set; }

        public string Checksum { get; set; }
    }
}