using Danske.HW.API.Mappings;
using Danske.HW.BusinessLogic;
using Danske.HW.Persistence;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }


    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddTransient<INumberService, NumberService>();

        var filePath = Configuration.GetValue<string>("RepositoryFilePath");
        services.AddTransient<INumberRepository>(provider => new NumberRepository(filePath));


        services.AddAutoMapper(typeof(MappingProfile));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {

        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseRouting();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.UseHttpsRedirection();
    }
}
