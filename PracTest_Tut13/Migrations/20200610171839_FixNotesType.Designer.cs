﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PracTest_Tut13.Entities;

namespace PracTest_Tut13.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20200610171839_FixNotesType")]
    partial class FixNotesType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PracTest_Tut13.Entities.Confectionery", b =>
                {
                    b.Property<int>("IdConfection")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<double>("PricePerite")
                        .HasColumnType("float");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.HasKey("IdConfection");

                    b.ToTable("Confectionery");
                });

            modelBuilder.Entity("PracTest_Tut13.Entities.Confectionery_Order", b =>
                {
                    b.Property<int>("IdConfection")
                        .HasColumnType("int");

                    b.Property<int>("IdOrder")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("IdConfection", "IdOrder");

                    b.HasIndex("IdConfection")
                        .IsUnique();

                    b.HasIndex("IdOrder")
                        .IsUnique();

                    b.ToTable("Confectionery_Order");
                });

            modelBuilder.Entity("PracTest_Tut13.Entities.Customer", b =>
                {
                    b.Property<int>("IdClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.HasKey("IdClient");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("PracTest_Tut13.Entities.Employee", b =>
                {
                    b.Property<int>("IdEmpl")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.HasKey("IdEmpl");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("PracTest_Tut13.Entities.Order", b =>
                {
                    b.Property<int>("IdOrder")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateAccepted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateFinished")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.Property<int>("IdEmpl")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("IdOrder");

                    b.HasIndex("IdClient");

                    b.HasIndex("IdEmpl");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("PracTest_Tut13.Entities.Confectionery_Order", b =>
                {
                    b.HasOne("PracTest_Tut13.Entities.Confectionery", "Confectionery")
                        .WithOne("Confectionery_Order")
                        .HasForeignKey("PracTest_Tut13.Entities.Confectionery_Order", "IdConfection")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PracTest_Tut13.Entities.Order", "Order")
                        .WithOne("Confectionery_Order")
                        .HasForeignKey("PracTest_Tut13.Entities.Confectionery_Order", "IdOrder")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PracTest_Tut13.Entities.Order", b =>
                {
                    b.HasOne("PracTest_Tut13.Entities.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("IdClient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PracTest_Tut13.Entities.Employee", "Employee")
                        .WithMany("Orders")
                        .HasForeignKey("IdEmpl")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
