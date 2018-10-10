using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FitnessMeal.Models;
using Microsoft.AspNet.Identity;


namespace FitnessMeal.Controllers
{
    public class SearchController : Controller
    {
        private FitnessMealModel db = new FitnessMealModel();

        // POST: Search/searchRestaurant
        [HttpPost]
        public ActionResult searchRestaurant(Search keywords)
        {
            try
            {
                if (keywords.keywords == "")
                {
                    double lat = keywords.lat;
                    double lng = keywords.lng;
                    IEnumerable<Restaurant> results;
                    if (keywords.range == 1)
                    {
                        var latRange = rangeLat(lat,1);
                        var lngRange = rangeLng(lng,2);
                        results = db.Restaurants.SqlQuery("Select * from Restaurants where latitude <="+
                            latRange[1]+" and latitude >="+latRange[0]+" and longtitude <="+lngRange[1]+
                            " and longtitude >="+lngRange[0]+";" );
                    }
                    else if (keywords.range == 3)
                    {
                        var latRange = rangeLat(lat, 3);
                        var lngRange = rangeLng(lng, 3);
                        results = db.Restaurants.SqlQuery("Select * from Restaurants where latitude <=" +
                            latRange[1] + " and latitude >=" + latRange[0] + " and longtitude <=" + lngRange[1] +
                            " and longtitude >=" + lngRange[0] + ";");
                    }
                    else if (keywords.range == 5)
                    {
                        var latRange = rangeLat(lat, 5);
                        var lngRange = rangeLng(lng, 5);
                        results = db.Restaurants.SqlQuery("Select * from Restaurants where latitude <=" +
                            latRange[1] + " and latitude >=" + latRange[0] + " and longtitude <=" + lngRange[1] +
                            " and longtitude >=" + lngRange[0] + ";");
                    }
                    else
                    {
                        var latRange = rangeLat(lat, 10);
                        var lngRange = rangeLng(lng, 10);
                        results = db.Restaurants.SqlQuery("Select * from Restaurants where latitude <=" +
                            latRange[1] + " and latitude >=" + latRange[0] + " and longtitude <=" + lngRange[1] +
                            " and longtitude >=" + lngRange[0] + ";");
                    }

                    foreach (var i in results)
                    {
                        i.DISTANCE = distance(lat, lng, (double)i.LATITUDE, (double)i.LONGITUDE, 'K');
                        
                    }
                    

                    
                }
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private double[] rangeLat(double lat,double range)
        {
            double latRange = range / 110.574;
            double minLat = lat - latRange;
            double maxLat = lat + latRange;
            double[] result = { minLat, maxLat };
            return result;
        }
        private double[] rangeLng(double lng,double range)
        {
            double lngRange = range / 110.574;
            double minLng = lng - lngRange;
            double maxLng = lng + lngRange;
            double[] result = { minLng, maxLng };
            return result;
        }

        private double distance(double lat1, double lon1, double lat2, double lon2, char unit)
        {
            //:::           where: 'M' is statute miles (default)                         :::
            //:::                  'K' is kilometers                                      :::
            //:::                  'N' is nautical miles
            double theta = lon1 - lon2;
            double dist = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta));
            dist = Math.Acos(dist);
            dist = rad2deg(dist);
            dist = dist * 60 * 1.1515;
            if (unit == 'K')
            {
                dist = dist * 1.609344;
            }
            else if (unit == 'N')
            {
                dist = dist * 0.8684;
            }
            return (dist);
        }

        private double deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        private double rad2deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }

    }
}
