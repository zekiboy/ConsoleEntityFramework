using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entityFramework
{
    public class Supplier
    {
        //Suplier - user ilişkisi one to one
        public int SupplierId { get; set; }
        public long SupplierTC { get; set; }
        public string SupplierFirstName { get; set;}
        public string SupplierLastName { get; set; }

        public User user { get; set; }
        public int UserUserId { get; set; }

    }
}
