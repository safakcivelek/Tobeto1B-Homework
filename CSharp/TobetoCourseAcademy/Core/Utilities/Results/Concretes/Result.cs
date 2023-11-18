using Core.Utilities.Results.Abstracts;

namespace Core.Utilities.Results.Concretes
{

    public class Result : IResult
    {        
        // this kullannımı ile ilgili güzel bir örnek!
        // :this(succes) bunun anlamı Result constructo'ı çalışırken ek olarak tek parametreli olan  yani parametresi succes olan constructor'ıda çalıştır demektir.
        public Result(bool success, string message):this(success)
        {
            Message = message;            
        }
        //Overloading / imzalar farklı
        public Result(bool success)
        {          
            Success = success;         
        }

        public bool Success { get; }

        public string Message { get; }

    }
}
