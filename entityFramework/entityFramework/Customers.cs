using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entityFramework
{
    public class Customers
    {
        public int CustomersId { get; set; }
        //Id ifadesinden primarykey olduğunu anlıyor
        //NOT: classadiId şeklinde olmalı yoksa hata veriyor. class adı ile aynı ve d harfi küçük

        //MaxLength ve Required koşulları sadece Name için geçerli, diğerleri için de aynı kısıtı istiyorsan yazmalısın
        //Eğer sonuna Id yazmadık ve primary key olsun istiyorsak [Key] yazıyoruz
        //Required  not null 
        [MaxLength(100)]
        [Required]
        public string Name { get;set; }

        public string Title { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public int EmployeeId { get; set; }
        //EmployeeId Employee tablosundaki ile aynı yap
        // daha sonra iki tabloyu bağlamak için terminale "dotnet ef migrations add ver
        //sonrasında sütunun Sql'e gelmesi için terminalde dotnet ef database update çalıştır
    }
}
