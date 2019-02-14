using Microsoft.EntityFrameworkCore.Migrations;

namespace DocumentsControl.DataAccess.EfCore.Migrations
{
    public partial class RelationFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NodeTags_Nodes_nodeId",
                table: "NodeTags");

            migrationBuilder.DropForeignKey(
                name: "FK_NodeTags_Tags_tagId",
                table: "NodeTags");

            migrationBuilder.DropColumn(
                name: "Node_Id",
                table: "NodeTags");

            migrationBuilder.DropColumn(
                name: "Tag_Id",
                table: "NodeTags");

            migrationBuilder.RenameColumn(
                name: "tagId",
                table: "NodeTags",
                newName: "TagId");

            migrationBuilder.RenameColumn(
                name: "nodeId",
                table: "NodeTags",
                newName: "NodeId");

            migrationBuilder.RenameIndex(
                name: "IX_NodeTags_tagId",
                table: "NodeTags",
                newName: "IX_NodeTags_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_NodeTags_nodeId",
                table: "NodeTags",
                newName: "IX_NodeTags_NodeId");

            migrationBuilder.AlterColumn<long>(
                name: "TagId",
                table: "NodeTags",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "NodeId",
                table: "NodeTags",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_NodeTags_Nodes_NodeId",
                table: "NodeTags",
                column: "NodeId",
                principalTable: "Nodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NodeTags_Tags_TagId",
                table: "NodeTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NodeTags_Nodes_NodeId",
                table: "NodeTags");

            migrationBuilder.DropForeignKey(
                name: "FK_NodeTags_Tags_TagId",
                table: "NodeTags");

            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "NodeTags",
                newName: "tagId");

            migrationBuilder.RenameColumn(
                name: "NodeId",
                table: "NodeTags",
                newName: "nodeId");

            migrationBuilder.RenameIndex(
                name: "IX_NodeTags_TagId",
                table: "NodeTags",
                newName: "IX_NodeTags_tagId");

            migrationBuilder.RenameIndex(
                name: "IX_NodeTags_NodeId",
                table: "NodeTags",
                newName: "IX_NodeTags_nodeId");

            migrationBuilder.AlterColumn<long>(
                name: "tagId",
                table: "NodeTags",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "nodeId",
                table: "NodeTags",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "Node_Id",
                table: "NodeTags",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Tag_Id",
                table: "NodeTags",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_NodeTags_Nodes_nodeId",
                table: "NodeTags",
                column: "nodeId",
                principalTable: "Nodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NodeTags_Tags_tagId",
                table: "NodeTags",
                column: "tagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
