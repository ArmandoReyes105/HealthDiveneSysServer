using System.Runtime.Serialization;

namespace HealthDiveneSysServer.Entities
{
    [DataContract]
    public class MedicalInformation
    {
        [DataMember]
        public int IdMedicalInformation {  get; set; }

        [DataMember]
        public string ChronicDiseases { get; set; }

        [DataMember]
        public string HereditaryFamilyHistory { get; set; }

        [DataMember]
        public string GastrointestinalDiseases { get; set; }

        [DataMember]
        public string FoodAllergies { get; set; }

        [DataMember]
        public string NonFoodAllergies { get; set; }

        [DataMember]
        public string SurgicalHistory { get; set; }

        [DataMember]
        public string Medications { get; set; }

        [DataMember]
        public string GeneralMedicalComments { get; set; }


    }
}