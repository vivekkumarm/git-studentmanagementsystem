#region References
using System.Web.Mvc;
using StudentBusinessLogic;
using StudentsBO;
#endregion References

namespace StudentsManagementSystem.Controllers
{
    public class UserController : Controller
    {
        public UserRepository userRepository = new UserRepository();
        public User user = new User();

        //Added by Yogalakshmi on 19.07.2013
        /// <summary>
        /// Logins this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User loginUser)
        {
            user.UserName = loginUser.UserName;
            user.Password = loginUser.Password;
            var getAllUser = userRepository.GetAllUser(user);
            Session["username"] = getAllUser.UserName;
            Session["userid"] = getAllUser.UserId;
            if (getAllUser.UserId > 0)
            {
                return RedirectToAction("HomePage", "Student");
            }
            return RedirectToAction("Login", "User");
        }

        //Added by Vivek on 19.07.2013
        [HttpGet]
        public ActionResult Register()
        {

            return View(user);
        }

        [HttpPost]
        public ActionResult Register(User UserRegisteration)
        {
            user.UserName = UserRegisteration.UserName;
            user.Password = UserRegisteration.Password;
            user.ConfirmPassword = UserRegisteration.ConfirmPassword;
            userRepository.GetAllUserDetail(UserRegisteration);
            Session["username"] = UserRegisteration.UserName;
            user.UserName = Session["username"].ToString();
            return RedirectToAction("Login", "User");
        }

        public string UserAvailablity(string input)
        {
            int result= userRepository.UserAvailablityCheck(input);
            if (result == 0)
            {
                return "Not Available";
            }

            else
            {
                return "Available";
            }

            
            return "";
        }
    }
}