using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models.DB;

[Table("Customer")]
public partial class Customer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Required]
    [StringLength(50)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(50)]
    public string LastName { get; set; }

    [Required]
    [StringLength(190)]
    public string Email { get; set; } 

    [StringLength(50)]
    public string? Phone { get; set; }

    [Required]
    public DateTime CreatedDate { get; set; }

    [Required]
    [StringLength(50)]
    public string CreatedBy { get; set; }

    [Required]
    public DateTime UpdatedDate { get; set; }

    [Required]
    [StringLength(50)]
    public string UpdatedBy { get; set; } 

    [ForeignKey("CustomerId")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
