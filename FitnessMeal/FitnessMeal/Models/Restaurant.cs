namespace FitnessMeal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Restaurant")]
    public partial class Restaurant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Restaurant()
        {
            FOOD_ITEM = new HashSet<FOOD_ITEM>();
            RESERVE_PICK_UP = new HashSet<RESERVE_PICK_UP>();
            MEAL = new HashSet<MEAL>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RESTAURANT_ID { get; set; }

        [Required]
        public string RESTAURANT_NAME { get; set; }

        public string DESCRIPTION { get; set; }

        [Required]
        [StringLength(20)]
        [ForeignKey("CUSINES")]
        public string Main_CUSINE { get; set; }

        [Required]
        [StringLength(128)]
        public string USER_ID { get; set; }

        public string ADRESS_FIRST_LINE { get; set; }

        [Required]
        [StringLength(10)]
        public string STREET_NO { get; set; }

        [Column("STREET_RD")]
        [Required]
        [StringLength(50)]
        public string STREET_RD { get; set; }

        [Required]
        [StringLength(50)]
        public string SURBURB { get; set; }
        
        [Required]
        public int POSTCODE { get; set; }

        [Required]
        [StringLength(10)]
        public string STATE { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:0.00000000000}", ApplyFormatInEditMode = true)]
        public double LATITUDE { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:0.00000000000}", ApplyFormatInEditMode = true)]
        public double LONGITUDE { get; set; }

        public double? SCORE { get; set; }

        public double? DISTANCE { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "hh:mm tt", ApplyFormatInEditMode = true)]
        public TimeSpan? OPENTIME { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "hh:mm tt", ApplyFormatInEditMode = true)]
        public TimeSpan? CLOSETIME { get; set; }



        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FOOD_ITEM> FOOD_ITEM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RESERVE_PICK_UP> RESERVE_PICK_UP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MEAL> MEAL { get; set; }




        public virtual USER USER { get; set; }
        public virtual CUSINES CUSINES { get; set; }
    }
}
