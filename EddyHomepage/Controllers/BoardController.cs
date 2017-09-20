using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EddyHomepage.Models;
using System.Data.Entity;
using System.IO;

namespace EddyHomepage.Controllers
{
    public class BoardController : Controller
    {
        EddyHomePageEntities db = new EddyHomePageEntities();

        [HttpGet]
        public ActionResult Create()
        {
            Articles articles = new Articles();
            return View(articles);
        }

        public ActionResult Create(Articles articles)
        {
            try
            {
                articles.ViewCnt = 0;
                articles.IPAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
                articles.RegistDate = DateTime.Now;
                articles.RegistMemberID = "admin";
                articles.ModifyDate = DateTime.Now;
                articles.ModifyMemberID = "admin";

                db.Articles.Add(articles);
                db.SaveChanges();

                if (Request.Files.Count > 0)
                {
                    var attachFile = Request.Files[0];
                    if (attachFile != null && attachFile.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(attachFile.FileName);
                        var path = Path.Combine(Server.MapPath("~/Upload/"), fileName);
                        attachFile.SaveAs(path);

                        ArticleFiles file = new ArticleFiles();
                        file.ArticleIDX = articles.ArticleIDX;
                        file.FilePath = "/Upload/";
                        file.FileName = fileName;
                        file.FileFormat = Path.GetExtension(attachFile.FileName);
                        file.FileSize = attachFile.ContentLength;
                        file.UploadDate = DateTime.Now;
                        db.ArticleFiles.Add(file);
                        db.SaveChanges();
                    }
                    ViewBag.Result = "OK";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Reuslt = "FAIL";
            }
            return View(articles);
                
        }
        [HttpGet]
        public ActionResult ArticleList()
        {
            List<Articles> list = db.Articles.OrderByDescending(o => o.ModifyDate).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult Edit(int aidx)
        {
            ArticleEditViewModel vm = new ArticleEditViewModel();

            Articles article = db.Articles.Where(c => c.ArticleIDX == aidx).FirstOrDefault();

            List<ArticleFiles> files = db.ArticleFiles.Where(c => c.ArticleIDX == aidx).OrderBy(o => o.UploadDate).ToList();
            vm.Article = article;
            vm.Files = files;

            return View(vm);
        }

        [HttpPost]
        public ActionResult Edit(ArticleEditViewModel vm)
        {
            ArticleEditViewModel dbVM = new ArticleEditViewModel();
            try
            {
                Articles dbArticle = db.Articles.Find(vm.Article.ArticleIDX);

                dbArticle.Title = vm.Article.Title;
                dbArticle.Category = vm.Article.Category;
                dbArticle.Contents = vm.Article.Contents;
                dbArticle.IPAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
                dbArticle.ModifyDate = DateTime.Now;
                dbArticle.ModifyMemberID = "admin";

                db.Entry(dbArticle).State = EntityState.Modified;
                db.SaveChanges();

                if(Request.Files.Count > 0)
                {
                    var attachFile = Request.Files[0];

                    if(attachFile != null && attachFile.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(attachFile.FileName);
                        var path = Path.Combine(Server.MapPath("~/Upload/"), fileName);
                        attachFile.SaveAs(path);

                        ArticleFiles file = new ArticleFiles();
                        file.ArticleIDX = vm.Article.ArticleIDX;
                        file.FilePath = "/Upload/";
                        file.FileName = "fileName";
                        file.FileFormat = Path.GetExtension(attachFile.FileName);
                        file.FileSize = attachFile.ContentLength;
                        file.UploadDate = DateTime.Now;
                        db.ArticleFiles.Add(file);
                        db.SaveChanges();
                       
                    }
                }
                Articles article = db.Articles.Where(c => c.ArticleIDX == vm.Article.ArticleIDX).FirstOrDefault();
                List<ArticleFiles> files = db.ArticleFiles.Where(c => c.ArticleIDX == vm.Article.ArticleIDX).OrderBy(o => o.UploadDate).ToList();

                dbVM.Article = article;
                dbVM.Files = files;
                ViewBag.Result = "OK";
            }
            catch(Exception ex)
            {
                dbVM = vm;
                ViewBag.Result = "FAIIL";
            }
            return View(dbVM);
        }
        
        [HttpGet]
        public ActionResult ArticleDelete(int aidx)
        {
            Articles dbArticle = db.Articles.Where(c => c.ArticleIDX == aidx).FirstOrDefault();
            db.Articles.Remove(dbArticle);
            db.SaveChanges();
            return RedirectToAction("ArticleList");

        }

        [HttpPost]
        public ActionResult FileRemove (int fidx)
        {
            ArticleFiles file = db.ArticleFiles.Where(c => c.FileIDX == fidx).FirstOrDefault();
            int articleIDX = Convert.ToInt32(file.ArticleIDX);

            System.IO.File.Delete(Server.MapPath(file.FilePath + file.FileName));

            db.ArticleFiles.Remove(file);
            db.SaveChanges();

            return RedirectToAction("Edit", new { aidx = articleIDX.ToString()});
        }
    }
       
}
