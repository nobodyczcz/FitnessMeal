namespace FitnessMeal.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class OrderData
    {
        public int[] itemIDs;
        public string pickTime;
        public string orderTime;
        public int restaurantID;
        public decimal totalPrice;
        public decimal totalEnergy;
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}