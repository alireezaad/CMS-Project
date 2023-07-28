using CMS.ModelLayer;
using CMS.ServiceLayer;
using CMSArticle.Views.ViewModel;
using CodeFirst_EF.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CMSArticle.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        private CMSContext db = new CMSContext();
        UserService _UserService;

        public UsersController()
        {
            _UserService = new UserService(db);
        }
        // GET: Admin/Users
        public async Task<ActionResult> Index()
        {
            var usersList = await _UserService.GetAll();
            //var veiwModelList = AutoMapperConfig.mapper.Map<List<User>,List<UserViewModel>>(usersList.ToList());
            return View(AutoMapperConfig.mapper.Map<List<User>, List<UserViewModel>>(usersList.ToList()));
        }

        // GET: Admin/Users/Details/5
        //public async Task<ActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    User user = await db.users.FindAsync(id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user);
        //}

        // GET: Admin/Users/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "UserId,Name,Family,Phonenumber,Password,ConfirmPassword,RegisterDate,IsActive")] UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                userViewModel.RegisterDate = DateTime.Now;
                userViewModel.Password = HashPass.ComputeSha256Hash(userViewModel.Password);
                var user = AutoMapperConfig.mapper.Map<UserViewModel, User>(userViewModel);
                await _UserService.Add(user);
                _UserService.Save();
                return RedirectToAction("Index");
            }

            return View(userViewModel);
        }

        // GET: Admin/Users/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await _UserService.GetEntity(id.Value);
            if (user == null)
            {
                return HttpNotFound();
            }
            var userViewModel = AutoMapperConfig.mapper.Map<User, UserViewModel>(user);
            return View(userViewModel);
        }

        // POST: Admin/Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "UserId,Name,Family,Phonenumber,Password,ConfirmPassword,RegisterDate,IsActive")] UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                userViewModel.Password = HashPass.ComputeSha256Hash(userViewModel.Password);
                var user = AutoMapperConfig.mapper.Map<UserViewModel, User>(userViewModel);
                await _UserService.Update(user);
                _UserService.Save();;
                return RedirectToAction("Index");

            }
            return View(userViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            _UserService.Dispose();
        }
    }
}
