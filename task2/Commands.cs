using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace DatabaseApplication
{



    abstract class Command
    {
        public SqliteDbContext connection;
        public int ID { get; set; }
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
            string res = string.Empty;
            switch (this.Model.ToLower())
            {
                case pages:
                    var page = Utils.ParseJson<Page>(this.Json);
                    this.connection.Pages.Add(page);
                    this.connection.SaveChanges();
                    res = "Page ID:" + this.connection.Pages.Last().PageId;



                    break;
                case navlinks:
                    var nav = Utils.ParseJson<NavLink>(this.Json);
                    this.connection.NavLinks.Add(nav);
                    this.connection.SaveChanges();
                    res = " NavLink:" + this.connection.NavLinks.Last().NavLinkId;

                    break;
                case relatedpages:
                    var relpages = Utils.ParseJson<RelatedPage>(this.Json);
                    System.Console.WriteLine(relpages);
                    this.connection.RelatedPages.Add(relpages);
                    this.connection.SaveChanges();
                    res = "relatedpages :" + this.connection.RelatedPages.Last();
                    break;
                default:
                    throw new InvalidOperationException("no such database  in list [page,navlink,relatedpages]");
            }
            System.Console.WriteLine(res);


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
                    if (nav.PageId != null)
                    {
                        navLinkDb.PageId = nav.PageId;
                    }
                    if (nav.ParentLinkID != null)
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
                    RelatedPage relpage = Utils.ParseJson<RelatedPage>(this.Json);
                    var relPageDb = this.connection.RelatedPages.Single(p => p.ID== this.ID);
                    if (relpage.Page1Id != null)
                    {
                        relPageDb.Page1Id = relpage.Page1Id;
                    }
                    if (relpage.Page2Id != null)
                    {
                        relPageDb.Page2Id = relpage.Page2Id;
                    }
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
                    var resRel = this.connection.RelatedPages.Single(m => m.ID == this.ID);
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
            Print(this.connection.Pages.ToList());

        }
        public void PrintNavLinks()
        {
            System.Console.WriteLine("Navigation links:");
            Print(this.connection.NavLinks.ToList());

        }
        public void PrintRelpages()
        {
            System.Console.WriteLine("RelatedPages :");
            Print(this.connection.RelatedPages.ToList());
        }

        private void Print(IEnumerable l)
        {
            foreach (var item in l)
            {
                System.Console.WriteLine(l);
            }

        }
    }
}