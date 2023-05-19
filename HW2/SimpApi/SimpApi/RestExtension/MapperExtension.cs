using AutoMapper;
using SimpApi.Schema;

namespace SimpApi.Service;

public static class MapperExtension
{

	public static void AddMapperExtension(this IServiceCollection services)
	{
		var config = new MapperConfiguration(cfg =>
		{
			cfg.AddProfile(new MapperProfile());
		});
		services.AddSingleton(config.CreateMapper());
	}
}
