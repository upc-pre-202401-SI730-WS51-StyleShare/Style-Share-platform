namespace StyleShare.Platform.API.Publications.Domain.Model.Commands;

public record UpdateGarmentCommand(int garmentId,float size, string description, string material, string brand, int timesRented);