//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SIGAC.Layers.Bussiness.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class SIEDU_PAE_CAPACITACION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SIEDU_PAE_CAPACITACION()
        {
            this.SIEDU_PRESUPUESTO = new HashSet<SIEDU_PRESUPUESTO>();
        }
    
        public int CAPA_CAPA { get; set; }
        public int CAPA_PAE { get; set; }
        public bool CAPA_UDE_FUERZA_ESCU { get; set; }
        public decimal CAPA_UDE_ESCU { get; set; }
        public short CAPA_DOM_PROCE { get; set; }
        public short CAPA_DOM_ESTRA { get; set; }
        public bool CAPA_FUERZA_CARRERA { get; set; }
        public decimal CAPA_ID_CARRERA { get; set; }
        public short CAPA_NRO_NECE { get; set; }
        public string CAPA_ESTADO { get; set; }
        public int CAPA_TOTAL_PERSONAS { get; set; }
        public short CAPA_TOTAL_EVENTOS { get; set; }
        public Nullable<short> CAPA_DOM_MODAL { get; set; }
        public string CAPA_PPTO { get; set; }
        public int CAPA_EVEN_T1 { get; set; }
        public int CAPA_PERS_T1 { get; set; }
        public int CAPA_EVEN_T2 { get; set; }
        public int CAPA_PERS_T2 { get; set; }
        public int CAPA_EVEN_T3 { get; set; }
        public int CAPA_PERS_T3 { get; set; }
        public int CAPA_EVEN_T4 { get; set; }
        public int CAPA_PERS_T4 { get; set; }
        public string CAPA_USU_CREA { get; set; }
        public System.DateTime CAPA_FECHA_CREA { get; set; }
        public string CAPA_MAQUINA_CREA { get; set; }
        public string CAPA_IP_CREA { get; set; }
        public string CAPA_USU_MOD { get; set; }
        public Nullable<System.DateTime> CAPA_FECHA_MOD { get; set; }
        public string CAPA_MAQUINA_MOD { get; set; }
        public string CAPA_IP_MOD { get; set; }
        public string CAPA_EXTERNO { get; set; }
    
        public virtual SIEDU_PAE SIEDU_PAE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SIEDU_PRESUPUESTO> SIEDU_PRESUPUESTO { get; set; }
    }
}
