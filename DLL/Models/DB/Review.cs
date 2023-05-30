using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models.DB;

[Table("Review")]
public partial class Review
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Required]
    public long ProductId { get; set; }

    [Required]
    public long CustomerId { get; set; }

    [Required]
    public int Rating { get; set; }

    [StringLength(500)]
    public string? Comment { get; set; }

    [Required]
    public DateTime CreatedDate { get; set; }

    [StringLength(50)]
    public string CreatedBy { get; set; }

    [Required]
    public DateTime UpdatedDate { get; set; }

    [StringLength(50)]
    public string UpdatedBy { get; set; } 

    public virtual Customer Customer { get; set; }

    public virtual Product Product { get; set; } 
}
