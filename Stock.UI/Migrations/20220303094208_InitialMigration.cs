using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stock.UI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "ConcreteProduct",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuthorUsername = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Sales = table.Column<int>(type: "int", nullable: false),
                    AuthorOfProductUsername = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcreteProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConcreteProduct_Authors_AuthorOfProductUsername",
                        column: x => x.AuthorOfProductUsername,
                        principalTable: "Authors",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConcreteProduct_Authors_AuthorUsername",
                        column: x => x.AuthorUsername,
                        principalTable: "Authors",
                        principalColumn: "Username");
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    ContentUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Sales = table.Column<int>(type: "int", nullable: false),
                    AuthorOfProductUsername = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Authors_AuthorOfProductUsername",
                        column: x => x.AuthorOfProductUsername,
                        principalTable: "Authors",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Texts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Length = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Sales = table.Column<int>(type: "int", nullable: false),
                    AuthorOfProductUsername = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Texts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Texts_Authors_AuthorOfProductUsername",
                        column: x => x.AuthorOfProductUsername,
                        principalTable: "Authors",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConcreteProduct_AuthorOfProductUsername",
                table: "ConcreteProduct",
                column: "AuthorOfProductUsername");

            migrationBuilder.CreateIndex(
                name: "IX_ConcreteProduct_AuthorUsername",
                table: "ConcreteProduct",
                column: "AuthorUsername");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_AuthorOfProductUsername",
                table: "Photos",
                column: "AuthorOfProductUsername");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_Id",
                table: "Photos",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Texts_AuthorOfProductUsername",
                table: "Texts",
                column: "AuthorOfProductUsername");

            migrationBuilder.CreateIndex(
                name: "IX_Texts_Id",
                table: "Texts",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConcreteProduct");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Texts");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
