using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace HealthDiveneSysServer.Entities
{
    [DataContract]
    public class MealPlan
    {
        [DataMember]
        public int IdMealPlan { get; set; }

        [DataMember]
        public string Comments { get; set; }

        [DataMember]
        public string PlanDescription { get; set; }

        [DataMember]
        public DateTime PlanDate { get; set; }

        [DataMember]
        public string Recommendations { get; set; }

        [DataMember]
        public int IdPatient { get; set; }

        [DataMember]
        public List<Meal> Meals { get; set; }
    }
}