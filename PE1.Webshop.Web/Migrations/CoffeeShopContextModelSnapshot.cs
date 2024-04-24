﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PE1.Webshop.Web.Data;

#nullable disable

namespace PE1.Webshop.Web.Migrations
{
    [DbContext(typeof(CoffeeShopContext))]
    partial class CoffeeShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CoffeeProperty", b =>
                {
                    b.Property<int>("CoffeesId")
                        .HasColumnType("int");

                    b.Property<int>("PropertiesId")
                        .HasColumnType("int");

                    b.HasKey("CoffeesId", "PropertiesId");

                    b.HasIndex("PropertiesId");

                    b.ToTable("CoffeeProperty");

                    b.HasData(
                        new
                        {
                            CoffeesId = 1,
                            PropertiesId = 1
                        },
                        new
                        {
                            CoffeesId = 1,
                            PropertiesId = 2
                        },
                        new
                        {
                            CoffeesId = 1,
                            PropertiesId = 3
                        },
                        new
                        {
                            CoffeesId = 2,
                            PropertiesId = 4
                        },
                        new
                        {
                            CoffeesId = 2,
                            PropertiesId = 5
                        },
                        new
                        {
                            CoffeesId = 2,
                            PropertiesId = 6
                        },
                        new
                        {
                            CoffeesId = 3,
                            PropertiesId = 1
                        },
                        new
                        {
                            CoffeesId = 3,
                            PropertiesId = 7
                        },
                        new
                        {
                            CoffeesId = 3,
                            PropertiesId = 8
                        },
                        new
                        {
                            CoffeesId = 4,
                            PropertiesId = 1
                        },
                        new
                        {
                            CoffeesId = 4,
                            PropertiesId = 2
                        },
                        new
                        {
                            CoffeesId = 4,
                            PropertiesId = 9
                        },
                        new
                        {
                            CoffeesId = 5,
                            PropertiesId = 1
                        },
                        new
                        {
                            CoffeesId = 5,
                            PropertiesId = 3
                        },
                        new
                        {
                            CoffeesId = 5,
                            PropertiesId = 10
                        },
                        new
                        {
                            CoffeesId = 6,
                            PropertiesId = 11
                        },
                        new
                        {
                            CoffeesId = 6,
                            PropertiesId = 12
                        },
                        new
                        {
                            CoffeesId = 6,
                            PropertiesId = 13
                        },
                        new
                        {
                            CoffeesId = 7,
                            PropertiesId = 1
                        },
                        new
                        {
                            CoffeesId = 7,
                            PropertiesId = 14
                        },
                        new
                        {
                            CoffeesId = 7,
                            PropertiesId = 15
                        },
                        new
                        {
                            CoffeesId = 8,
                            PropertiesId = 1
                        },
                        new
                        {
                            CoffeesId = 8,
                            PropertiesId = 14
                        },
                        new
                        {
                            CoffeesId = 8,
                            PropertiesId = 16
                        },
                        new
                        {
                            CoffeesId = 9,
                            PropertiesId = 16
                        },
                        new
                        {
                            CoffeesId = 9,
                            PropertiesId = 17
                        },
                        new
                        {
                            CoffeesId = 9,
                            PropertiesId = 18
                        },
                        new
                        {
                            CoffeesId = 10,
                            PropertiesId = 19
                        },
                        new
                        {
                            CoffeesId = 10,
                            PropertiesId = 20
                        },
                        new
                        {
                            CoffeesId = 10,
                            PropertiesId = 13
                        },
                        new
                        {
                            CoffeesId = 11,
                            PropertiesId = 1
                        },
                        new
                        {
                            CoffeesId = 11,
                            PropertiesId = 12
                        },
                        new
                        {
                            CoffeesId = 11,
                            PropertiesId = 17
                        },
                        new
                        {
                            CoffeesId = 12,
                            PropertiesId = 21
                        },
                        new
                        {
                            CoffeesId = 12,
                            PropertiesId = 22
                        },
                        new
                        {
                            CoffeesId = 12,
                            PropertiesId = 23
                        },
                        new
                        {
                            CoffeesId = 13,
                            PropertiesId = 1
                        },
                        new
                        {
                            CoffeesId = 13,
                            PropertiesId = 14
                        },
                        new
                        {
                            CoffeesId = 13,
                            PropertiesId = 17
                        },
                        new
                        {
                            CoffeesId = 14,
                            PropertiesId = 2
                        },
                        new
                        {
                            CoffeesId = 14,
                            PropertiesId = 12
                        },
                        new
                        {
                            CoffeesId = 14,
                            PropertiesId = 24
                        },
                        new
                        {
                            CoffeesId = 15,
                            PropertiesId = 2
                        },
                        new
                        {
                            CoffeesId = 15,
                            PropertiesId = 20
                        },
                        new
                        {
                            CoffeesId = 15,
                            PropertiesId = 11
                        },
                        new
                        {
                            CoffeesId = 16,
                            PropertiesId = 13
                        },
                        new
                        {
                            CoffeesId = 16,
                            PropertiesId = 24
                        },
                        new
                        {
                            CoffeesId = 16,
                            PropertiesId = 19
                        },
                        new
                        {
                            CoffeesId = 17,
                            PropertiesId = 20
                        },
                        new
                        {
                            CoffeesId = 17,
                            PropertiesId = 13
                        },
                        new
                        {
                            CoffeesId = 17,
                            PropertiesId = 19
                        },
                        new
                        {
                            CoffeesId = 18,
                            PropertiesId = 5
                        },
                        new
                        {
                            CoffeesId = 18,
                            PropertiesId = 9
                        },
                        new
                        {
                            CoffeesId = 18,
                            PropertiesId = 20
                        });
                });

            modelBuilder.Entity("PE1.Webshop.Core.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ImageString")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageString = "~/images/roast-1.jpg",
                            Name = "Light Roast"
                        },
                        new
                        {
                            Id = 2,
                            ImageString = "~/images/roast-2.jpg",
                            Name = "Medium Roast"
                        },
                        new
                        {
                            Id = 3,
                            ImageString = "~/images/roast-3.jpg",
                            Name = "Dark Roast"
                        });
                });

            modelBuilder.Entity("PE1.Webshop.Core.Coffee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<bool>("CertifiedOrganic")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageString")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Origin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(6, 2)
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Coffees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CertifiedOrganic = true,
                            Description = "A floral and chocolatey coffee straight from small farmers in northern Nicaragua. Light Roast.",
                            ImageString = "~/images/sku-1.webp",
                            Name = "Cantagallo",
                            Origin = "Nicaragua",
                            Price = 20m
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            CertifiedOrganic = true,
                            Description = "A sweet, balanced blend of natural and wash-processed coffees creating one of our favorites. Light Roast.",
                            ImageString = "~/images/sku-2.webp",
                            Name = "La Flor",
                            Origin = "Ethiopia Sidama, Mexico, Nicargua",
                            Price = 20m
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            CertifiedOrganic = false,
                            Description = "Deep in the Andes of Perú, the founding farmers of Pachamama grow exceptional organic coffee. Medium Roast.",
                            ImageString = "~/images/sku-3.webp",
                            Name = "Perú",
                            Origin = "Santa Teresa, Cusco, Peru",
                            Price = 18.5m
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            CertifiedOrganic = true,
                            Description = "The northern mountains of Las Segovia, Nicaragua, are known for their quality coffee and strong cooperatives. Medium Roast.",
                            ImageString = "~/images/sku-4.webp",
                            Name = "Nicaragua",
                            Origin = "Río Coco, Nicaragua",
                            Price = 18.5m
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            CertifiedOrganic = true,
                            Description = "In the volcanic highlands of Veracruz, México, the terroir is ideal for growing exceptional coffee. Medium Roast.",
                            ImageString = "~/images/sku-5.webp",
                            Name = "México",
                            Origin = "Huatusco, Mexico",
                            Price = 19m
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            CertifiedOrganic = true,
                            Description = "Grown on the volcanic shores of Lago Atitlán, this is an exceptional single origin coffee from Guatemala. Medium Roast.",
                            ImageString = "~/images/sku-6.webp",
                            Name = "Guatemala",
                            Origin = "Santa Clara, Guatemala",
                            Price = 20m
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 3,
                            CertifiedOrganic = false,
                            Description = "A rich, bold and satisfying, our French Roast Blend is a great coffee for those that prefer a darker roast. French Roast.",
                            ImageString = "~/images/sku-7.webp",
                            Name = "French Roast",
                            Origin = "Peru, Mexico, Nicaragua",
                            Price = 17.5m
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 3,
                            CertifiedOrganic = true,
                            Description = "Our Decaf French Roast is Mountain Water Processed (MWP) in Mexico, without the use of chemicals. Dark Roast.",
                            ImageString = "~/images/sku-8.webp",
                            Name = "Decaf French",
                            Origin = "Huatusco, Mexico",
                            Price = 19m
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 3,
                            CertifiedOrganic = false,
                            Description = "Our darkest roast, a bold blend with a full body and rich flavor. Italian Roast.",
                            ImageString = "~/images/sku-9.webp",
                            Name = "Farmer's Blend",
                            Origin = "Peru, Mexico, Nicaragua",
                            Price = 17.5m
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 1,
                            CertifiedOrganic = true,
                            Description = "A fruity, natural processed coffee from the Sidama region. Light Roast.",
                            ImageString = "~/images/sku-10.webp",
                            Name = "Ethiopia Sidama Natural",
                            Origin = "Sidama, Ethiopia",
                            Price = 25m
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 2,
                            CertifiedOrganic = true,
                            Description = "Straight from the valley just below Machu Picchu, Perú, this single origin is roasted medium-dark. Vienna Roast.",
                            ImageString = "~/images/sku-11.webp",
                            Name = "Machu Picchu",
                            Origin = "Santa Teresa, Cusco, Peru",
                            Price = 18.5m
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 1,
                            CertifiedOrganic = false,
                            Description = "The blend formerly known as Breakfast, Sunrise is always a bright and uplifting start to the day. Light Roast.",
                            ImageString = "~/images/sku-12.webp",
                            Name = "Sunrise",
                            Origin = "Guatemala, Peru, Nicaragua",
                            Price = 18.5m
                        },
                        new
                        {
                            Id = 13,
                            CategoryId = 3,
                            CertifiedOrganic = false,
                            Description = "Pachamama's traditional, rich and bold roasted espresso blend. Full Roast.",
                            ImageString = "~/images/sku-13.webp",
                            Name = "Classic Espresso",
                            Origin = "Ethiopia Sidama, Peru",
                            Price = 20m
                        },
                        new
                        {
                            Id = 14,
                            CategoryId = 2,
                            CertifiedOrganic = false,
                            Description = "An all-time favorite and the perfect café de la casa, sure to please a crowd. Medium Roast.",
                            ImageString = "~/images/sku-14.webp",
                            Name = "Five Sisters",
                            Origin = "Ethiopia Yirgacheffe, Guatemala",
                            Price = 19m
                        },
                        new
                        {
                            Id = 15,
                            CategoryId = 2,
                            CertifiedOrganic = true,
                            Description = "Our Decaf Medium Roast is Mountain Water Processed (MWP) in Mexico, without the use of chemicals. Whole Beans.",
                            ImageString = "~/images/sku-15.webp",
                            Name = "Decaf México",
                            Origin = "Huatusco, Mexico",
                            Price = 19.5m
                        },
                        new
                        {
                            Id = 16,
                            CategoryId = 2,
                            CertifiedOrganic = false,
                            Description = "Celebrating our hometown Sacramento, a complex yet balanced blend of fruit forward coffees. Medium Roast.",
                            ImageString = "~/images/sku-16.webp",
                            Name = "Sactown",
                            Origin = "Ethiopia Sidama, Ethiopia Yirgacheffe, Guatemala, Mexico",
                            Price = 21m
                        },
                        new
                        {
                            Id = 17,
                            CategoryId = 3,
                            CertifiedOrganic = false,
                            Description = "A deep, smooth blend of natural and washed-processed coffee that's perfect for cold brewing. Full Roast.",
                            ImageString = "~/images/sku-17.webp",
                            Name = "Inca",
                            Origin = "Ethiopia Sidama, Guatemala, Mexico",
                            Price = 20m
                        },
                        new
                        {
                            Id = 18,
                            CategoryId = 1,
                            CertifiedOrganic = true,
                            Description = "A classic coffee from Yirgacheffe, crisp with layered complexity. Light Roast. Whole Beans.",
                            ImageString = "~/images/sku-18.webp",
                            Name = "Ethiopia Yirgacheffe",
                            Origin = "Yirgacheffe, Ethiopia",
                            Price = 24m
                        });
                });

            modelBuilder.Entity("PE1.Webshop.Core.Property", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Properties");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Chocolate"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Citrus"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Almond"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Vanilla"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Lemon"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Bright"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Cream"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Cherry"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Floral"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Orange"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Pear"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Caramel"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Cacao"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Bold"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Pecan nut"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Walnut"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Rich"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Butterscotch"
                        },
                        new
                        {
                            Id = 19,
                            Name = "Blackberry"
                        },
                        new
                        {
                            Id = 20,
                            Name = "Honey"
                        },
                        new
                        {
                            Id = 21,
                            Name = "Honeydew"
                        },
                        new
                        {
                            Id = 22,
                            Name = "Crisp"
                        },
                        new
                        {
                            Id = 23,
                            Name = "Lime"
                        },
                        new
                        {
                            Id = 24,
                            Name = "Balanced"
                        });
                });

            modelBuilder.Entity("PE1.Webshop.Core.ShoppingCartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CoffeeId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CoffeeId");

                    b.ToTable("ShoppingCartItems");
                });

            modelBuilder.Entity("PE1.Webshop.Core.VolunteerApplication", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ArrivalDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("NewsLetterSignUp")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("VolunteerApplications");
                });

            modelBuilder.Entity("CoffeeProperty", b =>
                {
                    b.HasOne("PE1.Webshop.Core.Coffee", null)
                        .WithMany()
                        .HasForeignKey("CoffeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PE1.Webshop.Core.Property", null)
                        .WithMany()
                        .HasForeignKey("PropertiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PE1.Webshop.Core.Coffee", b =>
                {
                    b.HasOne("PE1.Webshop.Core.Category", "Category")
                        .WithMany("Coffees")
                        .HasForeignKey("CategoryId")
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("PE1.Webshop.Core.ShoppingCartItem", b =>
                {
                    b.HasOne("PE1.Webshop.Core.Coffee", "Coffee")
                        .WithMany()
                        .HasForeignKey("CoffeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coffee");
                });

            modelBuilder.Entity("PE1.Webshop.Core.Category", b =>
                {
                    b.Navigation("Coffees");
                });
#pragma warning restore 612, 618
        }
    }
}
