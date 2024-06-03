using System.Runtime.Serialization;

namespace HealthDiveneSysServer.Entities
{
    [DataContract]
    public class Person
    {
        [DataMember]
        public int IdPerson { get; set; }

        [DataMember]
        public string Names { get; set; }

        [DataMember]
        public string FirstLastName { get; set; }

        [DataMember]
        public string SecondLastName { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Phone { get; set; }

        public string GetFullName()
        {
            return Names + " " + FirstLastName + " " + SecondLastName;
        }
    }
}