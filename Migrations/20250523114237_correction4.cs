using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RecruitX.Migrations
{
    /// <inheritdoc />
    public partial class correction4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_job_skill_job_requisitions_JobRequisition_Id",
                table: "job_skill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_job_skill",
                table: "job_skill");

            migrationBuilder.AlterColumn<int>(
                name: "JobSkill_Id",
                table: "job_skill",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "JobRequisition_Id1",
                table: "job_skill",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_job_skill",
                table: "job_skill",
                column: "JobSkill_Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_job_skill_job_requisitions_JobRequisition_Id1",
                table: "job_skill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_job_skill",
                table: "job_skill");

            migrationBuilder.DropIndex(
                name: "IX_job_skill_JobRequisition_Id1",
                table: "job_skill");

            migrationBuilder.DropColumn(
                name: "JobRequisition_Id1",
                table: "job_skill");

            migrationBuilder.AlterColumn<int>(
                name: "JobSkill_Id",
                table: "job_skill",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_job_skill",
                table: "job_skill",
                columns: new[] { "JobRequisition_Id", "JobSkill_Id" });

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
