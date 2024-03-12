using entityFramework.Data.DBFirst;
using System.Xml.Schema;

namespace entityFramework
{
     class Program
     {
        static void Main(string[] args) 
        {
             AddData();
            // GetAllEmployeeData();
            //GetEmployeeByID(3);
            //GetCustomerByName("Mehmet");
            //Update(3);
            //Delete();
            //InsertUser();
            //InsertAddresses();

            //tekSupplierGirisi();
            //tekSupplierGirisi2();
            //urunEkle();
            //ProductCategoryDegerEkleme();
            //HazirDBVeriEkle();



        }

        static void AddData()
        {
            using(var db = new ShopContext())
            {
                //var e = new Employee { Name = "Serkan", Surname = "Cerk", Title = "Instructor", City = "Istanbul" };
                //db.Employees.Add(e);
                //db.SaveChanges();

                var e = new List<Employee>()
                {
                    new Employee{Name="Zeki", Surname="Boy", Title="Mechanical",City="Istanbul"},
                    new Employee{Name="Hacer", Surname="Dursun", Title="Software",City="Istanbul"},
                    new Employee{Name="Atakan", Surname="Değer", Title="Database",City="Antalya"},
                    new Employee{Name="Esra", Surname="Boz", Title="Design",City="Izmir"},
                    new Employee{Name="Fatih", Surname="Arslan", Title="Database",City="Istanbul"},
                };

                var c = new List<Customers>()
                {
                    new Customers{Name="Jack", Title="MOC", City="Tokyo", Country="Japan"},
                    new Customers{Name="Mehmet", Title="Sağlık", City="Ankara", Country="Turkey"}
                };

                db.Employees.AddRange(e);
                db.Customers.AddRange(c);
                //db database'ime Customers nesnem ile c değişkenimi ekle

                db.SaveChanges();

                Console.WriteLine("Veriler Eklendi !");


            }
        }

        static void GetAllEmployeeData()
        {
            using(var context = new ShopContext())
            {
                var employee = context.Employees.ToList();

               // var employee= context.Employees.Select(e=>new { e.Name, e.Surname }).ToList();
               // yorum satırındaki => büyük eşittir değil, arrow fonction
               //Yorum satırındaki üsttekinden farklı olarak, sadece seçilen değerleri getirir. Çalıştırsak Title bilgisi çekemeyiz
             
                foreach(var e in employee)
                {
                    Console.WriteLine($"Name: {e.Name} Surname:{e.Surname} Title:{e.Title}");
                }
            }
        }

        static void GetEmployeeByID(int id)
        {
            using(var context = new ShopContext())
            {
                var employee = context.Employees.Where(e=>e.EmployeeId==id).FirstOrDefault();
                Console.WriteLine($"Name: {employee.Name} Surname: {employee.Surname} Title: {employee.Title}");
                //FirstOrDefault en başından taramaya başlar ilk bulduğunu getirir. Bulamazsa null getirir
            }
        }

        static void GetCustomerByName(string name)
        {
            using(var context=new ShopContext())
            {
                var customer = context.Customers.Where(customer=> customer.Name==name).FirstOrDefault();
                Console.WriteLine($"Name:{customer.Name} City:{customer.City} Country:{customer.Country}");
            } 
        }

        static void Update(int id)
        {
            using(var db=new ShopContext())
            {
                var emp = db.Employees.Where(emp => emp.EmployeeId == id).FirstOrDefault();
                Console.Write("Lütfen güncellenecek ismi giriniz: ");
                emp.Name = Console.ReadLine();
                Console.WriteLine($"Name:{emp.Name} Surname:{emp.Surname}");
               
                db.SaveChanges();
            }
        }
        
        static void Delete()
        {
            using( var db=new ShopContext())
            {
                Console.Write("Silinecek Personelin IDsini giriniz: ");
                var id = Convert.ToInt32(Console.ReadLine());
                var emp = db.Employees.Where(emp => emp.EmployeeId == id).FirstOrDefault();
                Console.Write($"{emp.EmployeeId} ID'li kullanıcı bilgileri silindi");

                db.Employees.Remove(emp);
                db.SaveChanges();
            }
        }
        
        static void InsertUser()
        {
            var users = new List<User>()
            {
                new User(){UserName="serkancerk", UserMail="sc@gmail.com"},
                new User(){UserName="furkanncerk", UserMail="fc@gmail.com"},
                new User(){UserName="sudeserim", UserMail="ss@gmail.com"},
                new User(){UserName="kaanserim", UserMail="ks@gmail.com"}
            };

            using(var db=new ShopContext())
            {
                db.Users.AddRange(users);
                db.SaveChanges();
            }
        }

        static void InsertAddresses()
        {
            var addresses = new List<Address>()
            {
                new Address() {FullName="Serkan Cerk", Title= "Ev Adresi",Body="Beyoğlu",UserUserId=1},
                new Address() {FullName="Serkan Cerk", Title= "İş Adresi",Body="Beşiktaş",UserUserId=1},
                new Address() {FullName="Sude Serim", Title= "Ev Adresi",Body="Kadıköy",UserUserId=3},
                new Address() {FullName="Sude Serim", Title= "İş Adresi",Body="Üsküdar",UserUserId=3},
                new Address() {FullName="Furkan Cerk", Title= "Ev Adresi",Body="Beyoğlu",UserUserId=2},
                new Address() {FullName="Furkan Cerk", Title= "İş Adresi",Body="Beşiktaş",UserUserId=2},
                new Address() {FullName="Kaan Serim", Title= "Ev Adresi",Body="Kadıköy",UserUserId=4},
                new Address() {FullName="Kaan Serim", Title= "İş Adresi",Body="Üsküdar",UserUserId=4},

            };

            using(var db=new ShopContext())
            {
                db.Addresses.AddRange(addresses);
                db.SaveChanges();
            }
        }

        static void ornek()
        {
            //bu medotun içini direkt main'de çalıştırmıştık. Not olarak kalması için buraya taşıdım.
            using (var db = new ShopContext())
            {
                var user = db.Users.FirstOrDefault(i => i.UserName == "serkancerk");
                //navigation property oluşturduğumuz için username üzerinden adres tablosuna veri eklediğimizde,
                //otomatik olarak UserUserId değerimizi çekip adres tablomuza ekledi

                if (user != null)
                {
                    user.Addresses = new List<Address>();
                    //Daha sonradan AddRange metodunu kullanamabilmek için öncesinde listeyi oluşturmuş olmalıyız
                    user.Addresses.AddRange
                        (
                          new List<Address>()
                          {
                              new Address() { FullName="Serkan Cerk", Title="Ev Adresi-2", Body="Tuzla"},
                              new Address() { FullName = "Serkan Cerk", Title = "İş Adresi-2", Body = "Behçelievler" }
                          }
                        );
                    db.SaveChanges();
                }
            }
        }

        static void tekSupplierGirisi()
        {
            using (var db = new ShopContext())
            {
                var supplier = new Supplier()
                {
                    SupplierTC=25048698314,
                    SupplierFirstName="Serkan",
                    SupplierLastName="Cerk",
                    UserUserId=1
                };
                db.Suppliers.Add(supplier);
                db.SaveChanges();
            }
        }

        static void tekSupplierGirisi2()
        {
            //alternetif bir veri girişi, üstteki metodtan farkı bu
            using(var db = new ShopContext())
            {
                var supplier = new Supplier()
                {
                    //SupplierTC=24845325456,
                    //SupplierFirstName="Sude",
                    //SupplierLastName="Serim",
                    //user=db.Users.FirstOrDefault(i=>i.UserId==3)
                    //user supplier classındaki navigation property


                    SupplierTC = 25048698388,
                    SupplierFirstName = "Melih",
                    SupplierLastName = "Yıldız",
                    UserUserId = 4
                };
                db.Suppliers.Add(supplier);
                db.SaveChanges();
            }
        }

        static void urunEkle()
        {
            using (var db = new ShopContext())
            {
                var products = new List<Product>()
                 {
                     new Product() {Name="Samsung", Price=100},
                     new Product() {Name="IPhone", Price=500},
                     new Product() {Name="Huwai", Price=300},
                     new Product() {Name="Xaomi", Price=70}
                 };

                db.Products.AddRange(products);

                var categories = new List<Category>()
                {
                    new Category(){Name="Phone"},
                    new Category(){Name="Computer"},
                    new Category(){Name="Electric"}
                };

                db.Categories.AddRange(categories);
                db.SaveChanges();
              
            }
        }

        static void ProductCategoryDegerEkleme()
        {
            //oluşturduğumuz ara tablyoa veri ekleme
            using (var db = new ShopContext())
            {
                int[] ids = new int[] { 1, 2 };
                var p = db.Products.Find(1);

                p.ProductCategories = ids.Select(c_id => new ProductCategory()
                { 
                    //select foreach gibi çalışır
                    //önce ids dizisinden 1 değerini aldı bunu ProductCategory tablosunda CategoryCategoryId olarak atadı
                    //eklenen iki değerin de ProductProductId=1 olma nedeni, find fonksiyonunu 1 ile çalıştırmamız
                    CategoryCategoryId = c_id,
                    ProductProductId = p.ProductId,
                }).ToList();

                db.SaveChanges();
            }
        }

        static void HazirDBVeriEkle()
        {
            using (var HazirDB = new DBFirstContext())
            {
                // İki databasede de aynı tablo olduğu için. Namespace ile başlayarak yolunu gösterdik yoksa hata veriyor
                var z = new entityFramework.Data.DBFirst.Employee()
                { FirstName = "Ricardo", LastName = "Quaresma", Title = "Capitan" };

                HazirDB.Employees.Add(z);
                HazirDB.SaveChanges();
            }
        }
     }
}