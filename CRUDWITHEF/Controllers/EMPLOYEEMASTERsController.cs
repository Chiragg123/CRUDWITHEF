using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUDWITHEF.Models;

namespace CRUDWITHEF.Controllers
{
    public class EMPLOYEEMASTERsController : Controller
    {
        public CRUDDBEntities db = new CRUDDBEntities();

        public ActionResult Index()
        {
            return View(db.EMPLOYEEMASTERs.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLOYEEMASTER eMPLOYEEMASTER = db.EMPLOYEEMASTERs.Find(id);
            if (eMPLOYEEMASTER == null)
            {
                return HttpNotFound();
            }
            return View(eMPLOYEEMASTER);
        }
        
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EMPCODE,EMPNAME,DESIGNATION,SALARY")] EMPLOYEEMASTER eMPLOYEEMASTER)
        {
            if (ModelState.IsValid)
            {
                db.EMPLOYEEMASTERs.Add(eMPLOYEEMASTER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eMPLOYEEMASTER);
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLOYEEMASTER eMPLOYEEMASTER = db.EMPLOYEEMASTERs.Find(id);
            if (eMPLOYEEMASTER == null)
            {
                return HttpNotFound();
            }
            return View(eMPLOYEEMASTER);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EMPCODE,EMPNAME,DESIGNATION,SALARY")] EMPLOYEEMASTER eMPLOYEEMASTER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eMPLOYEEMASTER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eMPLOYEEMASTER);
        }
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLOYEEMASTER eMPLOYEEMASTER = db.EMPLOYEEMASTERs.Find(id);
            if (eMPLOYEEMASTER == null)
            {
                return HttpNotFound();
            }
            return View(eMPLOYEEMASTER);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EMPLOYEEMASTER eMPLOYEEMASTER = db.EMPLOYEEMASTERs.Find(id);
            db.EMPLOYEEMASTERs.Remove(eMPLOYEEMASTER);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Search()
        {
            return View();
        }
        public ActionResult SearchBySalary(decimal salary)
        {
            var employees = db.EMPLOYEEMASTERs.Where(e => e.SALARY <= salary).ToList();
            return Json(new { success = true, employees }, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

