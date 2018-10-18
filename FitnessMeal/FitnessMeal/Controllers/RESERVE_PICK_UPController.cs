using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FitnessMeal.Models;
using Newtonsoft.Json;
using Microsoft.AspNet.Identity;
using System.Diagnostics;
using System.Globalization;

namespace FitnessMeal.Controllers
{
    public class RESERVE_PICK_UPController : Controller
    {
        private FitnessMealModel db = new FitnessMealModel();

        // GET: RESERVE_PICK_UP
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userid = User.Identity.GetUserId();
                var rESERVE_PICK_UP = db.RESERVE_PICK_UP.Where(r=>r.USER_ID ==userid).Include(r => r.Restaurant).Include(r => r.USER);
                return View(rESERVE_PICK_UP.ToList());
            }
            else
            {
                return View("/Views/Account/login.cshtml");
            }
                
        }

        // GET: RESERVE_PICK_UP/Restaurant
        public ActionResult Restaurant()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userid = User.Identity.GetUserId();
                var restaurants = db.Restaurants.Where(r => r.USER_ID == userid);
                List<RestaurantAndOrder> restaurantAndOrder= new List<RestaurantAndOrder>();

                foreach (var i in restaurants)
                {
                    var newRes = new RestaurantAndOrder();
                    newRes.orderAndItem = new List<FitnessMeal.Models.OrderAndItem>();
                    newRes.restaurantID = i.RESTAURANT_ID;
                    newRes.restaurantName = i.RESTAURANT_NAME;

                    var orders = db.RESERVE_PICK_UP.Where(r => r.RESTAURANT_ID == i.RESTAURANT_ID);
                     
                    foreach(var o in orders)
                    {
                        var newOrder = new OrderAndItem();
                        newOrder.orderID = o.ORDER_ID;
                        newOrder.OrderTime = o.ORDER_TIME;
                        newOrder.PickTime = o.PICK_UP_TIME;
                        newOrder.totalPrice = o.ORDER_PRICE;
                        newOrder.state = o.STATE;
                        newOrder.items = new List<ItemAndDetail>();
                        var orderItems = db.ORDER_ITEM.Where(r => r.ORDER_ID == o.ORDER_ID).ToList();
                        Debug.WriteLine("item 0 id: " + orderItems[0].ITEM_ID);
                        foreach (var it in orderItems)
                        {
                            Debug.WriteLine("item id: " + it.ITEM_ID);
                            var newItem = new ItemAndDetail();
                            newItem.itemID = it.ITEM_ID;
                            var theItem = db.FOOD_ITEM.Find(it.ITEM_ID);
                            if (theItem != null)
                            {
                                newItem.itemName = theItem.ITEM_NAME;
                                newItem.price = theItem.PRICE;
                                newItem.quantity = it.QUANTITY;
                                newOrder.items.Add(newItem);
                            }
                            
                        }
                        newRes.orderAndItem.Add(newOrder);
                    }
                    restaurantAndOrder.Add(newRes);
                }
                string json = JsonConvert.SerializeObject(restaurantAndOrder);
                var jsonData = new JsonData();
                jsonData.data = json;
                return View(jsonData);
            }
            else
            {
                return View("/Views/Account/login.cshtml");
            }

        }

        // GET: RESERVE_PICK_UP/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESERVE_PICK_UP rESERVE_PICK_UP = db.RESERVE_PICK_UP.Find(id);
            if (rESERVE_PICK_UP == null)
            {
                return HttpNotFound();
            }
            return View(rESERVE_PICK_UP);
        }

       

        // POST: RESERVE_PICK_UP/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string json)
        {
            Debug.WriteLine("receive json: "+json);
            if (User.Identity.IsAuthenticated)
            {
                var userID = User.Identity.GetUserId();
                var newOrder = new RESERVE_PICK_UP();
                OrderData data = JsonConvert.DeserializeObject<OrderData>(json);
                newOrder.PICK_UP_TIME = DateTime.ParseExact(data.pickTime, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                newOrder.ORDER_TIME = DateTime.ParseExact(data.orderTime, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                newOrder.RESTAURANT_ID = data.restaurantID;
                newOrder.ORDER_PRICE = data.totalPrice;
                newOrder.TOTAL_ENERGY = data.totalEnergy;
                newOrder.USER_ID = userID;
                newOrder.STATE = "waiting";
                db.RESERVE_PICK_UP.Add(newOrder);
                db.SaveChanges();
                var newID = newOrder.ORDER_ID;
                Dictionary<int, int> dic = new Dictionary<int, int>();
                foreach (int i in data.itemIDs)
                {
                    if (dic.ContainsKey(i))
                    {
                        dic[i] += 1;
                    }
                    else
                    {
                        dic.Add(i, 1);
                    }
                }

                    foreach (KeyValuePair<int, int> entry in dic)
                {
                    var newItem = new ORDER_ITEM();
                    newItem.ITEM_ID = entry.Key;
                    newItem.ORDER_ID = newID;
                    newItem.QUANTITY = entry.Value;
                    var theItem = db.FOOD_ITEM.Find(entry.Key);
                    newItem.TOTAL_PRICE = theItem.PRICE * entry.Value;
                    newItem.TOTAL_ENERGY = theItem.ENERGY * entry.Value;
                    db.ORDER_ITEM.Add(newItem);

                }
                db.SaveChanges();

                return Json(new { result = "success"});

            }
            else
            {
                return Json(new { result = "failed" });

            }


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeState(int id,string action)
        {
            var order = db.RESERVE_PICK_UP.Find(id);
            if (action=="confirm")
            {
                order.STATE = "confirmed";
            }
            else if (action == "refuse")
            {
                order.STATE = "refused";
            }
            else if (action == "ready")
            {
                order.STATE = "ready";
            }
            else if (action == "done")
            {
                order.STATE = "close";
            }
            db.Entry(order).State = EntityState.Modified;
            db.SaveChanges();

            return Json(new {result="success" });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeTime(int id, DateTime start,DateTime end)
        {
            var order = db.RESERVE_PICK_UP.Find(id);

            order.ORDER_TIME = start;
            order.PICK_UP_TIME = end;
            db.Entry(order).State = EntityState.Modified;
            db.SaveChanges();
            return Json(new { result = "success" });
        }

            // GET: RESERVE_PICK_UP/Edit/5
            public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESERVE_PICK_UP rESERVE_PICK_UP = db.RESERVE_PICK_UP.Find(id);
            if (rESERVE_PICK_UP == null)
            {
                return HttpNotFound();
            }
            ViewBag.RESTAURANT_ID = new SelectList(db.Restaurants, "RESTAURANT_ID", "RESTAURANT_NAME", rESERVE_PICK_UP.RESTAURANT_ID);
            ViewBag.USER_ID = new SelectList(db.USERs, "USER_ID", "USERNAME", rESERVE_PICK_UP.USER_ID);
            return View(rESERVE_PICK_UP);
        }

        // POST: RESERVE_PICK_UP/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ORDER_ID,USER_ID,RESTAURANT_ID,ORDER_TIME,PICK_UP_TIME,ORDER_PRICE,NO_OF_EATER,TOTAL_ENERGY,STATE,REMARKS")] RESERVE_PICK_UP rESERVE_PICK_UP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rESERVE_PICK_UP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RESTAURANT_ID = new SelectList(db.Restaurants, "RESTAURANT_ID", "RESTAURANT_NAME", rESERVE_PICK_UP.RESTAURANT_ID);
            ViewBag.USER_ID = new SelectList(db.USERs, "USER_ID", "USERNAME", rESERVE_PICK_UP.USER_ID);
            return View(rESERVE_PICK_UP);
        }

        // GET: RESERVE_PICK_UP/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESERVE_PICK_UP rESERVE_PICK_UP = db.RESERVE_PICK_UP.Find(id);
            if (rESERVE_PICK_UP == null)
            {
                return HttpNotFound();
            }
            return View(rESERVE_PICK_UP);
        }

        // POST: RESERVE_PICK_UP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RESERVE_PICK_UP rESERVE_PICK_UP = db.RESERVE_PICK_UP.Find(id);
            db.RESERVE_PICK_UP.Remove(rESERVE_PICK_UP);
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
