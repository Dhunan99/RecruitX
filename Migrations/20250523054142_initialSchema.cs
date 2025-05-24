using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RecruitX.Migrations
{
    /// <inheritdoc />
    public partial class initialSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    client_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    client_name = table.Column<string>(type: "text", nullable: false),
                    client_country = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.client_id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<long>(type: "bigint", nullable: true),
                    Position = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DeliveryUnit = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Department = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    location_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    location_name = table.Column<string>(type: "text", nullable: false),
                    country = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locations", x => x.location_id);
                });

            migrationBuilder.CreateTable(
                name: "skills",
                columns: table => new
                {
                    skill_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    skill_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skills", x => x.skill_id);
                });

            migrationBuilder.CreateTable(
                name: "job_requisitions",
                columns: table => new
                {
                    JrId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BusinessUnit = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    RequestedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RequestedBy = table.Column<int>(type: "integer", nullable: true),
                    HiringManager = table.Column<int>(type: "integer", nullable: true),
                    NumPositions = table.Column<int>(type: "integer", nullable: true),
                    WorkShift = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ExpectedOnboardingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    WorkModel = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Role = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Qualification = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TotalExperienceRequired = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    RelevantExperienceRequired = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    LocationId = table.Column<int>(type: "integer", nullable: true),
                    JobPurpose = table.Column<string>(type: "text", nullable: false),
                    JobSpecification = table.Column<string>(type: "text", nullable: false),
                    ProjectName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ProjectRole = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    OnsiteOpportunity = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    Billable = table.Column<bool>(type: "boolean", nullable: true),
                    ClientInterview = table.Column<bool>(type: "boolean", nullable: true),
                    ClientId = table.Column<int>(type: "integer", nullable: true),
                    ExpectedSalaryRange = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IdealStartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    JdStatus = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, defaultValue: "Pending"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_job_requisitions", x => x.JrId);
                    table.CheckConstraint("CK_JobRequisitions_JdStatus", "\"JdStatus\" IN ('Pending', 'Draft', 'Completed')");
                    table.ForeignKey(
                        name: "FK_job_requisitions_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_job_requisitions_Employees_HiringManager",
                        column: x => x.HiringManager,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_job_requisitions_Employees_RequestedBy",
                        column: x => x.RequestedBy,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_job_requisitions_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clients",
                        principalColumn: "client_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_job_requisitions_locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "locations",
                        principalColumn: "location_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Email",
                table: "Employees",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_job_requisitions_ClientId",
                table: "job_requisitions",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_job_requisitions_CreatedBy",
                table: "job_requisitions",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_job_requisitions_HiringManager",
                table: "job_requisitions",
                column: "HiringManager");

            migrationBuilder.CreateIndex(
                name: "IX_job_requisitions_LocationId",
                table: "job_requisitions",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_job_requisitions_RequestedBy",
                table: "job_requisitions",
                column: "RequestedBy");

            migrationBuilder.CreateIndex(
                name: "IX_skills_skill_name",
                table: "skills",
                column: "skill_name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "job_requisitions");

            migrationBuilder.DropTable(
                name: "skills");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "locations");
        }
    }
}
