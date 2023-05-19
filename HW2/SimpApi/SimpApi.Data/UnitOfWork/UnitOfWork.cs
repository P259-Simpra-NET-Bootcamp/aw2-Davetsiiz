using SimpApi.Data.Context;
using SimpApi.Data.Domain;
using SimpApi.Data.Repository;
using SimpApi.Data.UOW;

namespace SimpApi.Data;

public class UnitOfWork:IUnitOfWork
{
	public IGenericRepository<Staff> StaffRepository { get; private set; }

	private readonly SimpDbContext dbContext;
	private bool disposed;

	public UnitOfWork(SimpDbContext dbContext)
	{
		this.dbContext = dbContext;


		StaffRepository = new GenericRepository<Staff>(dbContext);
		
	}
	public void Complete()
	{
		dbContext.SaveChanges();
	}

	public void CompleteWithTransaction()
	{
		using (var dbDcontextTransaction = dbContext.Database.BeginTransaction())
		{
			try
			{
				dbContext.SaveChanges();
				dbDcontextTransaction.Commit();
			}
			catch (Exception ex)
			{
				dbDcontextTransaction.Rollback();
			}
		}
	}


	private void Clean(bool disposing)
	{
		if (!disposed)
		{
			if (disposing)
			{
				dbContext.Dispose();
			}
		}

		disposed = true;
		GC.SuppressFinalize(this);
	}
	public void Dispose()
	{
		Clean(true);
	}
}
