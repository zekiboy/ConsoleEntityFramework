using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace entityFramework
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserMail { get; set; }
        public List<Address>Addresses { get; set; }
        //address user ilişkisi one to many
        public Supplier Supplier { get; set; }
        //Suplier - user ilişkisi one to one

    }
}
