using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PPM.Entity.Framework.Migrations
{
    /// <inheritdoc />
    public partial class FirstCommit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PPM_Project",
                columns: table => new
                {
                    ProjectId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PPM_Project", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "PPM_Role",
                columns: table => new
                {
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PPM_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "PPM_Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PPM_Employee", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_PPM_Employee_PPM_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "PPM_Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PPM_ProEmpRel",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PPM_ProEmpRel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PPM_ProEmpRel_PPM_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "PPM_Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PPM_ProEmpRel_PPM_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "PPM_Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PPM_Employee_RoleId",
                table: "PPM_Employee",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_PPM_ProEmpRel_EmployeeId",
                table: "PPM_ProEmpRel",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PPM_ProEmpRel_ProjectId",
                table: "PPM_ProEmpRel",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PPM_ProEmpRel");

            migrationBuilder.DropTable(
                name: "PPM_Employee");

            migrationBuilder.DropTable(
                name: "PPM_Project");

            migrationBuilder.DropTable(
                name: "PPM_Role");
        }
    }
}
