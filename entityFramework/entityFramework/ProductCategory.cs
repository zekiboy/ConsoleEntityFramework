using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entityFramework
{
    public class ProductCategory
    {
        //Many to many bağlantı yaparken ara tablo kullanılır
        //Burada primary key oluşturmadık. Oluşturduğumuz 2 tane foreing'in kombinasyonunu dotnet bize primary key olarak tutuyor
        public int ProductProductId { get; set; }
        public Product Product { get; set; }   //navigation property

        public int CategoryCategoryId { get; set; }
        public Category Category { get; set; } //navigation property

        //OLUSTURGUMUZ ARA TABLOYU ShopContext'te tanımlamıyoruz. Cünkü yeni bir deger yok
    }
}
