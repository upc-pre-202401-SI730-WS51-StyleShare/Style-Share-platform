namespace StyleShare.Platform.API.Rent.Domain.Model.ValueObjects;

public record Date(DateTime rental_date)
{
    public Date() : this(DateTime.Now)
    {
    }
    
    public string RentalDate => rental_date.ToString("yyyy-MM-dd");
    
    public static Date Parse(string dateStr)
    {
        DateTime dateTime;
        if (DateTime.TryParse(dateStr, out dateTime))
        {
            return new Date(dateTime);
        }
        else
        {
            throw new ArgumentException("Invalid date string");
        }
    }
}   