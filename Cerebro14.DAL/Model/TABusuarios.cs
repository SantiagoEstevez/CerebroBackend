//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cerebro14.DAL.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class TABusuarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TABusuarios()
        {
            this.TABacciones = new HashSet<TABacciones>();
        }
    
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public System.DateTime fechaN { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string pass { get; set; }
        public double FK_Edi_Lat { get; set; }
        public double FK_Edi_Lon { get; set; }
        public string telefono { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TABacciones> TABacciones { get; set; }
        public virtual TABedificios TABedificios { get; set; }
    }
}
