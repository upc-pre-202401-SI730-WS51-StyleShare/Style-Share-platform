namespace StyleShare.Platform.API.Rent.Domain.Model.ValueObjects;

public record ProductId(int idProduct)
{
    public ProductId() : this(0)
    {
    }

    public static ProductId Parse(string idStr)
    {
        int idProduct;
        if (int.TryParse(idStr, out idProduct))
        {
            return new ProductId(idProduct);
        }
        else
        {
            throw new ArgumentException("Invalid id string");
        }
    }
}