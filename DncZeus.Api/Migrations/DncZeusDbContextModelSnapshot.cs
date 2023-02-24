﻿// <auto-generated />
using System;
using DncZeus.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DncZeus.Api.Migrations
{
    [DbContext(typeof(DncZeusDbContext))]
    partial class DncZeusDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DncZeus.Api.Entities.DncIcon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Color")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("CreatedByUserGuid")
                        .HasColumnType("char(36)");

                    b.Property<string>("CreatedByUserName")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Custom")
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Description")
                        .HasMaxLength(800)
                        .HasColumnType("varchar(800)");

                    b.Property<int>("IsDeleted")
                        .HasColumnType("int");

                    b.Property<Guid?>("ModifiedByUserGuid")
                        .HasColumnType("char(36)");

                    b.Property<string>("ModifiedByUserName")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Size")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DncIcon");
                });

            modelBuilder.Entity("DncZeus.Api.Entities.DncMenu", b =>
                {
                    b.Property<Guid>("Guid")
                        .HasColumnType("char(36)");

                    b.Property<string>("Alias")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("BeforeCloseFun")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Component")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("CreatedByUserGuid")
                        .HasColumnType("char(36)");

                    b.Property<string>("CreatedByUserName")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasMaxLength(800)
                        .HasColumnType("varchar(800)");

                    b.Property<int?>("HideInMenu")
                        .HasColumnType("int");

                    b.Property<string>("Icon")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<int>("IsDefaultRouter")
                        .HasColumnType("int");

                    b.Property<int>("IsDeleted")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<Guid?>("ModifiedByUserGuid")
                        .HasColumnType("char(36)");

                    b.Property<string>("ModifiedByUserName")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("NotCache")
                        .HasColumnType("int");

                    b.Property<Guid?>("ParentGuid")
                        .HasColumnType("char(36)");

                    b.Property<string>("ParentName")
                        .HasColumnType("longtext");

                    b.Property<int>("Sort")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Guid");

                    b.ToTable("DncMenu");
                });

            modelBuilder.Entity("DncZeus.Api.Entities.DncPermission", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("ActionCode")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<Guid>("CreatedByUserGuid")
                        .HasColumnType("char(36)");

                    b.Property<string>("CreatedByUserName")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasMaxLength(800)
                        .HasColumnType("varchar(800)");

                    b.Property<string>("Icon")
                        .HasColumnType("longtext");

                    b.Property<int>("IsDeleted")
                        .HasColumnType("int");

                    b.Property<Guid>("MenuGuid")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("ModifiedByUserGuid")
                        .HasColumnType("char(36)");

                    b.Property<string>("ModifiedByUserName")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Code");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("MenuGuid");

                    b.ToTable("DncPermission");
                });

            modelBuilder.Entity("DncZeus.Api.Entities.DncRole", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("CreatedByUserGuid")
                        .HasColumnType("char(36)");

                    b.Property<string>("CreatedByUserName")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasMaxLength(800)
                        .HasColumnType("varchar(800)");

                    b.Property<bool>("IsBuiltin")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("IsDeleted")
                        .HasColumnType("int");

                    b.Property<bool>("IsSuperAdministrator")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid?>("ModifiedByUserGuid")
                        .HasColumnType("char(36)");

                    b.Property<string>("ModifiedByUserName")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Code");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("DncRole");
                });

            modelBuilder.Entity("DncZeus.Api.Entities.DncRolePermissionMapping", b =>
                {
                    b.Property<string>("RoleCode")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PermissionCode")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.HasKey("RoleCode", "PermissionCode");

                    b.HasIndex("PermissionCode");

                    b.ToTable("DncRolePermissionMapping");
                });

            modelBuilder.Entity("DncZeus.Api.Entities.DncUser", b =>
                {
                    b.Property<Guid>("Guid")
                        .HasColumnType("char(36)");

                    b.Property<string>("Avatar")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("CreatedByUserGuid")
                        .HasColumnType("char(36)");

                    b.Property<string>("CreatedByUserName")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasMaxLength(800)
                        .HasColumnType("varchar(800)");

                    b.Property<string>("DisplayName")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("IsDeleted")
                        .HasColumnType("int");

                    b.Property<int>("IsLocked")
                        .HasColumnType("int");

                    b.Property<string>("LoginName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid?>("ModifiedByUserGuid")
                        .HasColumnType("char(36)");

                    b.Property<string>("ModifiedByUserName")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Password")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("Guid");

                    b.ToTable("DncUser");
                });

            modelBuilder.Entity("DncZeus.Api.Entities.DncUserRoleMapping", b =>
                {
                    b.Property<Guid>("UserGuid")
                        .HasColumnType("char(36)");

                    b.Property<string>("RoleCode")
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.HasKey("UserGuid", "RoleCode");

                    b.HasIndex("RoleCode");

                    b.ToTable("DncUserRoleMapping");
                });

            modelBuilder.Entity("DncZeus.Api.Entities.DncPermission", b =>
                {
                    b.HasOne("DncZeus.Api.Entities.DncMenu", "Menu")
                        .WithMany("Permissions")
                        .HasForeignKey("MenuGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");
                });

            modelBuilder.Entity("DncZeus.Api.Entities.DncRolePermissionMapping", b =>
                {
                    b.HasOne("DncZeus.Api.Entities.DncPermission", "DncPermission")
                        .WithMany("Roles")
                        .HasForeignKey("PermissionCode")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DncZeus.Api.Entities.DncRole", "DncRole")
                        .WithMany("Permissions")
                        .HasForeignKey("RoleCode")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("DncPermission");

                    b.Navigation("DncRole");
                });

            modelBuilder.Entity("DncZeus.Api.Entities.DncUserRoleMapping", b =>
                {
                    b.HasOne("DncZeus.Api.Entities.DncRole", "DncRole")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleCode")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DncZeus.Api.Entities.DncUser", "DncUser")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserGuid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("DncRole");

                    b.Navigation("DncUser");
                });

            modelBuilder.Entity("DncZeus.Api.Entities.DncMenu", b =>
                {
                    b.Navigation("Permissions");
                });

            modelBuilder.Entity("DncZeus.Api.Entities.DncPermission", b =>
                {
                    b.Navigation("Roles");
                });

            modelBuilder.Entity("DncZeus.Api.Entities.DncRole", b =>
                {
                    b.Navigation("Permissions");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("DncZeus.Api.Entities.DncUser", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
