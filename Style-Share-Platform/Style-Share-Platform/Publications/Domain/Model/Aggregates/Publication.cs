using Comment = Style_Share_Platform.Publications.Domain.Model.Entities.Comment;

namespace Style_Share_Platform.Publications.Domain.Model.Aggregates;

public partial class Publication
{
    public int Id { get; }
    public double Cost { get; private set; }
    public int GarmentId { get; private set; }
    public int LessorId { get; private set; }
    public int Rating { get; private set; }
    public ICollection<Comment> Comments { get; private set; }
    
    public Publication(double cost, int garmentId, int lessorId, int rating)
    {
        Cost = cost;
        GarmentId = garmentId;
        LessorId = lessorId;
        Rating = rating;
        Comments = new List<Comment>();
    }

    public void editPublication(double cost, int garmentId, int lessorId, int rating)
    {
        Cost = cost;
        GarmentId = garmentId;
        LessorId = lessorId;
        Rating = rating;
    }
    
    public Comment addComment(Comment comment)
    {
        Comments.Add(comment);
        return comment;
    }
}