console.log("Merhaba!")
let sayi = 10;
sayi = "Şafak Civelek";

let student = {id:1,name:"Şafak"};
// console.log(student);

function save(puan=10,ogrenci)
{
    console.log(ogrenci.name+":"+puan);
}
save(undefined,student);

let students = ["Şafak Civelek","Kadir Avşar","Kadir Özdemir","Fatih Sevencan","Barış Yıldırım","Mehmet Ali"]

//console.log(students);


console.log("-------------------------");

let students2 = [students,{id:1,name:"Safak"},"Ankara",{city :"İstanbul"}]
console.log(students2);



console.log("-------------------------");

//
let showProducts = function (id,...products) {
    console.log(id);
    console.log(products[0]);

}
//
console.log(typeof showProducts);
showProducts(10,"Kadir","Avşar")
showProducts(10,["Kadir","Avşar"])
console.log("-------------------------");


// spread => ayrıştırmak- bir arrayi ayırmaya yarar
let points = [1,2,3,50,60,4,14]
console.log(...points);
console.log(Math.max(...points));

console.log(..."ABC","D",..."EFG","H");

console.log("-------------------------");


//Destructuring => array'ın değerlerini değişkenlere atar.

let populations = [15000,20000,30000, [40000,100000]]
let [small, medium, high, [veryHigh, maximum]] = populations
console.log(small);
console.log(medium);
console.log(high);
console.log(veryHigh);
console.log(maximum);

function someFunction([small1]) {
    console.log(small1);
}
someFunction(populations)

console.log("-------------------------");

let category = {id:1, name: "İçecek"}
console.log(category.id);
console.log(category["name"]);

console.log("-------------------------");

let {id, name} = category
console.log(id);
console.log(name);

console.log("-------------------------");
//

class Customer {
    constructor(id, customerNumber){ // ctor pattern
        this.id = id;
        this.customerNumber = customerNumber;
    }
}

let customer = new Customer(1,"616161343434")

// Prototyping => şuan Customer classı içerisinde "name" adında bir yer yok. Dışarıdan aşağıdaki gibi değer atamaya Prototyping denir. 

customer.name ="Kadir Avşar"
// console.log(customer.id);
//
console.log(customer.name);

Customer.birsey = "Bir sey"
console.log(Customer.birsey);


console.log(customer.customerNumber);
//

class IndividualCustomer extends Customer { //  
    constructor(firstName, id, customerNumber){
        super(id, customerNumber) // Super demek => Customer
        this.firstName = firstName
    }
}

class CorporateCustomer extends Customer {
    constructor(companyName, id, customerNumber){
        super(id, customerNumber)
        this.companyName = companyName
    }
}

let products = [
    {id:1, name: "Acer Laptop", unitPrice:15000},
    {id:2, name: "HP Laptop", unitPrice:16000},
    {id:3, name: "Asus Laptop", unitPrice:17000},
    {id:4, name: "Dell Laptop", unitPrice:18000},
    {id:5, name: "Casper Laptop", unitPrice:19000}
]

// Map => dizi içerisindeki elemanları döner => foreach 
console.log("<ul>");
products.map(product=>console.log(`<li>${product.name}</li>`))
console.log("</ul>");

// Filter => 
// Yeni bir sorgu ile  diziyi filtreler ve bize yeni bir dizi  verir.
let filterProducts = products.filter(product => product.unitPrice > 12000)
console.log(filterProducts);
//
let cartTotal = products.reduce((acc,product) => acc + product.unitPrice,0)
console.log(cartTotal); 

let cartTotal2 = products
                .filter(p => p.unitPrice>13000)
                .map(p=>{
                    p.unitPrice = p.unitPrice*1.18
                    return p
                })
                .reduce((acc,p)=>acc + p.unitPrice , 0)

console.log(cartTotal2);
//