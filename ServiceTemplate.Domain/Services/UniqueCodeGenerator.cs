using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using ServiceTemplate.Domain.Interfaces;

namespace ServiceTemplate.Domain.Services
{
    public class UniqueCodeGenerator : IUniqueCodeGenerator
    {
        public Task<Result<string>> Generate()
        {
            // TODO: replace with actual implementation
            return Task.FromResult(Result.Success(Guid.NewGuid().ToString()));
        }
    }
}
