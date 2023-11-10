
namespace Classes
{ 
    // Classlar bir referans türdür.
    // Nesneler class'lardan türer.

    // Field => class'dan üretilen nesneler üzerinde değerler tutmamızı sağlayan alanlardır.
    // Field => field'lar türüne özgü default değer alırlar.(int türündeki field'ların varsayılan değeri 0'dır.)

    // Property => property yapıları özünde nesne içerisindeki bir field'ın dışarıya kontrollü bir şekilde açılmasını ve kontrollü bir şekilde dışarıdan değer almasını sağlayan yapıdır.

    // Encapsulation => Class'lardan türetilmiş nesneler içerisindeki data'ların (field'lardaki verilerin) dışarıya kontrollü bir şekilde açılması ve kontrollü bir şekilde veri almasıdır.

    // get; set; blokları => bu blokları property yapılarında kullanabiliriz ve property yapıları içerisinde get ve set bloklarını uygularken aynı zamanda Encapsulation işelmini'de gerçekleştirmiş oluruz.

    internal class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
    }
}