﻿// <auto-generated />
using System;
using BrokerBackend.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BrokerBackend.Migrations
{
    [DbContext(typeof(BrokerContext))]
    partial class BrokerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BrokerBackend.Models.PersonModel", b =>
                {
                    b.Property<int>("IdPerson")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPerson"));

                    b.Property<decimal>("AccountMoney")
                        .HasColumnType("decimal(11,2)");

                    b.Property<DateTime?>("ActiveDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.Property<DateTime?>("InactiveDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<int?>("RolModelIdRol")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.HasKey("IdPerson");

                    b.HasIndex("RolModelIdRol");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("BrokerBackend.Models.PurchasesModel", b =>
                {
                    b.Property<int>("IdPurchase")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPurchase"));

                    b.Property<int?>("IdPerson")
                        .HasColumnType("int");

                    b.Property<DateTime?>("PurchaseDate")
                        .HasColumnType("datetime");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Symbol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(11,2)");

                    b.HasKey("IdPurchase");

                    b.HasIndex("IdPerson");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("BrokerBackend.Models.RolModel", b =>
                {
                    b.Property<int>("IdRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRol"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.HasKey("IdRol");

                    b.ToTable("Rol");
                });

            modelBuilder.Entity("BrokerBackend.Models.PersonModel", b =>
                {
                    b.HasOne("BrokerBackend.Models.RolModel", null)
                        .WithMany("Person")
                        .HasForeignKey("RolModelIdRol");
                });

            modelBuilder.Entity("BrokerBackend.Models.PurchasesModel", b =>
                {
                    b.HasOne("BrokerBackend.Models.PersonModel", "IdCuentaNavigation")
                        .WithMany("Purchases")
                        .HasForeignKey("IdPerson");

                    b.Navigation("IdCuentaNavigation");
                });

            modelBuilder.Entity("BrokerBackend.Models.PersonModel", b =>
                {
                    b.Navigation("Purchases");
                });

            modelBuilder.Entity("BrokerBackend.Models.RolModel", b =>
                {
                    b.Navigation("Person");
                });
#pragma warning restore 612, 618
        }
    }
}
