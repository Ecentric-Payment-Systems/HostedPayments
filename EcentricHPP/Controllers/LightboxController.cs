using EcentricHPP.Models;
using System;
using System.Text;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace EcentricHPP.Controllers
{
    public class LightboxController : Controller
    {
        // GET: Lightbox
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult LightboxPost(PaymentInfoModel model)
        {

            if (model == null || !ModelState.IsValid)
                throw new ArgumentException("LightboxPost");

            var MerchantReference = "O" + DateTime.Now.ToString("yyyyMMddhhmm") + new Random().Next(1000);

            StringBuilder sb = new StringBuilder();
            var requestModel = new PaymentRequestModel(model.Amount, model.Currency, MerchantReference, model.TransactionType, model.UserID);
            sb.Append("<script type='text/javascript' src='" + EcentricHPP.Helpers.ConfigHelper.HPPLink() + "/api/js'></script>");
            sb.Append("<script type='text/javascript'>window.onload = function() {  window.hpp.payment(" + new JavaScriptSerializer().Serialize(requestModel) + ", successFn, failureFn) }</script>");

            Response.Write(sb.ToString());
            return View();
        }

        public ActionResult Jquery()
        {
            return View();
        }

        public ActionResult Angular()
        {
            return View();
        }
    }
}