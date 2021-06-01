using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace ServiceTemplate.Domain.Interfaces
{
    public interface IUniqueCodeGenerator
    {
        Task<Result<string>> Generate();
    }
}
