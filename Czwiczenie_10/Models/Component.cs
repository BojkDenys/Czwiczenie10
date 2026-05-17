using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Czwiczenie_10.Models;

[Table("Components")]
public class Component
{
    [Key]
    [MaxLength(10)]
    public string Code { get; set; } = string.Empty;
    [Required]
    [MaxLength(300)]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;
    public int ComponentManufacturersId { get; set; }
    public int ComponentTypesId { get; set; }
    [ForeignKey(nameof(ComponentManufacturersId))]
    public ComponentManufacturer Manufacturer { get; set; } = null!;
    [ForeignKey(nameof(ComponentTypesId))]
    public ComponentType ComponentType { get; set; } = null!;

    public ICollection<PCComponent> PcComponents { get; set; } = new List<PCComponent>();
}