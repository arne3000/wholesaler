using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Wholesaler.Models;

namespace Wholesaler.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170221213359_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Wholesaler.Models.Fruit", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ConversionRateForCases");

                    b.Property<int>("ConversionRateForPallets");

                    b.Property<int>("StockLevel");

                    b.Property<decimal>("UnitCost");

                    b.HasKey("Name");

                    b.ToTable("Fruits");
                });
        }
    }
}
