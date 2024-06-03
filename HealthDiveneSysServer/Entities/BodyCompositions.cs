using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace HealthDiveneSysServer.Entities
{
    [DataContract]
    public class BodyCompositions
    {
        [DataMember]
        public int IdBodyComposition { get; set; }

        [DataMember]
        public double VisceralFat { get; set; }

        [DataMember]
        public double TotalWeight { get; set; }

        [DataMember]
        public double WaterPercentage { get; set; }

        [DataMember]
        public double FatPercentage { get; set; }

        [DataMember]
        public double MusclePercentage { get; set; }

        [DataMember]
        public int IdPatient { get; set; }

        [DataMember]
        public int IdDiagnosis { get; set; }
    }
}