using UpSchool_ChainOfResponsibility.DAL.Entities;

namespace UpSchool_ChainOfResponsibility.ChainOfResponsibility
{
    public abstract class Employee
    {
        protected Employee NextApprover;
        public void SetNextApprover(Employee supervisor)
        {
            this.NextApprover = supervisor;//NextApprover 
            //sonraki onay veren kişiyi gösteriyor. 
            //önceki adımda onay alamadığında sonraki adıma geçmesini sağlıyor.
            
        }
        public abstract void ProcessRequest(WithdrawViewModel p);
        //para çekecek kişiden request parametresi almış olan para çekme talebi
    }
}
