using Hospital_Management_System.data;
using Hospital_Management_System.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.services.IServices
{
    public interface IRoom
    {
        void CreateRoom(Room room, ApplicationDbContext context);
        List<Room> GetAllRooms(ApplicationDbContext context);

        Room GetRoom(int roomId, ApplicationDbContext context);

        void UpdateRoom(int roomId, string roomNumber, string roomType, ApplicationDbContext context);

        void DeleteRoom(int roomId, ApplicationDbContext context);
    }
}
