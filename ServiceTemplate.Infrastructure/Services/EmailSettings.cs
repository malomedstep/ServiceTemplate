using System;

namespace ServiceTemplate.Infrastructure.Services
{
    public class EmailSettings
    {
        public string From { get; }
        public string Login { get; }
        public string Password { get; }
        public string Server { get; }
        public int Port { get; }

        public EmailSettings(string @from, string login, string password, string server, int port)
        {
            From = @from ?? throw new ArgumentNullException(nameof(@from));
            Login = login ?? throw new ArgumentNullException(nameof(login));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            Server = server ?? throw new ArgumentNullException(nameof(server));
            Port = port;
        }
    }
}