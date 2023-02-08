using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DependencyInjection
{
     class Program
    {
        static void Main(string[] args)
        {
            var builder = Host.CreateDefaultBuilder(args);

            builder.ConfigureServices(
                services =>
                    services.AddHostedService<Worker>()
                        .AddScoped<IMessageWriter, MessageWriter>());

            var host = builder.Build();

            host.Run();
        }
    }
}
