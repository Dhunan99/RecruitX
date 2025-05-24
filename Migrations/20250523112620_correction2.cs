using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitX.Migrations
{
    /// <inheritdoc />
    public partial class correction2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_job_skill",
                table: "job_skill");

            migrationBuilder.AddColumn<int>(
                name: "JobSkill_Id",
                table: "job_skill",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_job_skill",
                table: "job_skill",
                columns: new[] { "JobRequisition_Id", "JobSkill_Id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_job_skill",
                table: "job_skill");

            migrationBuilder.DropColumn(
                name: "JobSkill_Id",
                table: "job_skill");

            migrationBuilder.AddPrimaryKey(
                name: "PK_job_skill",
                table: "job_skill",
                columns: new[] { "JobRequisition_Id", "SkillId" });
        }
    }
}
