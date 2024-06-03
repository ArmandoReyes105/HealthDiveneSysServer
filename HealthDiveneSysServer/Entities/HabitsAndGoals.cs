using System.Runtime.Serialization;

namespace HealthDiveneSysServer.Entities
{
    [DataContract]
    public class HabitsAndGoals
    {
        [DataMember]
        public int IdHabitsAndGoals { get; set; }

        [DataMember]
        public string Caffeine { get; set;  }

        [DataMember]
        public string Alcohol { get; set; }

        [DataMember]
        public string Cigarette { get; set; }

        [DataMember]
        public string Drugs { get; set; }

        [DataMember]
        public string HealthGoals { get; set; }

        [DataMember]
        public string SpecificNutritionalGoals { get; set; }

        [DataMember]
        public string Expectations { get; set; }

        [DataMember]
        public string GeneralComment { get; set; }
    }
}