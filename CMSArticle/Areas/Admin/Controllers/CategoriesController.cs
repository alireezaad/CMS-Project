using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CMS.ModelLayer;
using CMS.ServiceLayer;
using CodeFirst_EF.App_Start;
using CMSArticle.Views.ViewModel;
using System.IO;

namespace CMSArticle.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        private CMSContext db = new CMSContext();
        CategoryService _Service;
        public CategoriesController()
        {
            _Service = new CategoryService(db);
        }
        public async Task<ActionResult> Index()
        {
            IEnumerable<Category> category = await _Service.GetAll();
            return View(AutoMapperConfig.mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(category));
        }

        //[HttpGet]
        //public async Task<ActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Category category = await _Service.GetEntity(id.Value);
        //    if (category == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    var viewModel = AutoMapperConfig.mapper.Map<Category, CategoryViewModel>(category);
        //    return View(viewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CategoryId,Title")] CategoryViewModel viewModel, HttpPostedFileBase newImage)
        {
            if (ModelState.IsValid)
            {
                string imageName = "nophoto.png";
                if (newImage != null)
                {
                    if (newImage.ContentType != "image/jpeg" && newImage.ContentType != "image/png")
                    {
                        ModelState.AddModelError("newImage", "فرمت عکس انتخابی باید png و یا jpg باشد");
                        return View(viewModel);
                    }
                    if (newImage.ContentLength > 300000)
                    {
                        ModelState.AddModelError("newImage", "حجم عکس انتخابی باید کمتر از 300 کیلوبایت باشد");
                        return View(viewModel);
                    }   
                    imageName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(newImage.FileName);
                    newImage.SaveAs(Server.MapPath("/Images/Category/") + imageName);
                }
                viewModel.ImageName = imageName;
                Category category = AutoMapperConfig.mapper.Map<CategoryViewModel, Category>(viewModel);
                 await _Service.Add(category);
                 _Service.Save();
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = await _Service.GetEntity(id.Value);
            if (category == null)
            {
                return HttpNotFound();
            }
            CategoryViewModel viewModel = AutoMapperConfig.mapper.Map<Category,CategoryViewModel >(category);
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CategoryId,Title,ImageName")] CategoryViewModel viewModel, HttpPostedFileBase newImage)
        {
            if (ModelState.IsValid)
            {
                if (newImage != null)
                {
                    if (newImage.ContentType != "image/jpeg" && newImage.ContentType != "image/png")
                    {
                        ModelState.AddModelError("newImage", "فرمت عکس انتخابی باید png و یا jpg باشد");
                        return View(viewModel);
                    }
                    if (newImage.ContentLength > 300000)
                    {
                        ModelState.AddModelError("newImage", "حجم عکس انتخابی باید کمتر از 300 کیلوبایت باشد");
                        return View(viewModel);
                    }
                    System.IO.File.Delete(Server.MapPath("/Images/Category/") + viewModel.ImageName);
                    //viewModel.ImageName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(newImage.FileName);
                    newImage.SaveAs(Server.MapPath("/Images/Category/") + viewModel.ImageName);
                }
                Category category = AutoMapperConfig.mapper.Map<CategoryViewModel, Category>(viewModel);
                await _Service.Update(category);
                _Service.Save();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost, /*ActionName("Delete")*/]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            //if (id is null)
            //{
            //    return Content("آیدی اشتباه است.");
            //}
            //Category category = await _Service.GetEntity(id.Value);
            //if (category == null)
            //{
            //    return Content("موجودیتی با این آیدی وجود ندارد.");
            //}
            await _Service.Delete(id);
            _Service.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _Service.Dispose();
        
        }
    }
}
