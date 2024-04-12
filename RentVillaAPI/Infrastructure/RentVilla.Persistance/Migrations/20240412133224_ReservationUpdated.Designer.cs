﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RentVilla.Persistance.Contexts;

#nullable disable

namespace RentVilla.Persistence.Migrations
{
    [DbContext(typeof(RentVillaDbContext))]
    [Migration("20240412133224_ReservationUpdated")]
    partial class ReservationUpdated
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ProductProductImageFile", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductImageFilesId")
                        .HasColumnType("uuid");

                    b.HasKey("ProductId", "ProductImageFilesId");

                    b.HasIndex("ProductImageFilesId");

                    b.ToTable("ProductProductImageFile");
                });

            modelBuilder.Entity("ProductReservation", b =>
                {
                    b.Property<Guid>("ProductsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ReservationsId")
                        .HasColumnType("uuid");

                    b.HasKey("ProductsId", "ReservationsId");

                    b.HasIndex("ReservationsId");

                    b.ToTable("ProductReservation");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Attribute.AttributeType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AttributeTypes");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Attribute.Attributes", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AttributeTypeId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("AttributeTypeId");

                    b.ToTable("Attributes");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Attribute.ProductAttribute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AttributeTypeId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AttributesId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("AttributeTypeId");

                    b.HasIndex("AttributesId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductAttributes");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Cart.ReservationCart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ReservationCarts");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Cart.ReservationCartItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AdultNumber")
                        .HasColumnType("integer");

                    b.Property<int>("ChildrenNumber")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Note")
                        .HasColumnType("text");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("numeric");

                    b.Property<Guid>("ReservationCartId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("ReservationCartId");

                    b.ToTable("ReservationCartItems");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.File", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FileName")
                        .HasColumnType("text");

                    b.Property<string>("Path")
                        .HasColumnType("text");

                    b.Property<string>("Storage")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Files");

                    b.HasDiscriminator<string>("Discriminator").HasValue("File");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Identity.AppRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Identity.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("text");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("text");

                    b.Property<DateTime?>("RefreshTokenEndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("Deposit")
                        .HasColumnType("numeric");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("MapId")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("Properties")
                        .HasColumnType("text");

                    b.Property<string>("Rating")
                        .HasColumnType("text");

                    b.Property<int>("ShortestRentPeriod")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Region.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid>("StateId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Region.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Region.District", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CityId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Region.ProductAddress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CityId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("DistrictId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("StateId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CountryId");

                    b.HasIndex("DistrictId");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.HasIndex("StateId");

                    b.ToTable("ProductAddresses");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Region.State", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("States");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Region.UserAddress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AppUserId")
                        .HasColumnType("text");

                    b.Property<Guid?>("CityId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("DistrictId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("StateId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId")
                        .IsUnique();

                    b.HasIndex("CityId");

                    b.HasIndex("DistrictId");

                    b.HasIndex("StateId");

                    b.ToTable("UserAddress");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Reservation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AdultNumber")
                        .HasColumnType("integer");

                    b.Property<string>("AppUserId")
                        .HasColumnType("text");

                    b.Property<int>("ChildrenNumber")
                        .HasColumnType("integer");

                    b.Property<string>("ConversationId")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Note")
                        .HasColumnType("text");

                    b.Property<string>("PaymentId")
                        .HasColumnType("text");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("text");

                    b.Property<int>("PaymentType")
                        .HasColumnType("integer");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("StateStateImageFile", b =>
                {
                    b.Property<Guid>("StateImageFilesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("StatesId")
                        .HasColumnType("uuid");

                    b.HasKey("StateImageFilesId", "StatesId");

                    b.HasIndex("StatesId");

                    b.ToTable("StateStateImageFile");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.ProductImageFile", b =>
                {
                    b.HasBaseType("RentVilla.Domain.Entities.Concrete.File");

                    b.HasDiscriminator().HasValue("ProductImageFile");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Region.StateImageFile", b =>
                {
                    b.HasBaseType("RentVilla.Domain.Entities.Concrete.File");

                    b.HasDiscriminator().HasValue("StateImageFile");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("RentVilla.Domain.Entities.Concrete.Identity.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("RentVilla.Domain.Entities.Concrete.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("RentVilla.Domain.Entities.Concrete.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("RentVilla.Domain.Entities.Concrete.Identity.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentVilla.Domain.Entities.Concrete.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("RentVilla.Domain.Entities.Concrete.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProductProductImageFile", b =>
                {
                    b.HasOne("RentVilla.Domain.Entities.Concrete.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentVilla.Domain.Entities.Concrete.ProductImageFile", null)
                        .WithMany()
                        .HasForeignKey("ProductImageFilesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProductReservation", b =>
                {
                    b.HasOne("RentVilla.Domain.Entities.Concrete.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentVilla.Domain.Entities.Concrete.Reservation", null)
                        .WithMany()
                        .HasForeignKey("ReservationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Attribute.Attributes", b =>
                {
                    b.HasOne("RentVilla.Domain.Entities.Concrete.Attribute.AttributeType", "AttributeType")
                        .WithMany("Attributes")
                        .HasForeignKey("AttributeTypeId");

                    b.Navigation("AttributeType");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Attribute.ProductAttribute", b =>
                {
                    b.HasOne("RentVilla.Domain.Entities.Concrete.Attribute.AttributeType", "AttributeType")
                        .WithMany()
                        .HasForeignKey("AttributeTypeId");

                    b.HasOne("RentVilla.Domain.Entities.Concrete.Attribute.Attributes", "Attributes")
                        .WithMany()
                        .HasForeignKey("AttributesId");

                    b.HasOne("RentVilla.Domain.Entities.Concrete.Product", "Product")
                        .WithMany("Attributes")
                        .HasForeignKey("ProductId");

                    b.Navigation("AttributeType");

                    b.Navigation("Attributes");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Cart.ReservationCart", b =>
                {
                    b.HasOne("RentVilla.Domain.Entities.Concrete.Identity.AppUser", "User")
                        .WithMany("Carts")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Cart.ReservationCartItem", b =>
                {
                    b.HasOne("RentVilla.Domain.Entities.Concrete.Product", "Product")
                        .WithMany("CartItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentVilla.Domain.Entities.Concrete.Cart.ReservationCart", "ReservationCart")
                        .WithMany("CartItems")
                        .HasForeignKey("ReservationCartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ReservationCart");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Region.City", b =>
                {
                    b.HasOne("RentVilla.Domain.Entities.Concrete.Region.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Region.District", b =>
                {
                    b.HasOne("RentVilla.Domain.Entities.Concrete.Region.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Region.ProductAddress", b =>
                {
                    b.HasOne("RentVilla.Domain.Entities.Concrete.Region.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentVilla.Domain.Entities.Concrete.Region.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentVilla.Domain.Entities.Concrete.Region.District", "District")
                        .WithMany()
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentVilla.Domain.Entities.Concrete.Product", "Product")
                        .WithOne("ProductAddress")
                        .HasForeignKey("RentVilla.Domain.Entities.Concrete.Region.ProductAddress", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentVilla.Domain.Entities.Concrete.Region.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Country");

                    b.Navigation("District");

                    b.Navigation("Product");

                    b.Navigation("State");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Region.State", b =>
                {
                    b.HasOne("RentVilla.Domain.Entities.Concrete.Region.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Region.UserAddress", b =>
                {
                    b.HasOne("RentVilla.Domain.Entities.Concrete.Identity.AppUser", "AppUser")
                        .WithOne("UserAddress")
                        .HasForeignKey("RentVilla.Domain.Entities.Concrete.Region.UserAddress", "AppUserId");

                    b.HasOne("RentVilla.Domain.Entities.Concrete.Region.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("RentVilla.Domain.Entities.Concrete.Region.District", "District")
                        .WithMany()
                        .HasForeignKey("DistrictId");

                    b.HasOne("RentVilla.Domain.Entities.Concrete.Region.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId");

                    b.Navigation("AppUser");

                    b.Navigation("City");

                    b.Navigation("District");

                    b.Navigation("State");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Reservation", b =>
                {
                    b.HasOne("RentVilla.Domain.Entities.Concrete.Identity.AppUser", "AppUser")
                        .WithMany("Reservations")
                        .HasForeignKey("AppUserId");

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("StateStateImageFile", b =>
                {
                    b.HasOne("RentVilla.Domain.Entities.Concrete.Region.StateImageFile", null)
                        .WithMany()
                        .HasForeignKey("StateImageFilesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentVilla.Domain.Entities.Concrete.Region.State", null)
                        .WithMany()
                        .HasForeignKey("StatesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Attribute.AttributeType", b =>
                {
                    b.Navigation("Attributes");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Cart.ReservationCart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Identity.AppUser", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("Reservations");

                    b.Navigation("UserAddress");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Product", b =>
                {
                    b.Navigation("Attributes");

                    b.Navigation("CartItems");

                    b.Navigation("ProductAddress");
                });
#pragma warning restore 612, 618
        }
    }
}
