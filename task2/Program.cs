using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;



namespace DatabaseApplication
{
    public class Page
    {
        public int PageId { get; set; }
        [Required]
        [MaxLength(500)]
        public string UrlName { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        [Required]

        public string Content { get; set; }
        public DateTime AddedDate { get; set; }
    }
    class NavLink
    {
        public int NavLinkId { get; set; }
        [Required]
        [MaxLength(500)]
        public string Title { get; set; }

        public int ParentLinkID { get; set; }
        [ForeignKey("ParentLinkID")]
        public NavLink ParentLink { get; set; }
        public int PageId { get; set; }
        [ForeignKey("PageId")]
        public Page Page { get; set; }
        public int Position { get; set; }

    }
    class RelatedPage
    {
        public int RelatedPageId { get; set; }
        public int Page1ID { get; set; }
        [ForeignKey("Page1ID")]
        public Page Page1 { get; set; }
        public int Page2ID { get; set; }
        [ForeignKey("Page2ID")]
        public Page Page2 { get; set; }
    }
    class SqliteDbContext : DbContext
    {

        public DbSet<Page> Pages { get; set; }
        public DbSet<NavLink> NavLinks { get; set; }
        public DbSet<RelatedPage> RelatedPages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlite($@"Data Source={Directory.GetCurrentDirectory()}\mydb.db")
                .ConfigureWarnings(warnings => warnings.Throw(CoreEventId.IncludeIgnoredWarning));

        }
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Page>().Property(e => e.AddedDate).HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%S')");

        }
    }
    class Utils
    {
        public static void Print<T>(T t ){
        }
        public static T ParseJson<T>(string json) where T : class
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
        }
    }


    class ConsoleApplication
    {
        SqliteDbContext context;
       public ConsoleApplication(SqliteDbContext c){


        }
        public void ReadCommandAndExecute(){
           Command c= ReadUserInput();
           c.connection=this.context;
           c.Execute();
        }
        private  string _argsValidation = @"(((?<command>add)\s+(?<model>\w+)\s+(?<json>{.*}))|((?<command>update)\s+(?<model>\w+)\s+(?<id>[0-9]{1,5}){1}\s+(?<json>{.*}))|((?<command>delete)\s+(?<model>\w+)\s+(?<id>[0-9]{1,5}))|((?<command>list)\s+(?<model>\w+)\s*))";
        public  Command ReadUserInput()
        {
            System.Console.WriteLine("type your command add <model> {json}");
            string userInput = Console.ReadLine();
            Match m = Regex.Match(userInput, _argsValidation);
            if (m.Success)
            {
                System.Console.WriteLine(m.Value);
                var res = m.Groups["command"];
                Command command;
             

                switch (res.Value.ToLower())
                {
                    case "add":
                        command = new AddCommand();
                        command.Model = m.Groups["model"].Value;
                        command.Json = m.Groups["json"].Value;
                        break;
                    case "update":
                        command = new UpdateCommand();
                        command.Model = m.Groups["model"].Value;
                        command.Json = m.Groups["json"].Value;
                        command.ID = int.Parse(m.Groups["id"].Value);
                        break;
                    case "delete":
                    
                        command = new DeleteCommand();
                        command.Model = m.Groups["model"].Value;
                        command.ID = int.Parse(m.Groups["id"].Value);
                      
                        break;
                    case "list":
                        command = new ListAllCommand();
                        command.Model=m.Groups["model"].Value;
                        break;
                    default:
                        throw new InvalidOperationException("no such command");
                }

                return command;
            }

            throw new InvalidOperationException("user input error");

        }
    }
    public class Program
    {

        public static void Main(string[] args)
        {

            using (SqliteDbContext s = new SqliteDbContext())
            {
                ConsoleApplication c =new ConsoleApplication(s);
                c.ReadCommandAndExecute();

                s.SaveChanges();

            }




            // using (SqliteDbContext c = new SqliteDbContext())
            // {


            //     c.Add(new Page() { UrlName = "123", Content = "<h>jeje</h>" });
            //     c.SaveChanges();
            //     c.Pages.ToList().ForEach(a => System.Console.WriteLine(a));
            // }

        }
    }
}
