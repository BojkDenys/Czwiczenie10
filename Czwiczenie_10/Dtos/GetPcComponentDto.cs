namespace Czwiczenie_10.Dtos;

public class GetPcComponentDto
{
    public int Amount { get; set; }
    public GetComponentDto Component { get; set; } = null!;
}