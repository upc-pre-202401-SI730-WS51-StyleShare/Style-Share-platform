namespace StyleShare.Platform.API.Publications.Domain.Model.Entities;

public class Garment
{
    public int Id { get; }
    public float Size { get; private set; }
    public string Description { get; private set; }
    public string Material { get; private set; }
    public string Brand { get; private set; }
    public int TimesRented { get; private set; }

    public Garment(float size, string description, string material, string brand, int timesRented)
    {
        Size = size;
        Description = description;
        Material = material;
        Brand = brand;
        TimesRented = timesRented;
    }
}