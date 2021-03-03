
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess //Class,interface vb. isim uzaylarını koyarız rahat erişebilmek için.
{   //Generic Repository Tasarım Deseni

    //Generic Constraint=generic kısıt
    //class: referans tip olabilir. T bir referans tip olmalı ve T Entity veya entity implement olan bir şey olabilir.
    // New= new'lenebilir olmalıdır.
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);  //Linq ile gelir.

        T Get(Expression<Func<T, bool>> filter); // T döndüren, filtre yok ise tüm data istenir.

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        
    }
}
