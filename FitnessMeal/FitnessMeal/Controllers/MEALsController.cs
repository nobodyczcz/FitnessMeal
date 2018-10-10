using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FitnessMeal.Models;
using Microsoft.AspNet.Identity;

namespace FitnessMeal.Controllers
{
    public class MEALsController : Controller
    {
        private FitnessMealModel db = new FitnessMealModel();

        // GET: MEALs
        public ActionResult Index()
        {
            return View(db.MEALs.ToList());
        }

        // GET: MEALs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEAL mEAL = db.MEALs.Find(id);
            if (mEAL == null)
            {
                return HttpNotFound();
            }
            return View(mEAL);
        }

        // GET: MEALs/Create/RestaurantID
        public ActionResult Create(int? id)
        {
            
            if(id!= null && User.Identity.IsAuthenticated && db.Restaurants.Find(id).USER_ID == User.Identity.GetUserId())
            {
                MEAL newMeal = new MEAL();
                newMeal.RESTAURANT_ID = id.Value;
                newMeal.TOTAL_ENERGY = 0;
                newMeal.TOTAL_PRICE = 0;
                newMeal.DISCOUNT = 1;
                return View(newMeal);
            }
            return HttpNotFound();
            
        }

        // POST: MEALs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MEAL mEAL)
        {
            if (ModelState.IsValid)
            {
                db.MEALs.Add(mEAL);
                db.SaveChanges();
                return RedirectToAction("Edit/"+ mEAL.MEAL_ID);
            }

            return View(mEAL);
        }

        // GET: MEALs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null || !User.Identity.IsAuthenticated)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var all = new mealAndItem();
            all.MEAL = db.MEALs.Find(id);
            
            if (all.MEAL == null)
            {
                return HttpNotFound();
            }
            
            all.MEAL_ITEM_List = db.MEAL_ITEMS.Where(m => m.MEAL_ID == id).Include(m => m.FOOD_ITEM).Include(m => m.MEAL).ToList();
            ViewBag.ITEM_ID = new SelectList(db.FOOD_ITEM, "ITEM_ID", "ITEM_NAME");
            return View(all);
        }

        // POST: MEALs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MEAL_ID,TOTAL_PRICE,TOTAL_ENERGY,DISCOUNT")] MEAL mEAL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mEAL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mEAL);
        }

        // GET: MEALs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEAL mEAL = db.MEALs.Find(id);
            if (mEAL == null)
            {
                return HttpNotFound();
            }
            return View(mEAL);
        }

        // POST: MEALs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MEAL mEAL = db.MEALs.Find(id);
            db.MEALs.Remove(mEAL);
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
