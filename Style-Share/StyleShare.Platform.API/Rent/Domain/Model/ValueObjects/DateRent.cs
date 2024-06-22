namespace StyleShare.Platform.API.Rent.Domain.Model.ValueObjects;

public record DateRent(DateTime rental_date)
{
    public DateRent() : this(DateTime.Now)
    {
    }
    
    public string RentalDate => rental_date.ToString("yyyy-MM-dd");
    
    public static DateRent Parse(string dateStr)
    {
        DateTime dateTime;
        if (DateTime.TryParse(dateStr, out dateTime))
        {
            return new DateRent(dateTime);
        }
        else
        {
            throw new ArgumentException("Invalid date string");
        }
    }
}   