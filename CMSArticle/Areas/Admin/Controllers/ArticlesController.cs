﻿using CMS.ModelLayer;
using CMS.ServiceLayer;
using CMSArticle.Views.ViewModel;
using CodeFirst_EF.App_Start;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CMSArticle.Areas.Admin.Controllers
{
    public class ArticlesController : Controller
    {
        private CMSContext db = new CMSContext();

        ArticleService _ArticleService;
        UserService _UserService;
        CategoryService _CategoryService;
        public ArticlesController()
        {
            _ArticleService = new ArticleService(db);
            _UserService = new UserService(db);
            _CategoryService = new CategoryService(db);
        }

        // GET: Admin/Articles
        public async Task<ActionResult> Index()
        {
            ViewBag.CategoryId = new SelectList(await _CategoryService.GetAll(), "CategoryId", "Title");
            ViewBag.UserId = new SelectList(await _UserService.GetAll(), "UserId", "Name");
            var articles = await _ArticleService.GetAll();
            var articleViewModels = AutoMapperConfig.mapper.Map<List<Article>, List<ArticleViewModel>>((List<Article>)articles);

            return View(articleViewModels);
        }

        // GET: Admin/Articles/Details/5
        //public async Task<ActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Article articleViewModel = await db.articles.FindAsync(id);
        //    if (articleViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(articleViewModel);
        //}

        // GET: Admin/Articles/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.CategoryId = new SelectList(await _CategoryService.GetAll(), "CategoryId", "Title");
            ViewBag.UserId = new SelectList(await _UserService.GetAll(), "UserId", "Name");
            return View();
        }

        // POST: Admin/Articles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ArticleId,Title,Content,CategoryId")] ArticleViewModel articleViewModel, HttpPostedFileBase imageUpload)
        {
            if (ModelState.IsValid)
            {
                string newImageName = "nophoto.png";

                if (imageUpload != null)
                {
                    if (imageUpload.ContentType != "image/jpeg" && imageUpload.ContentType != "image/png")
                    {
                        ModelState.AddModelError(" MyPropName ", "تصویر شما فقط باید با فرمت png یا jpg یا jpeg باشد!");
                        return View();
                    }

                    if (imageUpload.ContentLength > 300000)
                    {
                        ModelState.AddModelError(" MyPropName ", "سایز تصویر شما نباید بیشتر از 300 کیلوبایت باشد!");
                        return View();
                    }

                    newImageName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(imageUpload.FileName);
                    imageUpload.SaveAs(Server.MapPath("/Images/Article/") + newImageName);
                }
                var article = AutoMapperConfig.mapper.Map<ArticleViewModel, Article>(articleViewModel);
                article.ImageName = newImageName;
                article.IsActive = true;
                article.RegisterDate = DateTime.Now;
                article.Visit = 15;
                article.Like = 3;
                article.UserId = await _UserService.GetAdminId(User.Identity.Name);
                await _ArticleService.Add(article);
                _ArticleService.Save();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.categories, "CategoryId", "Title", articleViewModel.CategoryId);
            ViewBag.UserId = new SelectList(db.users, "UserId", "Name", articleViewModel.UserId);
            return View(articleViewModel);
        }

        // GET: Admin/Articles/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = await _ArticleService.GetEntity(id.Value);
            if (article == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(await _CategoryService.GetAll(), "CategoryId", "Title");
            ViewBag.UserId = new SelectList(await _UserService.GetAll(), "UserId", "Name");
            var articleViewModel = AutoMapperConfig.mapper.Map<Article, ArticleViewModel>(article);
            return View(articleViewModel);
        }

        // POST: Admin/Articles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ArticleId,Title,Content,ImageName,RegisterDate,IsActive,Like,Visit,UserId,CategoryId")] ArticleViewModel articleViewModel, HttpPostedFileBase newImage)
        {
            if (ModelState.IsValid)
            {
                if (newImage != null)
                {
                    if (newImage.ContentType != "image/jpeg" && newImage.ContentType != "image/png")
                    {
                        ModelState.AddModelError("newImage", "فرمت عکس انتخابی باید png و یا jpg باشد");
                        return View(articleViewModel);
                    }
                    if (newImage.ContentLength > 300000)
                    {
                        ModelState.AddModelError("newImage", "حجم عکس انتخابی باید کمتر از 300 کیلوبایت باشد");
                        return View(articleViewModel);
                    }
                    System.IO.File.Delete(Server.MapPath("/Images/Article/") + articleViewModel.ImageName);
                    //viewModel.ImageName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(newImage.FileName);
                    newImage.SaveAs(Server.MapPath("/Images/Article/") + articleViewModel.ImageName);
                }
                var article = AutoMapperConfig.mapper.Map<ArticleViewModel, Article>(articleViewModel);
                await _ArticleService.Update(article);
                _ArticleService.Save();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(await _CategoryService.GetAll(), "CategoryId", "Title");
            ViewBag.UserId = new SelectList(await _UserService.GetAll(), "UserId", "Name");
            return View(articleViewModel);
        }

        // GET: Admin/Articles/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = await _ArticleService.GetEntity(id.Value);

            if (article == null)
            {
                return HttpNotFound();
            }
            var articleViewModel = AutoMapperConfig.mapper.Map<Article, ArticleViewModel>(article);
            return View(articleViewModel);
        }

        // POST: Admin/Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Article article = await _ArticleService.GetEntity(id);
            await _ArticleService.Delete(article);
            _ArticleService.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
