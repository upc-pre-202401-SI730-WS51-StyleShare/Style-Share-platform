namespace StyleShare.Platform.API.Publications.Interfaces.REST.Resources;

public record UpdateGarmentResource(float size, string description, string material, string brand, int timesRented);