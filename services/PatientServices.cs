using Hospital_Management_System.data;
using Hospital_Management_System.models;
using Hospital_Management_System.services.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.services
{
    internal class PatientServices : IPatient
    {
        public void AddPatientAppointment(int patientId, Appointment appointment, ApplicationDbContext context)
        {
            try
            {
                var patient = context.Patients
                            .Where(p => p.PatientId == patientId)
                            .Include(p => p.appointments)
                            .FirstOrDefault();

                if (patient != null)
                {
                    if (patient.appointments == null)
                    {
                        patient.appointments = new List<Appointment>();
                    }
                    patient.appointments.Add(appointment);
                    context.SaveChanges();
                    Console.WriteLine("\nAppointment added successfully... :)\n");
                }
                else
                {
                    Console.WriteLine("\nPatient you want to create an appointment for does not exist:(\n");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void CreatePatient(Patient patient, ApplicationDbContext context)
        {
            try
            {
                context.Patients.Add(patient);
                context.SaveChanges();
                Console.WriteLine("\nPatient Added Successfully... :)\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DeletePatient(int patientId, ApplicationDbContext context)
        {
            try
            {
                var patient = context.Patients.Where(p => p.PatientId == patientId).FirstOrDefault();

                if (patient != null)
                {
                    context.Patients.Remove(patient);
                    context.SaveChanges();
                    Console.WriteLine("\nPatient Deleted Successfully... :)\n");
                    return;
                }
                Console.WriteLine("\n Patient you want to delete does not exist :(\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }

        public List<Patient>? GetAllPatients(ApplicationDbContext context)
        {
            try {
                var patients = context.Patients
                                .Include(p => p.appointments)
                                .Include(p => p.room)
                                .ToList();
                return patients ?? null;
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

          
        }

        public Patient? GetPatient(int patientId, ApplicationDbContext context)
        {
            try
            {
                var patient = context.Patients
                                .Where(p => p.PatientId == patientId)
                                .Include(p => p.appointments)
                                .Include(p => p.room)
                                .FirstOrDefault();

                return patient ?? null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
