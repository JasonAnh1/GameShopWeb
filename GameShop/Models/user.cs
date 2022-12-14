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
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    public partial class user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            this.orders = new HashSet<order>();
            img_url = "~/Asset/admin/img/user.jpg";
        }

        public int id { get; set; }
        [DisplayName("User name")]
        public string name { get; set; }
        public string phone { get; set; }
        [DataType(DataType.Password)]
        public string password { get; set; }
        public Nullable<System.DateTime> update_at { get; set; }
        public Nullable<bool> deleted { get; set; }
        public Nullable<int> permission { get; set; }
        public Nullable<System.DateTime> create_at { get; set; }
        public string img_url { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order> orders { get; set; }

        public string Email { get; set; }
        public String LoginErrorMessage { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}