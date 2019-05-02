﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ventas.Data;

namespace ventas.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190427005317_26042019_Create_tables_Sale_SaleDetails_V2")]
    partial class _26042019_Create_tables_Sale_SaleDetails_V2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ventas.Models.Articulo", b =>
                {
                    b.Property<int>("ArticuloID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoriaID");

                    b.Property<string>("Codigo");

                    b.Property<string>("Descripcion")
                        .HasColumnType("text");

                    b.Property<byte>("Estado")
                        .HasColumnType("tinyint");

                    b.Property<string>("Nombre");

                    b.Property<int>("Stock");

                    b.Property<int?>("UbicacionID");

                    b.HasKey("ArticuloID");

                    b.HasIndex("CategoriaID");

                    b.HasIndex("UbicacionID");

                    b.ToTable("Articulo");
                });

            modelBuilder.Entity("ventas.Models.Categoria", b =>
                {
                    b.Property<int>("CategoriaID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("Condicion")
                        .HasColumnType("tinyint");

                    b.Property<string>("Descripcion")
                        .HasColumnType("text");

                    b.Property<string>("Nombre");

                    b.HasKey("CategoriaID");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("ventas.Models.Comprobante", b =>
                {
                    b.Property<int>("ComprobanteID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Numero");

                    b.Property<string>("Serie");

                    b.Property<string>("Tipo");

                    b.HasKey("ComprobanteID");

                    b.ToTable("Comprobante");
                });

            modelBuilder.Entity("ventas.Models.DetalleIngreso", b =>
                {
                    b.Property<int>("DetalleIngresoID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArticuloID");

                    b.Property<int>("Cantidad");

                    b.Property<int>("IngresoID");

                    b.Property<decimal>("PrecioCompra")
                        .HasColumnType("money");

                    b.Property<decimal>("PrecioVenta")
                        .HasColumnType("money");

                    b.HasKey("DetalleIngresoID");

                    b.HasIndex("ArticuloID");

                    b.HasIndex("IngresoID");

                    b.ToTable("DetalleIngreso");
                });

            modelBuilder.Entity("ventas.Models.Ingreso", b =>
                {
                    b.Property<int>("IngresoID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ComprobanteID");

                    b.Property<byte>("Estado")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("Date");

                    b.Property<int>("Impuesto");

                    b.Property<int>("PersonaID");

                    b.Property<TimeSpan>("hora")
                        .HasColumnType("time");

                    b.HasKey("IngresoID");

                    b.HasIndex("ComprobanteID");

                    b.HasIndex("PersonaID");

                    b.ToTable("Ingreso");
                });

            modelBuilder.Entity("ventas.Models.Persona", b =>
                {
                    b.Property<int>("PersonaID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Direccion");

                    b.Property<string>("Email");

                    b.Property<string>("Nombre");

                    b.Property<int>("NumeroDocumento");

                    b.Property<string>("Telefono");

                    b.Property<byte>("TipoDocumento")
                        .HasColumnType("tinyint");

                    b.Property<byte>("TipoPersona")
                        .HasColumnType("tinyint");

                    b.HasKey("PersonaID");

                    b.ToTable("Persona");
                });

            modelBuilder.Entity("ventas.Models.Sale", b =>
                {
                    b.Property<int>("SaleID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ComprobanteID");

                    b.Property<byte>("Estado")
                        .HasColumnType("Tinyint");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("Date");

                    b.Property<TimeSpan>("Hora")
                        .HasColumnType("Time");

                    b.Property<int>("Impuesto");

                    b.Property<int>("PersonaID");

                    b.HasKey("SaleID");

                    b.HasIndex("ComprobanteID");

                    b.HasIndex("PersonaID");

                    b.ToTable("Sale");
                });

            modelBuilder.Entity("ventas.Models.SaleDetail", b =>
                {
                    b.Property<int>("SaleDetailID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArticuloID");

                    b.Property<int>("Cantidad");

                    b.Property<decimal>("PrecioVenta")
                        .HasColumnType("Money");

                    b.Property<int>("SaleID");

                    b.HasKey("SaleDetailID");

                    b.HasIndex("ArticuloID");

                    b.HasIndex("SaleID");

                    b.ToTable("SaleDetail");
                });

            modelBuilder.Entity("ventas.Models.Ubicacion", b =>
                {
                    b.Property<int>("UbicacionID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("text");

                    b.Property<byte>("Estado")
                        .HasColumnType("tinyint");

                    b.Property<string>("Nombre");

                    b.HasKey("UbicacionID");

                    b.ToTable("Ubicacion");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ventas.Models.Articulo", b =>
                {
                    b.HasOne("ventas.Models.Categoria", "categoria")
                        .WithMany("Articulos")
                        .HasForeignKey("CategoriaID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ventas.Models.Ubicacion", "ubicacion")
                        .WithMany("articulo")
                        .HasForeignKey("UbicacionID");
                });

            modelBuilder.Entity("ventas.Models.DetalleIngreso", b =>
                {
                    b.HasOne("ventas.Models.Articulo", "articulo")
                        .WithMany("DetalleIngresos")
                        .HasForeignKey("ArticuloID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ventas.Models.Ingreso", "ingreso")
                        .WithMany("DetalleIngresos")
                        .HasForeignKey("IngresoID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ventas.Models.Ingreso", b =>
                {
                    b.HasOne("ventas.Models.Comprobante", "comprobante")
                        .WithMany("Ingresos")
                        .HasForeignKey("ComprobanteID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ventas.Models.Persona", "persona")
                        .WithMany("ingresos")
                        .HasForeignKey("PersonaID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ventas.Models.Sale", b =>
                {
                    b.HasOne("ventas.Models.Comprobante", "comprobante")
                        .WithMany("Sales")
                        .HasForeignKey("ComprobanteID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ventas.Models.Persona", "persona")
                        .WithMany("Sales")
                        .HasForeignKey("PersonaID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ventas.Models.SaleDetail", b =>
                {
                    b.HasOne("ventas.Models.Articulo", "articulo")
                        .WithMany("SaleDetails")
                        .HasForeignKey("ArticuloID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ventas.Models.Sale", "sale")
                        .WithMany("saleDetails")
                        .HasForeignKey("SaleID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
