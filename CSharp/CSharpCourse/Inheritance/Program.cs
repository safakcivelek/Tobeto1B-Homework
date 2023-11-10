// Inheritance

Person[] persons = new Person[3]
{
    new Customer{FirstName="Engin"}, 
    new Student{FirstName="Derin"},
    new Person{FirstName="Salih"}
};
foreach (var person in persons)
{
    Console.WriteLine(person.FirstName);
}

Console.ReadLine();
class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
interface IPerson
{

}
class Customer : Person, IPerson
{
    public string City { get; set; }
}
class Student : Person
{
    public string Department { get; set; }
}

// Interface ile Inheritance arasında karar vermek projenin yapısına göre değişebilir.
// Özetle; Eğer interface kullanabiliyorsak ve inheritance'a ihtiyacımız yok ise, zorunlu olduğunu da düşünmüyorsak bu durumda interface kullanılabilir...

// 47.Ders - 2.Gün Ödev Sonu...