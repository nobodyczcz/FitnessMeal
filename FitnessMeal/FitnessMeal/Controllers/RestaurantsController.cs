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
using System.Diagnostics;



namespace FitnessMeal.Controllers
{
    public class RestaurantsController : Controller
    {
        private FitnessMealModel db = new FitnessMealModel();

        // GET: Restaurants
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var id = User.Identity.GetUserId();
                var restaurants = db.Restaurants.Where(r=>r.USER_ID==id);
                return View(restaurants.ToList());
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // GET: Restaurants/Details/5
        public ActionResult Details(int? id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View("../Account/Login");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurants.Find(id);
            var userId = User.Identity.GetUserId();
            if (restaurant == null)
            {
                return HttpNotFound();
            }

            if (restaurant.USER_ID!=userId)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(restaurant);
        }

        // GET: Restaurants/Create
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                
                Restaurant newRes = new Restaurant();
                newRes.USER_ID = User.Identity.GetUserId();
                ViewBag.CUSINES = new SelectList(db.CUSINEs, "CUSINE", "CUSINE");
                return View(newRes);

            }
            else
            {
                return View("../Account/Login");
            }
            
        }

        // POST: Restaurants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            var errors = ModelState
    .Where(x => x.Value.Errors.Count > 0)
    .Select(x => new { x.Key, x.Value.Errors })
    .ToArray();

            Debug.WriteLine("data received: " + restaurant.RESTAURANT_ID+" id: "+restaurant.USER_ID);

            Debug.WriteLine("error : " + errors);

            if (ModelState.IsValid)
            {
                db.Restaurants.Add(restaurant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CUSINES = new SelectList(db.CUSINEs, "CUSINE", "CUSINE", restaurant.Main_CUSINE);
            return View(restaurant);
        }

        // GET: Restaurants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            ViewBag.USER_ID = new SelectList(db.USERs, "USER_ID", "USERNAME", restaurant.USER_ID);
            return View(restaurant);
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RESTAURANT_ID,RESTAURANT_NAME,DESCRIPTION,Main_CUSINE,USER_ID,ADRESS_FIRST_LINE,STREET_NO,STREET_RD,SURBURB,POSTCODE,STATE")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.USER_ID = new SelectList(db.USERs, "USER_ID", "USERNAME", restaurant.USER_ID);
            return View(restaurant);
        }

        // GET: Restaurants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            db.Restaurants.Remove(restaurant);
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
