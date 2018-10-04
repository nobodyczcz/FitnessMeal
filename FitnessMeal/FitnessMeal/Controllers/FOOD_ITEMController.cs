﻿using System;
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
    public class FOOD_ITEMController : Controller
    {
        private FitnessMealModel db = new FitnessMealModel();

        // GET: FOOD_ITEM/RESTAURANT_ID
        public ActionResult Index(int? id)
        {
            if (User.Identity.IsAuthenticated && db.Restaurants.Find(id).USER_ID == User.Identity.GetUserId())
            {
                
                var fOOD_ITEM = db.FOOD_ITEM.Where(r => r.RESTAURANT_ID == id);
                return View(fOOD_ITEM.ToList());
            }
            else
            {
                return HttpNotFound();
            }
        }

        // GET: FOOD_ITEM/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FOOD_ITEM fOOD_ITEM = db.FOOD_ITEM.Find(id);
            if (fOOD_ITEM == null)
            {
                return HttpNotFound();
            }
            return View(fOOD_ITEM);
        }

        // GET: FOOD_ITEM/Create
        public ActionResult Create()
        {
            ViewBag.RESTAURANT_ID = new SelectList(db.Restaurants, "RESTAURANT_ID", "RESTAURANT_NAME");
            return View();
        }

        // POST: FOOD_ITEM/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ITEM_ID,RESTAURANT_ID,ITEM_NAME,DESCRIPTION,CUISINE,ENERGY,PRICE,IS_DRINK,IS_PURE_VEGI,HAS_BEEF,HAS_PORK,HAS_OTHERMEAT,HAS_CHICKEN,HAS_EGG,HAS_MILK,HAS_NUTS,HAS_VEGI,HAS_FRUIT,HAS_RICE")] FOOD_ITEM fOOD_ITEM)
        {
            if (ModelState.IsValid)
            {
                db.FOOD_ITEM.Add(fOOD_ITEM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RESTAURANT_ID = new SelectList(db.Restaurants, "RESTAURANT_ID", "RESTAURANT_NAME", fOOD_ITEM.RESTAURANT_ID);
            return View(fOOD_ITEM);
        }

        // GET: FOOD_ITEM/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FOOD_ITEM fOOD_ITEM = db.FOOD_ITEM.Find(id);
            if (fOOD_ITEM == null)
            {
                return HttpNotFound();
            }
            ViewBag.RESTAURANT_ID = new SelectList(db.Restaurants, "RESTAURANT_ID", "RESTAURANT_NAME", fOOD_ITEM.RESTAURANT_ID);
            return View(fOOD_ITEM);
        }

        // POST: FOOD_ITEM/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ITEM_ID,RESTAURANT_ID,ITEM_NAME,DESCRIPTION,CUISINE,ENERGY,PRICE,IS_DRINK,IS_PURE_VEGI,HAS_BEEF,HAS_PORK,HAS_OTHERMEAT,HAS_CHICKEN,HAS_EGG,HAS_MILK,HAS_NUTS,HAS_VEGI,HAS_FRUIT,HAS_RICE")] FOOD_ITEM fOOD_ITEM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fOOD_ITEM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RESTAURANT_ID = new SelectList(db.Restaurants, "RESTAURANT_ID", "RESTAURANT_NAME", fOOD_ITEM.RESTAURANT_ID);
            return View(fOOD_ITEM);
        }

        // GET: FOOD_ITEM/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FOOD_ITEM fOOD_ITEM = db.FOOD_ITEM.Find(id);
            if (fOOD_ITEM == null)
            {
                return HttpNotFound();
            }
            return View(fOOD_ITEM);
        }

        // POST: FOOD_ITEM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FOOD_ITEM fOOD_ITEM = db.FOOD_ITEM.Find(id);
            db.FOOD_ITEM.Remove(fOOD_ITEM);
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