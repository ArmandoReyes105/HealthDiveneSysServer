using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace HealthDiveneSysServer.Entities
{
    [DataContract]
    public class GeneralInformation
    {
        [DataMember]
        public int IdGeneralInformation {  get; set; }

        [DataMember]
        public string GeneralComments { get; set; }

        [DataMember]
        public int PhysicalActivity {  get; set; }

        [DataMember]
        public string PhysicalActivityComments { get; set; }

        [DataMember]
        public string FavoriteFoods { get; set; }

        [DataMember]
        public string NonFavoriteFoods { get; set; }

        [DataMember]
        public string DietarySupplements { get; set; }

        [DataMember]
        public string NutritionalFamiliarity { get; set; }

        [DataMember]
        public string EatingEmotionalBehavior { get; set; }
    }
}