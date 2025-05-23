using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RecruitX.Migrations
{
    /// <inheritdoc />
    public partial class jdtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "job_descriptions",
                columns: table => new
                {
                    jd_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    jr_id = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<string>(type: "text", nullable: true),
                    job_desc = table.Column<string>(type: "text", nullable: true),
                    fill_positions = table.Column<int>(type: "integer", nullable: true),
                    updates = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: true),
                    JobRequisitionJrId = table.Column<int>(type: "integer", nullable: true),
                    CreatedByEmployeeEmployeeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_job_descriptions", x => x.jd_id);
                    table.ForeignKey(
                        name: "FK_job_descriptions_employees_CreatedByEmployeeEmployeeId",
                        column: x => x.CreatedByEmployeeEmployeeId,
                        principalTable: "employees",
                        principalColumn: "employee_id");
                    table.ForeignKey(
                        name: "FK_job_descriptions_employees_created_by",
                        column: x => x.created_by,
                        principalTable: "employees",
                        principalColumn: "employee_id");
                    table.ForeignKey(
                        name: "FK_job_descriptions_job_requisitions_JobRequisitionJrId",
                        column: x => x.JobRequisitionJrId,
                        principalTable: "job_requisitions",
                        principalColumn: "JrId");
                    table.ForeignKey(
                        name: "FK_job_descriptions_job_requisitions_jr_id",
                        column: x => x.jr_id,
                        principalTable: "job_requisitions",
                        principalColumn: "JrId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_job_descriptions_created_by",
                table: "job_descriptions",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "IX_job_descriptions_CreatedByEmployeeEmployeeId",
                table: "job_descriptions",
                column: "CreatedByEmployeeEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_job_descriptions_JobRequisitionJrId",
                table: "job_descriptions",
                column: "JobRequisitionJrId");

            migrationBuilder.CreateIndex(
                name: "IX_job_descriptions_jr_id",
                table: "job_descriptions",
                column: "jr_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "job_descriptions");
        }
    }
}
