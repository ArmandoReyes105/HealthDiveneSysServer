using System;
using System.Runtime.Serialization;

namespace HealthDiveneSysServer.Entities
{
    [DataContract]
    public class Diagnosis
    {
        [DataMember]
        public int IdDiagnosis { get; set; }

        [DataMember]
        public DateTime DiagnosisDate { get; set; }

        [DataMember]
        public string PhysicalActivity { get; set; }

        [DataMember]
        public string PhysicalPerception { get; set; }

        [DataMember]
        public string Feeding {  get; set; }

        [DataMember]
        public string Appetite { get; set; }

        [DataMember]
        public string WaterConsumption { get; set; }

        [DataMember]
        public string Dream { get; set; }

        [DataMember]
        public string StomachUpset { get; set; }

        [DataMember]
        public string EnergyLevel { get; set; }

        [DataMember]
        public string StressLevel { get; set; }

        [DataMember]
        public string SubstanceUse { get; set; }

        [DataMember]
        public string GeneralComments { get; set; }

        [DataMember]
        public int PatientId { get; set; }

        [DataMember]
        public BodyCompositions BodyComposition { get; set; }

        [DataMember]
        public Measure Measure { get; set; }

        [DataMember]
        public DiagnosisImage Image { get; set; }

    }
}