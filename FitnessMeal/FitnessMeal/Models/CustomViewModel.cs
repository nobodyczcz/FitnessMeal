using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessMeal.Models
{
    public class CustomViewModel
    {
        public RegisterViewModel RegisterViewModel { get; set; }
        public USER USER { get; set; }
    }
    public class mealAndItem
    {
        public MEAL MEAL { get; set; }
        public IEnumerable<FitnessMeal.Models.MEAL_ITEMS> MEAL_ITEM_List { get; set; }

    }

    public class ItemAndDetail
    {
        public int itemID { get; set; }
        public string itemName { get; set; }
        public decimal price { get; set; }
        public decimal quantity { get; set; }

    }

    public class OrderAndItem
    {
        
        public int orderID { get; set; }
        public DateTime OrderTime { get; set; }
        public DateTime PickTime { get; set; }
        public decimal totalPrice { get; set; }
        public string state { get; set; }
        public List<ItemAndDetail> items { get; set; }
    }

    public class RestaurantAndOrder
    {
        public List<FitnessMeal.Models.OrderAndItem>  orderAndItem { get; set; }
        public int restaurantID { get; set; }
        public string restaurantName { get; set; }
    }

    public class JsonData
    {
        public string data { get; set; }
    }


}