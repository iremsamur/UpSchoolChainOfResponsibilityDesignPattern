using System;
using UpSchool_ChainOfResponsibility.DAL;
using UpSchool_ChainOfResponsibility.DAL.Entities;

namespace UpSchool_ChainOfResponsibility.ChainOfResponsibility
{
    public class Treasurer : Employee
    {
        //Treasurer'da bir çalışan olduğundan employee'dan miras alır
        //veznedar 
        public override void ProcessRequest(WithdrawViewModel req)
        {
            if (req.Amount <= 40000)
            {
                //db'ye kaydetme işlemi
                using(var context = new Context())
                {
                    BankProcess bankProcess = new BankProcess();
                    //BankProcess bankProcess = new BankProcess();
                    bankProcess.EmployeeName = "Veznedar - Ayşenur Yıldız";
                    bankProcess.Description = "Müşteriye talep etmiş olduğu tutarın ödemesi gerçekleştirildi.";
                    bankProcess.Amount = req.Amount;
                    bankProcess.CustomerName = req.CustomerName;
                    context.BankProcesses.Add(bankProcess);
                    context.SaveChanges();
                }
                /*
                //parmatre tutarı 40000'den küçükse o kişi tarafından onaylanır.
                Console.WriteLine("{0} tarafından para çekme işlemi onaylandı #{1}",
                    this.GetType().Name, p.Amount);//GetType.Name class'ın ismini belirtir.
                //Yani veznedar tarafından para çekme işlemi onaylandı der
                //içinde bulunduğu class'ın ismini belirtir.
                */
            }
            else if (NextApprover != null)
            {
                //NextApprover Zincirin sonraki elemanını yönlendirecek tarafı temsil eder.
                using (var context = new Context())
                {
                    BankProcess bankProcess = new BankProcess();
                    bankProcess.EmployeeName = "Veznedar - Ayşenur Yıldız";
                    bankProcess.Description = "Müşterinin talep ettiği tutar yetkim dahilinde olmadığı için işlem Şube Müdür Yardımcısına gönderildi.";
                    bankProcess.Amount = req.Amount;
                    bankProcess.CustomerName = req.CustomerName;
                    //Console.WriteLine("{0} TL işlem tutarı {1} max. limitini aştığından işlem yöneticiye gönderildi.", p.Amount, this.GetType().Name);
                    //tutar o değerin 40000'in üzerinde ise yöneticiye gönderir
                    context.BankProcesses.Add(bankProcess);
                    context.SaveChanges();

                    NextApprover.ProcessRequest(req);
                }
                  
            }
        }


    }
}
