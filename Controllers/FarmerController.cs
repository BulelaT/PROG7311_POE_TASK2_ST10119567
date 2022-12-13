using PROG7311_POE_TASK2_ST10119567.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows;

namespace PROG7311_POE_TASK2_ST10119567.Controllers
{
    public class FarmerController : Controller
    {
        // GET: Farmer
        public ActionResult Index()
        {
            if (CurrentUser.efm != null)
            {
                if (!CurrentUser.efm.checkUserStatus)//checks if user is employee(true) or farmer(false)
                {
                    DataAccessLayer dal = new DataAccessLayer();
                    ItemModel im = new ItemModel();
                    im.imList = new List<ItemModel>();//current user items

                    List<ItemModel> allUserItems = (List<ItemModel>)dal.GetAllItems();//all items in database

                    //ensure user only sees their data
                    foreach (var item in allUserItems)
                    {
                        if (item.FarmerEmail.Equals(CurrentUser.efm.email))
                        {
                            im.imList.Add(item);
                        }
                    }
                    return View(im);
                }
                else
                {
                    return RedirectToAction("Index", "Employee");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        public ActionResult AddItem()
        {
            if (CurrentUser.efm != null)
            {
                if (!CurrentUser.efm.checkUserStatus)//checks if user is employee(true) or farmer(false)
                {

                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Employee");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        //Confirmation of Added Item
        [HttpPost]
        public ActionResult AddItem(FormCollection fc)
        {

            if (CurrentUser.efm != null)
            {
                if (!CurrentUser.efm.checkUserStatus)//checks if user is employee(true) or farmer(false)
                {
                    DataAccessLayer dal = new DataAccessLayer();
                    ItemModel im = new ItemModel();
                    im.Name = fc["Name"] == "" ? null : fc["Name"];
                    im.Type = fc["Type"] == "" ? null : fc["Type"];
                    im.Price = Convert.ToDouble(fc["Price"] == "" ? null : fc["Price"]);
                    im.DateAdded = Convert.ToDateTime(fc["StartDateValue"] == "" ? null : fc["StartDateValue"]);
                    im.FarmerEmail = CurrentUser.efm.email;
                    im.quantity = Convert.ToInt32(fc["quantity"] == "" ? null : fc["quantity"]);//added field

                    dal.AddItem(im);

                    return RedirectToAction("Index", "Farmer");
                }
                else
                {
                    return RedirectToAction("Index", "Employee");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }
    }
}