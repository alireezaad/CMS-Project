using CMS.ModelLayer;
using CMS.ServiceLayer;
using CMSArticle.Views.ViewModel;
using CodeFirst_EF.App_Start;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CMSArticle.Areas.Admin.Controllers
{
    public class CommentsController : Controller
    {
        private CMSContext db = new CMSContext();
        CommentService _CommentService;

        public CommentsController()
        {
            _CommentService = new CommentService(db);
        }

        // GET: Admin/Comments
        public async Task<ActionResult> Index()
        {
            var comments = await _CommentService.GetAll();
            var commentViewModel = AutoMapperConfig.mapper.Map<IEnumerable<Comment>, IEnumerable<CommentViewModel>>(comments);
            return View(commentViewModel.ToList());
        }

        // GET: Admin/Comments/Details/5
        //public async Task<ActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Comment comment = await db.comments.FindAsync(id);
        //    if (comment == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(comment);
        //}

        // GET: Admin/Comments/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Admin/Comments/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "CommentId,FullName,Email,Content")] CommentViewModel commentViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var comment = AutoMapperConfig.mapper.Map<CommentViewModel, Comment>(commentViewModel);
        //        comment.RegisterDate = DateTime.Now;
        //        comment.IsActive = false;
        //        await _CommentService.Add(comment);
        //        _CommentService.Save();
        //        return RedirectToAction("Index");
        //    }

        //    return View(commentViewModel);
        //}

        // GET: Admin/Comments/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = await _CommentService.GetEntity(id.Value);
            if (comment == null)
            {
                return HttpNotFound();
            }
            var commentViewModel = AutoMapperConfig.mapper.Map<Comment, CommentViewModel>(comment);
            return View(commentViewModel);
        }

        // POST: Admin/Comments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CommentId,FullName,Email,Content,RegisterDate,IsActive")] CommentViewModel commentViewModel)
        {
            if (ModelState.IsValid)
            {
                var comment = AutoMapperConfig.mapper.Map<CommentViewModel, Comment>(commentViewModel);
                await _CommentService.Update(comment);
                _CommentService.Save();
                return RedirectToAction("Index");
            }
            return View(commentViewModel);
        }

        // GET: Admin/Comments/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = await _CommentService.GetEntity(id.Value);
            if (comment == null)
            {
                return HttpNotFound();
            }
            var commentViewModel = AutoMapperConfig.mapper.Map<Comment, CommentViewModel>(comment);
            return View(commentViewModel);
        }

        // POST: Admin/Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _CommentService.Delete(await _CommentService.GetEntity(id));
            _CommentService.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _CommentService.Dispose();
        }
    }
}
