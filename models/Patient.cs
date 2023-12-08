using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.models
{
    public class Patient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PatientId { get; set; }
        public string FirstName { get; set; }=string.Empty;
        public string LastName { get; set; } =string.Empty;
        public string Title { get; set; }= string.Empty;
        public int RoomID { get; set; } = 0;
        public Room room { get; set; }
        public List<Doctor> doctors { get; set; }
    }
}
