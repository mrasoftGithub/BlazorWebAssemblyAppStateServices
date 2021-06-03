using BlazorBlogProject.Client.Inlichtingen;
using BlazorBlogProject.Client.Model;
using BlazorBlogProject.Client.ViewModels;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorBlogProject.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            // Model
            builder.Services.AddScoped<IModel, MemoryModel>();
            // builder.Services.AddScoped<IModel, DbModel>();

            // ViewModel
            builder.Services.AddScoped<IVoegToeViewModel, VoegToeViewModel>();
            builder.Services.AddScoped<ITotaalAantalViewModel, TotaalAantalViewModel>();

            // Inlichtingendienst
            builder.Services.AddScoped<Inlichtingendienst>();

            await builder.Build().RunAsync();
        }
    }
}
