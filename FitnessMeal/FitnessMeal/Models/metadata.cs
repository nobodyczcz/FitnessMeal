using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace FitnessMeal.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel.DataAnnotations.Schema;


    public class MealMetadata
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MEAL_ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal TOTAL_PRICE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal TOTAL_ENERGY { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? DISCOUNT { get; set; }
    }

    public class UserMetadata
    {
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
    }

    public class RestaurantMetadata
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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

        [Column("STREET/RD")]
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
        [Column(TypeName = "numeric")]
        public decimal latitude { get; set; }

        [Required]
        [Column(TypeName = "numeric")]
        public decimal longitude { get; set; }
    }

    public class ReserveMetadata
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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
    }

    public class OrderMealMetadata
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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

    }

    public class OrderItemMetadata
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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

    }

    public class FoodItemMetadata
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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
    }

    public class CusineMetadata
    {
        [Key]
        [StringLength(20)]
        public string CUSINE { get; set; }
    }
}