
namespace Oop3
{
    //interface şunu anlatır ve derki; eğer ki birisi bu aşağıdaki interfaceyi kullanır ise kullanılan yapı içerisinde aşağıdaki Calculate() metodu içermek zorunda. eğer birden fazla metot var ise hepsi içermek zorunda.
    //Okunuruluk açısından interfacelerin başına "I" harfi eklenir.
    //Interface arayüz yani şablon anlamına gelir ve bu şablona uyulmasını gerekli kılar.
    interface ICreditManager
    {
        void Calculate();
        void DoSomething();
    }
}
