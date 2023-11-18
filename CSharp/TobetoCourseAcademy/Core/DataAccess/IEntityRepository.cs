using System.Linq.Expressions;
using Core.Entities;

namespace Core.DataAccess
{
    #region Notlarım:
    //Core katmanı diğer katmanları referans almaz
    //Generic constraint where T: kısıtlamalar aşağıda
    //class: referans tip olmasını zorunlu kılar.
    //IEntity: IEntity veya bunu implement eden bir class.Yani veritabanı tablosu olmasını zorunlu kılar.
    //new(): new'lenebilir olmalı, bu IEntity gibi interfacelerin T yerine gelmesini engeller. Çünkü interfaceler new'lenemez yapıdadır.
    //Bu kısıtlamalar ile <T> tipinin sadece veritabanı nesnelerini karşılayacağını garanti etmiş oluruz. 
    #endregion
    public interface IEntityRepository<T> where T : class, IEntity, new()
	{
        //interface içindeki metodlar default olarak public'dir.
        //"Expression<Func<T,bool>> filter"
        //Yukarıdaki ifade bizim şu şekilde filtreler yazabilmemizi sağlıyor; "(p=>p.Category == 2)" gibi...
        T Get(Expression<Func<T, bool>> filter);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);      
        void Add(T entity);
		void Update(T entity);
		void Delete(T entity);
		
	}
}

