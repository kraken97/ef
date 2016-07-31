using System;
using System.Linq;
namespace DatabaseApplication
{



    abstract class Command
    {
        public SqliteDbContext connection;
        public int? ID { get; set; }
        public string Model { get; set; }
        public string Json { get; set; }

        public abstract void Execute();
        public const string pages = "pages";
        public const string navlinks = "navlinks";
        public const string relatedpages = "relatedpages";
    }
    class AddCommand : Command
    {
        public override void Execute()
        {
            switch (this.Model.ToLower())
            {
                case pages:
                    var page = Utils.ParseJson<Page>(this.Json);
                    this.connection.Pages.Add(page);
                    System.Console.WriteLine("Page ID:"+this.connection.Pages.Last().PageId);

                    break;
                case navlinks:
                    var nav = Utils.ParseJson<NavLink>(this.Json);
                    this.connection.NavLinks.Add(nav);
                    System.Console.WriteLine(" NavLink:"+this.connection.NavLinks.Last().NavLinkId);
                    
                    break;
                case relatedpages:
                    var relpages = Utils.ParseJson<RelatedPage>(this.Json);
                    this.connection.RelatedPages.Add(relpages);
                    System.Console.WriteLine("relatedpages :"+this.connection.RelatedPages.Last());
                    break;
                default:
                    throw new InvalidOperationException("no such database  in list [page,navlink,relatedpages]");
            }


        }
    }
    class UpdateCommand : Command
    {
        public override void Execute()
        {
            switch (this.Model.ToLower())
            {
                case pages:
                    Page res = Utils.ParseJson<Page>(this.Json);
                    var dbPage = this.connection.Pages.Single(p => p.PageId == this.ID);


                    if (res.Content != null)
                    {
                        dbPage.Content = res.Content;
                    }
                    if (res.Description != null)
                    {
                        dbPage.Description = res.Description;
                    }
                    if (res.UrlName != null)
                    {
                        dbPage.UrlName = res.UrlName;
                    }
                    break;
                case navlinks:
                    NavLink nav = Utils.ParseJson<NavLink>(this.Json);
                    var navLinkDb = this.connection.NavLinks.Single(p => p.NavLinkId == this.ID);
                    if (nav.PageId != 0)
                    {
                        navLinkDb.PageId = nav.PageId;
                    }
                    if (nav.ParentLinkID != 0)
                    {
                        navLinkDb.ParentLinkID = nav.ParentLinkID;
                    }
                    if (nav.Position != 0)
                    {
                        navLinkDb.Position = nav.Position;
                    }
                    if (string.IsNullOrEmpty(nav.Title))
                    {
                        navLinkDb.Title = nav.Title;
                    }
                    break;
                case relatedpages:
                    // var relpages=Utils.ParseJson<RelatedPage>()
                    break;
                default:
                    throw new InvalidOperationException("no such database  in list [page,navlink,relatedpages]");
            }


        }
    }

    class DeleteCommand : Command
    {
        public override void Execute()
        {
            switch (this.Model.ToLower())
            {
                case pages:
                    var res = this.connection.Pages.Single(m => m.PageId == this.ID);
                    this.connection.Pages.Remove(res);
                    break;
                case navlinks:
                    var resNav = this.connection.NavLinks.Single(m => m.NavLinkId == this.ID);
                    this.connection.NavLinks.Remove(resNav);
                    break;
                case relatedpages:
                    System.Console.WriteLine("deleting row using page id ( if one page's id is equals then this row will be delete)");
                    var resRel = this.connection.RelatedPages.Single(m => m.Page1Id == this.ID || m.Page2Id == this.ID);
                    this.connection.RelatedPages.Remove(resRel);
                    break;
                default:
                    throw new InvalidOperationException("no such database  in list [page,navlink,relatedpages]");
            }

        }
    }
    //fix me
    class ListAllCommand : Command
    {
        public override void Execute()
        {
            switch (this.Model.ToLower())
            {
                case pages:
                PrintPages();
                    break;
                case navlinks:
                PrintNavLinks();
                    break;
                case relatedpages:
                    PrintRelpages();
                    break;
                case "all":
                    PrintPages();
                    PrintNavLinks();
                    PrintRelpages();
                    break;
                default:
                    throw new InvalidOperationException("no such database  in list [page,navlink,relatedpages]");
            }

        }

        public void PrintPages()
        {
            System.Console.WriteLine("Pages:");
            this.connection.Pages.ToList().ForEach(res => System.Console.WriteLine($"PageID: {res.PageId}  UrlName: {res.UrlName} Description: {res.Description}  Content:{res.Content}  AddedDate: {res.AddedDate} "));

        }
        public void PrintNavLinks(){
            System.Console.WriteLine("Navigation links:");
                    this.connection.NavLinks.ToList().ForEach(res => System.Console.WriteLine($"NavLink: {res.NavLinkId} Title: {res.Title} ParentLinkID: {res.ParentLinkID}  PageID: {res.PageId}  Position: {res.Position}"));

        }
        public void PrintRelpages(){
            System.Console.WriteLine("RelatedPages :");
                                this.connection.RelatedPages.ToList().ForEach(res => System.Console.WriteLine($"Page1ID: { res.Page1Id} Page2Id: {res.Page2Id}"));
        }
    }
}