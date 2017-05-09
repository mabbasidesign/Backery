using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Backery.Models;

namespace Backery.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20170502211644_Ordering")]
    partial class Ordering
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Backery.Models.Bread", b =>
                {
                    b.Property<int>("BreadId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AllergyInformation");

                    b.Property<int>("CategoryId");

                    b.Property<string>("ImageThumbnailUrl");

                    b.Property<string>("ImageUrl");

                    b.Property<bool>("InStock");

                    b.Property<bool>("IsBreadOfTheWeek");

                    b.Property<string>("LongDescription");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<string>("ShortDescription");

                    b.HasKey("BreadId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Breads");
                });

            modelBuilder.Entity("Backery.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName");

                    b.Property<string>("Description");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Backery.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("AddressLine2");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<DateTime>("OrderPlaced");

                    b.Property<decimal>("OrderTotal");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 25);

                    b.Property<string>("State")
                        .HasAnnotation("MaxLength", 10);

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 10);

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Backery.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<int>("BreadId");

                    b.Property<int>("OrderId");

                    b.Property<decimal>("Price");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("BreadId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Backery.Models.ShoppingCartItem", b =>
                {
                    b.Property<int>("ShoppingCartItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<int?>("BreadId");

                    b.Property<string>("ShoppingCartId");

                    b.HasKey("ShoppingCartItemId");

                    b.HasIndex("BreadId");

                    b.ToTable("ShoppingCartItems");
                });

            modelBuilder.Entity("Backery.Models.Bread", b =>
                {
                    b.HasOne("Backery.Models.Category", "Category")
                        .WithMany("Breads")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backery.Models.OrderDetail", b =>
                {
                    b.HasOne("Backery.Models.Bread", "Bread")
                        .WithMany()
                        .HasForeignKey("BreadId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Backery.Models.Order", "Order")
                        .WithMany("OrderLines")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backery.Models.ShoppingCartItem", b =>
                {
                    b.HasOne("Backery.Models.Bread", "Bread")
                        .WithMany()
                        .HasForeignKey("BreadId");
                });
        }
    }
}
