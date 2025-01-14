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
    
    public partial class Measures
    {
        public int IdMeasures { get; set; }
        public Nullable<double> Chest { get; set; }
        public Nullable<double> Arm { get; set; }
        public Nullable<double> ContractedArm { get; set; }
        public Nullable<double> Forearm { get; set; }
        public Nullable<double> Waist { get; set; }
        public Nullable<double> Hip { get; set; }
        public Nullable<double> Thigh { get; set; }
        public Nullable<double> Calf { get; set; }
        public Nullable<int> IdPatient { get; set; }
        public Nullable<int> IdDiagnosis { get; set; }
    
        public virtual Diagnoses Diagnoses { get; set; }
        public virtual Patients Patients { get; set; }
    }
}
