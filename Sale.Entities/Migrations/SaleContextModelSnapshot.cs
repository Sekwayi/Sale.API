﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Sale.Entities.Models;

#nullable disable

namespace Sale.Entities.Migrations
{
    [DbContext(typeof(SaleContext))]
    partial class SaleContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Sale.Entities.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CustomerId"));
                    NpgsqlPropertyBuilderExtensions.HasIdentityOptions(b.Property<int>("CustomerId"), 10001L, null, null, null, null, null);

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int?>("CustomerPhone")
                        .HasColumnType("integer");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("Sale.Entities.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("EmployeeId"));
                    NpgsqlPropertyBuilderExtensions.HasIdentityOptions(b.Property<int>("EmployeeId"), 20001L, null, null, null, null, null);

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employee", (string)null);
                });

            modelBuilder.Entity("Sale.Entities.Models.Invoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .HasColumnType("integer");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("InvoiceDate")
                        .HasColumnType("date");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.HasKey("InvoiceId");

                    b.HasIndex(new[] { "CustomerId" }, "fki_Customer_FK");

                    b.HasIndex(new[] { "EmployeeId" }, "fki_Employee_FK");

                    b.HasIndex(new[] { "InvoiceId" }, "fki_Invoice_FK");

                    b.HasIndex(new[] { "ProductId" }, "fki_Product_FK");

                    b.ToTable("Invoice", (string)null);
                });

            modelBuilder.Entity("Sale.Entities.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("ProductId"));
                    NpgsqlPropertyBuilderExtensions.HasIdentityOptions(b.Property<int>("ProductId"), 40001L, null, null, null, null, null);

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("character varying");

                    b.Property<string>("ProductSupplier")
                        .HasColumnType("character varying");

                    b.Property<int?>("SupplierId")
                        .HasColumnType("integer");

                    b.HasKey("ProductId");

                    b.HasIndex(new[] { "SupplierId" }, "fki_Supplier_FK");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("Sale.Entities.Models.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SupplierId"));
                    NpgsqlPropertyBuilderExtensions.HasIdentityOptions(b.Property<int>("SupplierId"), 50001L, null, null, null, null, null);

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("SupplierId");

                    b.ToTable("Supplier", (string)null);
                });

            modelBuilder.Entity("Sale.Entities.Models.Invoice", b =>
                {
                    b.HasOne("Sale.Entities.Models.Customer", "Customer")
                        .WithMany("Invoices")
                        .HasForeignKey("CustomerId")
                        .IsRequired()
                        .HasConstraintName("Customer_FK");

                    b.HasOne("Sale.Entities.Models.Employee", "Employee")
                        .WithMany("Invoices")
                        .HasForeignKey("EmployeeId")
                        .IsRequired()
                        .HasConstraintName("Employee_FK");

                    b.HasOne("Sale.Entities.Models.Product", "Product")
                        .WithMany("Invoices")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("Product_FK");

                    b.Navigation("Customer");

                    b.Navigation("Employee");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Sale.Entities.Models.Product", b =>
                {
                    b.HasOne("Sale.Entities.Models.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId")
                        .HasConstraintName("Supplier_FK");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Sale.Entities.Models.Customer", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("Sale.Entities.Models.Employee", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("Sale.Entities.Models.Product", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("Sale.Entities.Models.Supplier", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
