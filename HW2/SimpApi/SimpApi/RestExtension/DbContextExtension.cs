using Microsoft.EntityFrameworkCore;
using SimpApi.Data.Context;

namespace SimpApi.Service;

public static class DbContextExtension
{

	public static void AddDbContextExtension(this IServiceCollection services, IConfiguration Configuration)
	{
		var dbType = Configuration.GetConnectionString("DbType");
		if (dbType == "SQL")
		{
			var dbConfig = Configuration.GetConnectionString("MsSqlConnection");
			services.AddDbContext<SimpDbContext>(opts =>
			opts.UseSqlServer(dbConfig));
		}
		else if (dbType == "PostgreSql")
		{
			var dbConfig = Configuration.GetConnectionString("PostgreSqlConnection");
			services.AddDbContext<SimpDbContext>(opts =>
			  opts.UseNpgsql(dbConfig));
		}
	}
}
