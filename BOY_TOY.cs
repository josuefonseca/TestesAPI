//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestesAPI
{
    using System;
    using System.Collections.Generic;
    
    public partial class BOY_TOY
    {
        public int ID_BOY_TOY { get; set; }
        public int ID_BOY { get; set; }
        public int ID_TOY { get; set; }
        public System.DateTime DT_DONATION { get; set; }
    
        public virtual BOY BOY { get; set; }
        public virtual TOY TOY { get; set; }
    }
}
