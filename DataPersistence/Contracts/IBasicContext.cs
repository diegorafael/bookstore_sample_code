using Microsoft.EntityFrameworkCore;

namespace DataPersistence.Contracts
{
    public interface IBasicContext
    {
        DbContext Context { get; }
    }
}
