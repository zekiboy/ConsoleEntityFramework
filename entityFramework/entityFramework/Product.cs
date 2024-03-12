using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entityFramework
{
    // [NotMapped] yaparsak burayı veritabanında tabloyu oluşturmuyor, sadece programın içinde tutuyor
    //[Table("Ürünler")] veri tabanında tablonun adını Ürünler olarak tutar. Data Annotations olarak
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public List<ProductCategory>ProductCategories { get; set; }
    }
}
