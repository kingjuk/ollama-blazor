using Data;
using Markdig;
using Markdown.ColorCode;
using Microsoft.Extensions.Options;
using Ollama_Blazor.Components;
using OllamaSharp;

namespace Ollama_Blazor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            var pipeline = new MarkdownPipelineBuilder()
                    .UseAdvancedExtensions()
                    .UseColorCode()
                    .UseBootstrap()
                    .Build();

            builder.Services.AddSingleton(pipeline);


            builder.Services.Configure<OllamaApiSettings>(builder.Configuration.GetSection("OllamaApi"));
            builder.Services.AddScoped<IOllamaApiClient>(sp =>
            {
                var config = sp.GetRequiredService<IOptions<OllamaApiSettings>>().Value;

                return new OllamaApiClient(new Uri(config.BaseUrl));
            });



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
