using Microsoft.EntityFrameworkCore;
using SimpApi.Data.Domain;
using System.Reflection;
using static SimpApi.Data.Domain.Staff;

namespace SimpApi.Data.Context;

public class SimpDbContext:DbContext
{
	public SimpDbContext(DbContextOptions<SimpDbContext> options) : base(options)
    {

	}



	public DbSet<Staff> Staff { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

		base.OnModelCreating(modelBuilder);
	}
}
