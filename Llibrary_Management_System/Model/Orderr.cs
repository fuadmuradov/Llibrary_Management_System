//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Llibrary_Management_System.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Orderr
    {
        public int id { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public Nullable<double> Debtbook { get; set; }
        public Nullable<bool> returned { get; set; }
        public Nullable<int> ReaderId { get; set; }
        public Nullable<int> BookId { get; set; }
    
        public virtual Book Book { get; set; }
        public virtual Reader Reader { get; set; }
    }
}