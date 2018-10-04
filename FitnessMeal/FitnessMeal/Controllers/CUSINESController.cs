using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FitnessMeal.Models;

namespace FitnessMeal.Controllers
{
    public class CUSINESController : Controller
    {
        private FitnessMealModel db = new FitnessMealModel();

        // GET: CUSINES
        public ActionResult Index()
        {
            return View(db.CUSINEs.ToList());
        }

        // GET: CUSINES/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSINES cUSINES = db.CUSINEs.Find(id);
            if (cUSINES == null)
            {
                return HttpNotFound();
            }
            return View(cUSINES);
        }

        // GET: CUSINES/Create
        public ActionResult Create()
        {
            if (db.CUSINEs.ToArray().GetLength(0)==0)
            {
                string[] cusines = { "Alcohol", "American", "Asian", "BBQ", "Breakfast and Brunch", "Bubble Tea", "Burgers", "Chicken", "Chinese", "Comfort Food", "Desserts", "Fast Food", "Fish and Chips", "Greek", "Halal", "Healthy", "Ice Cream","Frozen Yogurt", "Indian", "Italian", "Japanese", "Korean", "Mexican", "Middle Eastern", "Pizza", "Sandwiches", "Thai", "Turkish", "Vegan", "Vegetarian", "Vietnamese" };
                foreach(string i in cusines)
                {
                    CUSINES theCusine = new CUSINES();
                    theCusine.CUSINE = i;
                    db.CUSINEs.Add(theCusine);
                }

                db.SaveChanges();
            }
            return View();
        }

        // POST: CUSINES/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CUSINE")] CUSINES cUSINES)
        {
            if (ModelState.IsValid)
            {
                db.CUSINEs.Add(cUSINES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cUSINES);
        }

        // GET: CUSINES/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSINES cUSINES = db.CUSINEs.Find(id);
            if (cUSINES == null)
            {
                return HttpNotFound();
            }
            return View(cUSINES);
        }

        // POST: CUSINES/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CUSINE")] CUSINES cUSINES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cUSINES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cUSINES);
        }

        // GET: CUSINES/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSINES cUSINES = db.CUSINEs.Find(id);
            if (cUSINES == null)
            {
                return HttpNotFound();
            }
            return View(cUSINES);
        }

        // POST: CUSINES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CUSINES cUSINES = db.CUSINEs.Find(id);
            db.CUSINEs.Remove(cUSINES);
            db.SaveChanges();
            return RedirectToAction("Index");
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
