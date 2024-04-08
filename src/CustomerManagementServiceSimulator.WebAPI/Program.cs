
using CustomerManagementServiceSimulator.WebAPI.Clients;
using CustomerManagementServiceSimulator.WebAPI.Configuration;
using CustomerManagementServiceSimulator.WebAPI.Services;
using Microsoft.Extensions.Options;

namespace CustomerManagementServiceSimulator.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add application services.
            builder.Services.AddOptions();
            builder.Services.Configure<ServiceUrlsOptions>(builder.Configuration.GetSection("ServiceUrls"));
            builder.Services.Configure<SimulatorSettingsOptions>(builder.Configuration.GetSection("SimulatorSettings"));
            builder.Services.Configure<CustomerCreationSettingsOptions>(builder.Configuration.GetSection("CustomerCreationSettings"));
            builder.Services.AddScoped<ICustomersClient, CustomersClient>();
            builder.Services.AddHttpClient<ICustomersClient, CustomersClient>((services, client) =>
            {
                var serviceUrlsOptions = builder.Services.BuildServiceProvider().GetService<IOptions<ServiceUrlsOptions>>().Value;
                client.BaseAddress = new Uri(serviceUrlsOptions.CustomerManagementService);
            });
            builder.Services.AddScoped<ICustomersService, CustomersService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
