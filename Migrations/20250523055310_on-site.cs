using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RecruitX.Migrations
{
    /// <inheritdoc />
    public partial class onsite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "on_site_details",
                columns: table => new
                {
                    onsite_detail_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    jr_id = table.Column<int>(type: "integer", nullable: false),
                    rate = table.Column<string>(type: "text", nullable: false),
                    ideal_start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    contract_type = table.Column<string>(type: "text", nullable: true),
                    contract_duration = table.Column<string>(type: "text", nullable: false),
                    reporting_to = table.Column<string>(type: "text", nullable: false),
                    preferred_time_zone = table.Column<string>(type: "text", nullable: false),
                    preferred_visa_status = table.Column<string>(type: "text", nullable: false),
                    h1_transfer_accepted = table.Column<bool>(type: "boolean", nullable: true),
                    interview_process = table.Column<string>(type: "text", nullable: true),
                    travel_required = table.Column<bool>(type: "boolean", nullable: true),
                    client_background = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_on_site_details", x => x.onsite_detail_id);
                    table.ForeignKey(
                        name: "FK_OnsiteJobDetail_JobRequisition",
                        column: x => x.jr_id,
                        principalTable: "job_requisitions",
                        principalColumn: "JrId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_on_site_details_jr_id",
                table: "on_site_details",
                column: "jr_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "on_site_details");
        }
    }
}
