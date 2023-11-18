using Core.Utilities.Results.Abstracts;
using System.Text.Json.Serialization;

namespace Core.Utilities.Results.Concretes
{
    //Bir class başka bir class'ın  çözelliklerini tekrar kendi sınıfı içinde yazmadan kullanmak isterse kendine o class'ı miras olarak almalıdır.  (DataResult<T> :Result)
    public class DataResult<T> :Result, IDataResult<T>
    {
        // :base(success, message) ifadesi Result class'ının constructor'unu çağırmak için kullanılır.
        // Yani bu kod derki şu an içinde olduğun class'ın miras aldığı class'ı yani base class'ını (Result) belirle sonrada o base clasının (Result) success,message parametreli constroctur'ını tetikle ve tetikledikten sonra ilgili parametrelerin(succes,message) için dolmuş bir şekilde bilgilerle geri dön. Sonrada gel bu class'ın (DataResult<T>) constructor'ını tetikle. Bize base class'ın (Result) constructor'ından bilgiler gelmişti ":base(success, message)" bu ifade vasıtasıyla o bilgileri DataResult constoructorun içindeki paremtrelere ver.

        // Peki biz neden Result'ın constructor'ını çağırma ihtiyacı duyuyoruz çünkü Result class'ının özelliklerini burada kullanmak istiyoruz. Bunun içinde DataResult<T> class'ına Result sınıfını miras olarak veriyoruz. Result sınıfının constructor'ı olduğu için bizden istediği şeyleri,parametreleri,bilgileri ona gönderiyorz ve karşılığnda bir veri dönmesini sağlıyoruz.

        public DataResult(T data, bool success, string message) : base(success, message)
        {
            Data = data;
        }
        public DataResult(T data, bool success) : base(success)
        {
            Data = data;
        }
        public T Data { get; }

    }
}
