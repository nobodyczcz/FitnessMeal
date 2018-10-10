namespace FitnessMeal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CUSINES")]
    public partial class CUSINES
    {
        public CUSINES()
        {
            Restaurants = new HashSet<Restaurant>();
        }

        [Key]
        [StringLength(20)]
        public string CUSINE { get; set; }

        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
}
