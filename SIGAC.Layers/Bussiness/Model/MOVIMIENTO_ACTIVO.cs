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
    
    public partial class MOVIMIENTO_ACTIVO
    {
        public int ID { get; set; }
        public Nullable<int> ID_ACTIVO { get; set; }
        public Nullable<int> ID_AULA { get; set; }
        public Nullable<int> ID_ASIGNADO { get; set; }
        public Nullable<System.DateTime> FECHA { get; set; }
        public byte[] NOTA { get; set; }
        public byte[] OBSERVACION { get; set; }
        public string ESTATUS { get; set; }
        public Nullable<int> ID_ESCUELAS { get; set; }
    }
}
