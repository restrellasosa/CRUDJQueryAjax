﻿// <auto-generated />
using JQueryAjax.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JQueryAjax.Migrations
{
    [DbContext(typeof(TransactionDbContext))]
    [Migration("20200417145927_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JQueryAjax.Models.TransactionModel", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountNumber")
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("Amount")
                        .IsRequired()
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("BankName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("BeneficiaryName")
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("SWIFTCode")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("TransactionId");

                    b.ToTable("transactionModels");
                });
#pragma warning restore 612, 618
        }
    }
}
