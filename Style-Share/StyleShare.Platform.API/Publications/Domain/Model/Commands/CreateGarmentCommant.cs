namespace StyleShare.Platform.API.Publications.Domain.Model.Commands;

public record CreateGarmentCommant(float size, string description, string material, string brand, int timesRented);