using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Enviro365Assessment_Grad_DOTNET_version.Model;

[Table("Waste")]
public class Waste
{
    [Key]
    [Required]
    [Column(name: "waste_id")]
    public Guid Id { get; set; }

    [Required]
    [Column(name: "waste_category", TypeName = "varchar(10)")]
    public required string Category { get; set; }

    [Required]
    [Column(name: "disposal_guideline", TypeName = "varchar(50)")]
    public required string Disposalguideline { get; set; }

    [Required]
    [Column(name: "recycling_tips", TypeName = "varchar(100)")]
    public required string Recyclingtips { get; set; }
}