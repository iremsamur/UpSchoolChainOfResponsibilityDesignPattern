using Microsoft.EntityFrameworkCore;
using UpSchool_ChainOfResponsibility.DAL.Entities;

namespace UpSchool_ChainOfResponsibility.DAL
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-ISO96UVH\\SQLEXPRESS;Database=UpSchoolChainOfResponsibilityDb;integrated security=True;");//DataSource='de kullanılabilir.


        }
        public DbSet<BankProcess> BankProcesses { get; set; }
    }
}
