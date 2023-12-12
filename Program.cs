using Hospital_Management_System;
using Hospital_Management_System.data;
using Hospital_Management_System.models;

using ApplicationDbContext context = new ApplicationDbContext();

try
{
    var rooms = context.Rooms;
    var doctors = context.Doctors;
    if (rooms.Count() == 0 && doctors.Count() == 0)
    {
        InitialEntries.IntializeRoomsAndDoctors(context);
    }
    else
    {
        StartPage startPage = new StartPage();
        startPage.Index(context);
    }
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
