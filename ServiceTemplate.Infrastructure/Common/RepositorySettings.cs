using System;

namespace ServiceTemplate.Infrastructure.Common
{
    public class RepositorySettings<TRepository>
    {
        public RepositorySettings(string connectionString, string database, string collection)
        {
            ConnectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
            Database = database ?? throw new ArgumentNullException(nameof(database));
            Collection = collection ?? throw new ArgumentNullException(nameof(collection));
        }

        public string ConnectionString { get;  }
        public string Database { get; }
        public string Collection { get; }
    }
}
