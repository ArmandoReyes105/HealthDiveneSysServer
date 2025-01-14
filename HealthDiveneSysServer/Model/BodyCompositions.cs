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
    
    public partial class BodyCompositions
    {
        public int IdBodyComposition { get; set; }
        public Nullable<double> VisceralFat { get; set; }
        public Nullable<double> TotalWeight { get; set; }
        public Nullable<double> WaterPercentage { get; set; }
        public Nullable<double> FatPercentage { get; set; }
        public Nullable<double> MusclePercentage { get; set; }
        public Nullable<int> IdPatient { get; set; }
        public Nullable<int> IdDiagnosis { get; set; }
    
        public virtual Diagnoses Diagnoses { get; set; }
        public virtual Patients Patients { get; set; }
    }
}
