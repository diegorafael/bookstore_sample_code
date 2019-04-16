
namespace DataPersistence.Contracts
{
    public interface IBookstoreContext : IBasicContext
    {
        string ConnectionString { get; }
    }
}
