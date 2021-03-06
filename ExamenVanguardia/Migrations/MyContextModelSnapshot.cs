// <auto-generated />
using System;
using ExamenVanguardia.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ExamenVanguardia.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ExamenVanguardia.Models.CategoriaEvento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CategoriaEvento");
                });

            modelBuilder.Entity("ExamenVanguardia.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<int?>("EstadoClienteId")
                        .HasColumnType("int");

                    b.Property<int>("IdEstadoCliente")
                        .HasColumnType("int");

                    b.Property<string>("Identidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EstadoClienteId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("ExamenVanguardia.Models.EstadoCliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("EstadoCliente");
                });

            modelBuilder.Entity("ExamenVanguardia.Models.Mobiliario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CantidadDisponible")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<string>("EstadoMobiliario")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Mobiliario");
                });

            modelBuilder.Entity("ExamenVanguardia.Models.Reserva", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoriaEventoId")
                        .HasColumnType("int");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaFinal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicial")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCategoriaEvento")
                        .HasColumnType("int");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaEventoId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Reserva");
                });

            modelBuilder.Entity("ExamenVanguardia.Models.ReservaDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CantidadReserva")
                        .HasColumnType("int");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<int>("IdMobiliario")
                        .HasColumnType("int");

                    b.Property<int>("IdReserva")
                        .HasColumnType("int");

                    b.Property<int?>("MobiliarioId")
                        .HasColumnType("int");

                    b.Property<int?>("ReservaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MobiliarioId");

                    b.HasIndex("ReservaId");

                    b.ToTable("ReservaDetalle");
                });

            modelBuilder.Entity("ExamenVanguardia.Models.Cliente", b =>
                {
                    b.HasOne("ExamenVanguardia.Models.EstadoCliente", "EstadoCliente")
                        .WithMany("Clientes")
                        .HasForeignKey("EstadoClienteId");

                    b.Navigation("EstadoCliente");
                });

            modelBuilder.Entity("ExamenVanguardia.Models.Reserva", b =>
                {
                    b.HasOne("ExamenVanguardia.Models.CategoriaEvento", "CategoriaEvento")
                        .WithMany("Reservas")
                        .HasForeignKey("CategoriaEventoId");

                    b.HasOne("ExamenVanguardia.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.Navigation("CategoriaEvento");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("ExamenVanguardia.Models.ReservaDetalle", b =>
                {
                    b.HasOne("ExamenVanguardia.Models.Mobiliario", "Mobiliario")
                        .WithMany("ReservaDetalle")
                        .HasForeignKey("MobiliarioId");

                    b.HasOne("ExamenVanguardia.Models.Reserva", "Reserva")
                        .WithMany("Detalle")
                        .HasForeignKey("ReservaId");

                    b.Navigation("Mobiliario");

                    b.Navigation("Reserva");
                });

            modelBuilder.Entity("ExamenVanguardia.Models.CategoriaEvento", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("ExamenVanguardia.Models.EstadoCliente", b =>
                {
                    b.Navigation("Clientes");
                });

            modelBuilder.Entity("ExamenVanguardia.Models.Mobiliario", b =>
                {
                    b.Navigation("ReservaDetalle");
                });

            modelBuilder.Entity("ExamenVanguardia.Models.Reserva", b =>
                {
                    b.Navigation("Detalle");
                });
#pragma warning restore 612, 618
        }
    }
}
