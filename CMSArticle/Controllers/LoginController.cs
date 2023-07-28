using CMS.ModelLayer;
using CMS.ServiceLayer;
using CMSArticle.Views.ViewModel;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;

namespace CMSArticle.Controllers
{
    public class LoginController : Controller
    {
        CMSContext db = new CMSContext();
        UserService _UserService;
        public LoginController()
        {
            _UserService = new UserService(db);
        }
        [HttpGet]
        public ActionResult Login(string returnUrl = "/")
        {
            UserLoginViewModel model = new UserLoginViewModel() { ReturnUrl = returnUrl };
            //if (string.IsNullOrEmpty(returnUrl) && Request.UrlReferrer != null)
            //    returnUrl = Server.UrlEncode(Request.UrlReferrer.PathAndQuery);
            //if (Url.IsLocalUrl(returnUrl) && !string.IsNullOrEmpty(returnUrl))
            //{
            //}



            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login([Bind(Include = "Phonenumber,Password,SavePassword,ReturnUrl")] UserLoginViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                userViewModel.Password = HashPass.ComputeSha256Hash(userViewModel.Password);
                var tempList = await _UserService.GetAll();
                var admin = tempList.FirstOrDefault(a => a.Phonenumber == userViewModel.Phonenumber && a.Password == userViewModel.Password);
                if (admin != null)
                {
                    FormsAuthentication.SetAuthCookie(userViewModel.Phonenumber, userViewModel.SavePassword);
                    if (userViewModel.ReturnUrl is null)
                    {
                        userViewModel.ReturnUrl = "/";
                    }
                    return Redirect(userViewModel.ReturnUrl);
                }
                ModelState.AddModelError("PhoneNumber", "شماره موبایل یا رمز عبور شما اشتباه است!");
                return View(userViewModel);
            }
            return View(userViewModel);
        }
    }
}