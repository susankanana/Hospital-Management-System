using Hospital_Management_System.data;
using Hospital_Management_System.models;
using Hospital_Management_System.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.controllers
{
    public class RoomController
    {

        private readonly RoomServices _roomServices;
        public RoomController()
        {
            _roomServices = new RoomServices();
        }
        public void ViewAllRooms(ApplicationDbContext context)
        {
            var rooms = _roomServices.GetAllRooms(context);
            Console.WriteLine("\nAvailable Rooms");
            Console.WriteLine("--------------\n");
            if (rooms.Count() > 0)
            {
                foreach (var room in rooms)
                {
                    Console.WriteLine($"\t\tRoom Id: {room.RoomId} Room Number: {room.RoomNumber} | Room Type: {room.RoomType}\n");
                }
            }
            else
            {
                Console.WriteLine("\nNo patients at the moment\n");
            }

        }
        public void ViewRoom(ApplicationDbContext context)
        {
            do
            {
                ViewAllRooms(context);
                Console.WriteLine("\nEnter Id of the room you want to view.");
                string? roomId = Console.ReadLine();
                Room room;


                try
                {
                    room = ValidateRoomId(roomId, context);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                Console.WriteLine("Room Details");
                Console.WriteLine("------------\n");
                Console.WriteLine($"\tRoom Number: {room.RoomNumber} | Room Type: {room.RoomType}\n");
                var patients = room.patients;
                if (patients != null)
                {
                    Console.WriteLine("\t\tPatients in Room");
                    Console.WriteLine("\t\t-------------------\n");
                    foreach (var patient in patients)
                    {
                        Console.WriteLine($"\t\t\tPatient Name: {patient.FirstName} {patient.LastName}");
                        Console.WriteLine($"\t\t\tPatient Email: {patient.Email}");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("\n\tNo patients currently in this room\n");
                }
                break;
            }
            while (true);
        }

        public Room? ValidateRoomId(string roomId, ApplicationDbContext context)
        {
            bool isInteger = int.TryParse(roomId, out int number);
            if (isInteger)
            {
                var room = _roomServices.GetRoom(number, context);
                if (room.RoomType == null)
                {
                    throw new Exception($"\t\tThe room id you entered is not valid\n");
                }
                return room;
            }
            throw new Exception("\t\tThe room id you entered is not valid\n");
        }

    }
}
