﻿// <auto-generated />
using System;
using EyePocket.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EyePocket.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EyePocket.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("EyePocket.Models.CXP", b =>
                {
                    b.Property<int>("CuentaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CuentaId"));

                    b.Property<int>("EstadoCXPId")
                        .HasColumnType("int");

                    b.Property<int>("FacturaId")
                        .HasColumnType("int");

                    b.Property<int>("MetodoPagoId")
                        .HasColumnType("int");

                    b.Property<decimal>("SaldoPendiente")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("UltimoPago")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CuentaId");

                    b.HasIndex("EstadoCXPId");

                    b.HasIndex("MetodoPagoId");

                    b.ToTable("CXP");
                });

            modelBuilder.Entity("EyePocket.Models.Clientes", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"));

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteId");

                    b.HasIndex("EstadoId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("EyePocket.Models.Compras", b =>
                {
                    b.Property<int>("CompraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompraId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.Property<int>("ProvedorId")
                        .HasColumnType("int");

                    b.HasKey("CompraId");

                    b.HasIndex("EstadoId");

                    b.HasIndex("ProvedorId");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("EyePocket.Models.EstadoCXP", b =>
                {
                    b.Property<int>("EstadoCXPId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EstadoCXPId"));

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EstadoCXPId");

                    b.ToTable("EstadoCXP");

                    b.HasData(
                        new
                        {
                            EstadoCXPId = 1,
                            descripcion = "Pagada"
                        },
                        new
                        {
                            EstadoCXPId = 2,
                            descripcion = "Pendiente"
                        },
                        new
                        {
                            EstadoCXPId = 3,
                            descripcion = "Retrasada"
                        },
                        new
                        {
                            EstadoCXPId = 4,
                            descripcion = "Aceptada"
                        },
                        new
                        {
                            EstadoCXPId = 5,
                            descripcion = "Rechazada"
                        });
                });

            modelBuilder.Entity("EyePocket.Models.EstadoOrdenCompra", b =>
                {
                    b.Property<int>("EstadoOdId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EstadoOdId"));

                    b.Property<string>("descripcionEstado")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EstadoOdId");

                    b.ToTable("estadoOdCompra");

                    b.HasData(
                        new
                        {
                            EstadoOdId = 1,
                            descripcionEstado = "Realizada"
                        },
                        new
                        {
                            EstadoOdId = 2,
                            descripcionEstado = "Aprobada"
                        },
                        new
                        {
                            EstadoOdId = 3,
                            descripcionEstado = "Enviada"
                        },
                        new
                        {
                            EstadoOdId = 4,
                            descripcionEstado = "Facturada"
                        },
                        new
                        {
                            EstadoOdId = 5,
                            descripcionEstado = "Rechazada"
                        },
                        new
                        {
                            EstadoOdId = 6,
                            descripcionEstado = "Recibida"
                        },
                        new
                        {
                            EstadoOdId = 7,
                            descripcionEstado = "Cerrada"
                        });
                });

            modelBuilder.Entity("EyePocket.Models.Estados", b =>
                {
                    b.Property<int>("EstadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EstadoId"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EstadoId");

                    b.ToTable("Estados");

                    b.HasData(
                        new
                        {
                            EstadoId = 1,
                            Nombre = "Pendientes"
                        },
                        new
                        {
                            EstadoId = 2,
                            Nombre = "Aprobado"
                        },
                        new
                        {
                            EstadoId = 3,
                            Nombre = "Aceptada"
                        },
                        new
                        {
                            EstadoId = 4,
                            Nombre = "Cancelada"
                        },
                        new
                        {
                            EstadoId = 5,
                            Nombre = "Rechazada"
                        });
                });

            modelBuilder.Entity("EyePocket.Models.MetodoPago", b =>
                {
                    b.Property<int>("MetodoPagoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MetodoPagoId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MetodoPagoId");

                    b.ToTable("MetodoPagos");

                    b.HasData(
                        new
                        {
                            MetodoPagoId = 1,
                            Descripcion = "Pago por Cuota"
                        },
                        new
                        {
                            MetodoPagoId = 2,
                            Descripcion = "Efectivo"
                        },
                        new
                        {
                            MetodoPagoId = 3,
                            Descripcion = "Transferencia Bancaria"
                        },
                        new
                        {
                            MetodoPagoId = 4,
                            Descripcion = "Tarjeta de crédito"
                        },
                        new
                        {
                            MetodoPagoId = 5,
                            Descripcion = "Cheque"
                        });
                });

            modelBuilder.Entity("EyePocket.Models.OrdenCompra", b =>
                {
                    b.Property<int>("OrdenCompraID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrdenCompraID"));

                    b.Property<int>("EstadoOdId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaEmision")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaVencimiento")
                        .HasColumnType("datetime2");

                    b.Property<double>("MontoTotal")
                        .HasColumnType("float");

                    b.Property<string>("NumeroFactura")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProveedorId")
                        .HasColumnType("int");

                    b.HasKey("OrdenCompraID");

                    b.HasIndex("EstadoOdId");

                    b.HasIndex("ProveedorId");

                    b.ToTable("ordenCompra");
                });

            modelBuilder.Entity("EyePocket.Models.OrdenCompraDetalle", b =>
                {
                    b.Property<int>("OdDetalleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OdDetalleID"));

                    b.Property<int>("OrdenCompraID")
                        .HasColumnType("int");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<double>("SubTotal")
                        .HasColumnType("float");

                    b.Property<int>("cantidad")
                        .HasColumnType("int");

                    b.HasKey("OdDetalleID");

                    b.HasIndex("OrdenCompraID");

                    b.HasIndex("ProductoId");

                    b.ToTable("ordenCompraDetalles");
                });

            modelBuilder.Entity("EyePocket.Models.Productos", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductoId"));

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Costo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Descuento")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Proveedor")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductoId");

                    b.ToTable("Productos");

                    b.HasData(
                        new
                        {
                            ProductoId = 1,
                            Categoria = "Comestibles",
                            Codigo = "5334",
                            Costo = 344m,
                            Descripcion = "Galletas",
                            Descuento = 200m,
                            FechaIngreso = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Galletas Princesa",
                            Precio = 123m,
                            Proveedor = "Club Crackers"
                        },
                        new
                        {
                            ProductoId = 2,
                            Categoria = "Bebibas",
                            Codigo = "8254",
                            Costo = 345m,
                            Descripcion = "Jugo",
                            Descuento = 654m,
                            FechaIngreso = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Jugo Santal",
                            Precio = 234m,
                            Proveedor = "Santal"
                        },
                        new
                        {
                            ProductoId = 3,
                            Categoria = "Comestibles",
                            Codigo = "7259",
                            Costo = 643m,
                            Descripcion = "salami",
                            Descuento = 523m,
                            FechaIngreso = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Salami Mortadela",
                            Precio = 156m,
                            Proveedor = "Induveca"
                        },
                        new
                        {
                            ProductoId = 4,
                            Categoria = "Toallas humedas",
                            Codigo = "3842",
                            Costo = 764m,
                            Descripcion = "Toallas",
                            Descuento = 402m,
                            FechaIngreso = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Toallitas Nosotras",
                            Precio = 564m,
                            Proveedor = "Nosotras"
                        });
                });

            modelBuilder.Entity("EyePocket.Models.Provedores", b =>
                {
                    b.Property<int>("ProvedorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProvedorId"));

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProvedorId");

                    b.ToTable("Provedores");
                });

            modelBuilder.Entity("EyePocket.Models.Tickets", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketId"));

                    b.Property<string>("Asunto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreAgente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prioridad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TicketId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("EyePocket.Models.CXP", b =>
                {
                    b.HasOne("EyePocket.Models.EstadoCXP", "EstadoCXP")
                        .WithMany()
                        .HasForeignKey("EstadoCXPId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EyePocket.Models.MetodoPago", "MetodoPago")
                        .WithMany()
                        .HasForeignKey("MetodoPagoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstadoCXP");

                    b.Navigation("MetodoPago");
                });

            modelBuilder.Entity("EyePocket.Models.Clientes", b =>
                {
                    b.HasOne("EyePocket.Models.Estados", "Estados")
                        .WithMany()
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estados");
                });

            modelBuilder.Entity("EyePocket.Models.Compras", b =>
                {
                    b.HasOne("EyePocket.Models.Estados", "Estados")
                        .WithMany()
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EyePocket.Models.Provedores", "Provedores")
                        .WithMany()
                        .HasForeignKey("ProvedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estados");

                    b.Navigation("Provedores");
                });

            modelBuilder.Entity("EyePocket.Models.OrdenCompra", b =>
                {
                    b.HasOne("EyePocket.Models.EstadoOrdenCompra", "estadoOd")
                        .WithMany()
                        .HasForeignKey("EstadoOdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EyePocket.Models.Provedores", "proveedores")
                        .WithMany()
                        .HasForeignKey("ProveedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("estadoOd");

                    b.Navigation("proveedores");
                });

            modelBuilder.Entity("EyePocket.Models.OrdenCompraDetalle", b =>
                {
                    b.HasOne("EyePocket.Models.OrdenCompra", "OrdenCompra")
                        .WithMany("OrdenCompraDetalle")
                        .HasForeignKey("OrdenCompraID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EyePocket.Models.Productos", "Productos")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrdenCompra");

                    b.Navigation("Productos");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("EyePocket.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("EyePocket.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EyePocket.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("EyePocket.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EyePocket.Models.OrdenCompra", b =>
                {
                    b.Navigation("OrdenCompraDetalle");
                });
#pragma warning restore 612, 618
        }
    }
}
