using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace HealthDiveneSysServer.Entities
{
    [DataContract]
    public class Meal
    {
        [DataMember]
        public int IdMeal { get; set; }

        [DataMember]
        public string MealType { get; set; }

        [DataMember]
        public string Equivalences { get; set; }

        [DataMember]
        public string MealExamples { get; set; }

        [DataMember]
        public int IdMealPlan { get; set; }
    }
}