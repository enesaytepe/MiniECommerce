﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Persistence.Contexts;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(BaseDbContext))]
    partial class BaseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("timezone('utc', now())");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<long?>("ParentCategoryId")
                        .HasColumnType("bigint");

                    b.Property<uint>("RowVersion")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("xid")
                        .HasColumnName("xmin");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.HasIndex(new[] { "Name" }, "UK_Categories_Name")
                        .IsUnique();

                    b.ToTable("Categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedDateTime = new DateTime(2025, 2, 3, 17, 13, 53, 172, DateTimeKind.Utc).AddTicks(3944),
                            Name = "Elektronik",
                            RowVersion = 0u
                        },
                        new
                        {
                            Id = 2L,
                            CreatedDateTime = new DateTime(2025, 2, 3, 17, 13, 53, 172, DateTimeKind.Utc).AddTicks(3950),
                            Name = "Bilgisayar",
                            ParentCategoryId = 1L,
                            RowVersion = 0u
                        },
                        new
                        {
                            Id = 3L,
                            CreatedDateTime = new DateTime(2025, 2, 3, 17, 13, 53, 172, DateTimeKind.Utc).AddTicks(3951),
                            Name = "Telefon",
                            ParentCategoryId = 1L,
                            RowVersion = 0u
                        },
                        new
                        {
                            Id = 4L,
                            CreatedDateTime = new DateTime(2025, 2, 3, 17, 13, 53, 172, DateTimeKind.Utc).AddTicks(3952),
                            Name = "Dizüstü Bilgisayar",
                            ParentCategoryId = 2L,
                            RowVersion = 0u
                        },
                        new
                        {
                            Id = 5L,
                            CreatedDateTime = new DateTime(2025, 2, 3, 17, 13, 53, 172, DateTimeKind.Utc).AddTicks(3953),
                            Name = "Masaüstü Bilgisayar",
                            ParentCategoryId = 2L,
                            RowVersion = 0u
                        },
                        new
                        {
                            Id = 6L,
                            CreatedDateTime = new DateTime(2025, 2, 3, 17, 13, 53, 172, DateTimeKind.Utc).AddTicks(3955),
                            Name = "Android Telefon",
                            ParentCategoryId = 3L,
                            RowVersion = 0u
                        },
                        new
                        {
                            Id = 7L,
                            CreatedDateTime = new DateTime(2025, 2, 3, 17, 13, 53, 172, DateTimeKind.Utc).AddTicks(3956),
                            Name = "iOS Telefon",
                            ParentCategoryId = 3L,
                            RowVersion = 0u
                        },
                        new
                        {
                            Id = 8L,
                            CreatedDateTime = new DateTime(2025, 2, 3, 17, 13, 53, 172, DateTimeKind.Utc).AddTicks(3957),
                            Name = "Ev Elektroniği",
                            RowVersion = 0u
                        },
                        new
                        {
                            Id = 9L,
                            CreatedDateTime = new DateTime(2025, 2, 3, 17, 13, 53, 172, DateTimeKind.Utc).AddTicks(3958),
                            Name = "Televizyon",
                            ParentCategoryId = 8L,
                            RowVersion = 0u
                        },
                        new
                        {
                            Id = 10L,
                            CreatedDateTime = new DateTime(2025, 2, 3, 17, 13, 53, 172, DateTimeKind.Utc).AddTicks(3960),
                            Name = "Beyaz Eşya",
                            ParentCategoryId = 8L,
                            RowVersion = 0u
                        });
                });

            modelBuilder.Entity("Domain.Entities.OperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("timezone('utc', now())");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<uint>("RowVersion")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("xid")
                        .HasColumnName("xmin");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "UK_OperationClaims_Name")
                        .IsUnique();

                    b.ToTable("OperationClaims", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "product.admin",
                            RowVersion = 0u
                        },
                        new
                        {
                            Id = 2,
                            CreatedDateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "product.read",
                            RowVersion = 0u
                        },
                        new
                        {
                            Id = 3,
                            CreatedDateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "product.write",
                            RowVersion = 0u
                        },
                        new
                        {
                            Id = 4,
                            CreatedDateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "product.add",
                            RowVersion = 0u
                        },
                        new
                        {
                            Id = 5,
                            CreatedDateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "product.update",
                            RowVersion = 0u
                        },
                        new
                        {
                            Id = 6,
                            CreatedDateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "product.delete",
                            RowVersion = 0u
                        },
                        new
                        {
                            Id = 7,
                            CreatedDateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "category.admin",
                            RowVersion = 0u
                        },
                        new
                        {
                            Id = 8,
                            CreatedDateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "category.read",
                            RowVersion = 0u
                        },
                        new
                        {
                            Id = 9,
                            CreatedDateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "category.write",
                            RowVersion = 0u
                        },
                        new
                        {
                            Id = 10,
                            CreatedDateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "category.add",
                            RowVersion = 0u
                        },
                        new
                        {
                            Id = 11,
                            CreatedDateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "category.update",
                            RowVersion = 0u
                        },
                        new
                        {
                            Id = 12,
                            CreatedDateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "category.delete",
                            RowVersion = 0u
                        },
                        new
                        {
                            Id = 13,
                            CreatedDateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Admin",
                            RowVersion = 0u
                        });
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("timezone('utc', now())");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<double?>("Price")
                        .HasColumnType("double precision");

                    b.Property<uint>("RowVersion")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("xid")
                        .HasColumnName("xmin");

                    b.Property<int>("StockCount")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex(new[] { "Name" }, "UK_Products_Name")
                        .IsUnique();

                    b.ToTable("Products", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CategoryId = 4L,
                            CreatedDateTime = new DateTime(2025, 2, 3, 17, 13, 53, 172, DateTimeKind.Utc).AddTicks(7841),
                            Description = "Dell'in popüler dizüstü bilgisayarı",
                            Name = "Dell XPS 13",
                            Price = 15000.0,
                            RowVersion = 0u,
                            StockCount = 10
                        },
                        new
                        {
                            Id = 2L,
                            CategoryId = 4L,
                            CreatedDateTime = new DateTime(2025, 2, 3, 17, 13, 53, 172, DateTimeKind.Utc).AddTicks(7844),
                            Description = "Apple'ın profesyoneller için dizüstü bilgisayarı",
                            Name = "Apple MacBook Pro",
                            Price = 25000.0,
                            RowVersion = 0u,
                            StockCount = 5
                        },
                        new
                        {
                            Id = 3L,
                            CategoryId = 5L,
                            CreatedDateTime = new DateTime(2025, 2, 3, 17, 13, 53, 172, DateTimeKind.Utc).AddTicks(7845),
                            Description = "Günlük kullanım için ideal masaüstü bilgisayar",
                            Name = "HP Pavilion Masaüstü",
                            Price = 12000.0,
                            RowVersion = 0u,
                            StockCount = 7
                        },
                        new
                        {
                            Id = 4L,
                            CategoryId = 6L,
                            CreatedDateTime = new DateTime(2025, 2, 3, 17, 13, 53, 172, DateTimeKind.Utc).AddTicks(7847),
                            Description = "Samsung'ın yeni amiral gemisi akıllı telefonu",
                            Name = "Samsung Galaxy S23",
                            Price = 20000.0,
                            RowVersion = 0u,
                            StockCount = 15
                        },
                        new
                        {
                            Id = 5L,
                            CategoryId = 7L,
                            CreatedDateTime = new DateTime(2025, 2, 3, 17, 13, 53, 172, DateTimeKind.Utc).AddTicks(7848),
                            Description = "Apple'ın son model akıllı telefonu",
                            Name = "Apple iPhone 14",
                            Price = 25000.0,
                            RowVersion = 0u,
                            StockCount = 20
                        },
                        new
                        {
                            Id = 6L,
                            CategoryId = 9L,
                            CreatedDateTime = new DateTime(2025, 2, 3, 17, 13, 53, 172, DateTimeKind.Utc).AddTicks(7851),
                            Description = "En iyi görüntü kalitesi sunan televizyon",
                            Name = "LG OLED TV",
                            Price = 30000.0,
                            RowVersion = 0u,
                            StockCount = 5
                        },
                        new
                        {
                            Id = 7L,
                            CategoryId = 10L,
                            CreatedDateTime = new DateTime(2025, 2, 3, 17, 13, 53, 172, DateTimeKind.Utc).AddTicks(7853),
                            Description = "Yüksek performanslı beyaz eşya",
                            Name = "Bosch Çamaşır Makinesi",
                            Price = 18000.0,
                            RowVersion = 0u,
                            StockCount = 3
                        });
                });

            modelBuilder.Entity("Domain.Entities.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedByIp")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("timezone('utc', now())");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ReasonRevoked")
                        .HasColumnType("text");

                    b.Property<string>("ReplacedByToken")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Revoked")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("RevokedByIp")
                        .HasColumnType("text");

                    b.Property<uint>("RowVersion")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("xid")
                        .HasColumnName("xmin");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("timezone('utc', now())");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<uint>("RowVersion")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("xid")
                        .HasColumnName("xmin");

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Email" }, "UK_Users_Email")
                        .IsUnique();

                    b.HasIndex(new[] { "UserName" }, "UK_Users_UserName")
                        .IsUnique();

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.UserOperationClaim", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("timezone('utc', now())");

                    b.Property<int>("OperationClaimId")
                        .HasColumnType("integer");

                    b.Property<uint>("RowVersion")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("xid")
                        .HasColumnName("xmin");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("OperationClaimId");

                    b.HasIndex(new[] { "UserId", "OperationClaimId" }, "UK_UserOperationClaims_UserId_Id")
                        .IsUnique();

                    b.ToTable("UserOperationClaims", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Category", b =>
                {
                    b.HasOne("Domain.Entities.Category", "ParentCategory")
                        .WithMany("SubCategories")
                        .HasForeignKey("ParentCategoryId");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.HasOne("Domain.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Domain.Entities.RefreshToken", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.UserOperationClaim", b =>
                {
                    b.HasOne("Domain.Entities.OperationClaim", "OperationClaim")
                        .WithMany()
                        .HasForeignKey("OperationClaimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OperationClaim");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Category", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("SubCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
