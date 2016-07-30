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
    }
    class AddCommand : Command
    {
        public override void Execute()
        {
            switch (this.Model.ToLower())
            {
                case "pages":
                    var page = Utils.ParseJson<Page>(this.Json);
                    this.connection.Pages.Add(page);
                    System.Console.WriteLine(page);
                    break;
                case "navlink":
                    var nav = Utils.ParseJson<NavLink>(this.Json);
                    this.connection.NavLinks.Add(nav);
                    break;
                case "relatedpages":
                    var relatedpages = Utils.ParseJson<RelatedPage>(this.Json);
                    this.connection.RelatedPages.Add(relatedpages);
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
                case "pages":
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
                case "navlink":
                    NavLink nav = Utils.ParseJson<NavLink>(this.Json);
                    var navLinkDb = this.connection.NavLinks.Single(p => p.NavLinkId == this.ID);
                    if (nav.PageId!=0)
                    {
                        navLinkDb.PageId=nav.PageId;
                    }
                    if (nav.ParentLinkID!=0)
                    {
                        navLinkDb.ParentLinkID=nav.ParentLinkID;
                    }
                    if (nav.Position!=0)
                    {
                        navLinkDb.Position=nav.Position;
                    }
                    if (string.IsNullOrEmpty(nav.Title))
                    {
                        navLinkDb.Title=nav.Title;
                    }
                    break;
                case "relatedpages":
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
                case "pages":
                    var res = this.connection.Pages.Single(m => m.PageId == this.ID);
                    this.connection.Pages.Remove(res);
                    break;
                case "navlink":
                    var resNav = this.connection.NavLinks.Single(m => m.NavLinkId == this.ID);
                    this.connection.NavLinks.Remove(resNav);
                    break;
                case "relatedpages":
                    var resRel = this.connection.RelatedPages.Single(m => m.RelatedPageId == this.ID);
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
                case "pages":
                    this.connection.Pages.ToList().ForEach(res => System.Console.WriteLine(res.UrlName));
                    break;
                case "navlinks":
                    this.connection.NavLinks.ToList().ForEach(res => System.Console.WriteLine(res.Title));
                    break;
                case "relatedpages":
                    this.connection.RelatedPages.ToList().ForEach(res => System.Console.WriteLine(res.RelatedPageId));
                    break;
                default:
                    throw new InvalidOperationException("no such database  in list [page,navlink,relatedpages]");
            }

        }
    }
}