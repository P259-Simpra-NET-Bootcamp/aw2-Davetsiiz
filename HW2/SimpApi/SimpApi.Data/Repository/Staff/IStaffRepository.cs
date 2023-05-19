using SimpApi.Data.Domain;
namespace SimpApi.Data.Repository;

public interface IStaffRepository:IGenericRepository<Staff>
{
	ICollection<Staff> FindByFirstName(string name);
	ICollection<Staff> FindByLastName(string name);
	int GetAllCount();
}
