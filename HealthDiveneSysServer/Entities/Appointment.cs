using System;
using System.Runtime.Serialization;

namespace HealthDiveneSysServer.Entities
{
    [DataContract]
    public class Appointment
    {
        [DataMember]
        public int IdAppointment { get; set; }

        [DataMember]
        public DateTime AppointmentDate { get; set; }

        [DataMember]
        public TimeSpan StartTime { get; set; }

        [DataMember]
        public TimeSpan EndTime { get; set; }

        [DataMember]
        public int IdPatient { get; set; }

        [DataMember]
        public int IdNutritionist { get; set; }
    }
}