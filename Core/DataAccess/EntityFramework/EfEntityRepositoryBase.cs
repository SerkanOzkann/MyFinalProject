using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{//core katmanına yazılan kod bir kere yazmak yeterlidir.her yerde kullanılabilir.

    public class EfEntityRepositoryBase<TEntity,TContext>: IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext()) // Using bitince belleği boşaltır.boşa yer tutmaz.
            {
                var addedEntity = context.Entry(entity); //db git ekleme yap. referans yakalama
                addedEntity.State = EntityState.Added; // eklenecek nesne
                context.SaveChanges();  //Ekle
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext()) // Using bitince belleği boşaltır.boşa yer tutmaz.
            {
                var deletedEntity = context.Entry(entity); //db git silme yap. referans yakalama
                deletedEntity.State = EntityState.Deleted; // silinecek nesne
                context.SaveChanges();  //Sil
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
            {                         //select *from table yap list ekle.
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();  // null ise ilk kısım değilse diğer kısım çalışır.
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext()) // Using bitince belleği boşaltır.boşa yer tutmaz.
            {
                var updatedEntity = context.Entry(entity); //db git update yap. referans yakalama
                updatedEntity.State = EntityState.Modified; // güncellenecek nesne
                context.SaveChanges();  //güncellenecek
            }

        }
    }


}

