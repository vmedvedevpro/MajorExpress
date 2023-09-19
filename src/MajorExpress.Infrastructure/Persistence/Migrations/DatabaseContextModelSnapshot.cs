﻿// <auto-generated />
using System;
using MajorExpress.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MajorExpress.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MajorExpress.Domain.Entities.CancelComment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("DeliveryRequestId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryRequestId")
                        .IsUnique();

                    b.ToTable("CancelComments");
                });

            modelBuilder.Entity("MajorExpress.Domain.Entities.Cargo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Height")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Lenght")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Name")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Weight")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Width")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Cargoes");
                });

            modelBuilder.Entity("MajorExpress.Domain.Entities.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("MajorExpress.Domain.Entities.DeliveryMan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("DeliveryMen");
                });

            modelBuilder.Entity("MajorExpress.Domain.Entities.DeliveryRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AssigneeId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CargoId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uuid");

                    b.Property<string>("DepartureAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DestinationAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DestinationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AssigneeId");

                    b.HasIndex("CargoId")
                        .IsUnique();

                    b.HasIndex("ClientId");

                    b.ToTable("DeliveryRequests");
                });

            modelBuilder.Entity("MajorExpress.Domain.Entities.CancelComment", b =>
                {
                    b.HasOne("MajorExpress.Domain.Entities.DeliveryRequest", "DeliveryRequest")
                        .WithOne()
                        .HasForeignKey("MajorExpress.Domain.Entities.CancelComment", "DeliveryRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeliveryRequest");
                });

            modelBuilder.Entity("MajorExpress.Domain.Entities.DeliveryRequest", b =>
                {
                    b.HasOne("MajorExpress.Domain.Entities.DeliveryMan", "Assignee")
                        .WithMany("DeliveryRequests")
                        .HasForeignKey("AssigneeId");

                    b.HasOne("MajorExpress.Domain.Entities.Cargo", "Cargo")
                        .WithOne()
                        .HasForeignKey("MajorExpress.Domain.Entities.DeliveryRequest", "CargoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MajorExpress.Domain.Entities.Client", "Client")
                        .WithMany("DeliveryRequests")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assignee");

                    b.Navigation("Cargo");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("MajorExpress.Domain.Entities.Client", b =>
                {
                    b.Navigation("DeliveryRequests");
                });

            modelBuilder.Entity("MajorExpress.Domain.Entities.DeliveryMan", b =>
                {
                    b.Navigation("DeliveryRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
