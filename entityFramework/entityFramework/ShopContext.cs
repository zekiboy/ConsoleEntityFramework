using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entityFramework
{
    public class ShopContext : DbContext
    {
        //Context olacak class'ın sonunda bunu belirt, program otomatik algılıyo böylece
        //ShopContext veritabanının tuttuğumuz sınıf
        //DbContext entity framework ile hazır gelen bir sınıf, içerisinde database oluşturma ve yönetme komutları yer alıyor
        //Önceki örneklerde uzun uzun yazdığımız komutları burada kalıtım alarak doğrudan hallediyoruz.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlite("DataSource=ShopDB.db");
            //ShopDB.db sqlite'ta oluşturduğumuz database'in adı

            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-4APHPR6\SQLEXPRESS; Initial Catalog=ShopDB; Integrated Security=SSPI; TrustServerCertificate=True;");
            /*sqlite bağlantısını kesip msSql bğlantısı kurduk. bu satırı yazdıktan sonra sağdaki toolbardan Migration klasörünü sildik ve sonrasında 
            * dotnet ef migrations add InitialCreate  dizisini terminalde tekrar çalıştırarak yeni bir migration yükledik
             *Bu learn.microsoftdan çalıştırdığımız 4 satırlık Create the database kod dizisinin üçüncüsü
             dotnet ef database update (4.satır) çalıştırdık*/
        }

        public DbSet<Customers> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        //Employee  sınıfında bulunan bir DbSet oluştur. Buna Employees adını ver
        //DbSet'i tablo oluşturma komutu olarak düşünebilirsin
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        //Fluent API ile ProductCategory tablosunun özelliklerini belirliyoruz
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>()
                .HasKey(k => new { k.ProductProductId, k.CategoryCategoryId });
            //.HasKey data annotatıondaki [Key] karşılığı
            //ProductProductId ve CategoryCategoryId kombinasyonuyla bir primary key oluşturduk

            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.ProductCategories)
                //producttan aldığım bir değer ProductCategories tablosunda bir çok kez kullanılabilir
                .HasForeignKey(pc => pc.ProductProductId);
                //ProductProductId foreignKey olarak tutulsun

            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Category)
                .WithMany(c => c.ProductCategories)
                //category'den aldığım bir değer ProductCategories tablosunda bir çok kez kullanılabilir
                .HasForeignKey(pc => pc.CategoryCategoryId);
            //CategoryCategoryId foreignKey olarak tutulsun

            /* modelBuilder.Entity<Product>()
                 .ToTable("Ürünler");
            veri tabanında tablonun adını Ürünler olarak tutar. Fluent API olarak
            */
        }
        //Many to many aslında çapraz bir şekilde iki tane one to many oluşturmak gibi


    }

}
/*HAZIR VERI TABANI CEKME
 dotnet ef dbcontext scaffold
"Data Source=DESKTOP-4APHPR6\SQLEXPRESS; Initial Catalog=calisma; Integrated Security=SSPI; TrustServerCertificate=True;" 
Microsoft.EntityFrameworkCore.SqlServer --output-dir "Data/DBFirst" --context "DBFirstContext"

 */