﻿
using Oop2;

// Engin Demiroğ  //gerçek müşteri
IndividualCustomer customer1 = new IndividualCustomer();
customer1.Id = 1;
customer1.CustomerNumber = "12345";
customer1.FirstName = "Engin";
customer1.LastName = "Demiroğ";
customer1.TcNumber = "12345678910";

//Kodlama.io //tüzel müşteri
CorporateCustomer customer2 = new CorporateCustomer();
customer2.Id = 2;
customer2.CustomerNumber = "54321";
customer2.CompanyName = "Kodalama.io";
customer2.TaxNumber = "1234567890";

//Burada Oop2 projesinde verilmek istenen mesaj eğer bir base/temel sınıf var ise işte o base sınıf referans tutucudur.
Customer customer3 = new IndividualCustomer();
Customer customer4 = new CorporateCustomer();

CustomerManager customerManager = new CustomerManager();
customerManager.Add(customer1);
customerManager.Add(customer2);
