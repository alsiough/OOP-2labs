namespace Domain
{
    public interface IEntity
    {
        string FirstName { get; }
        string LastName { get; }
        string TypeName { get; } //  "Student", "Teacher"
        string UniqueId { get; } //  StudentId or generated id or empty
    }
}
