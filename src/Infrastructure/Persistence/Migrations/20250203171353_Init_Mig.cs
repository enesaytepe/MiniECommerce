using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init_Mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ParentCategoryId = table.Column<long>(type: "bigint", nullable: true),
                    xmin = table.Column<uint>(type: "xid", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "timezone('utc', now())"),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    xmin = table.Column<uint>(type: "xid", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "timezone('utc', now())"),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "bytea", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "bytea", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    xmin = table.Column<uint>(type: "xid", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "timezone('utc', now())"),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    StockCount = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: true),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    xmin = table.Column<uint>(type: "xid", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "timezone('utc', now())"),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: false),
                    Expires = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByIp = table.Column<string>(type: "text", nullable: false),
                    Revoked = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RevokedByIp = table.Column<string>(type: "text", nullable: true),
                    ReplacedByToken = table.Column<string>(type: "text", nullable: true),
                    ReasonRevoked = table.Column<string>(type: "text", nullable: true),
                    xmin = table.Column<uint>(type: "xid", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "timezone('utc', now())"),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOperationClaims",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    OperationClaimId = table.Column<int>(type: "integer", nullable: false),
                    xmin = table.Column<uint>(type: "xid", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "timezone('utc', now())"),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOperationClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_OperationClaims_OperationClaimId",
                        column: x => x.OperationClaimId,
                        principalTable: "OperationClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDateTime", "Name", "ParentCategoryId", "UpdatedDateTime" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 2, 3, 17, 13, 53, 172, DateTimeKind.Utc).AddTicks(3944), "Elektronik", null, null },
                    { 8L, new DateTime(2025, 2, 3, 17, 13, 53, 172, DateTimeKind.Utc).AddTicks(3957), "Ev Elektroniği", null, null }
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "Name", "UpdatedDateTime" },
                values: new object[,]
                {
                    { 1, "product.admin", null },
                    { 2, "product.read", null },
                    { 3, "product.write", null },
                    { 4, "product.add", null },
                    { 5, "product.update", null },
                    { 6, "product.delete", null },
                    { 7, "category.admin", null },
                    { 8, "category.read", null },
                    { 9, "category.write", null },
                    { 10, "category.add", null },
                    { 11, "category.update", null },
                    { 12, "category.delete", null },
                    { 13, "Admin", null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDateTime", "Name", "ParentCategoryId", "UpdatedDateTime" },
                values: new object[,]
                {
                    { 2L, new DateTime(2025, 2, 3, 17, 13, 53, 172, DateTimeKind.Utc).AddTicks(3950), "Bilgisayar", 1L, null },
                    { 3L, new DateTime(2025, 2, 3, 17, 13, 53, 172, DateTimeKind.Utc).AddTicks(3951), "Telefon", 1L, null },
                    { 9L, new DateTime(2025, 2, 3, 17, 13, 53, 172, DateTimeKind.Utc).AddTicks(3958), "Televizyon", 8L, null },
                    { 10L, new DateTime(2025, 2, 3, 17, 13, 53, 172, DateTimeKind.Utc).AddTicks(3960), "Beyaz Eşya", 8L, null },
                    { 4L, new DateTime(2025, 2, 3, 17, 13, 53, 172, DateTimeKind.Utc).AddTicks(3952), "Dizüstü Bilgisayar", 2L, null },
                    { 5L, new DateTime(2025, 2, 3, 17, 13, 53, 172, DateTimeKind.Utc).AddTicks(3953), "Masaüstü Bilgisayar", 2L, null },
                    { 6L, new DateTime(2025, 2, 3, 17, 13, 53, 172, DateTimeKind.Utc).AddTicks(3955), "Android Telefon", 3L, null },
                    { 7L, new DateTime(2025, 2, 3, 17, 13, 53, 172, DateTimeKind.Utc).AddTicks(3956), "iOS Telefon", 3L, null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDateTime", "Description", "Name", "Price", "StockCount", "UpdatedDateTime" },
                values: new object[,]
                {
                    { 6L, 9L, new DateTime(2025, 2, 3, 17, 13, 53, 172, DateTimeKind.Utc).AddTicks(7851), "En iyi görüntü kalitesi sunan televizyon", "LG OLED TV", 30000.0, 5, null },
                    { 7L, 10L, new DateTime(2025, 2, 3, 17, 13, 53, 172, DateTimeKind.Utc).AddTicks(7853), "Yüksek performanslı beyaz eşya", "Bosch Çamaşır Makinesi", 18000.0, 3, null },
                    { 1L, 4L, new DateTime(2025, 2, 3, 17, 13, 53, 172, DateTimeKind.Utc).AddTicks(7841), "Dell'in popüler dizüstü bilgisayarı", "Dell XPS 13", 15000.0, 10, null },
                    { 2L, 4L, new DateTime(2025, 2, 3, 17, 13, 53, 172, DateTimeKind.Utc).AddTicks(7844), "Apple'ın profesyoneller için dizüstü bilgisayarı", "Apple MacBook Pro", 25000.0, 5, null },
                    { 3L, 5L, new DateTime(2025, 2, 3, 17, 13, 53, 172, DateTimeKind.Utc).AddTicks(7845), "Günlük kullanım için ideal masaüstü bilgisayar", "HP Pavilion Masaüstü", 12000.0, 7, null },
                    { 4L, 6L, new DateTime(2025, 2, 3, 17, 13, 53, 172, DateTimeKind.Utc).AddTicks(7847), "Samsung'ın yeni amiral gemisi akıllı telefonu", "Samsung Galaxy S23", 20000.0, 15, null },
                    { 5L, 7L, new DateTime(2025, 2, 3, 17, 13, 53, 172, DateTimeKind.Utc).AddTicks(7848), "Apple'ın son model akıllı telefonu", "Apple iPhone 14", 25000.0, 20, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "UK_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UK_OperationClaims_Name",
                table: "OperationClaims",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "UK_Products_Name",
                table: "Products",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_OperationClaimId",
                table: "UserOperationClaims",
                column: "OperationClaimId");

            migrationBuilder.CreateIndex(
                name: "UK_UserOperationClaims_UserId_Id",
                table: "UserOperationClaims",
                columns: new[] { "UserId", "OperationClaimId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UK_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UK_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "OperationClaims");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
