namespace FitnessMeal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ORDER_ITEM
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ORDER_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        public int ITEM_ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal QUANTITY { get; set; }

        [Column(TypeName = "numeric")]
        public decimal TOTAL_PRICE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal TOTAL_ENERGY { get; set; }

        public virtual FOOD_ITEM FOOD_ITEM { get; set; }

        public virtual RESERVE_PICK_UP RESERVE_PICK_UP { get; set; }
    }
}
