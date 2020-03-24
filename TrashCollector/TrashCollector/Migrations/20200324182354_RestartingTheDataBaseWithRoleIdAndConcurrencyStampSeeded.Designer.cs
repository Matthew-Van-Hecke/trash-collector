﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrashCollector.Data;

namespace TrashCollector.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200324182354_RestartingTheDataBaseWithRoleIdAndConcurrencyStampSeeded")]
    partial class RestartingTheDataBaseWithRoleIdAndConcurrencyStampSeeded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "8b6f421d-acb0-4e20-ab83-05e9c4aa44c2",
                            ConcurrencyStamp = "db2af3c0-3a7e-4e90-add5-d1080e26ec43",
                            Name = "Customer",
                            NormalizedName = "CUSTOMER"
                        },
                        new
                        {
                            Id = "c3511e67-5c87-4a06-9aca-5189dfb38757",
                            ConcurrencyStamp = "ccd699a7-1834-4a72-a769-c330791a1edd",
                            Name = "Employee",
                            NormalizedName = "EMPLOYEE"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("TrashCollector.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Customer_Id")
                        .HasColumnType("int");

                    b.Property<string>("Street_Number_and_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("USStateId")
                        .HasColumnType("int");

                    b.Property<int>("Zip_Code")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Customer_Id");

                    b.HasIndex("USStateId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("TrashCollector.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Balance_Due")
                        .HasColumnType("float");

                    b.Property<string>("IdentityUser_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdentityUser_Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("TrashCollector.Models.Day", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Days");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Sunday"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Monday"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Tuesday"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Wednesday"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Thursday"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Friday"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Saturday"
                        });
                });

            modelBuilder.Entity("TrashCollector.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IdentityUser_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdentityUser_Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("TrashCollector.Models.Pickup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Address_Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Date_Of_Extra_Pickup")
                        .HasColumnType("datetime2");

                    b.Property<int>("Day_Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("End_Of_Pickup_Suspension")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("PickedUp")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Start_Of_Pickup_Suspension")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Address_Id");

                    b.HasIndex("Day_Id");

                    b.ToTable("Pickups");
                });

            modelBuilder.Entity("TrashCollector.Models.USState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("USStates");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Alabama"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Alaska"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Arizona"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Arkansas"
                        },
                        new
                        {
                            Id = 5,
                            Name = "California"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Colorado"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Connecticut"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Delaware"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Florida"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Georgia"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Hawaii"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Idaho"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Illinois"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Indiana"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Iowa"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Kansas"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Kentucky"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Louisiana"
                        },
                        new
                        {
                            Id = 19,
                            Name = "Maine"
                        },
                        new
                        {
                            Id = 20,
                            Name = "Maryland"
                        },
                        new
                        {
                            Id = 21,
                            Name = "Massachusetts"
                        },
                        new
                        {
                            Id = 22,
                            Name = "Michigan"
                        },
                        new
                        {
                            Id = 23,
                            Name = "Minnesota"
                        },
                        new
                        {
                            Id = 24,
                            Name = "Mississippi"
                        },
                        new
                        {
                            Id = 25,
                            Name = "Missouri"
                        },
                        new
                        {
                            Id = 26,
                            Name = "Montana"
                        },
                        new
                        {
                            Id = 27,
                            Name = "Nebraska"
                        },
                        new
                        {
                            Id = 28,
                            Name = "Nevada"
                        },
                        new
                        {
                            Id = 29,
                            Name = "New Hampshire"
                        },
                        new
                        {
                            Id = 30,
                            Name = "New Jersey"
                        },
                        new
                        {
                            Id = 31,
                            Name = "New Mexico"
                        },
                        new
                        {
                            Id = 32,
                            Name = "New York"
                        },
                        new
                        {
                            Id = 33,
                            Name = "North Carolina"
                        },
                        new
                        {
                            Id = 34,
                            Name = "North Dakota"
                        },
                        new
                        {
                            Id = 35,
                            Name = "Ohio"
                        },
                        new
                        {
                            Id = 36,
                            Name = "Oklahoma"
                        },
                        new
                        {
                            Id = 37,
                            Name = "Oregon"
                        },
                        new
                        {
                            Id = 38,
                            Name = "Pennsylvania"
                        },
                        new
                        {
                            Id = 39,
                            Name = "Rhode Island"
                        },
                        new
                        {
                            Id = 40,
                            Name = "South Carolina"
                        },
                        new
                        {
                            Id = 41,
                            Name = "South Dakota"
                        },
                        new
                        {
                            Id = 42,
                            Name = "Tennessee"
                        },
                        new
                        {
                            Id = 43,
                            Name = "Texas"
                        },
                        new
                        {
                            Id = 44,
                            Name = "Utah"
                        },
                        new
                        {
                            Id = 45,
                            Name = "Vermont"
                        },
                        new
                        {
                            Id = 46,
                            Name = "Virginia"
                        },
                        new
                        {
                            Id = 47,
                            Name = "Washington"
                        },
                        new
                        {
                            Id = 48,
                            Name = "West Virginia"
                        },
                        new
                        {
                            Id = 49,
                            Name = "Wisconsin"
                        },
                        new
                        {
                            Id = 50,
                            Name = "Wyoming"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TrashCollector.Models.Address", b =>
                {
                    b.HasOne("TrashCollector.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("Customer_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrashCollector.Models.USState", "State")
                        .WithMany()
                        .HasForeignKey("USStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TrashCollector.Models.Customer", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUser_Id");
                });

            modelBuilder.Entity("TrashCollector.Models.Employee", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUser_Id");
                });

            modelBuilder.Entity("TrashCollector.Models.Pickup", b =>
                {
                    b.HasOne("TrashCollector.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("Address_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrashCollector.Models.Day", "Day")
                        .WithMany()
                        .HasForeignKey("Day_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
