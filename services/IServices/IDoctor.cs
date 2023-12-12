using Hospital_Management_System.data;
using Hospital_Management_System.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.services.IServices
{
    public interface IDoctor
    {
        void CreateDoctor(Doctor doctor, ApplicationDbContext context);
        List<Doctor> GetAllDoctors(ApplicationDbContext context);

        Doctor GetDoctor(int doctorId, ApplicationDbContext context);

        void UpdateDoctor(int doctorId, string doctorName, string doctorSpecialty, ApplicationDbContext context);

        void DeleteDoctor(int doctorId, ApplicationDbContext context);
    }
}
