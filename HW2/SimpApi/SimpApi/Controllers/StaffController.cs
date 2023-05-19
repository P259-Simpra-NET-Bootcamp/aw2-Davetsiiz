using AutoMapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SimpApi.Data.Context;
using SimpApi.Data.Domain;
using SimpApi.Data.Repository;
using SimpApi.Data.UOW;
using SimpApi.Operation;
using SimpApi.Schema;

namespace SimpApi.Service.Controllers;

[Route("simpapi/v1/[controller]")]
[ApiController]
public class StaffController : ControllerBase
{
	private IUnitOfWork unitOfWork;
	private IMapper mapper;
	private SimpDbContext context;
	StaffValidator sv = new();
	
	public StaffController(IUnitOfWork unitOfWork, IMapper mapper)
	{
		this.unitOfWork = unitOfWork;
		this.mapper = mapper;
	}

	[HttpGet]
	public List<StaffResponse> GetAll()
	{
		var list = unitOfWork.StaffRepository.GetAll();
		var mapped = mapper.Map<List<StaffResponse>>(list);
		return mapped;
	}

	[HttpPost]
	public void Post([FromBody] Staff request)
	{
		ValidationResult result = sv.Validate(request);


		if (result.IsValid)
		{
			var entity = mapper.Map<Staff>(request);
			unitOfWork.StaffRepository.Insert(entity);
			unitOfWork.CompleteWithTransaction();
		}
		else
		{
			foreach (var item in result.Errors)
			{
				ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
			}
		}
	}
	[HttpPut("{id}")]
	public void Put(int id, [FromBody] Staff request)
	{
		ValidationResult result = sv.Validate(request);


		if (result.IsValid)
		{
			request.Id = id;
			var entity = mapper.Map<Staff>(request);
			unitOfWork.StaffRepository.Update(entity);
			unitOfWork.Complete();
		}
		else
		{
			foreach (var item in result.Errors)
			{
				ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
			}
		}

	}
	[HttpDelete("{id}")]
	public void Delete(int id)
	{
		unitOfWork.StaffRepository.DeleteById(id);
		unitOfWork.Complete();
	}

	[HttpGet("{id}")]
	public StaffResponse GetById(int id)
	{
		var row = unitOfWork.StaffRepository.GetById(id);
		var mapped = mapper.Map<StaffResponse>(row);
		return mapped;
	}

	//[HttpGet("{name}")]
	//public List<StaffResponse> GetByFirstName(string name)
	//{
	//	var list = context.Staff.Where(x => x.FirstName == name);
	//	var mapped = mapper.Map<List<StaffResponse>>(list);
	//	return mapped;
		
	//}
	//[HttpGet("{name}")]
	//public List<StaffResponse> GetByLastName(string name)
	//{
	//	var list = context.Staff.Where(x => x.LastName == name);
	//	var mapped = mapper.Map<List<StaffResponse>>(list);
	//	return mapped;

	//}

}
