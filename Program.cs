﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace cablemodem_info
{
    public class Program
    {
        //This thing must be a singleton instance if you don't want to leak resources.
        private static readonly HttpClient _httpclient = new HttpClient();

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }
        
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>().ConfigureServices((services) => {
                    services.Add(new ServiceDescriptor(typeof(HttpClient),_httpclient));
                });
    }
}