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
    
    public partial class EMPLEADO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EMPLEADO()
        {
            this.EMPLEADO1 = new HashSet<EMPLEADO>();
        }
    
        public short EMPNO { get; set; }
        public string ENAME { get; set; }
        public string JOB { get; set; }
        public Nullable<short> MGR { get; set; }
        public Nullable<System.DateTime> HIREDATE { get; set; }
        public Nullable<decimal> SAL { get; set; }
        public Nullable<decimal> COMM { get; set; }
        public Nullable<byte> DEPTNO { get; set; }
    
        public virtual DEPARTAMENTO DEPARTAMENTO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPLEADO> EMPLEADO1 { get; set; }
        public virtual EMPLEADO EMPLEADO2 { get; set; }
    }
}
