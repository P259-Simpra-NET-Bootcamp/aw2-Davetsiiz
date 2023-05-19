using SimpApi.Data.Repository;

namespace SimpApi.Service;

public static class RepositoryExtension
{
	public static void AddRepositoryExtension(this IServiceCollection services)
	{
		services.AddScoped<IStaffRepository, StaffRepository>();
	}
}
