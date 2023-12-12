using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.models
{
    public class Appointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AppointmentId { get; set; }
        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public Patient patient { get; set; } = null!;
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public Doctor doctor { get; set; } = null!;
        
        public DateTime AppointmentDate { get; set; }

        public DateTime AppointmentTime { get; set; }
    }
}
