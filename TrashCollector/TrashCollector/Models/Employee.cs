using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollector.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ZipCode { get; set; }
        [ForeignKey("IdentityUser")]
        public string IdentityUser_Id { get; set; }
        public IdentityUser IdentityUser { get; set; }
        [NotMapped]
        public IEnumerable<IdentityUser> IdentityUsers { get; set; }
        [NotMapped]
        public List<Pickup> Pickups { get; set; }
        [NotMapped]
        public List<Day> Days { get; set; }
    }
}
