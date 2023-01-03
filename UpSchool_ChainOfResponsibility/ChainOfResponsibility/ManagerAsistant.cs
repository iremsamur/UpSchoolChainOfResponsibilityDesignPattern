using UpSchool_ChainOfResponsibility.DAL;
using UpSchool_ChainOfResponsibility.DAL.Entities;

namespace UpSchool_ChainOfResponsibility.ChainOfResponsibility
{
    public class ManagerAsistant : Employee
    {
        public override void ProcessRequest(WithdrawViewModel req)
        {
            if (req.Amount <= 70000)
            {
                //tutar değişiyor sadece. Çünkü tutar 70.000'den küçükse başkasına işlem devredilecek
                //db'ye kaydetme işlemi
                using (var context = new Context())
                {
                    BankProcess bankProcess = new BankProcess();
                    //BankProcess bankProcess = new BankProcess();
                    bankProcess.EmployeeName = "Şube Müdürü-Hilal Sarı";
                    bankProcess.Description = "Müşteriye talep etmiş olduğu tutarın ödemesi şube müdür yardımcısı tarafından gerçekleştirildi.";
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
                    bankProcess.EmployeeName = "Şube Müdür Yardımcısı - Hilal Sarı";
                    bankProcess.Description = "Müşterinin talep ettiği tutar yetkim dahilinde olmadığı için işlem Şube Müdürüne gönderildi.";
                    bankProcess.Amount = req.Amount;
                    bankProcess.CustomerName = req.CustomerName;
                    context.BankProcesses.Add(bankProcess);
                    context.SaveChanges();

                    NextApprover.ProcessRequest(req);
                }

            }
        }
    }
}
