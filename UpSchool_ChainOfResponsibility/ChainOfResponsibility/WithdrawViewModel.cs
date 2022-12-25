namespace UpSchool_ChainOfResponsibility.ChainOfResponsibility
{
    public class WithdrawViewModel
    {
        //para çekme işlemini gösteren view model sınıfı
        public int BankProcessID { get; set; }
        public int Amount { get; set; }

        public string CustomerName { get; set; }
        public string EmployeeName { get; set; }
        public string Description { get; set; }
    }
}
