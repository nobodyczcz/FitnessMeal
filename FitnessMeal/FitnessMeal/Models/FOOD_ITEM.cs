namespace FitnessMeal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FOOD_ITEM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FOOD_ITEM()
        {
            ORDER_ITEM = new HashSet<ORDER_ITEM>();
            MEAL_ITEMS = new HashSet<MEAL_ITEMS>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ITEM_ID { get; set; }

        [Required]
        public int RESTAURANT_ID { get; set; }

        [Required]
        [StringLength(20)]
        public string ITEM_NAME { get; set; }

        [Required]
        public string DESCRIPTION { get; set; }

        [Required]
        [StringLength(20)]
        public string CUISINE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ENERGY { get; set; }

        [Column(TypeName = "numeric")]
        public decimal PRICE { get; set; }

        [Required]
        [StringLength(2)]
        public string IS_DRINK { get; set; }

        [Required]
        [StringLength(2)]
        public string IS_PURE_VEGI { get; set; }

        [Required]
        [StringLength(2)]
        public string HAS_BEEF { get; set; }

        [Required]
        [StringLength(2)]
        public string HAS_PORK { get; set; }

        [Required]
        [StringLength(2)]
        public string HAS_OTHERMEAT { get; set; }

        [Required]
        [StringLength(2)]
        public string HAS_CHICKEN { get; set; }

        [Required]
        [StringLength(2)]
        public string HAS_EGG { get; set; }

        [Required]
        [StringLength(2)]
        public string HAS_MILK { get; set; }

        [Required]
        [StringLength(2)]
        public string HAS_NUTS { get; set; }

        [Required]
        [StringLength(2)]
        public string HAS_VEGI { get; set; }

        [Required]
        [StringLength(2)]
        public string HAS_FRUIT { get; set; }

        [Required]
        [StringLength(2)]
        public string HAS_RICE { get; set; }

        public virtual Restaurant Restaurant { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER_ITEM> ORDER_ITEM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MEAL_ITEMS> MEAL_ITEMS { get; set; }

    }
}
