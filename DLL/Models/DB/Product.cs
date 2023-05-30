using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models.DB;

[Table("Product")]
public partial class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Required]
    [StringLength(500)]
    public string Descs { get; set; }

    [Required]
    [Range(0, double.MaxValue)]
    public decimal Price { get; set; }

    [Required]
    [StringLength(200)]
    public string ImgUrl { get; set; }

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

    [ForeignKey("ProductId")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
