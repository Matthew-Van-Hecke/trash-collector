using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollector.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string Street_Number_and_Name { get; set; }
        public string City { get; set; }
        public int Zip_Code { get; set; }
        [ForeignKey("State")]
        public int USStateId { get; set; }
        public USState State { get; set; }
        [ForeignKey("Customer")]
        public int Customer_Id { get; set; }
        public Customer Customer { get; set; }
        [NotMapped]
        public string Single_Line_Address { get; set; }
        [NotMapped]
        public IEnumerable<USState> USStates { get; set; }
        [NotMapped]
        public IEnumerable<Customer> Customers { get; set; }
    }
}
