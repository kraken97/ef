using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
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
        public int Page1Id { get; set; }
        [ForeignKey("Page1Id")]
        public Page Page1 { get; set; }
        public int Page2Id { get; set; }
        [ForeignKey("Page2Id")]
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
            mb.Entity<Page>().Property(e => e.AddedDate).HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%S')").ValueGeneratedOnAdd();
            mb.Entity<RelatedPage>().HasKey(r => new { r.Page1Id, r.Page2Id });

        }
    }
    class Utils
    {
        public static T ParseJson<T>(string json) where T : class
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
        }
    }


    class ConsoleApplication
    {
        SqliteDbContext context;
        public ConsoleApplication(SqliteDbContext c)
        {
            this.context=c;

        }
        public void ReadCommandAndExecute()
        {
            Command c = ReadUserInput();
            c.connection = this.context;
            c.Execute();
        }
        private string _argsValidation = @"(((?<command>add)\s+(?<model>\w+)\s+(?<json>{.*}))|((?<command>update)\s+(?<model>\w+)\s+(?<id>[0-9]{1,5}){1}\s+(?<json>{.*}))|((?<command>delete)\s+(?<model>\w+)\s+(?<id>[0-9]{1,5}))|((?<command>list)\s+(?<model>\w+)\s*))";
        public Command ReadUserInput()
        {
            System.Console.WriteLine(@"
                (supported model names:
                ________________________
                pages(UrlName,Description,Content),
                navlinks(Title,ParentLinkID,PageId,Position(must be greater than 0)),
                relatedpages(Page1Id,Page2Id)
                __________________ 
                type your command :
                _________________
                add <model> <json> 
                update <model> <id> <json> 
                delete <model> <id> 
                list <model> or all
                __________________");
            string userInput = Console.ReadLine();
            Match m = Regex.Match(userInput, _argsValidation);
            if (m.Success)
            {
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
                        command.Model = m.Groups["model"].Value;
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
                string res = string.Empty;
                ConsoleApplication c = new ConsoleApplication(s);
                while (true)
                {
                    if (string.IsNullOrEmpty(res)&&"no".Equals(res))
                    {
                        System.Console.WriteLine("Good bye");
                        break;
                    }
                    try
                    {

                        c.ReadCommandAndExecute();
                        s.SaveChanges();
                        System.Console.WriteLine("changes is saved");
                    }
                    //dont sure what i should do in this case catch error  and print error msg without programm closing or close programm with stacktrace 
                    catch (System.Exception ex)
                    {
                    System.Console.WriteLine(@"error occurs ");

                        throw ex;
                    }
                    System.Console.WriteLine(@"Do your want countinue ? 
type 'yes' or 'no ' ");
                    res = Console.ReadLine();

                }


            }

        }
    }
}
