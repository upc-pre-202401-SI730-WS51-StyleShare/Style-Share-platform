﻿namespace Style_Share_Platform.Publications.Domain.Model.Entities;

public partial class Garment
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
    
    public void editGarment(float size, string description, string material, string brand, int timesRented)
    {
        Size = size;
        Description = description;
        Material = material;
        Brand = brand;
        TimesRented = timesRented;
    }
}