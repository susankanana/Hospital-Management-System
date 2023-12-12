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
    public class RoomServices : IRoom
    {
        public void CreateRoom(Room room, ApplicationDbContext context)
        {
            try
            {
                context.Rooms.Add(room);
                context.SaveChanges();
                Console.WriteLine("Room Added Successfully... :)");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DeleteRoom(int roomId, ApplicationDbContext context)
        {
            try
            {
                var room = context.Rooms.Where(room => room.RoomId == roomId).FirstOrDefault();

                if (room != null)
                {
                    context.Rooms.Remove(room);
                    context.SaveChanges();
                    Console.WriteLine("Room removed successfully");
                }
                Console.WriteLine("The room you are trying to delete does not exist :(");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<Room> GetAllRooms(ApplicationDbContext context)
        {
            try
            {
                var rooms = context.Rooms;
                if (rooms == null || rooms.Count() == 0)
                {
                    return new List<Room>();
                }
                return rooms.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Room>();
            }
        }

        public Room GetRoom(int roomId, ApplicationDbContext context)
        {
            try
            {
                var room = context.Rooms
                                .Where(room => room.RoomId == roomId)
                                .Include(room => room.patients)
                                .FirstOrDefault();

                if (room != null)
                {
                    return room;
                }
                return new Room();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Room();
            }
        }

        public void UpdateRoom(int roomId, string roomNumber, string roomType, ApplicationDbContext context)
        {
            try
            {
                var room = context.Rooms.Where(room => room.RoomId == roomId).FirstOrDefault();

                if (room != null)
                {
                    room.RoomNumber = roomNumber;
                    room.RoomType = roomType;
                    context.SaveChanges();
                    Console.WriteLine("Room updated successfully");
                }
                Console.WriteLine("The room you are trying to update does not exist :(");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
