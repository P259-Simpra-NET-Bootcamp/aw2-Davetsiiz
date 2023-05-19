using SimpApi.Data.Domain;
using SimpApi.Data.Repository;

namespace SimpApi.Data.UOW;

public interface IUnitOfWork:IDisposable
{
	IGenericRepository<Staff> StaffRepository { get; }

	void Complete();
	void CompleteWithTransaction();
}
