using Hospital_Management_System.data;
using Hospital_Management_System.models;

using ApplicationDbContext context = new ApplicationDbContext();
//one-to-many relationship room and patients
List<Patient> _patient = new List<Patient>()
{
    new Patient(){ FirstName="Albert", LastName="Einstein", Title="Anaemia"},
    new Patient(){ FirstName="Gordon", LastName="Wabosho", Title="Tuberculosis"},
    new Patient(){ FirstName="Brenda", LastName="Njoki", Title="Malaria"},
};
List<Patient> _patient1 = new List<Patient>()
{
    new Patient(){ FirstName="Brian", LastName="Kimathi", Title="Flu"},
    new Patient(){ FirstName="Janet", LastName="Akinyi", Title="Dehydration"}
};
//Room room = new Room()
//{
//    RoomNumber="2",
//    RoomType="Tripple",
//    patients = _patient,
//};
//Room room1 = new Room()
//{
//    RoomNumber = "1",
//    RoomType = "Double",
//    patients = _patient1,
//};
//context.Rooms.Add(room);
//context.Rooms.Add(room1 );
//context.SaveChanges(true);

//many-to-mamny relationship between patient and doctor
Doctor doctor = new Doctor()
{
    DoctorName = "Njau",
    Speciality = "Microbiology",
    patients = _patient
};
Doctor doctor1 = new Doctor()
{
    DoctorName = "Muriuki",
    Speciality = "General doctor",
    patients = _patient
};
Doctor doctor2 = new Doctor()
{
    DoctorName = "Omondi",
    Speciality = "Physiotherapy",
    patients = _patient1
};
context.Doctors.Add(doctor);
context.Doctors.Add(doctor1);
context.Doctors.Add(doctor2);
context.SaveChanges(true);

