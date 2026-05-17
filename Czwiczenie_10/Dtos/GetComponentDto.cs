namespace Czwiczenie_10.Dtos;

public class GetComponentDto
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public GetManufacturerDto Manufacturer { get; set; } = null!;
    public GetComponentTypeDto ComponentType { get; set; } = null!;
}