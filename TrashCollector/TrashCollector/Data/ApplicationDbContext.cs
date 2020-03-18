using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrashCollector.Models;

namespace TrashCollector.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<IdentityRole> IdentityRoles { get; set; }
        public DbSet<Pickup> Pickups { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<USState> USStates { get; set; }
        public DbSet<Day> Days { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Name = "Customer",
                    NormalizedName = "CUSTOMER"
                },
                new IdentityRole
                {
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE"
                }
                );
            builder.Entity<Day>().HasData(
                    new Day
                    {
                        Id = 1,
                        Name = "Sunday"
                    },
                    new Day
                    {
                        Id = 2,
                        Name = "Monday"
                    },
                    new Day
                    {
                        Id = 3,
                        Name = "Tuesday"
                    },
                    new Day
                    {
                        Id = 4,
                        Name = "Wednesday"
                    },
                    new Day
                    {
                        Id = 5,
                        Name = "Thursday"
                    },
                    new Day
                    {
                        Id = 6,
                        Name = "Friday"
                    },
                    new Day
                    {
                        Id = 7,
                        Name = "Saturday"
                    }
                );
            builder.Entity<USState>().HasData(
                    new USState
                    {
                        Id = 1,
                        Name = "Alabama"
                    },
                    new USState
                    {
                        Id = 2,
                        Name = "Alaska"
                    },
                    new USState
                    {
                        Id = 3,
                        Name = "Arizona"
                    },
                    new USState
                    {
                        Id = 4,
                        Name = "Arkansas"
                    },
                    new USState
                    {
                        Id = 5,
                        Name = "California"
                    },
                    new USState
                    {
                        Id = 6,
                        Name = "Colorado"
                    },
                    new USState
                    {
                        Id = 7,
                        Name = "Connecticut"
                    },
                    new USState
                    {
                        Id = 8,
                        Name = "Delaware"
                    },
                    new USState
                    {
                        Id = 9,
                        Name = "Florida"
                    },
                    new USState
                    {
                        Id = 10,
                        Name = "Georgia"
                    },
                    new USState
                    {
                        Id = 11,
                        Name = "Hawaii"
                    },
                    new USState
                    {
                        Id = 12,
                        Name = "Idaho"
                    },
                    new USState
                    {
                        Id = 13,
                        Name = "Illinois"
                    },
                    new USState
                    {
                        Id = 14,
                        Name = "Indiana"
                    },
                    new USState
                    {
                        Id = 15,
                        Name = "Iowa"
                    },
                    new USState
                    {
                        Id = 16,
                        Name = "Kansas"
                    },
                    new USState
                    {
                        Id = 17,
                        Name = "Kentucky"
                    },
                    new USState
                    {
                        Id = 18,
                        Name = "Louisiana"
                    },
                    new USState
                    {
                        Id = 19,
                        Name = "Maine"
                    },
                    new USState
                    {
                        Id = 20,
                        Name = "Maryland"
                    },
                    new USState
                    {
                        Id = 21,
                        Name = "Massachusetts"
                    },
                    new USState
                    {
                        Id = 22,
                        Name = "Michigan"
                    },
                    new USState
                    {
                        Id = 23,
                        Name = "Minnesota"
                    },
                    new USState
                    {
                        Id = 24,
                        Name = "Mississippi"
                    },
                    new USState
                    {
                        Id = 25,
                        Name = "Missouri"
                    },
                    new USState
                    {
                        Id = 26,
                        Name = "Montana"
                    },
                    new USState
                    {
                        Id = 27,
                        Name = "Nebraska"
                    },
                    new USState
                    {
                        Id = 28,
                        Name = "Nevada"
                    },
                    new USState
                    {
                        Id = 29,
                        Name = "New Hampshire"
                    },
                    new USState
                    {
                        Id = 30,
                        Name = "New Jersey"
                    },
                    new USState
                    {
                        Id = 31,
                        Name = "New Mexico"
                    },
                    new USState
                    {
                        Id = 32,
                        Name = "New York"
                    },
                    new USState
                    {
                        Id = 33,
                        Name = "North Carolina"
                    },
                    new USState
                    {
                        Id = 34,
                        Name = "North Dakota"
                    },
                    new USState
                    {
                        Id = 35,
                        Name = "Ohio"
                    },
                    new USState
                    {
                        Id = 36,
                        Name = "Oklahoma"
                    },
                    new USState
                    {
                        Id = 37,
                        Name = "Oregon"
                    },
                    new USState
                    {
                        Id = 38,
                        Name = "Pennsylvania"
                    },
                    new USState
                    {
                        Id = 39,
                        Name = "Rhode Island"
                    },
                    new USState
                    {
                        Id = 40,
                        Name = "South Carolina"
                    },
                    new USState
                    {
                        Id = 41,
                        Name = "South Dakota"
                    },
                    new USState
                    {
                        Id = 42,
                        Name = "Tennessee"
                    },
                    new USState
                    {
                        Id = 43,
                        Name = "Texas"
                    },
                    new USState
                    {
                        Id = 44,
                        Name = "Utah"
                    },
                    new USState
                    {
                        Id = 45,
                        Name = "Vermont"
                    },
                    new USState
                    {
                        Id = 46,
                        Name = "Virginia"
                    },
                    new USState
                    {
                        Id = 47,
                        Name = "Washington"
                    },
                    new USState
                    {
                        Id = 48,
                        Name = "West Virginia"
                    },
                    new USState
                    {
                        Id = 49,
                        Name = "Wisconsin"
                    },
                    new USState
                    {
                        Id = 50,
                        Name = "Wyoming"
                    }
                );
        }
    }
}
