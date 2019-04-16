namespace CrossCutting
{
    public interface IDatabaseConfigurationProvider
    {
        string ConnectionString { get; }
    }
}