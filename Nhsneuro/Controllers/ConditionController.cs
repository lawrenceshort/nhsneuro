using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nhsneuro.Controllers
{
    public class ConditionController : Controller
    {
        public ConditionController()
        {
            dbContext = new nhsneuroEntities();
        }

        private nhsneuroEntities dbContext;

        // GET: Condition
        public ActionResult Index()
        {
            var result = dbContext.Conditions;
                     ViewData.Add(new KeyValuePair<string, object>("conditions", result));

            return View(ViewData);
        }
    }
}
