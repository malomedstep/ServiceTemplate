using MongoDB.Driver;
using ServiceTemplate.Domain.Common;
using ServiceTemplate.Infrastructure.Repositories;

namespace ServiceTemplate.Infrastructure.Common
{
    public abstract class RepositoryBase<TEntity> where TEntity : EntityBase
    {
        protected readonly RepositorySettings<BookRepository> Settings;
        protected readonly IMongoClient Client;

        protected IMongoCollection<TEntity> Collection => Client
            .GetDatabase(Settings.Database)
            .GetCollection<TEntity>(Settings.Collection);

        protected RepositoryBase(RepositorySettings<BookRepository> settings)
        {
            Settings = settings;
            Client = new MongoClient(settings.ConnectionString);
        }
    }
}