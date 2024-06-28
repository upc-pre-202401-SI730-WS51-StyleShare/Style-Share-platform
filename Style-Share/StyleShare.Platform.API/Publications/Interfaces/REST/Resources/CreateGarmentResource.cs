namespace StyleShare.Platform.API.Publications.Interfaces.REST.Resources;

public record CreateGarmentResource(float size, string description, string material, string brand, int timesRented);