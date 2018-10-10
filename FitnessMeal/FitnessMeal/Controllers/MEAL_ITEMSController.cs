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
    public class MEAL_ITEMSController : Controller
    {
        private FitnessMealModel db = new FitnessMealModel();

        // GET: MEAL_ITEMS
        public ActionResult Index()
        {
            var mEAL_ITEMS = db.MEAL_ITEMS.Include(m => m.FOOD_ITEM).Include(m => m.MEAL);
            return View(mEAL_ITEMS.ToList());
        }

        // GET: MEAL_ITEMS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEAL_ITEMS mEAL_ITEMS = db.MEAL_ITEMS.Find(id);
            if (mEAL_ITEMS == null)
            {
                return HttpNotFound();
            }
            return View(mEAL_ITEMS);
        }

        // GET: MEAL_ITEMS/Create
        public ActionResult Create()
        {
            ViewBag.ITEM_ID = new SelectList(db.FOOD_ITEM, "ITEM_ID", "ITEM_NAME");
            ViewBag.MEAL_ID = new SelectList(db.MEALs, "MEAL_ID", "MEAL_ID");
            return View();
        }

        // POST: MEAL_ITEMS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MEAL_ID,ITEM_ID")] MEAL_ITEMS mEAL_ITEMS)
        {
            if (ModelState.IsValid)
            {
                db.MEAL_ITEMS.Add(mEAL_ITEMS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ITEM_ID = new SelectList(db.FOOD_ITEM, "ITEM_ID", "ITEM_NAME", mEAL_ITEMS.ITEM_ID);
            ViewBag.MEAL_ID = new SelectList(db.MEALs, "MEAL_ID", "MEAL_ID", mEAL_ITEMS.MEAL_ID);
            return View(mEAL_ITEMS);
        }

        // GET: MEAL_ITEMS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEAL_ITEMS mEAL_ITEMS = db.MEAL_ITEMS.Find(id);
            if (mEAL_ITEMS == null)
            {
                return HttpNotFound();
            }
            ViewBag.ITEM_ID = new SelectList(db.FOOD_ITEM, "ITEM_ID", "ITEM_NAME", mEAL_ITEMS.ITEM_ID);
            ViewBag.MEAL_ID = new SelectList(db.MEALs, "MEAL_ID", "MEAL_ID", mEAL_ITEMS.MEAL_ID);
            return View(mEAL_ITEMS);
        }

        // POST: MEAL_ITEMS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MEAL_ID,ITEM_ID")] MEAL_ITEMS mEAL_ITEMS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mEAL_ITEMS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ITEM_ID = new SelectList(db.FOOD_ITEM, "ITEM_ID", "ITEM_NAME", mEAL_ITEMS.ITEM_ID);
            ViewBag.MEAL_ID = new SelectList(db.MEALs, "MEAL_ID", "MEAL_ID", mEAL_ITEMS.MEAL_ID);
            return View(mEAL_ITEMS);
        }

        // GET: MEAL_ITEMS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEAL_ITEMS mEAL_ITEMS = db.MEAL_ITEMS.Find(id);
            if (mEAL_ITEMS == null)
            {
                return HttpNotFound();
            }
            return View(mEAL_ITEMS);
        }

        // POST: MEAL_ITEMS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int meal_id,int item_id)
        {
            MEAL_ITEMS mEAL_ITEMS = db.MEAL_ITEMS.Find(meal_id,item_id);
            db.MEAL_ITEMS.Remove(mEAL_ITEMS);
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
