using Hospital_Management_System.data;
using Hospital_Management_System.models;
using Hospital_Management_System.services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.services
{
    public class DoctorServices : IDoctor
    {
        public void CreateDoctor(Doctor doctor, ApplicationDbContext context)
        {
            try
            {
                context.Doctors.Add(doctor);
                context.SaveChanges();
                Console.WriteLine("Doctor Added Successfully :)");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DeleteDoctor(int doctorId, ApplicationDbContext context)
        {
            try
            {
                var doctor = context.Doctors
                                .Where(doctor => doctor.DoctorId == doctorId)
                                .FirstOrDefault();
                if (doctor != null)
                {
                    context.Doctors.Remove(doctor);
                    context.SaveChanges();
                    Console.WriteLine("Doctor deleted Successfully :)");
                }
                Console.WriteLine("The doctor you are try to delete does not exist :(");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }

        public List<Doctor> GetAllDoctors(ApplicationDbContext context)
        {
            try
            {
                var doctors = context.Doctors;

                if (doctors != null)
                {
                    return doctors.ToList();
                }

                return new List<Doctor>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Doctor>();
            }
        }

        public Doctor GetDoctor(int doctorId, ApplicationDbContext context)
        {
            try
            {
                var doctor = context.Doctors
                                .Where(doctor => doctor.DoctorId == doctorId)
                                .FirstOrDefault();
                if (doctor != null)
                {
                    return doctor;
                }
                return new Doctor();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Doctor();
            }
        }

        public void UpdateDoctor(int doctorId, string doctorName, string doctorSpecialty, ApplicationDbContext context)
        {
            try
            {
                var doctor = context.Doctors
                                .Where(doctor => doctor.DoctorId == doctorId)
                                .FirstOrDefault();
                if (doctor != null)
                {
                    doctor.DoctorName = doctorName;
                    doctor.Speciality = doctorSpecialty;
                    context.SaveChanges();
                    Console.WriteLine("Doctor Updated Successfully :)");
                }
                Console.WriteLine("The doctor you are try to update does not exist :(");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }
    }
}
