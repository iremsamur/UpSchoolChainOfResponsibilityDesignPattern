using UpSchool_ChainOfResponsibility.DAL;
using UpSchool_ChainOfResponsibility.DAL.Entities;

namespace UpSchool_ChainOfResponsibility.ChainOfResponsibility
{
    public class RegionManager : Employee
    {
        public override void ProcessRequest(WithdrawViewModel req)
        {
            if (req.Amount <= 1500000)
            {
                //tutar değişiyor sadece. Çünkü tutar 70.000'den küçükse başkasına işlem devredilecek
                //db'ye kaydetme işlemi
                using (var context = new Context())
                {
                    BankProcess bankProcess = new BankProcess();
                    //BankProcess bankProcess = new BankProcess();
                    bankProcess.EmployeeName = "Bölge Müdürü - Zeynep Dere";
                    bankProcess.Description = "Müşteriye talep etmiş olduğu tutarın ödemesi bölge müdürü tarafından gerçekleştirildi.";
                    bankProcess.Amount = req.Amount;
                    bankProcess.CustomerName = req.CustomerName;
                    context.BankProcesses.Add(bankProcess);
                    context.SaveChanges();
                }

            }
            else if (NextApprover != null)
            {

                using (var context = new Context())
                {
                    BankProcess bankProcess = new BankProcess();
                    bankProcess.EmployeeName = "Bölge Müdürü - Zeynep Dere";
                    bankProcess.Description = "Müşterinin talep ettiği tutar banka limitlerinin günlük çekim tutarı üzerinde olduğu için müşteriye ödeme yapılamadı.";
                    bankProcess.Amount = req.Amount;
                    bankProcess.CustomerName = req.CustomerName;
                    context.BankProcesses.Add(bankProcess);
                    context.SaveChanges();

                }

                    
            }
        }
    }
}
