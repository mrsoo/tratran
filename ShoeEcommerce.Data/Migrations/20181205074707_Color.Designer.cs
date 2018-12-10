﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoeEcommerce.Data;

namespace ShoeEcommerce.Data.Migrations
{
    [DbContext(typeof(ShoeEcommerceDBContext))]
    [Migration("20181205074707_Color")]
    partial class Color
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShoeEcommerce.Model.Accounts.Account", b =>
                {
                    b.Property<string>("idAccount")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10);

                    b.Property<string>("IdMerchant")
                        .HasMaxLength(10);

                    b.Property<string>("avt_path")
                        .IsRequired();

                    b.Property<string>("idCustomer")
                        .HasMaxLength(10);

                    b.Property<string>("passwd")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int>("rankVip");

                    b.Property<int>("rate");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("idAccount");

                    b.HasIndex("IdMerchant");

                    b.HasIndex("idCustomer");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("ShoeEcommerce.Model.Accounts.Address", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Addressid");

                    b.Property<string>("City_Provine")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("District_town")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("add_Info")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("idAccount")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("subDistrict")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("id");

                    b.HasIndex("Addressid");

                    b.HasIndex("idAccount");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("ShoeEcommerce.Model.Accounts.Email", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10);

                    b.Property<string>("Addressid");

                    b.Property<string>("IdAccount")
                        .HasMaxLength(10);

                    b.Property<string>("email");

                    b.HasKey("id");

                    b.HasIndex("Addressid");

                    b.HasIndex("IdAccount");

                    b.ToTable("Emails");
                });

            modelBuilder.Entity("ShoeEcommerce.Model.Accounts.RankVip", b =>
                {
                    b.Property<string>("idRank")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10);

                    b.Property<int>("viewRate");

                    b.HasKey("idRank");

                    b.ToTable("RankVips");
                });

            modelBuilder.Entity("ShoeEcommerce.Model.Advertisements.Advertisement", b =>
                {
                    b.Property<string>("idAdvertisement")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10);

                    b.Property<int?>("PositionidPosition");

                    b.Property<DateTime>("creat_date");

                    b.Property<int>("expire");

                    b.Property<string>("idAccount")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<int>("position");

                    b.HasKey("idAdvertisement");

                    b.HasIndex("PositionidPosition");

                    b.HasIndex("idAccount");

                    b.ToTable("Advertisements");
                });

            modelBuilder.Entity("ShoeEcommerce.Model.Advertisements.Position", b =>
                {
                    b.Property<int>("idPosition")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("height");

                    b.Property<float>("width");

                    b.HasKey("idPosition");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("ShoeEcommerce.Model.Bills.BillState", b =>
                {
                    b.Property<int>("idState")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("idState");

                    b.ToTable("BillStates");
                });

            modelBuilder.Entity("ShoeEcommerce.Model.Bills.ItemOrderList", b =>
                {
                    b.Property<string>("idList")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10);

                    b.Property<int>("avgRate");

                    b.Property<int>("count");

                    b.Property<string>("idOrder")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("idProduct")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.HasKey("idList");

                    b.HasIndex("idOrder");

                    b.HasIndex("idProduct");

                    b.ToTable("ItemOrderLists");
                });

            modelBuilder.Entity("ShoeEcommerce.Model.Bills.Order", b =>
                {
                    b.Property<string>("idOrder")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10);

                    b.Property<string>("AccountidAccount");

                    b.Property<string>("Addressid");

                    b.Property<int?>("BillStateidState");

                    b.Property<string>("IdSaleAcc")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<DateTime>("creat_date");

                    b.Property<string>("idBuyAcc")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<int>("idStt");

                    b.Property<double>("total");

                    b.HasKey("idOrder");

                    b.HasIndex("AccountidAccount");

                    b.HasIndex("Addressid");

                    b.HasIndex("BillStateidState");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ShoeEcommerce.Model.Bills.Rating", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cmt")
                        .IsRequired();

                    b.Property<string>("ItemOrderListidList");

                    b.Property<int>("idItemOrderList");

                    b.Property<int>("rateValue");

                    b.HasKey("id");

                    b.HasIndex("ItemOrderListidList");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("ShoeEcommerce.Model.Extensions.historySearch", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountidAccount");

                    b.Property<string>("idAcc")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("keyword");

                    b.HasKey("id");

                    b.HasIndex("AccountidAccount");

                    b.ToTable("HistorySearches");
                });

            modelBuilder.Entity("ShoeEcommerce.Model.OnlinePost.Post", b =>
                {
                    b.Property<string>("idPost")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10);

                    b.Property<DateTime>("create_date");

                    b.Property<int>("curRank");

                    b.Property<string>("idAcc")
                        .IsRequired();

                    b.HasKey("idPost");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("ShoeEcommerce.Model.OnlinePost.Show", b =>
                {
                    b.Property<string>("idShow")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10);

                    b.Property<string>("Intro");

                    b.Property<string>("idPost")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("idProduct")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.HasKey("idShow");

                    b.HasIndex("idPost");

                    b.HasIndex("idProduct");

                    b.ToTable("Shows");
                });

            modelBuilder.Entity("ShoeEcommerce.Model.Products.Brand", b =>
                {
                    b.Property<int>("IdBrand")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NameBrand")
                        .HasMaxLength(200);

                    b.HasKey("IdBrand");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("ShoeEcommerce.Model.Products.Category", b =>
                {
                    b.Property<string>("idCategory")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10);

                    b.Property<bool>("Sex");

                    b.Property<string>("link_imageCategory");

                    b.Property<string>("nameCategory")
                        .IsRequired();

                    b.HasKey("idCategory");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ShoeEcommerce.Model.Products.ImageProduct", b =>
                {
                    b.Property<string>("idImage")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10);

                    b.Property<string>("ProductidProduct");

                    b.Property<int>("idProduct");

                    b.Property<string>("link_Image")
                        .HasMaxLength(40);

                    b.HasKey("idImage");

                    b.HasIndex("ProductidProduct");

                    b.ToTable("ImageProducts");
                });

            modelBuilder.Entity("ShoeEcommerce.Model.Products.Product", b =>
                {
                    b.Property<string>("idProduct")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10);

                    b.Property<string>("Code")
                        .HasMaxLength(100);

                    b.Property<string>("Color")
                        .HasMaxLength(100);

                    b.Property<int>("Count");

                    b.Property<DateTime>("Creat_date");

                    b.Property<string>("Description")
                        .HasMaxLength(100);

                    b.Property<float>("Fee");

                    b.Property<bool>("Home");

                    b.Property<int>("IdBrand");

                    b.Property<string>("IdRepository")
                        .HasMaxLength(10);

                    b.Property<string>("Image")
                        .HasMaxLength(500);

                    b.Property<double>("OldPrice");

                    b.Property<double>("Price");

                    b.Property<bool>("Sex");

                    b.Property<int>("Size");

                    b.Property<bool>("Status");

                    b.Property<int>("View");

                    b.Property<string>("idAccount")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("idCategory")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("nameProduct");

                    b.HasKey("idProduct");

                    b.HasIndex("IdBrand");

                    b.HasIndex("IdRepository");

                    b.HasIndex("idAccount");

                    b.HasIndex("idCategory");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ShoeEcommerce.Model.Repositories.ExportForm", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10);

                    b.Property<DateTime>("creat_date");

                    b.Property<string>("idRepository")
                        .IsRequired();

                    b.Property<double>("total");

                    b.HasKey("id");

                    b.HasIndex("idRepository");

                    b.ToTable("ExportForms");
                });

            modelBuilder.Entity("ShoeEcommerce.Model.Repositories.ImportForm", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10);

                    b.Property<DateTime>("creat_date");

                    b.Property<string>("idRepository")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<double>("total");

                    b.HasKey("id");

                    b.HasIndex("idRepository");

                    b.ToTable("ImportForms");
                });

            modelBuilder.Entity("ShoeEcommerce.Model.Repositories.ItemEplist", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ExportFormid");

                    b.Property<string>("ProductidProduct");

                    b.Property<int>("count");

                    b.Property<int>("idEpform");

                    b.Property<int>("idProduct");

                    b.HasKey("id");

                    b.HasIndex("ExportFormid");

                    b.HasIndex("ProductidProduct");

                    b.ToTable("ItemEplists");
                });

            modelBuilder.Entity("ShoeEcommerce.Model.Repositories.ItemIplist", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImportFormid");

                    b.Property<int>("count");

                    b.Property<string>("idIpForm")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("idProduct")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.HasKey("id");

                    b.HasIndex("ImportFormid");

                    b.HasIndex("idProduct");

                    b.ToTable("ItemIplists");
                });

            modelBuilder.Entity("ShoeEcommerce.Model.Repositories.Repository", b =>
                {
                    b.Property<string>("idRepository")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<int>("Stt");

                    b.Property<string>("name")
                        .IsRequired();

                    b.HasKey("idRepository");

                    b.ToTable("Repositories");
                });

            modelBuilder.Entity("ShoeEcommerce.Model.Users.Customer", b =>
                {
                    b.Property<string>("idCustomer")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10);

                    b.Property<string>("fstname")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("lstname")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("phone")
                        .IsRequired();

                    b.HasKey("idCustomer");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ShoeEcommerce.Model.Users.Link_ImgStore", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10);

                    b.Property<string>("CustomeridCustomer");

                    b.Property<string>("idMerchant");

                    b.Property<string>("path")
                        .IsRequired();

                    b.HasKey("id");

                    b.HasIndex("CustomeridCustomer");

                    b.HasIndex("idMerchant");

                    b.ToTable("Link_ImgStores");
                });

            modelBuilder.Entity("ShoeEcommerce.Model.Users.Merchant", b =>
                {
                    b.Property<string>("idMerchant")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10);

                    b.Property<string>("fstname")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("lstname")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("phone")
                        .IsRequired();

                    b.Property<string>("storename")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("website");

                    b.HasKey("idMerchant");

                    b.ToTable("Merchants");
                });

            modelBuilder.Entity("ShoeEcommerce.Model.Accounts.Account", b =>
                {
                    b.HasOne("ShoeEcommerce.Model.Users.Merchant", "Merchant")
                        .WithMany("Accounts")
                        .HasForeignKey("IdMerchant");

                    b.HasOne("ShoeEcommerce.Model.Users.Customer", "Customer")
                        .WithMany("Accounts")
                        .HasForeignKey("idCustomer");
                });

            modelBuilder.Entity("ShoeEcommerce.Model.Accounts.Address", b =>
                {
                    b.HasOne("ShoeEcommerce.Model.Accounts.Address")
                        .WithMany("Addresses")
                        .HasForeignKey("Addressid");

                    b.HasOne("ShoeEcommerce.Model.Accounts.Account", "Account")
                        .WithMany()
                        .HasForeignKey("idAccount")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShoeEcommerce.Model.Accounts.Email", b =>
                {
                    b.HasOne("ShoeEcommerce.Model.Accounts.Address")
                        .WithMany("Emails")
                        .HasForeignKey("Addressid");

                    b.HasOne("ShoeEcommerce.Model.Accounts.Account", "Account")
                        .WithMany()
                        .HasForeignKey("IdAccount");
                });

            modelBuilder.Entity("ShoeEcommerce.Model.Advertisements.Advertisement", b =>
                {
                    b.HasOne("ShoeEcommerce.Model.Advertisements.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionidPosition");

                    b.HasOne("ShoeEcommerce.Model.Accounts.Account", "Account")
                        .WithMany("Advertisements")
                        .HasForeignKey("idAccount")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShoeEcommerce.Model.Bills.ItemOrderList", b =>
                {
                    b.HasOne("ShoeEcommerce.Model.Bills.Order", "Order")
                        .WithMany()
                        .HasForeignKey("idOrder")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShoeEcommerce.Model.Products.Product", "Product")
                        .WithMany("ItemOrderLists")
                        .HasForeignKey("idProduct")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShoeEcommerce.Model.Bills.Order", b =>
                {
                    b.HasOne("ShoeEcommerce.Model.Accounts.Account")
                        .WithMany("Orders")
                        .HasForeignKey("AccountidAccount");

                    b.HasOne("ShoeEcommerce.Model.Accounts.Address")
                        .WithMany("Orders")
                        .HasForeignKey("Addressid");

                    b.HasOne("ShoeEcommerce.Model.Bills.BillState", "BillState")
                        .WithMany("Orders")
                        .HasForeignKey("BillStateidState");
                });

            modelBuilder.Entity("ShoeEcommerce.Model.Bills.Rating", b =>
                {
                    b.HasOne("ShoeEcommerce.Model.Bills.ItemOrderList", "ItemOrderList")
                        .WithMany("Ratings")
                        .HasForeignKey("ItemOrderListidList");
                });

            modelBuilder.Entity("ShoeEcommerce.Model.Extensions.historySearch", b =>
                {
                    b.HasOne("ShoeEcommerce.Model.Accounts.Account", "Account")
                        .WithMany("HistorySearches")
                        .HasForeignKey("AccountidAccount");
                });

            modelBuilder.Entity("ShoeEcommerce.Model.OnlinePost.Show", b =>
                {
                    b.HasOne("ShoeEcommerce.Model.OnlinePost.Post", "Post")
                        .WithMany("Shows")
                        .HasForeignKey("idPost")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShoeEcommerce.Model.Products.Product", "Products")
                        .WithMany("Shows")
                        .HasForeignKey("idProduct")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShoeEcommerce.Model.Products.ImageProduct", b =>
                {
                    b.HasOne("ShoeEcommerce.Model.Products.Product", "Product")
                        .WithMany("ImageProducts")
                        .HasForeignKey("ProductidProduct");
                });

            modelBuilder.Entity("ShoeEcommerce.Model.Products.Product", b =>
                {
                    b.HasOne("ShoeEcommerce.Model.Products.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("IdBrand")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShoeEcommerce.Model.Repositories.Repository", "Repository")
                        .WithMany("Product")
                        .HasForeignKey("IdRepository");

                    b.HasOne("ShoeEcommerce.Model.Accounts.Account", "Account")
                        .WithMany("Products")
                        .HasForeignKey("idAccount")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShoeEcommerce.Model.Products.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("idCategory")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShoeEcommerce.Model.Repositories.ExportForm", b =>
                {
                    b.HasOne("ShoeEcommerce.Model.Repositories.Repository", "Repository")
                        .WithMany()
                        .HasForeignKey("idRepository")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShoeEcommerce.Model.Repositories.ImportForm", b =>
                {
                    b.HasOne("ShoeEcommerce.Model.Repositories.Repository", "Repository")
                        .WithMany("ImportForms")
                        .HasForeignKey("idRepository")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShoeEcommerce.Model.Repositories.ItemEplist", b =>
                {
                    b.HasOne("ShoeEcommerce.Model.Repositories.ExportForm", "ExportForm")
                        .WithMany("ItemExlists")
                        .HasForeignKey("ExportFormid");

                    b.HasOne("ShoeEcommerce.Model.Products.Product", "Product")
                        .WithMany("ItemEpLists")
                        .HasForeignKey("ProductidProduct");
                });

            modelBuilder.Entity("ShoeEcommerce.Model.Repositories.ItemIplist", b =>
                {
                    b.HasOne("ShoeEcommerce.Model.Repositories.ImportForm", "ImportForm")
                        .WithMany("ItemIplists")
                        .HasForeignKey("ImportFormid");

                    b.HasOne("ShoeEcommerce.Model.Products.Product", "Product")
                        .WithMany("ItemIpLists")
                        .HasForeignKey("idProduct")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShoeEcommerce.Model.Users.Link_ImgStore", b =>
                {
                    b.HasOne("ShoeEcommerce.Model.Users.Customer")
                        .WithMany("Link_ImgStores")
                        .HasForeignKey("CustomeridCustomer");

                    b.HasOne("ShoeEcommerce.Model.Users.Merchant", "Merchant")
                        .WithMany()
                        .HasForeignKey("idMerchant");
                });
#pragma warning restore 612, 618
        }
    }
}