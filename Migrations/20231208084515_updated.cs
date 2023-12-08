using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorPatient_Doctors_doctorsDoctorId",
                table: "DoctorPatient");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorPatient_Patients_patientsPatientId",
                table: "DoctorPatient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DoctorPatient",
                table: "DoctorPatient");

            migrationBuilder.RenameTable(
                name: "DoctorPatient",
                newName: "Appointment");

            migrationBuilder.RenameIndex(
                name: "IX_DoctorPatient_patientsPatientId",
                table: "Appointment",
                newName: "IX_Appointment_patientsPatientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointment",
                table: "Appointment",
                columns: new[] { "doctorsDoctorId", "patientsPatientId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Doctors_doctorsDoctorId",
                table: "Appointment",
                column: "doctorsDoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Patients_patientsPatientId",
                table: "Appointment",
                column: "patientsPatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Doctors_doctorsDoctorId",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Patients_patientsPatientId",
                table: "Appointment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointment",
                table: "Appointment");

            migrationBuilder.RenameTable(
                name: "Appointment",
                newName: "DoctorPatient");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_patientsPatientId",
                table: "DoctorPatient",
                newName: "IX_DoctorPatient_patientsPatientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoctorPatient",
                table: "DoctorPatient",
                columns: new[] { "doctorsDoctorId", "patientsPatientId" });

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorPatient_Doctors_doctorsDoctorId",
                table: "DoctorPatient",
                column: "doctorsDoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorPatient_Patients_patientsPatientId",
                table: "DoctorPatient",
                column: "patientsPatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
