﻿// <auto-generated />
using System;
using AllianzInsure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AllianzInsure.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20231204081003_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AllianzeInsure.Data.Entities.Insurance", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("BodyType")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedBy")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("ModifiedBy")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("RegistrationNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("VehicleMake")
                        .HasColumnType("longtext");

                    b.Property<string>("VehicleModel")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Insurances");
                });

            modelBuilder.Entity("AllianzeInsure.Data.Entities.Payment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedBy")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CustomerFirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CustomerLastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("InsuranceId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("ModifiedBy")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("PaymentType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TransactionReference")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("AllianzeInsure.Data.Entities.Product", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("BodyTpe")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedBy")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ModifiedBy")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Premium")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("AllianzeInsure.Data.Entities.Vehicle", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CreatedBy")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Make")
                        .HasColumnType("longtext");

                    b.Property<string>("Model")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("ModifiedBy")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
