using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nhsneuro.Controllers
{
    using Models;

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

        //// GET: Condition/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Condition/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Condition/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Condition/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Condition/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Condition/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Condition/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
