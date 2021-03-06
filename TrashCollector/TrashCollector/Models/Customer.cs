﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollector.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Balance_Due { get; set; }
        [ForeignKey("IdentityUser")]
        public string IdentityUser_Id { get; set; }
        public IdentityUser IdentityUser { get; set; }
        [NotMapped]
        public IEnumerable<IdentityUser> IdentityUsers { get; set; }
        [NotMapped]
        public IEnumerable<Pickup> Pickups { get; set; }
    }
}
