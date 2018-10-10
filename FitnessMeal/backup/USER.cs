namespace FitnessMeal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USER")]
    public partial class USER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USER()
        {
            RESERVE_PICK_UP = new HashSet<RESERVE_PICK_UP>();
            Restaurants = new HashSet<Restaurant>();
        }

        [Key]
        public string USER_ID { get; set; }

        [Required]
        [StringLength(20)]
        public string USERNAME { get; set; }

        public string EMAIL { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DOB { get; set; }

        public string DESCRIPTION { get; set; }

        [StringLength(20)]
        public string User_Type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RESERVE_PICK_UP> RESERVE_PICK_UP { get; set; }

        

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
    
}
