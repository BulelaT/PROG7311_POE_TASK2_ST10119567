using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PROG7311_POE_TASK2_ST10119567.Models
{
    public class DataAccessLayer//Access the database
    {
        //string connectionString = "Data Source=LAPTOP-3N0PSLIN;Initial Catalog=FarmersHub;Integrated Security=True"; //Original script
        string connectionString = "Data Source=LAPTOP-3N0PSLIN;Initial Catalog=FarmersHubBackUp;Integrated Security=True";
        //Employee Table
        //getting all employees
        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            List<EmployeeModel> employeeList = new List<EmployeeModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllEmployees", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EmployeeModel e = new EmployeeModel();
                    e.userName = Convert.ToString(dr["uName"].ToString());
                    e.email = Convert.ToString(dr["Email"].ToString());
                    e.password = Convert.ToString(dr["uPassword"].ToString());


                    employeeList.Add(e);
                }

                con.Close();
            }

            return employeeList;
        }

        //Adding employee to table
        public void AddEmployee(EmployeeModel e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_InsertUser", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@euName", e.userName);
                cmd.Parameters.AddWithValue("@eemail", e.email);
                cmd.Parameters.AddWithValue("@euPassword", e.password);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //Farmer Table
        //Getting All Farmers
        public IEnumerable<FarmerModel> GetAllFarmers()
        {
            List<FarmerModel> farmerList = new List<FarmerModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllFarmers", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    FarmerModel f = new FarmerModel();
                    f.Name = Convert.ToString(dr["fName"].ToString());
                    f.Surname = Convert.ToString(dr["lName"].ToString());
                    f.Username = Convert.ToString(dr["uName"].ToString());
                    f.Email = Convert.ToString(dr["email"].ToString());
                    f.Password = Convert.ToString(dr["uPassword"].ToString());
                    f.StartDate = Convert.ToDateTime(dr["sDate"].ToString());

                    farmerList.Add(f);
                }

                con.Close();
            }

            return farmerList;
        }

        //Adding farmer to table
        public void AddFarmer(FarmerModel e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_InsertFarmer", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //@ffName,@flName,@fuName,@femail,@fuPassword,@fsDate
                cmd.Parameters.AddWithValue("@ffName", e.Name);
                cmd.Parameters.AddWithValue("@flName", e.Surname);
                cmd.Parameters.AddWithValue("@fuName", e.Username);
                cmd.Parameters.AddWithValue("@femail", e.Email);
                cmd.Parameters.AddWithValue("@fuPassword", e.Password);
                cmd.Parameters.AddWithValue("@fsDate", e.StartDate);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //Item Table
        //Getting All Items
        public IEnumerable<ItemModel> GetAllItems()
        {
            List<ItemModel> ItemList = new List<ItemModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllItems", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ItemModel i = new ItemModel();
                    i.Name = Convert.ToString(dr["pName"].ToString());
                    i.Type = Convert.ToString(dr["pType"].ToString());
                    i.DateAdded = Convert.ToDateTime(dr["dateAdded"].ToString());
                    i.Price = Convert.ToDouble(dr["price"].ToString());
                    i.FarmerEmail = Convert.ToString(dr["Email"].ToString());
                    i.quantity = Convert.ToInt32(dr["quantity"].ToString());


                    ItemList.Add(i);
                }

                con.Close();
            }

            return ItemList;
        }

        //Adding item to table
        public void AddItem(ItemModel i)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_InsertItem", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ipName", i.Name);
                cmd.Parameters.AddWithValue("@ipType", i.Type);
                cmd.Parameters.AddWithValue("@idateAdded", i.DateAdded);
                cmd.Parameters.AddWithValue("@iprice", i.Price);
                cmd.Parameters.AddWithValue("@iemail", i.FarmerEmail);
                cmd.Parameters.AddWithValue("@iquantity", i.quantity);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}