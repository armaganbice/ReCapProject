using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                Color addedColor = context.Colors.SingleOrDefault(p => p.Id == entity.Id);
                if (addedColor == null)
                {
                    context.Colors.Add(entity);
                    context.SaveChanges();
                }
            }
        }

        public void Update(Color entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                Color updatedColor = context.Colors.SingleOrDefault(p => p.Id == entity.Id);
                updatedColor.Name = entity.Name;
                context.SaveChanges();
            }
        }

        public void Delete(Color entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                Color deletedColor = context.Colors.SingleOrDefault(p => p.Id == entity.Id);
                context.Colors.Remove(deletedColor);
                context.SaveChanges();
            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return context.Colors.ToList();
            }
        }

        public Color GetById(int id)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return context.Colors.SingleOrDefault(p => p.Id == id);
            }
        }
    }
}
