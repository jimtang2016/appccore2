using System;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class MysqlDbContext:DbContext
    {
      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=10.255.19.111;database=mydb;uid=root;pwd=yourpassword;");
        }
      public  DbSet<Users> Users{get;set;} 
      public  DbSet<Orders> Orders{get;set;}
    }
    [Table("Users")]
    public  class  Users{
        public int Id{get;set;}
         public string UserName{get;set;}
         public string Phone{get;set;} 
         public visual List<Orders> Orders{get;set;}
    } 

    [Table("Orders")]
    public class Orders{
         public int Id {get;set;}
          public visual Users User{get;set;}
          
          public int  UserId{get;set;}
    }
}
