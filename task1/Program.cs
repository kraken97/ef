using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;


namespace DatabaseApplication
{


    public class Blog
    {
        public int BlogId { get; set; }
         [MaxLength(500)]
        public string Url { get; set; }

        public List<Post> Posts { get; set; }
        
    }

    public class Post
    {
      

        public int PostId { get; set; }
         [MaxLength(200)]
        public string Title { get; set; }
         [MaxLength(2500)]
        public string Content { get; set; }

        //fk for blog 
        public Blog Blog { get; set; }

        public  override string ToString(){
                return $"postid {PostId}  Title {Title}";
        }
    }


    class SqliteDbContext : DbContext
    {
        
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlite($@"Data Source={Directory.GetCurrentDirectory()}\mydb.db")
                .ConfigureWarnings(warnings => warnings.Throw(CoreEventId.IncludeIgnoredWarning));
        }
        protected override void OnModelCreating(ModelBuilder mb)
        {
            
        }
    }


    public class Program
    {
        public static List<Post> GenPosts(Blog b)
        {
            return new List<Post>() {
                new Post() { Title = "Post Title", Content = "<h1>Hello world</h1>" ,Blog=b },
                new Post() { Title = "Post Title", Content = "<h1>Hello world</h1>",Blog=b } };
        }
        public static void Main(string[] args)
        {
          
            using (SqliteDbContext s = new SqliteDbContext())
            {
                for (int i = 0; i < 10; i++)
                {
                    var blog = new Blog() { Url = "blog "+i};
                    blog.Posts = GenPosts(blog);
                    s.Add(blog);
                }
                 
                s.SaveChanges();
                var res = s.Blogs.Include(blog=>blog.Posts).ToList();    

                foreach (var item in res)
                {      
                    System.Console.WriteLine($@"blog url :{item.Url}  blogid:{item.BlogId}  ");
                    System.Console.WriteLine("posts ");
                    item.Posts.ForEach(post=> System.Console.WriteLine(post));
            
                }
         
            }

        }
    }
}
