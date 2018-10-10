namespace FitnessMeal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MEAL")]
    public partial class MEAL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MEAL()
        {
            ORDER_MEAL = new HashSet<ORDER_MEAL>();
            FOOD_ITEM = new HashSet<FOOD_ITEM>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MEAL_ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal TOTAL_PRICE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal TOTAL_ENERGY { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? DISCOUNT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER_MEAL> ORDER_MEAL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FOOD_ITEM> FOOD_ITEM { get; set; }
    }
}
