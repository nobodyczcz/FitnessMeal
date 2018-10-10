namespace FitnessMeal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RESERVE_PICK_UP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RESERVE_PICK_UP()
        {
            ORDER_ITEM = new HashSet<ORDER_ITEM>();
            ORDER_MEAL = new HashSet<ORDER_MEAL>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ORDER_ID { get; set; }

        [Required]
        [StringLength(128)]
        public string USER_ID { get; set; }

        [Required]
        public int RESTAURANT_ID { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime ORDER_TIME { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime PICK_UP_TIME { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ORDER_PRICE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? NO_OF_EATER { get; set; }

        [Column(TypeName = "numeric")]
        public decimal TOTAL_ENERGY { get; set; }

        [StringLength(20)]
        public string STATE { get; set; }

        public string REMARKS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER_ITEM> ORDER_ITEM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER_MEAL> ORDER_MEAL { get; set; }

        public virtual Restaurant Restaurant { get; set; }

        public virtual USER USER { get; set; }
    }
}
