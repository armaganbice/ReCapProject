using Core.Entities;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
         where TEntity : class, IEntity, new()
         where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntry=context.Entry(entity);
                addedEntry.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity  = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }


        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity GetById(int id)
        {
            using (TContext context = new TContext())
            {
                //                return context.Find(p => p.Id == id);
                // return context.Set<TEntity>().SingleOrDefault(p=>p.Id == id);
                return null;
            }
        }

      

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                //Car updatedCar = context.Cars.SingleOrDefault(p => p.Id == entity.Id);
                //updatedCar.Description = entity.Description;
                //updatedCar.ModelYear = entity.ModelYear;
                //updatedCar.BrandId = entity.BrandId;
                //updatedCar.ColorId = entity.ColorId;
                //updatedCar.DailyPrice = entity.DailyPrice;
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
