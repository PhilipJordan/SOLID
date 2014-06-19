using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATDD_and_MVC.Models;

namespace ATDD_and_MVC.Controllers
{
    public class AuthenticationController : Controller
    {
        
        public ActionResult Index()
        {
            LoginViewModel viewModel = new LoginViewModel();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel viewModel)
        {
            //bool bothHaveValues = !String.IsNullOrEmpty(viewModel.UserName) && !String.IsNullOrEmpty(viewModel.Password);

            //if (bothHaveValues && !viewModel.UserName.ToLower().Equals("red") && !viewModel.Password.Equals("Rover123"))
            //    ModelState.AddModelError("Mistakes were made", "Wrong Password or User Name given");
                  
            if(!IsValidUser(viewModel.UserName, viewModel.Password))
                ModelState.AddModelError("Mistakes were made", "Wrong Password or User Name given");

            if(ModelState.IsValid)
                return RedirectToAction("Staging", "Mission");
            
            return View(viewModel);
        }

        private bool IsValidUser(string userName, string password)
        {
            bool isValidUser = false;
            bool isValidPassword = false;

            if (!String.IsNullOrEmpty(userName))
                isValidUser = userName.ToLower().Equals("red");

            if(!String.IsNullOrEmpty(password))
                isValidPassword = password.Equals("Rover123");
            
            return isValidUser && isValidPassword;
        }

        

    }
}
