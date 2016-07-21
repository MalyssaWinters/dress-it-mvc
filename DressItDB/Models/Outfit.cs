//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DressItDB.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Outfit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Outfit()
        {
            this.WardrobeItems = new HashSet<WardrobeItem>();
        }
    
        public int OutfitID { get; set; }
        public int TopID { get; set; }
        public int BottomID { get; set; }
        public int ShoeID { get; set; }
    
        public virtual WardrobeItem WardrobeItem { get; set; }
        public virtual WardrobeItem WardrobeItem1 { get; set; }
        public virtual WardrobeItem WardrobeItem2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WardrobeItem> WardrobeItems { get; set; }
    }
}