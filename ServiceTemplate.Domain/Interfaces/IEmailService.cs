using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace ServiceTemplate.Domain.Interfaces
{
    public interface IEmailService
    {
        Task<Result> SendEmail(string to, string text, string subject);
    }
}
