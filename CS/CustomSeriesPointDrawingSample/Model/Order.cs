namespace CustomSeriesPointDrawingSample.Model {
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Order
    {
        [Key]
        [Required]
        [Column("OrderID")]
        public int OrderId { get; set; }


        [ForeignKey("Employee")]
        [Column("EmployeeID")]
        public int? EmployeeId { get; set; }

        public DateTime OrderDate { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal? Freight { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
