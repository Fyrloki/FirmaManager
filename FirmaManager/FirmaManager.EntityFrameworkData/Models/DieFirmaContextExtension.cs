using FimaManager.Common.Configs;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FirmaManager.EntityFrameworkData.Models
{
    public partial class DieFirmaContext
    {
        private string Connectionstring { get; }

        public DieFirmaContext(string connectionstring)
        {
            Connectionstring = connectionstring;
        }

        public void CheckConnection()
        {
            new SqlConnection(Database.GetDbConnection().ConnectionString).Open();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Connectionstring);
            }
        }
    }
}
