﻿// <auto-generated />
using System;
using Encuba.Exam.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Encuba.Exam.Infrastructure.Migrations
{
    [DbContext(typeof(SecurityDbContext))]
    [Migration("20241010174322_encuba")]
    partial class encuba
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Encuba.Exam.Domain.Entities.PublicAccessToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccessToken")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpiresIn")
                        .HasColumnType("datetime2");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Scope")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("AccessToken")
                        .IsUnique();

                    b.HasIndex("RefreshToken")
                        .IsUnique();

                    b.ToTable("PublicAccessToken", (string)null);
                });

            modelBuilder.Entity("Encuba.Exam.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("AcceptedTermsAndCondition")
                        .HasColumnType("bit");

                    b.Property<DateTime>("AcceptedTermsAndConditionAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("FirstLastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<Guid?>("PublicAccessTokenId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ResetPasswordToken")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ResetPasswordTokenExpiresIn")
                        .HasColumnType("datetime2");

                    b.Property<string>("SecondLastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(false)
                        .HasColumnType("varchar(64)");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("PublicAccessTokenId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Encuba.Exam.Domain.Entities.UserPublicAccessToken", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PublicAccessTokenId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClientIp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserAgent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "PublicAccessTokenId");

                    b.HasIndex("PublicAccessTokenId");

                    b.ToTable("UserPublicAccessToken", (string)null);
                });

            modelBuilder.Entity("Encuba.Exam.Domain.Entities.User", b =>
                {
                    b.HasOne("Encuba.Exam.Domain.Entities.PublicAccessToken", null)
                        .WithMany()
                        .HasForeignKey("PublicAccessTokenId");
                });

            modelBuilder.Entity("Encuba.Exam.Domain.Entities.UserPublicAccessToken", b =>
                {
                    b.HasOne("Encuba.Exam.Domain.Entities.PublicAccessToken", "PublicAccessToken")
                        .WithMany()
                        .HasForeignKey("PublicAccessTokenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Encuba.Exam.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PublicAccessToken");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
