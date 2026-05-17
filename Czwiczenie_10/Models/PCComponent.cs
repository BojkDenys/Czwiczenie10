using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Czwiczenie_10.Models;

[Table("PCComponents")]
public class PCComponent
{
    [Key]
    public int PCId { get; set; }
    [Required] 
    public string ComponentCode { get; set; } = string.Empty;
    public int Amount { get; set; }
    [ForeignKey(nameof(PCId))]
    public Pc Pc { get; set; } = null!;
    [ForeignKey(nameof(ComponentCode))]
    public Component Component { get; set; } = null!;

}