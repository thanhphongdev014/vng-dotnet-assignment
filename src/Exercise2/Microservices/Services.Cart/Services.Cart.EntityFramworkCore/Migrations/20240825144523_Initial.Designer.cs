﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Services.Cart.EntityFrameworkCore.EntityFrameworkCore;

#nullable disable

namespace Services.Cart.EntityFrameworkCore.Migrations
{
    [DbContext(typeof(CartDbContext))]
    [Migration("20240825144523_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Services.Cart.EntityFrameworkCore.Models.CartModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Carts", "cart");
                });

            modelBuilder.Entity("Services.Cart.EntityFrameworkCore.Models.ListItem", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CardId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("ProductId", "CardId");

                    b.HasIndex("CardId");

                    b.ToTable("ListItems", "cart");
                });

            modelBuilder.Entity("Services.Cart.EntityFrameworkCore.Models.ListItem", b =>
                {
                    b.HasOne("Services.Cart.EntityFrameworkCore.Models.CartModel", "Cart")
                        .WithMany("ListItems")
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");
                });

            modelBuilder.Entity("Services.Cart.EntityFrameworkCore.Models.CartModel", b =>
                {
                    b.Navigation("ListItems");
                });
#pragma warning restore 612, 618
        }
    }
}
