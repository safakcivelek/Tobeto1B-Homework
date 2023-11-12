using Entities.Abstract;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    //Generic constraint
    //class: referans tip.
    //IEntity: IEntity veya bunu implement eden bir class.
    //new(): new'lenebilir olmalı. Bu da bize IEntity gibi interfaceler'in T yerine gelemeyeceğini garantiledi.
    //Bu kısıtlamalar ile (<T>) artık sadece veritabanı nesneleri ile çalışabileceğimizi garanti etmiş olduk.

    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        // interface metodları default olarak public'dir.

        // "Expression<Func<T,bool>> filter"
        // Yukarıdaki ifade bizim şu şekilde filtreler yazabilmemizi sağlıyor; "(p=>p.Category == 2)" gibi...
        List<T> GetAll(Expression<Func<T,bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
