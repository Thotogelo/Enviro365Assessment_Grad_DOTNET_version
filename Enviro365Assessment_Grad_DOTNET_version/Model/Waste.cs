using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Enviro365Assessment_Grad_DOTNET_version.Model;

[Table("Waste")]
public class Waste
{
    [Key]
    [Required]
    [Column(name: "waste_id")]
    public long Id { get; set; }

    [Required]
    [Column(name: "waste_category", TypeName = "varchar(10)")]
    public string Category { get; set; }

    [Required]
    [Column(name: "disposal_guideline", TypeName = "varchar(50)")]
    public string Disposalguideline { get; set; }

    [Required]
    [Column(name: "recycling_tips", TypeName = "varchar(100)")]
    public string Recyclingtips { get; set; }
}