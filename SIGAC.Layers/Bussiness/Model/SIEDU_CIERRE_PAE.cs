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
    
    public partial class SIEDU_CIERRE_PAE
    {
        public int RPAE_RPAE { get; set; }
        public short RPAE_NOVE { get; set; }
        public int RPAE_CAPA { get; set; }
        public short RPAE_CAPA_NRO_NECE { get; set; }
        public int RPAE_FORM { get; set; }
        public short RPAE_FORM_NRO_NECE { get; set; }
        public string RPAE_USU_CREA { get; set; }
        public System.DateTime RPAE_FECHA_CREA { get; set; }
        public string RPAE_MAQUINA_CREA { get; set; }
        public string RPAE_IP_CREA { get; set; }
        public string RPAE_USU_MOD { get; set; }
        public Nullable<System.DateTime> RPAE_FECHA_MOD { get; set; }
        public string RPAE_MAQUINA_MOD { get; set; }
        public string RPAE_IP_MOD { get; set; }
    
        public virtual SIEDU_PAE_CAPACITACION SIEDU_PAE_CAPACITACION { get; set; }
        public virtual SIEDU_PAE_FORMACION SIEDU_PAE_FORMACION { get; set; }
        public virtual SIEDU_NOVEDAD_PAE SIEDU_NOVEDAD_PAE { get; set; }
    }
}
