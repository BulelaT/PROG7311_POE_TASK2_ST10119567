using PROG7311_POE_TASK2_ST10119567.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows;

namespace PROG7311_POE_TASK2_ST10119567.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            //Ensure a user is active currently
            if (CurrentUser.efm != null)
            {
                if (CurrentUser.efm.checkUserStatus)//checks if user is employee(true) or farmer(false)
                {
                    DataAccessLayer dal = new DataAccessLayer();
                    FarmerModel fm = new FarmerModel();
                    fm.farmerList = (List<FarmerModel>)dal.GetAllFarmers();
                    return View(fm);
                }
                else
                {
                    return RedirectToAction("Index", "Farmer");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        //Add Farmer to database
        public ActionResult AddFarmer()
        {

            if (CurrentUser.efm != null)
            {
                if (CurrentUser.efm.checkUserStatus)//checks if user is employee(true) or farmer(false)
                {

                    FarmerModel fm = new FarmerModel();
                    return View(fm);
                }
                else
                {
                    return RedirectToAction("Index", "Farmer");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        //Confirmation of Added farmer
        [HttpPost]
        public ActionResult AddFarmer(FormCollection fc)
        {

            if (CurrentUser.efm != null)
            {
                if (CurrentUser.efm.checkUserStatus)//checks if user is employee(true) or farmer(false)
                {
                    DataAccessLayer dal = new DataAccessLayer();
                    FarmerModel fm = new FarmerModel();
                    fm.Name = fc["Name"] == "" ? null : fc["Name"];
                    fm.Surname = fc["Surname"] == "" ? null : fc["Surname"];
                    fm.Username = fc["Username"] == "" ? null : fc["Username"];
                    fm.Email = fc["Email"] == "" ? null : fc["Email"];
                    fm.Password = fc["Password"] == "" ? null : fc["Password"];
                    fm.StartDate = Convert.ToDateTime(fc["StartDateValue"] == "" ? null : fc["StartDateValue"]);

                    dal.AddFarmer(fm);
                    
                    return RedirectToAction("Index", "Employee");
                }
                else
                {
                    return RedirectToAction("Index", "Farmer");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        //Search for farmer
        public ActionResult SearchFarmer()
        {

            if (CurrentUser.efm != null)
            {
                
                if (CurrentUser.efm.checkUserStatus)//checks if user is employee(true) or farmer(false)
                {
                    DataAccessLayer dal = new DataAccessLayer();
                    ItemModel itemModel = new ItemModel();
                    itemModel.fmList = (List<FarmerModel>)dal.GetAllFarmers();
                    itemModel.imList = (List<ItemModel>)dal.GetAllItems();
                    return View(itemModel);
                }
                else
                {
                    return RedirectToAction("Index", "Farmer");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }


        //Search for product type
        public ActionResult SearchProductType()
        {

            if (CurrentUser.efm != null)
            {
                if (CurrentUser.efm.checkUserStatus)//checks if user is employee(true) or farmer(false)
                {
                    DataAccessLayer dal = new DataAccessLayer();
                    ItemModel itemModel = new ItemModel();
                    itemModel.imList = (List<ItemModel>)dal.GetAllItems();
                    return View(itemModel);
                }
                else
                {
                    return RedirectToAction("Index", "Farmer");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        

    }
}