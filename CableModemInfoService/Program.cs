using System.Net.Http;
using CableModemInfoService.lib.Processors;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace CableModemInfoService
{
    public class Program
    {
        //This thing must be a singleton instance if you don't want to leak resources.
        //You'd attach whatever handlers you'd want on the client here. For testing you could write a handler that would  
        //prevent the request from going out the the requested URI.
        private static readonly HttpClient Httpclient = new HttpClient();

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }
        
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>().ConfigureServices((services) => {
                    services.Add(new ServiceDescriptor(typeof(HttpClient),Httpclient));
                    services.Add(new ServiceDescriptor(typeof(StatusPageProcessorFactory),typeof(StatusPageProcessorFactory),ServiceLifetime.Scoped));
                });
    }
}
