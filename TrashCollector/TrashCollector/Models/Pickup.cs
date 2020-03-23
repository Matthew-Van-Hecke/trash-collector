using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollector.Models
{
    public class Pickup
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Customer")]
        public int Customer_Id { get; set; }
        public Customer Customer { get; set; }
        [ForeignKey("Address")]
        public int Address_Id { get; set; }
        public Address Address { get; set; }
        [ForeignKey("Day")]
        public int Day_Id { get; set; }
        public Day Day { get; set; }
        public DateTime? Start_Of_Pickup_Suspension { get; set; }
        public DateTime? End_Of_Pickup_Suspension { get; set; }
        public DateTime? Date_Of_Extra_Pickup { get; set; }
        public bool? PickedUp { get; set; }
        [NotMapped]
        public IEnumerable<Day> Days { get; set; }
        [NotMapped]
        public IEnumerable<Address> Addresses { get; set; }
    }
}
