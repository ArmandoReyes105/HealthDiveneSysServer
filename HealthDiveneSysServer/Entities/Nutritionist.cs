using System.Runtime.Serialization;

namespace HealthDiveneSysServer.Entities
{
    [DataContract]
    public class Nutritionist
    {
        [DataMember]
        public int IdNutritionist {  get; set; }

        [DataMember]
        public string ProfessionalId { get; set; }

        [DataMember]
        public Person Person { get; set; }
    }
}