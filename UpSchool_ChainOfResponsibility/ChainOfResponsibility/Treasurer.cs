using System;
using UpSchool_ChainOfResponsibility.DAL;

namespace UpSchool_ChainOfResponsibility.ChainOfResponsibility
{
    public class Treasurer : Employee
    {
        //Treasurer'da bir çalışan olduğundan employee'dan miras alır
        //veznedar 
        public override void ProcessRequest(WithdrawViewModel p)
        {
            if (p.Amount <= 40000)
            {
                //db'ye kaydetme işlemi
                using(var context = new Context())
                {
                    p.EmployeeName = "Veznedar - Ayşenur Yıldız";
                    p.Description = "Müşteriye talep etmiş olduğu tutarın ödemesi gerçekleştirildi.";
                    //context.BankProcesses.Add(p);
                    //context.SaveChanges();
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
                Console.WriteLine("{0} TL işlem tutarı {1} max. limitini aştığından işlem yöneticiye gönderildi.", p.Amount, this.GetType().Name);
                //tutar o değerin 40000'in üzerinde ise yöneticiye gönderir

                NextApprover.ProcessRequest(p);
            }
        }


    }
}
