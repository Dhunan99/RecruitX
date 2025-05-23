using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RecruitX.Migrations
{
    /// <inheritdoc />
    public partial class jrassignment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobSkill_job_requisitions_JobRequisitionJrId",
                table: "JobSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_JobSkill_skills_SkillId",
                table: "JobSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobSkill",
                table: "JobSkill");

            migrationBuilder.RenameTable(
                name: "JobSkill",
                newName: "job_skill");

            migrationBuilder.RenameIndex(
                name: "IX_JobSkill_SkillId",
                table: "job_skill",
                newName: "IX_job_skill_SkillId");

            migrationBuilder.RenameIndex(
                name: "IX_JobSkill_JobRequisitionJrId",
                table: "job_skill",
                newName: "IX_job_skill_JobRequisitionJrId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_job_skill",
                table: "job_skill",
                columns: new[] { "JrId", "SkillId" });

            migrationBuilder.CreateTable(
                name: "jr_assignments",
                columns: table => new
                {
                    assignment_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    jr_id = table.Column<int>(type: "integer", nullable: false),
                    assigned_to = table.Column<long>(type: "bigint", nullable: false),
                    assigned_by = table.Column<long>(type: "bigint", nullable: false),
                    assigned_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jr_assignments", x => x.assignment_id);
                    table.ForeignKey(
                        name: "FK_jr_assignments_job_requisitions_jr_id",
                        column: x => x.jr_id,
                        principalTable: "job_requisitions",
                        principalColumn: "JrId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_jr_assignments_users_assigned_by",
                        column: x => x.assigned_by,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_jr_assignments_users_assigned_to",
                        column: x => x.assigned_to,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_jr_assignments_assigned_by",
                table: "jr_assignments",
                column: "assigned_by");

            migrationBuilder.CreateIndex(
                name: "IX_jr_assignments_assigned_to",
                table: "jr_assignments",
                column: "assigned_to");

            migrationBuilder.CreateIndex(
                name: "IX_jr_assignments_jr_id",
                table: "jr_assignments",
                column: "jr_id");

            migrationBuilder.AddForeignKey(
                name: "FK_job_skill_job_requisitions_JobRequisitionJrId",
                table: "job_skill",
                column: "JobRequisitionJrId",
                principalTable: "job_requisitions",
                principalColumn: "JrId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_job_skill_skills_SkillId",
                table: "job_skill",
                column: "SkillId",
                principalTable: "skills",
                principalColumn: "skill_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_job_skill_job_requisitions_JobRequisitionJrId",
                table: "job_skill");

            migrationBuilder.DropForeignKey(
                name: "FK_job_skill_skills_SkillId",
                table: "job_skill");

            migrationBuilder.DropTable(
                name: "jr_assignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_job_skill",
                table: "job_skill");

            migrationBuilder.RenameTable(
                name: "job_skill",
                newName: "JobSkill");

            migrationBuilder.RenameIndex(
                name: "IX_job_skill_SkillId",
                table: "JobSkill",
                newName: "IX_JobSkill_SkillId");

            migrationBuilder.RenameIndex(
                name: "IX_job_skill_JobRequisitionJrId",
                table: "JobSkill",
                newName: "IX_JobSkill_JobRequisitionJrId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobSkill",
                table: "JobSkill",
                columns: new[] { "JrId", "SkillId" });

            migrationBuilder.AddForeignKey(
                name: "FK_JobSkill_job_requisitions_JobRequisitionJrId",
                table: "JobSkill",
                column: "JobRequisitionJrId",
                principalTable: "job_requisitions",
                principalColumn: "JrId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobSkill_skills_SkillId",
                table: "JobSkill",
                column: "SkillId",
                principalTable: "skills",
                principalColumn: "skill_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
