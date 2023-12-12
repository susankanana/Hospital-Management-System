using Hospital_Management_System.data;
using Hospital_Management_System.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.services.IServices
{
    public interface IPatient
    {
        void CreatePatient(Patient patient, ApplicationDbContext context);
        List<Patient>? GetAllPatients(ApplicationDbContext context);

        Patient? GetPatient(int patientId, ApplicationDbContext context);

        void AddPatientAppointment(int patientId, Appointment appointment, ApplicationDbContext context);

        void DeletePatient(int patientId, ApplicationDbContext context);
    }
}
