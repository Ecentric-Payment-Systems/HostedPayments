using EcentricHPP.Models;
using System;
using System.Reflection;
using System.Text;
using System.Web.Mvc;

namespace EcentricHPP.Controllers
{
    public class HostedController : Controller
    {
        // GET: Hosted
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult IndexPost(PaymentInfoModel model)
        {

            if (model == null || !ModelState.IsValid)
                throw new ArgumentException("IndexPost");

            //Generate Unique Reference for Order
            var MerchantReference = "O" + DateTime.Now.ToString("yyyyMMddhhmm") + new Random().Next(1000);

            //build form to post to page
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<form id='EpaymentForm' action='{0}' method='post'>", EcentricHPP.Helpers.ConfigHelper.HPPLink());

            var requestModel = new PaymentRequestModel(model.Amount, model.Currency, MerchantReference, model.TransactionType, model.UserID);
            PropertyInfo[] properties = requestModel.GetType().GetProperties();
            foreach (var prop in properties)
            {
                string name = prop.Name; // Get string name
                object value = prop.GetValue(requestModel, null); // Get value
                sb.AppendFormat("<input type='hidden' name='{0}' value='{1}'/>", name, value);
            }

            sb.Append("</form>");
            sb.Append("<script type='text/javascript'>document.getElementById('EpaymentForm').submit();</script>");

            //write to response object
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