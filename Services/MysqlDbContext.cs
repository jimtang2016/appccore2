using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class MysqlDbContext:DbContext
    {

        public MysqlDbContext(DbContextOptions<MysqlDbContext> options)
            : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=aspnetcore.cf7plm3xqt5k.us-east-2.rds.amazonaws.com; Port=3306; Database=firstdb; Uid=mysql12; Pwd=T1ang1234; SslMode=Preferred;");
        }

        public  DbSet<Users> Users{get;set;} 
      public  DbSet<Orders> Orders{get;set;}
    }

    [Table("Users")]
    public  class  Users{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{get;set;}
         public string UserName{get;set;}
         public string Phone{get;set;} 
         public virtual List<Orders> Orders{get;set;}
    } 

    [Table("Orders")]
    public class Orders{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int Id {get;set;}
          public virtual Users User{get;set;}
          
        [ForeignKey("FK_Orders_Users_UserId")]
          public int  UserId{get;set;}
    }
}
