using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test_cargo_tracker_api.Migrations
{
    /// <inheritdoc />
    public partial class updtatemodelcontainer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "typeContainer",
                table: "Container",
                newName: "TypeContainer");

            migrationBuilder.RenameColumn(
                name: "containerStatus",
                table: "Container",
                newName: "ContainerStatus");

            migrationBuilder.RenameColumn(
                name: "containerCategory",
                table: "Container",
                newName: "ContainerCategory");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeContainer",
                table: "Container",
                newName: "typeContainer");

            migrationBuilder.RenameColumn(
                name: "ContainerStatus",
                table: "Container",
                newName: "containerStatus");

            migrationBuilder.RenameColumn(
                name: "ContainerCategory",
                table: "Container",
                newName: "containerCategory");
        }
    }
}
