//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GameShop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class banner
    {
        public int id { get; set; }
        public string img_url { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public Nullable<bool> deleted { get; set; }
        public System.DateTime create_at { get; set; }
        public System.DateTime update_at { get; set; }
    }
}
