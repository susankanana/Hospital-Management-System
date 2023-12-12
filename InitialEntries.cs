using Hospital_Management_System.data;
using Hospital_Management_System.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System
{
    public class InitialEntries
    {
        public static void IntializeRoomsAndDoctors(ApplicationDbContext context)
        {
            try
            {
                var general = new Room()
                {
                    RoomNumber = "01",
                    RoomType = "General Ward"
                };
                var intensive = new Room()
                {
                    RoomNumber = "01",
                    RoomType = "ICU"
                };
                var intern = new Doctor()
                {
                    DoctorName = "Anna",
                    Speciality = "Intern"
                };

                var specialist = new Doctor()
                {
                    DoctorName = "Samuel",
                    Speciality = "Dermatologist"
                };

                context.Rooms.Add(general);
                context.Rooms.Add(intensive);
                context.Doctors.Add(intern);
                context.Doctors.Add(specialist);
                context.SaveChanges();
                Console.WriteLine("System Initialized successfully..... :)");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
