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
    
    public partial class Account
    {
        public int IdAccount { get; set; }
        public string Username { get; set; }
        public string AccountPassword { get; set; }
        public Nullable<int> IdNutritionist { get; set; }
    
        public virtual Nutritionists Nutritionists { get; set; }
    }
}