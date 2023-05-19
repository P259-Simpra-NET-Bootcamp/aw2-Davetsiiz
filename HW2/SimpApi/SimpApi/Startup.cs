using SimpApi.Data.UOW;
using SimpApi.Data;
using SimpApi.Service.RestExtension;
using FluentValidation.AspNetCore;
using SimpApi.Operation;

namespace SimpApi.Service;

public class Startup
{
	public Startup(IConfiguration configuration)
	{
		Configuration = configuration;
	}
	public IConfiguration Configuration { get; }

	public void ConfigureServices(IServiceCollection services)
	{
		services.AddControllers().AddFluentValidation(fv =>
		{
			fv.RegisterValidatorsFromAssemblyContaining<StaffValidator>();
		}); ;
		services.AddSwaggerExtension();
		services.AddDbContextExtension(Configuration);
		services.AddScoped<IUnitOfWork, UnitOfWork>();
		services.AddMapperExtension();
		services.AddRepositoryExtension();
		

	}






	public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
	{
		if (env.IsDevelopment())
		{
			app.UseDeveloperExceptionPage();

		}

		app.UseSwagger();
		app.UseSwaggerUI(c =>
		{
			c.DefaultModelsExpandDepth(-1);
			c.SwaggerEndpoint("/swagger/v1/swagger.json", "Simp Company");
			c.DocumentTitle = "SimpApi  Company";
		});
		app.UseHttpsRedirection();
		// add auth 
		app.UseAuthentication();
		app.UseRouting();
		app.UseAuthorization();
		app.UseDeveloperExceptionPage();

		app.UseEndpoints(endpoints =>
		{
			endpoints.MapControllers();
		});
	}
}