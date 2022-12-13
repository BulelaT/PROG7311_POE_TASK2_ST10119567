using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PROG7311_POE_TASK2_ST10119567.Models
{
    public class EmployeeFarmerModel
    {
        //Add users to arraylists depending on what type of user they are
        public List<FarmerModel> f { get; set; }
        public List<EmployeeModel> e { get; set; }
        public string email { get; set; }
        public string password{ get; set; }
        public Boolean checkUserStatus { get; set; }
    }
}