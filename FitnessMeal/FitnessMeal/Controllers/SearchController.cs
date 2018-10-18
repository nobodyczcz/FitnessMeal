using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FitnessMeal.Models;
using Microsoft.AspNet.Identity;
using System.Diagnostics;


namespace FitnessMeal.Controllers
{
    public class SearchController : Controller
    {
        private FitnessMealModel db = new FitnessMealModel();

        // POST: Search/searchRestaurant
        [HttpPost]
        public ActionResult searchRestaurant(string keywords,double theLat,double theLng,string theRange)
        {

            Debug.WriteLine(keywords);
            Debug.WriteLine(theLat);
            Debug.WriteLine(theLng);
            Debug.WriteLine(theRange);
                    double lat = theLat;
                    double lng = theLng;
                    IEnumerable<Restaurant> results;
                    var range = Convert.ToInt32(theRange);
                    if (range == 1)
                    {
                Debug.WriteLine("at 1");
                        var latRange = rangeLat(lat,1);
                        var lngRange = rangeLng(lng,1);
                        results = db.Restaurants.SqlQuery("Select * from Restaurant where latitude <="+
                            latRange[1]+" and latitude >="+latRange[0]+" and longitude <="+lngRange[1]+
                            " and longitude >="+lngRange[0]+";" );
                    }
                    else if (range == 3)
                    {
                Debug.WriteLine("at 3");
                var latRange = rangeLat(lat, 3);
                        var lngRange = rangeLng(lng, 3);
                        results = db.Restaurants.SqlQuery("Select * from Restaurant where latitude <=" +
                            latRange[1] + " and latitude >=" + latRange[0] + " and longitude <=" + lngRange[1] +
                            " and longitude >=" + lngRange[0] + ";");
                    }
                    else if (range == 5)
                    {
                Debug.WriteLine("at 5");
                var latRange = rangeLat(lat, 5);
                        var lngRange = rangeLng(lng, 5);
                        results = db.Restaurants.SqlQuery("Select * from Restaurant where latitude <=" +
                            latRange[1] + " and latitude >=" + latRange[0] + " and longitude <=" + lngRange[1] +
                            " and longitude >=" + lngRange[0] + ";");
                    }
                    else
                    {
                Debug.WriteLine("at other");
                var latRange = rangeLat(lat, 10);
                        var lngRange = rangeLng(lng, 10);
                        results = db.Restaurants.SqlQuery("Select * from Restaurant where latitude <=" +
                            latRange[1] + " and latitude >=" + latRange[0] + " and longitude <=" + lngRange[1] +
                            " and longitude >=" + lngRange[0] + ";");
                    }

                foreach (var i in results)
                {
                    i.DISTANCE = Math.Round(distance(lat, lng, (double)i.LATITUDE, (double)i.LONGITUDE, 'K'),2);
                    i.SCORE = Convert.ToInt16((1 - i.DISTANCE / range)*100);

                }

                if (keywords.Trim()!="")
                {
                Debug.WriteLine("start check words");
                    var keywordsList = keywords.ToLower().Split(' ');
                    foreach (var i in results)
                    {
                        var score = 0;
                    var basewords = (i.DESCRIPTION + i.RESTAURANT_NAME).ToLower();
                        foreach (var x in keywordsList)
                        {
                            if (basewords.Contains(x))
                            {
                                score += 1;
                            }

                        }
                        i.SCORE += Convert.ToInt16((score / keywordsList.Length)*100);
                         Debug.WriteLine(i.SCORE);
                     }


                }

                results=results.OrderByDescending(m => m.SCORE);
                

                return PartialView("/Views/Home/_partialResult.cshtml",results);

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
