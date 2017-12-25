using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Sino.OnlineMarket.Repositories.ViewModel
{
    public class OnlineMarketContext : DbContext
    {
        public DbSet<Administrators> Administrators { get; set; }
        public DbSet<BuyGoods> BuyGoods { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Goods> Goods { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "C:/Users/83627/Desktop/Sino.OnlineMarket/src/Sino.OnlineMarket.Webhost/bin/Debug/netcoreapp1.0/OnlineMarketDB.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);
            optionsBuilder.UseSqlite(connection);
        }
    }
}
