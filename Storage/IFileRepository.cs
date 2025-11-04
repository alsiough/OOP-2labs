using Domain;
namespace Storage
{
    public interface IFileRepository
    {
        void SaveEntities(string path, IEntity[] entities);
        IEntity[] LoadEntities(string path);
    }
}
