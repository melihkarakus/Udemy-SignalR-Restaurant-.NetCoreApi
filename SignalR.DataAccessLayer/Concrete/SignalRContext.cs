using Microsoft.EntityFrameworkCore;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Concrete
{
    public class SignalRContext : DbContext
    {
        //Database Bağlantı Konfigrasyonu
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Database Bağlantısı
            optionsBuilder.UseSqlServer("server=LAPTOP-VLOIQ6M3\\SQLEXPRESS;initial Catalog=SignalRDb;integrated security=true");
        }
        //Database Tabloları
        public DbSet<About> Abouts { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
