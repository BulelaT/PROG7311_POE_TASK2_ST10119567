using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PROG7311_POE_TASK2_ST10119567.Models
{
    public class FarmerModel
    {
        //All variables Farmer has
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime StartDate { get; set; }
        public List<FarmerModel> farmerList { get; set; }
    }
}