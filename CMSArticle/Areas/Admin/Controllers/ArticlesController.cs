using CMS.ModelLayer;
using CMS.ServiceLayer;
using CMSArticle.Views.ViewModel;
using CodeFirst_EF.App_Start;
using System.Collections.Generic;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CMSArticle.Areas.Admin.Controllers
{
    public class ArticlesController : Controller
    {
        private CMSContext db = new CMSContext();
        ArticleService _service;
        public ArticlesController()
        {
            _service = new ArticleService(db);
        }

        // GET: Admin/Articles
        public async Task<ActionResult> Index()
        {
            var articles = await _service.GetAll();
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
        //    Article article = await db.articles.FindAsync(id);
        //    if (article == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(article);
        //}

        // GET: Admin/Articles/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.users, "UserId", "Name");
            return View();
        }

        // POST: Admin/Articles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ArticleId,Title,Content,ImageName,RegisterDate,IsActive,Like,Visit,UserId")] Article article)
        {
            if (ModelState.IsValid)
            {
                db.articles.Add(article);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.users, "UserId", "Name", article.UserId);
            return View(article);
        }

        // GET: Admin/Articles/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = await db.articles.FindAsync(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.users, "UserId", "Name", article.UserId);
            return View(article);
        }

        // POST: Admin/Articles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ArticleId,Title,Content,ImageName,RegisterDate,IsActive,Like,Visit,UserId")] Article article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.users, "UserId", "Name", article.UserId);
            return View(article);
        }

        // GET: Admin/Articles/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = await db.articles.FindAsync(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Admin/Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Article article = await db.articles.FindAsync(id);
            db.articles.Remove(article);
            await db.SaveChangesAsync();
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
