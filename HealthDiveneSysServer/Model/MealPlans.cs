//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HealthDiveneSysServer.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class MealPlans
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MealPlans()
        {
            this.Meals = new HashSet<Meals>();
        }
    
        public int IdMealPlan { get; set; }
        public string Comments { get; set; }
        public string PlanDescription { get; set; }
        public Nullable<System.DateTime> PlanDate { get; set; }
        public string Recommendations { get; set; }
        public Nullable<int> IdPatient { get; set; }
    
        public virtual Patients Patients { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Meals> Meals { get; set; }
    }
}
