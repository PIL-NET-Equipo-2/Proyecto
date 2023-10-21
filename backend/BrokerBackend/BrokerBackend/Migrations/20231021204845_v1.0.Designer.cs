﻿// <auto-generated />
using System;
using BrokerBackend.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BrokerBackend.Migrations
{
    [DbContext(typeof(BrokerContext))]
    [Migration("20231021204845_v1.0")]
    partial class v10
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Adress")
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

                    b.Property<DateTime?>("InactiveDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.HasKey("IdPerson");

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

                    b.Property<int?>("IdStock")
                        .HasColumnType("int");

                    b.Property<DateTime?>("PurchaseDate")
                        .HasColumnType("datetime");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(11,2)");

                    b.HasKey("IdPurchase");

                    b.HasIndex("IdPerson");

                    b.HasIndex("IdStock");

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

            modelBuilder.Entity("BrokerBackend.Models.StockModel", b =>
                {
                    b.Property<int>("IdStock")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdStock"));

                    b.Property<DateTime?>("ActiveDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<DateTime?>("InactiveDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(11,2)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdStock");

                    b.ToTable("Stock");
                });

            modelBuilder.Entity("PersonModelRolModel", b =>
                {
                    b.Property<int>("PersonIdPerson")
                        .HasColumnType("int");

                    b.Property<int>("RolIdRol")
                        .HasColumnType("int");

                    b.HasKey("PersonIdPerson", "RolIdRol");

                    b.HasIndex("RolIdRol");

                    b.ToTable("PersonModelRolModel");
                });

            modelBuilder.Entity("BrokerBackend.Models.PurchasesModel", b =>
                {
                    b.HasOne("BrokerBackend.Models.PersonModel", "IdCuentaNavigation")
                        .WithMany("Purchases")
                        .HasForeignKey("IdPerson");

                    b.HasOne("BrokerBackend.Models.StockModel", "IdAccionNavigation")
                        .WithMany("Purchases")
                        .HasForeignKey("IdStock");

                    b.Navigation("IdAccionNavigation");

                    b.Navigation("IdCuentaNavigation");
                });

            modelBuilder.Entity("PersonModelRolModel", b =>
                {
                    b.HasOne("BrokerBackend.Models.PersonModel", null)
                        .WithMany()
                        .HasForeignKey("PersonIdPerson")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BrokerBackend.Models.RolModel", null)
                        .WithMany()
                        .HasForeignKey("RolIdRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BrokerBackend.Models.PersonModel", b =>
                {
                    b.Navigation("Purchases");
                });

            modelBuilder.Entity("BrokerBackend.Models.StockModel", b =>
                {
                    b.Navigation("Purchases");
                });
#pragma warning restore 612, 618
        }
    }
}
