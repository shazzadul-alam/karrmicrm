//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LogisticManagement.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_CandidateDocument
    {
        public int AutoId { get; set; }
        public int CandidateId { get; set; }
        public Nullable<int> DocumentId { get; set; }
        public string DocumentKey { get; set; }
        public Nullable<System.DateTime> DocumentExpiryDate { get; set; }
        public string DocumentImageRef { get; set; }
        public string DocumentOrgImageRef { get; set; }
    }
}