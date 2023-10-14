using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ApiCSharp.DB;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using ApiCSharp;

namespace ApiCSharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                        .ConfigureWebHostDefaults(webBuilders =>
                        {
                            webBuilders.UseStartup<Startup>();
                        });

    }
}





