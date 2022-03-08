using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stock.UI.Migrations
{
    public partial class RatingMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConcreteProduct_Authors_AuthorOfProductUsername",
                table: "ConcreteProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Authors_AuthorOfProductUsername",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Texts_Authors_AuthorOfProductUsername",
                table: "Texts");

            migrationBuilder.RenameColumn(
                name: "AuthorOfProductUsername",
                table: "Texts",
                newName: "ProductAuthorUsername");

            migrationBuilder.RenameIndex(
                name: "IX_Texts_AuthorOfProductUsername",
                table: "Texts",
                newName: "IX_Texts_ProductAuthorUsername");

            migrationBuilder.RenameColumn(
                name: "AuthorOfProductUsername",
                table: "Photos",
                newName: "ProductAuthorUsername");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_AuthorOfProductUsername",
                table: "Photos",
                newName: "IX_Photos_ProductAuthorUsername");

            migrationBuilder.RenameColumn(
                name: "AuthorOfProductUsername",
                table: "ConcreteProduct",
                newName: "ProductAuthorUsername");

            migrationBuilder.RenameIndex(
                name: "IX_ConcreteProduct_AuthorOfProductUsername",
                table: "ConcreteProduct",
                newName: "IX_ConcreteProduct_ProductAuthorUsername");

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Texts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Photos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "ConcreteProduct",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_ConcreteProduct_Authors_ProductAuthorUsername",
                table: "ConcreteProduct",
                column: "ProductAuthorUsername",
                principalTable: "Authors",
                principalColumn: "Username",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Authors_ProductAuthorUsername",
                table: "Photos",
                column: "ProductAuthorUsername",
                principalTable: "Authors",
                principalColumn: "Username",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Texts_Authors_ProductAuthorUsername",
                table: "Texts",
                column: "ProductAuthorUsername",
                principalTable: "Authors",
                principalColumn: "Username",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConcreteProduct_Authors_ProductAuthorUsername",
                table: "ConcreteProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Authors_ProductAuthorUsername",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Texts_Authors_ProductAuthorUsername",
                table: "Texts");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Texts");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "ConcreteProduct");

            migrationBuilder.RenameColumn(
                name: "ProductAuthorUsername",
                table: "Texts",
                newName: "AuthorOfProductUsername");

            migrationBuilder.RenameIndex(
                name: "IX_Texts_ProductAuthorUsername",
                table: "Texts",
                newName: "IX_Texts_AuthorOfProductUsername");

            migrationBuilder.RenameColumn(
                name: "ProductAuthorUsername",
                table: "Photos",
                newName: "AuthorOfProductUsername");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_ProductAuthorUsername",
                table: "Photos",
                newName: "IX_Photos_AuthorOfProductUsername");

            migrationBuilder.RenameColumn(
                name: "ProductAuthorUsername",
                table: "ConcreteProduct",
                newName: "AuthorOfProductUsername");

            migrationBuilder.RenameIndex(
                name: "IX_ConcreteProduct_ProductAuthorUsername",
                table: "ConcreteProduct",
                newName: "IX_ConcreteProduct_AuthorOfProductUsername");

            migrationBuilder.AddForeignKey(
                name: "FK_ConcreteProduct_Authors_AuthorOfProductUsername",
                table: "ConcreteProduct",
                column: "AuthorOfProductUsername",
                principalTable: "Authors",
                principalColumn: "Username",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Authors_AuthorOfProductUsername",
                table: "Photos",
                column: "AuthorOfProductUsername",
                principalTable: "Authors",
                principalColumn: "Username",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Texts_Authors_AuthorOfProductUsername",
                table: "Texts",
                column: "AuthorOfProductUsername",
                principalTable: "Authors",
                principalColumn: "Username",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
