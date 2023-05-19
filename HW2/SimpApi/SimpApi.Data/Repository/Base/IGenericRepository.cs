﻿using System.Linq.Expressions;

namespace SimpApi.Data.Repository;

public interface IGenericRepository<Entity> where Entity : class
{
	Entity GetById(int id);
	void Insert(Entity entity);
	void Update(Entity entity);
	void DeleteById(int id);
	void Delete(Entity entity);
	List<Entity> GetAll();
	IQueryable<Entity> Where(Expression<Func<Entity, bool>> expression);

	void Complete();
	void CompleteWithTransaction();
}
