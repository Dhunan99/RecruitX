using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitX.Migrations
{
    /// <inheritdoc />
    public partial class correction3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_job_skill_job_requisitions_JobRequisition_Id1",
                table: "job_skill");

            migrationBuilder.DropIndex(
                name: "IX_job_skill_JobRequisition_Id1",
                table: "job_skill");

            migrationBuilder.DropColumn(
                name: "JobRequisition_Id1",
                table: "job_skill");

            migrationBuilder.AddForeignKey(
                name: "FK_job_skill_job_requisitions_JobRequisition_Id",
                table: "job_skill",
                column: "JobRequisition_Id",
                principalTable: "job_requisitions",
                principalColumn: "JobRequisition_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_job_skill_job_requisitions_JobRequisition_Id",
                table: "job_skill");

            migrationBuilder.AddColumn<int>(
                name: "JobRequisition_Id1",
                table: "job_skill",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_job_skill_JobRequisition_Id1",
                table: "job_skill",
                column: "JobRequisition_Id1");

            migrationBuilder.AddForeignKey(
                name: "FK_job_skill_job_requisitions_JobRequisition_Id1",
                table: "job_skill",
                column: "JobRequisition_Id1",
                principalTable: "job_requisitions",
                principalColumn: "JobRequisition_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
