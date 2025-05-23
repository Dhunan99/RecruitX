using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitX.Migrations
{
    /// <inheritdoc />
    public partial class employeemodificationmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_job_requisitions_Employees_CreatedBy",
                table: "job_requisitions");

            migrationBuilder.DropForeignKey(
                name: "FK_job_requisitions_Employees_HiringManager",
                table: "job_requisitions");

            migrationBuilder.DropForeignKey(
                name: "FK_job_requisitions_Employees_RequestedBy",
                table: "job_requisitions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Email",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "employees");

            migrationBuilder.RenameColumn(
                name: "Position",
                table: "employees",
                newName: "position");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "employees",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "employees",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Department",
                table: "employees",
                newName: "department");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "employees",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "employees",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "employees",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "DeliveryUnit",
                table: "employees",
                newName: "delivery_unit");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "employees",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "employees",
                newName: "employee_id");

            migrationBuilder.AddColumn<int>(
                name: "location_id",
                table: "employees",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "user_id",
                table: "employees",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_employees",
                table: "employees",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_employees_location_id",
                table: "employees",
                column: "location_id");

            migrationBuilder.CreateIndex(
                name: "IX_employees_user_id",
                table: "employees",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_employees_locations_location_id",
                table: "employees",
                column: "location_id",
                principalTable: "locations",
                principalColumn: "location_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_employees_users_user_id",
                table: "employees",
                column: "user_id",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_job_requisitions_employees_CreatedBy",
                table: "job_requisitions",
                column: "CreatedBy",
                principalTable: "employees",
                principalColumn: "employee_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_job_requisitions_employees_HiringManager",
                table: "job_requisitions",
                column: "HiringManager",
                principalTable: "employees",
                principalColumn: "employee_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_job_requisitions_employees_RequestedBy",
                table: "job_requisitions",
                column: "RequestedBy",
                principalTable: "employees",
                principalColumn: "employee_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employees_locations_location_id",
                table: "employees");

            migrationBuilder.DropForeignKey(
                name: "FK_employees_users_user_id",
                table: "employees");

            migrationBuilder.DropForeignKey(
                name: "FK_job_requisitions_employees_CreatedBy",
                table: "job_requisitions");

            migrationBuilder.DropForeignKey(
                name: "FK_job_requisitions_employees_HiringManager",
                table: "job_requisitions");

            migrationBuilder.DropForeignKey(
                name: "FK_job_requisitions_employees_RequestedBy",
                table: "job_requisitions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_employees",
                table: "employees");

            migrationBuilder.DropIndex(
                name: "IX_employees_location_id",
                table: "employees");

            migrationBuilder.DropIndex(
                name: "IX_employees_user_id",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "location_id",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "employees");

            migrationBuilder.RenameTable(
                name: "employees",
                newName: "Employees");

            migrationBuilder.RenameColumn(
                name: "position",
                table: "Employees",
                newName: "Position");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "Employees",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Employees",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "department",
                table: "Employees",
                newName: "Department");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Employees",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "Employees",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "Employees",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "delivery_unit",
                table: "Employees",
                newName: "DeliveryUnit");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Employees",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "employee_id",
                table: "Employees",
                newName: "EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Email",
                table: "Employees",
                column: "Email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_job_requisitions_Employees_CreatedBy",
                table: "job_requisitions",
                column: "CreatedBy",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_job_requisitions_Employees_HiringManager",
                table: "job_requisitions",
                column: "HiringManager",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_job_requisitions_Employees_RequestedBy",
                table: "job_requisitions",
                column: "RequestedBy",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
