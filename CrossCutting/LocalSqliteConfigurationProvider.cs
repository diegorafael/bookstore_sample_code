namespace CrossCutting
{
    public class LocalSqliteConfigurationProvider : IDatabaseConfigurationProvider
    {
        public string ConnectionString { get => "FileName=BookstoreDBfile.db"; }
    }
}
