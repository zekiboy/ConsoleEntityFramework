using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entityFramework
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        public string Surname { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
    }
}
