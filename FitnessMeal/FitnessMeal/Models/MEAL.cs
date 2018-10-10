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
            MEAL_ITEMS = new HashSet<MEAL_ITEMS>();
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

        public int RESTAURANT_ID { get; set; }

        [Required]
        [StringLength(20)]
        public string MEAL_NAME { get; set; }

        public string DESCRIPTION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER_MEAL> ORDER_MEAL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MEAL_ITEMS> MEAL_ITEMS { get; set; }

        public virtual Restaurant Restaurant { get; set; }

    }
}
