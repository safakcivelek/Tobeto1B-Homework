
namespace Core.Utilities.Results.Concretes
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        // SuccessDataResult Constructor'ında diyoruzki bana bir tane T data, birtane string message ver.
        // Ama base'ye yani DataResult'a git ve deki bu işlemin sonucu data'dır, işlem sonucu true'dir ve mesajımda message'dir.
        // Yani Manager tarafında işlem yapılırken SuccessDataResult class'ım tetiklenirse buraya gel ve SuccessDataResult class'ımın constructor'ındaki T data, string message değişkenlerimi geri gönder fakat içinde bilgiler ile tabiki. 
        // Peki bu değişkenler yani parametrelerin değerleri nasıl karşılanıcak tabikide  ":base(data,true,message)" ifadesi ile bu   değişkenler base'ye yani DataResult'a gidecek ve orada birtakım işlemlerden geçerek bu parametreler (data,true,message)    içi dolu bir şekilde bu geri dönücek.Daha sonra SuccessDataResult constructor'ından bu parametreler eşlenerek Manager      tarafına istenilen bilgiler ile dönüş yapılacak ve neticesinde bir takım sonuç çıktısı, dönüş değeri elde edicez...
        public SuccessDataResult(T data, string message):base(data,true,message)
        {
           // işlem sonucu default true döner!
        }
        public SuccessDataResult(T data) : base(data, true)
        {

        }
        public SuccessDataResult(string message):base(default,true,message)
        {
           // default: buradaki default parametresi data 'ya karşılık geliyor  <T> buradaki T class'veya interface gibi referans türlü ise default parametresine karşılık null döner.
           // eğer return tipi int ise int'in default'unu geçmesini isteriz. (0)
        }
        public SuccessDataResult():base(default,true)
        {
            
        }
    }
}
