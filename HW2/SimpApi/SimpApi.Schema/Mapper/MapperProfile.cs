using AutoMapper;
using SimpApi.Data.Domain;

namespace SimpApi.Schema;

public class MapperProfile:Profile
{
	public MapperProfile()
	{
	
		CreateMap<Staff, StaffResponse>();
		CreateMap<StaffRequest, Staff>();
	}
}
