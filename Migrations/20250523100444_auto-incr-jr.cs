using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitX.Migrations
{
    /// <inheritdoc />
    public partial class autoincrjr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_job_descriptions_job_requisitions_JobRequisitionJrId",
                table: "job_descriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_job_skill_job_requisitions_JobRequisitionJrId",
                table: "job_skill");

            migrationBuilder.RenameColumn(
                name: "JobRequisitionJrId",
                table: "job_skill",
                newName: "JobRequisition_Id");

            migrationBuilder.RenameIndex(
                name: "IX_job_skill_JobRequisitionJrId",
                table: "job_skill",
                newName: "IX_job_skill_JobRequisition_Id");

            migrationBuilder.RenameColumn(
                name: "JrId",
                table: "job_requisitions",
                newName: "JobRequisition_Id");

            migrationBuilder.RenameColumn(
                name: "JobRequisitionJrId",
                table: "job_descriptions",
                newName: "JobRequisition_Id");

            migrationBuilder.RenameIndex(
                name: "IX_job_descriptions_JobRequisitionJrId",
                table: "job_descriptions",
                newName: "IX_job_descriptions_JobRequisition_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_job_descriptions_job_requisitions_JobRequisition_Id",
                table: "job_descriptions",
                column: "JobRequisition_Id",
                principalTable: "job_requisitions",
                principalColumn: "JobRequisition_Id");

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
                name: "FK_job_descriptions_job_requisitions_JobRequisition_Id",
                table: "job_descriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_job_skill_job_requisitions_JobRequisition_Id",
                table: "job_skill");

            migrationBuilder.RenameColumn(
                name: "JobRequisition_Id",
                table: "job_skill",
                newName: "JobRequisitionJrId");

            migrationBuilder.RenameIndex(
                name: "IX_job_skill_JobRequisition_Id",
                table: "job_skill",
                newName: "IX_job_skill_JobRequisitionJrId");

            migrationBuilder.RenameColumn(
                name: "JobRequisition_Id",
                table: "job_requisitions",
                newName: "JrId");

            migrationBuilder.RenameColumn(
                name: "JobRequisition_Id",
                table: "job_descriptions",
                newName: "JobRequisitionJrId");

            migrationBuilder.RenameIndex(
                name: "IX_job_descriptions_JobRequisition_Id",
                table: "job_descriptions",
                newName: "IX_job_descriptions_JobRequisitionJrId");

            migrationBuilder.AddForeignKey(
                name: "FK_job_descriptions_job_requisitions_JobRequisitionJrId",
                table: "job_descriptions",
                column: "JobRequisitionJrId",
                principalTable: "job_requisitions",
                principalColumn: "JrId");

            migrationBuilder.AddForeignKey(
                name: "FK_job_skill_job_requisitions_JobRequisitionJrId",
                table: "job_skill",
                column: "JobRequisitionJrId",
                principalTable: "job_requisitions",
                principalColumn: "JrId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
