using EcentricHPP.Models;
using System;
using System.Web.Http;

namespace EcentricHPP.Controllers.Api
{
    public class PaymentController : ApiController
    {
        /// <summary>
        /// Generates the Payment Request object to pass to Ecentric Payments
        /// </summary>
        /// <param name="model">Payment Information</param>
        /// <returns>Payment Request object</returns>
        [HttpPost]
        public PaymentRequestModel GetRequest([FromBody] PaymentInfoModel model)
        {
            if (model == null || !ModelState.IsValid)
                throw new ArgumentException("GetRequest");

            var MerchantReference = "O" + DateTime.Now.ToString("yyyyMMddhhmm") + new Random().Next(1000);
            return new PaymentRequestModel(model.Amount, model.Currency, MerchantReference, model.TransactionType, model.UserID);
        }

        /// <summary>
        /// Generates the Wallet Request object to pass to Ecentric Payments
        /// </summary>
        /// <param name="model">User Information - UserID</param>
        /// <returns>Wallet Request object</returns>
        [HttpPost]
        public WalletRequestModel GetWalletRequest([FromBody] UserInfo model)
        {
            if (model == null || !ModelState.IsValid)
                throw new ArgumentException("GetWalletRequest");

            return new WalletRequestModel(model.UserID);
        }
    }
}
