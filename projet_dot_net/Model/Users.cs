//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace projet_dot_net.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            this.Classrooms = new HashSet<Classrooms>();
            this.Establishments = new HashSet<Establishments>();
            this.Evaluations = new HashSet<Evaluations>();
        }
    
        public System.Guid Id { get; set; }
        [Required(ErrorMessage = "the UserName is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "the Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "the Firstname is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "the LastName is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "the Mail is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Mail { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Classrooms> Classrooms { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Establishments> Establishments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Evaluations> Evaluations { get; set; }
    }
}
