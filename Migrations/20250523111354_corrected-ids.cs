using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitX.Migrations
{
    /// <inheritdoc />
    public partial class correctedids : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_job_descriptions_job_requisitions_JobRequisition_Id",
                table: "job_descriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_job_skill_job_requisitions_JobRequisition_Id",
                table: "job_skill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_job_skill",
                table: "job_skill");

            migrationBuilder.DropIndex(
                name: "IX_job_skill_JobRequisition_Id",
                table: "job_skill");

            migrationBuilder.RenameColumn(
                name: "JrId",
                table: "job_skill",
                newName: "JobRequisition_Id1");

            migrationBuilder.RenameColumn(
                name: "JobRequisition_Id",
                table: "job_descriptions",
                newName: "JobRequisition_Id1");

            migrationBuilder.RenameIndex(
                name: "IX_job_descriptions_JobRequisition_Id",
                table: "job_descriptions",
                newName: "IX_job_descriptions_JobRequisition_Id1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_job_skill",
                table: "job_skill",
                columns: new[] { "JobRequisition_Id", "SkillId" });

            migrationBuilder.CreateIndex(
                name: "IX_job_skill_JobRequisition_Id1",
                table: "job_skill",
                column: "JobRequisition_Id1");

            migrationBuilder.AddForeignKey(
                name: "FK_job_descriptions_job_requisitions_JobRequisition_Id1",
                table: "job_descriptions",
                column: "JobRequisition_Id1",
                principalTable: "job_requisitions",
                principalColumn: "JobRequisition_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_job_skill_job_requisitions_JobRequisition_Id1",
                table: "job_skill",
                column: "JobRequisition_Id1",
                principalTable: "job_requisitions",
                principalColumn: "JobRequisition_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_job_descriptions_job_requisitions_JobRequisition_Id1",
                table: "job_descriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_job_skill_job_requisitions_JobRequisition_Id1",
                table: "job_skill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_job_skill",
                table: "job_skill");

            migrationBuilder.DropIndex(
                name: "IX_job_skill_JobRequisition_Id1",
                table: "job_skill");

            migrationBuilder.RenameColumn(
                name: "JobRequisition_Id1",
                table: "job_skill",
                newName: "JrId");

            migrationBuilder.RenameColumn(
                name: "JobRequisition_Id1",
                table: "job_descriptions",
                newName: "JobRequisition_Id");

            migrationBuilder.RenameIndex(
                name: "IX_job_descriptions_JobRequisition_Id1",
                table: "job_descriptions",
                newName: "IX_job_descriptions_JobRequisition_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_job_skill",
                table: "job_skill",
                columns: new[] { "JrId", "SkillId" });

            migrationBuilder.CreateIndex(
                name: "IX_job_skill_JobRequisition_Id",
                table: "job_skill",
                column: "JobRequisition_Id");

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
    }
}
