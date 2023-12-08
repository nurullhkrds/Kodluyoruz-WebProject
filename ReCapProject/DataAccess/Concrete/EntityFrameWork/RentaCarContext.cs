using Core.Entities.Concretes;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class RentaCarContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                 .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RenttaCar;Trusted_Connection=true");
        }

        //Aşağıdaki DbSet tanımlaması ise Hangi Entity sınıfımızın db'deki hangi tabloya karşılık geldiğini belirttik.
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }

        public DbSet<Color> Colors { get; set; }
        public DbSet<Users> Users { get; set; }

        public DbSet<Customers> Customers { get; set; }
        public DbSet<Rentals> Rentals { get; set; }

        public DbSet<CarImage> CarImages { get; set; }

        public DbSet<OperationClaim> OperationsClaims { get; set; }

        public DbSet<UserOperationClaim> UserOperationsClaims { get; set; }


    }

}
