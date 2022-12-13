using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PROG7311_POE_TASK2_ST10119567.Models
{
    public class ItemModel
    {
        //all variables Item has
        public int id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime DateAdded { get; set; }
        public double Price { get; set; }
        public string FarmerEmail { get; set; }
        public int quantity { get; set; }
        public List<ItemModel> imList;// list of all items a farmer has added under their account
        public List<FarmerModel> fmList;//a list of all farmers
    }
}