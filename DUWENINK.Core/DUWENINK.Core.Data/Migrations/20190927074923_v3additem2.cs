using Microsoft.EntityFrameworkCore.Migrations;

namespace DUWENINK.Core.Data.Migrations
{
    public partial class v3additem2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ParentItemGroupId",
                table: "ItemGroups",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemGroups_ParentItemGroupId",
                table: "ItemGroups",
                column: "ParentItemGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemGroups_ItemGroups_ParentItemGroupId",
                table: "ItemGroups",
                column: "ParentItemGroupId",
                principalTable: "ItemGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemGroups_ItemGroups_ParentItemGroupId",
                table: "ItemGroups");

            migrationBuilder.DropIndex(
                name: "IX_ItemGroups_ParentItemGroupId",
                table: "ItemGroups");

            migrationBuilder.DropColumn(
                name: "ParentItemGroupId",
                table: "ItemGroups");
        }
    }
}
