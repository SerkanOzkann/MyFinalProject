using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{

    //DbContext eklee
    public class NortWindContext:DbContext  //Context: Db tabloları ile proje classlarını bağlamak.
    {    
        //Projenin hangi veritabanı ile ilişkilendireceğini belirten method, yerdir.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Northwind;Trusted_Connection=true"); //Db bağlantı Noktası
            //SERVERADI-DATABASEADİ-GİRİŞİZNİ
            // @"\\" ters / olarak algıla. sql serverin nerede oldugunu algıla.


        }

        // Burada hangi class, hangi tabloya karşılık gelir eşleştirilir.
        public DbSet<Product> Products { get; set; } 
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
