
namespace Oop3
{
    class ApplicationManager
    {
        // Buraya hangi kredinin parametresi gönderilirse o kredinin işlemleri çalışır
        public void MakeApplication(ICreditManager creditManager,List<ILoggerService> loggerServices)
        {
            //Başvuran bilgileri değerlendirme
            //
            creditManager.Calculate();
            foreach (var loggerService in loggerServices)
            {
                loggerService.Log();
            }
        }

        //Birden çok kredinin hesaplaması yapılır.
        public void KrediOnBilgilendirmesiYap(List<ICreditManager> credits)
        {
            foreach (var credit in credits)
            {
                credit.Calculate();
            }
        }
    }
}
