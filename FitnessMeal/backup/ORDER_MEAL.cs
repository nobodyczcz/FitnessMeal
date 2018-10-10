namespace FitnessMeal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ORDER_MEAL
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ORDER_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        public int MEAL_ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal QUANTITY { get; set; }

        [Column(TypeName = "numeric")]
        public decimal TOTAL_PRICE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal TOTAL_ENERGY { get; set; }

        public virtual MEAL MEAL { get; set; }

        public virtual RESERVE_PICK_UP RESERVE_PICK_UP { get; set; }
    }
}
