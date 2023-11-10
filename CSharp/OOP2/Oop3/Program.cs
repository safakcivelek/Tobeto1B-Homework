
using Oop3;

// Yani interfaceler de o interface'yi implemente eden class'ın referans numarasını tutabilir.

//Buradaki kredileri bir ekrandaki açılır kutudan seçebileceğimiz krediler olarak düşünebiliriz.Ve seçeneklerden birini seçtiğmizi hayal edebiliriz.
ICreditManager consumerLoanManager = new ConsumerLoanManager();
ICreditManager vehicleLoanManager = new VehicleLoanManager();
ICreditManager mortgageLoanManager = new MortgageLoanManager();

ILoggerService databaseLoggerService = new DatabaseLoggerService();
ILoggerService fileLogerService = new FileLoggerService();

ApplicationManager applicationManager = new ApplicationManager();
applicationManager.MakeApplication(mortgageLoanManager,new List<ILoggerService> { new DatabaseLoggerService(),new FileLoggerService()});

List<ICreditManager> credits = new List<ICreditManager>() { consumerLoanManager,vehicleLoanManager};

//applicationManager.KrediOnBilgilendirmesiYap(credits);