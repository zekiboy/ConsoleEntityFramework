using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entityFramework
{
    public class Address
    {
        //address user ilişkisi one to many
        public int AddressId { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public User User { get; set; } //navigation proporty
        public int UserUserId { get; set; }  //otomatik yabancı anahtar olduğunu tanımlamak için böyle yazdık
    }
}
