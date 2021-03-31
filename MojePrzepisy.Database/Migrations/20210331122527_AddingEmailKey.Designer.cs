﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MojePrzepisy.Database;

namespace MojePrzepisy.Database.Migrations
{
    [DbContext(typeof(MojePrzepisyDbContext))]
    [Migration("20210331122527_AddingEmailKey")]
    partial class AddingEmailKey
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MojePrzepisy.Database.Entities.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("AmountDesc")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("RecepieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecepieId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("MojePrzepisy.Database.Entities.PreparationStep", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RecepieId")
                        .HasColumnType("int");

                    b.Property<int>("StepNumber")
                        .HasMaxLength(20)
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.HasKey("Id");

                    b.HasIndex("RecepieId");

                    b.ToTable("PreparationSteps");
                });

            modelBuilder.Entity("MojePrzepisy.Database.Entities.Recepie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CookingTime")
                        .HasMaxLength(20)
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("Difficulty")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<int>("People")
                        .HasMaxLength(20)
                        .HasColumnType("int");

                    b.Property<int>("PreparationTime")
                        .HasMaxLength(20)
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Recepies");
                });

            modelBuilder.Entity("MojePrzepisy.Database.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegistrationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Role")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MojePrzepisy.Database.Entities.Ingredient", b =>
                {
                    b.HasOne("MojePrzepisy.Database.Entities.Recepie", null)
                        .WithMany("Ingredients")
                        .HasForeignKey("RecepieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MojePrzepisy.Database.Entities.PreparationStep", b =>
                {
                    b.HasOne("MojePrzepisy.Database.Entities.Recepie", null)
                        .WithMany("PreparationSteps")
                        .HasForeignKey("RecepieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MojePrzepisy.Database.Entities.Recepie", b =>
                {
                    b.Navigation("Ingredients");

                    b.Navigation("PreparationSteps");
                });
#pragma warning restore 612, 618
        }
    }
}
