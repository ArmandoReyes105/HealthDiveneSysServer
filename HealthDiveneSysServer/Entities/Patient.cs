using System;
using System.Runtime.Serialization;

namespace HealthDiveneSysServer.Entities
{
    [DataContract]
    public class Patient
    {
        [DataMember]
        public int IdPatient { get; set; }

        [DataMember]
        public float Height { get; set; }

        [DataMember]
        public DateTime Birthday { get; set; }

        [DataMember]
        public string Gender { get; set; }

        [DataMember]
        public Person Person { get; set; }

        [DataMember]
        public int Nutritionist { get; set; }

        [DataMember]
        public MedicalInformation MedicalInformation { get; set; }

        [DataMember]
        public GeneralInformation GeneralInfomation { get; set; }

        [DataMember]
        public HabitsAndGoals HabitsAndGoals { get; set; }
    }
}