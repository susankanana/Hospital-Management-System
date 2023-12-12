using Hospital_Management_System.controllers;
using Hospital_Management_System.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System
{
    public class StartPage
    {
        private readonly PatientsController _patientsController;
        private readonly RoomController _roomController;

        public StartPage()
        {
            _patientsController = new PatientsController();
            _roomController= new RoomController();
        }
        public void Index(ApplicationDbContext context)
        {
            do
            {
                Console.WriteLine("Hospital Management System");
                Console.WriteLine("--------------------------\n");
                Console.WriteLine("Enter 1 to add a patient.");
                Console.WriteLine("Enter 2 to view all patients.");
                Console.WriteLine("Enter 3 to view a single patient.");
                Console.WriteLine("Enter 4 to add a patient appointment.");
                Console.WriteLine("Enter 5 to delete a patient.");
                Console.WriteLine("Enter 6 to view all rooms.");
                Console.WriteLine("Enter 7 to view a room.");
                Console.WriteLine("q to exit");
                string? option = Console.ReadLine();
                if (option == "q")
                {
                    Console.WriteLine("Bye...");
                    break;
                }
                var options = new List<string>() { "1", "2", "3", "4", "5" ,"6","7","q"};
                try
                {
                    ValidateOptions(option, options);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                RedirectUser(option, context);
            } while (true);
        }

        public void RedirectUser(string option, ApplicationDbContext context)
        {
            switch (option)
            {
                case "1":
                    _patientsController.AddPatient(context);
                    break;
                case "2":
                    _patientsController.ViewAllPatients(context);
                    break;
                case "3":
                    _patientsController.ViewSinglePatient(context);
                    break;
                case "4":
                    _patientsController.CreateAppointment(context);
                    break;
                case "5":
                    _patientsController.DeletePatient(context);
                    break;
                case "6":
                    _roomController.ViewAllRooms(context);
                    break;
                case "7":
                    _roomController.ViewRoom(context);
                    break;
            }
        }
        public void ValidateOptions(string option, List<string> options)
        {
            if (string.IsNullOrWhiteSpace(option) || !options.Contains(option))
            {
                throw new Exception("\t\tInvalid option.\n");
            }
        }
    }
}

