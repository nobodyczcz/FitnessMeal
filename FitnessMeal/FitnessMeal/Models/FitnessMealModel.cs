namespace FitnessMeal.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FitnessMealModel : DbContext
    {
        public FitnessMealModel()
            : base("name=FitnessModel")
        {
        }

        public virtual DbSet<FOOD_ITEM> FOOD_ITEM { get; set; }
        public virtual DbSet<MEAL> MEALs { get; set; }
        public virtual DbSet<ORDER_ITEM> ORDER_ITEM { get; set; }
        public virtual DbSet<ORDER_MEAL> ORDER_MEAL { get; set; }
        public virtual DbSet<RESERVE_PICK_UP> RESERVE_PICK_UP { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<USER> USERs { get; set; }
        public virtual DbSet<CUSINES> CUSINEs { get; set; }
        public virtual DbSet<MEAL_ITEMS> MEAL_ITEMS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FOOD_ITEM>()
                .Property(e => e.ENERGY)
                .HasPrecision(10, 0);

            modelBuilder.Entity<FOOD_ITEM>()
                .Property(e => e.PRICE)
                .HasPrecision(10, 2);

            modelBuilder.Entity<FOOD_ITEM>()
                .Property(e => e.IS_DRINK)
                .IsUnicode(false);

            modelBuilder.Entity<FOOD_ITEM>()
                .Property(e => e.IS_PURE_VEGI)
                .IsUnicode(false);

            modelBuilder.Entity<FOOD_ITEM>()
                .Property(e => e.HAS_BEEF)
                .IsUnicode(false);

            modelBuilder.Entity<FOOD_ITEM>()
                .Property(e => e.HAS_PORK)
                .IsUnicode(false);

            modelBuilder.Entity<FOOD_ITEM>()
                .Property(e => e.HAS_OTHERMEAT)
                .IsUnicode(false);

            modelBuilder.Entity<FOOD_ITEM>()
                .Property(e => e.HAS_CHICKEN)
                .IsUnicode(false);

            modelBuilder.Entity<FOOD_ITEM>()
                .Property(e => e.HAS_EGG)
                .IsUnicode(false);

            modelBuilder.Entity<FOOD_ITEM>()
                .Property(e => e.HAS_MILK)
                .IsUnicode(false);

            modelBuilder.Entity<FOOD_ITEM>()
                .Property(e => e.HAS_NUTS)
                .IsUnicode(false);

            modelBuilder.Entity<FOOD_ITEM>()
                .Property(e => e.HAS_VEGI)
                .IsUnicode(false);

            modelBuilder.Entity<FOOD_ITEM>()
                .Property(e => e.HAS_FRUIT)
                .IsUnicode(false);

            modelBuilder.Entity<FOOD_ITEM>()
                .Property(e => e.HAS_RICE)
                .IsUnicode(false);

            modelBuilder.Entity<FOOD_ITEM>()
                .HasMany(e => e.ORDER_ITEM)
                .WithRequired(e => e.FOOD_ITEM)
                .WillCascadeOnDelete(false);

            
            modelBuilder.Entity<MEAL>()
                .Property(e => e.TOTAL_PRICE)
                .HasPrecision(10, 2);

            modelBuilder.Entity<MEAL>()
                .Property(e => e.TOTAL_ENERGY)
                .HasPrecision(10, 0);

            modelBuilder.Entity<MEAL>()
                .Property(e => e.DISCOUNT)
                .HasPrecision(3, 2);

            modelBuilder.Entity<MEAL>()
                .HasMany(e => e.ORDER_MEAL)
                .WithRequired(e => e.MEAL)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ORDER_ITEM>()
                .Property(e => e.QUANTITY)
                .HasPrecision(2, 0);

            modelBuilder.Entity<ORDER_ITEM>()
                .Property(e => e.TOTAL_PRICE)
                .HasPrecision(10, 0);

            modelBuilder.Entity<ORDER_ITEM>()
                .Property(e => e.TOTAL_ENERGY)
                .HasPrecision(10, 0);

            modelBuilder.Entity<ORDER_MEAL>()
                .Property(e => e.QUANTITY)
                .HasPrecision(2, 0);

            modelBuilder.Entity<ORDER_MEAL>()
                .Property(e => e.TOTAL_PRICE)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ORDER_MEAL>()
                .Property(e => e.TOTAL_ENERGY)
                .HasPrecision(10, 0);

            modelBuilder.Entity<RESERVE_PICK_UP>()
                .Property(e => e.ORDER_PRICE)
                .HasPrecision(10, 2);

            modelBuilder.Entity<RESERVE_PICK_UP>()
                .Property(e => e.NO_OF_EATER)
                .HasPrecision(2, 0);

            modelBuilder.Entity<RESERVE_PICK_UP>()
                .Property(e => e.TOTAL_ENERGY)
                .HasPrecision(10, 0);

            modelBuilder.Entity<RESERVE_PICK_UP>()
                .HasMany(e => e.ORDER_ITEM)
                .WithRequired(e => e.RESERVE_PICK_UP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RESERVE_PICK_UP>()
                .HasMany(e => e.ORDER_MEAL)
                .WithRequired(e => e.RESERVE_PICK_UP)
                .WillCascadeOnDelete(false);





            modelBuilder.Entity<Restaurant>()
                .HasMany(e => e.FOOD_ITEM)
                .WithRequired(e => e.Restaurant)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Restaurant>()
                .HasMany(e => e.RESERVE_PICK_UP)
                .WithRequired(e => e.Restaurant)
                .WillCascadeOnDelete(false);



            modelBuilder.Entity<USER>()
                .HasMany(e => e.RESERVE_PICK_UP)
                .WithRequired(e => e.USER)
                .WillCascadeOnDelete(false);



            modelBuilder.Entity<USER>()
                .HasMany(e => e.Restaurants)
                .WithRequired(e => e.USER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CUSINES>()
                .HasMany(e => e.Restaurants)
                .WithRequired(e => e.CUSINES)
                .WillCascadeOnDelete(false);
        }
    }
}
