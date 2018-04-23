namespace CustomSeriesPointDrawingSample.Model {
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Employee
    {
        [Key]
        [Required]
        [Column("EmployeeID")]
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required]
        [StringLength(10)]
        public string FirstName { get; set; }

        [Column(TypeName = "image")]
        public byte[] Photo { get; set; }

        public string FullName {
            get { return FirstName + " " + LastName; }
        }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
