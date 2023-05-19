using SimpApi.Data.Context;
using SimpApi.Data.Domain;

namespace SimpApi.Data.Repository;

public class StaffRepository : GenericRepository<Staff>, IStaffRepository
{
	public StaffRepository(SimpDbContext dbContext) : base(dbContext)
	{
	}

	public ICollection<Staff> FindByFirstName(string name)
	{
		var list = dbContext.Set<Staff>().Where(c => c.FirstName.Contains(name)).ToList();
		return list;
	}

	public ICollection<Staff> FindByLastName(string name)
	{
		var list = dbContext.Set<Staff>().Where(c => c.LastName.Contains(name)).ToList();
		return list;
	}

	public int GetAllCount()
	{
		return dbContext.Set<Staff>().Count();
	}
}
