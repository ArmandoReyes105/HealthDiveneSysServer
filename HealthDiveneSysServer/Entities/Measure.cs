using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace HealthDiveneSysServer.Entities
{
    [DataContract]
    public class Measure
    {
        [DataMember]
        public int IdMeasure { get; set; }

        [DataMember]
        public double Chest { get; set; }

        [DataMember]
        public double Arm { get; set; }

        [DataMember]
        public double ContractedArm { get; set; }

        [DataMember]
        public double Forearm { get; set; }

        [DataMember]
        public double Waist { get; set; }

        [DataMember]
        public double Hip { get; set; }

        [DataMember]
        public double Thigh { get; set; }

        [DataMember]
        public double Calf { get; set; }

        [DataMember]
        public int IdPatient { get; set; }

        [DataMember]
        public int IdDiagnosis { get; set; }
    }
}