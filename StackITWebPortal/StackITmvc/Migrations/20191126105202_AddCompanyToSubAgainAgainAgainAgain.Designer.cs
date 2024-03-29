﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StackITmvc.Data;

namespace StackITmvc.Migrations
{
    [DbContext(typeof(StackItContext))]
    [Migration("20191126105202_AddCompanyToSubAgainAgainAgainAgain")]
    partial class AddCompanyToSubAgainAgainAgainAgain
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StackITmvc.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("StreetNo")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("VAT")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("StackITmvc.Models.Hardware", b =>
                {
                    b.Property<int>("HardwareId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HardwareName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("HardwareId");

                    b.ToTable("Hardware");
                });

            modelBuilder.Entity("StackITmvc.Models.Job", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("JobName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("JobId");

                    b.ToTable("Job");
                });

            modelBuilder.Entity("StackITmvc.Models.K_Admin", b =>
                {
                    b.Property<int>("K_AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PhoneNo")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("K_AdminId");

                    b.HasIndex("CustomerId");

                    b.ToTable("K_Admin");
                });

            modelBuilder.Entity("StackITmvc.Models.Subscription", b =>
                {
                    b.Property<int>("SubscriptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("HardwareId")
                        .HasColumnType("int");

                    b.Property<string>("SubscriptionName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("SubscriptionId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("HardwareId");

                    b.ToTable("Subscription");
                });

            modelBuilder.Entity("StackITmvc.Models.SubscriptionJobs", b =>
                {
                    b.Property<int>("SubscriptionId")
                        .HasColumnType("int");

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.HasKey("SubscriptionId", "JobId");

                    b.HasAlternateKey("SubscriptionId");

                    b.HasIndex("JobId");

                    b.ToTable("SubscriptionJobs");
                });

            modelBuilder.Entity("StackITmvc.Models.K_Admin", b =>
                {
                    b.HasOne("StackITmvc.Models.Customer", "Company")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StackITmvc.Models.Subscription", b =>
                {
                    b.HasOne("StackITmvc.Models.Customer", "Company")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("StackITmvc.Models.Hardware", "Hardware")
                        .WithMany()
                        .HasForeignKey("HardwareId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StackITmvc.Models.SubscriptionJobs", b =>
                {
                    b.HasOne("StackITmvc.Models.Job", "Job")
                        .WithMany("SubscriptionJobs")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StackITmvc.Models.Subscription", "Subscription")
                        .WithMany("SubscriptionJobs")
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
