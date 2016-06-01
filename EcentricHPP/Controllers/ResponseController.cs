using EcentricHPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcentricHPP.Controllers
{
    public class ResponseController : Controller
    {
        [HttpPost]
        public ActionResult Index(PaymentResponse model)
        {
            return View(model);
        }

        [HttpPost]
        public ActionResult Card(CardResponse model)
        {
            return View(model);
        }
    }
}