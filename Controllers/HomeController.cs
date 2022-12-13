using PROG7311_POE_TASK2_ST10119567.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows;

namespace PROG7311_POE_TASK2_ST10119567.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            EmployeeFarmerModel efm = new EmployeeFarmerModel();

            return View(efm);
        }

        [HttpPost]
        public ActionResult Index(FormCollection fc)
        {
            EmployeeFarmerModel efm = new EmployeeFarmerModel();
            efm.email = fc["Email"] == "" ? null : fc["Email"];//retireving Email text field from form
            efm.password = fc["Password"] == "" ? null : fc["Password"];
            DataAccessLayer dal = new DataAccessLayer();

            //Read from database and store data in program
            efm.e = (List<EmployeeModel>)dal.GetAllEmployees();
            efm.f = (List<FarmerModel>)dal.GetAllFarmers();

            foreach (var employee in efm.e)
            {
                if (efm.email.Equals(employee.email))
                {
                    if (efm.password.Equals(employee.password))
                    {
                        //change to employee
                        CurrentUser.efm = efm;
                        CurrentUser.efm.checkUserStatus = true;
                        return RedirectToAction("Index", "Employee");
                    }
                }
            }

            foreach (var farmer in efm.f)
            {
                if (efm.email.Equals(farmer.Email))
                {
                    if (efm.password.Equals(farmer.Password))
                    {
                        //change to farmer
                        CurrentUser.efm = efm;
                        CurrentUser.efm.checkUserStatus = false;
                        return RedirectToAction("Index", "Farmer"); ;
                    }
                }
            }

            return RedirectToAction("Index","Home");
        }

        private bool IsNullOrEmpty(string email)
        {
            throw new NotImplementedException();
        }

        
    }
}