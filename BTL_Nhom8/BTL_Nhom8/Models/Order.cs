namespace BTL_Nhom8.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            DetailProduct_Order = new HashSet<DetailProduct_Order>();
        }

        [Key]
        public int Order_Id { get; set; }

        public int Account_Id { get; set; }

        public long Total { get; set; }

        public long Sum { get; set; }

        public bool Status { get; set; }

        public virtual Account Account { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetailProduct_Order> DetailProduct_Order { get; set; }
    }
}
