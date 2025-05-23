using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitX.Migrations
{
    /// <inheritdoc />
    public partial class jobskill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobSkill",
                columns: table => new
                {
                    JrId = table.Column<int>(type: "integer", nullable: false),
                    SkillId = table.Column<int>(type: "integer", nullable: false),
                    SkillType = table.Column<int>(type: "integer", nullable: false),
                    JobRequisitionJrId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSkill", x => new { x.JrId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_JobSkill_job_requisitions_JobRequisitionJrId",
                        column: x => x.JobRequisitionJrId,
                        principalTable: "job_requisitions",
                        principalColumn: "JrId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobSkill_skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "skills",
                        principalColumn: "skill_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobSkill_JobRequisitionJrId",
                table: "JobSkill",
                column: "JobRequisitionJrId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSkill_SkillId",
                table: "JobSkill",
                column: "SkillId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobSkill");
        }
    }
}
