using System;

public class ProjectDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreationDate { get; set; }
    public decimal? Price { get; set; }
    public decimal SoldSumm { get; set; }
}

public class ItemDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? ManufacturerNumber { get; set; }
    public int? LocationId { get; set; }
    public LocationDto? Location { get; set; }
    public string? Sku { get; set; }
    public double? InPrice { get; set; }
    public DateTime? InDate { get; set; }
    public double? OutPrice { get; set; }
    public DateTime? OutDate { get; set; }
    public ItemStatus? Status { get; set; }
    public string? Description { get; set; }
    public int ProjectId { get; set; }
    public ProjectDto? Project { get; set; }
}

public class LocationDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public enum ItemStatus
{
    Sold = 0,
    Used = 1,
    InStock = 2
}
