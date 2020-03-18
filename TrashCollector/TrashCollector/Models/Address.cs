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
        [ForeignKey("USState")]
        public int USStateId { get; set; }
        public USState State { get; set; }
        [NotMapped]
        public IEnumerable<USState> USStates { get; set; }
    }
}
