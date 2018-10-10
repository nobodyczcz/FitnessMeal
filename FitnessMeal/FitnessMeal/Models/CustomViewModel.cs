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

    public class Search
    {
        public string keywords { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public int range { get; set; }
    }
}