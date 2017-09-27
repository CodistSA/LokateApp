using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace Lokate.Models
{

    public class Registration
    {
        [Required(ErrorMessage = "CompanyName Required:")]
        [DisplayName("Company Name")]
        [RegularExpression(@"^[a-zA-Z'.\s]{1,40}$", ErrorMessage = "Special Characters not allowed")]
        [StringLength(50, ErrorMessage = "Less than 50 characters")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "CompanyAddress Required:")]
        [DisplayName("Company Address")]
        [StringLength(100, ErrorMessage = "Less than 100 characters")]
        public string CompanyAddress { get; set; }

        [Required(ErrorMessage = "Admin_Name Required:")]
        [DisplayName("Admin Name")]
        [RegularExpression(@"^[a-zA-Z'.\s]{1,40}$", ErrorMessage = "Special Characters not allowed")]
        [StringLength(50, ErrorMessage = "Less than 50 characters")]
        public string AdminName { get; set; }

        [Required(ErrorMessage = "Admin_Surname Required:")]
        [DisplayName("Admin Surname")]
        [RegularExpression(@"^[a-zA-Z'.\s]{1,40}$", ErrorMessage = "Special Characters not allowed")]
        [StringLength(50, ErrorMessage = "Less than 50 characters")]
        public string AdminSurname { get; set; }

        [Required(ErrorMessage = "Admin Email Required:")]
        [DisplayName("Admin Email")]
        //[RegularExpression(@"^[a-zA-Z'.\s]{1,40}$", ErrorMessage = "Special Characters not allowed")]
        //[StringLength(50, ErrorMessage = "Less than 50 characters")]
        public string AdminEmail { get; set; }

        [Required(ErrorMessage = "Admin_Phone Required:")]
        [DisplayName("Admin Phone")]
        //[RegularExpression(@"^[a-zA-Z'.\s]{1,40}$", ErrorMessage = "Special Characters not allowed")]
        [StringLength(12, ErrorMessage = "Less than 50 characters")]
        public string AdminPhone { get; set; }

        [Required(ErrorMessage = "Admin_Password Required:")]
        [DataType(DataType.Password)]
        [DisplayName("Admin Password:")]
        [StringLength(150, ErrorMessage = "Less than 150 characters", MinimumLength = 6)]
        public string AdminPassword { get; set; }

        public string PasswordSalt { get; set; }

        public bool IsUserExist(string AdminEmail)
        {
            bool flag = false;
            SqlConnection connection = new SqlConnection
    (System.Configuration.ConfigurationManager.ConnectionStrings["cs"].ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("select count(*) from [lokateapp_DB].[AdminUsers] where Admin_Email = '" + AdminEmail + "'", connection);
            flag = Convert.ToBoolean(command.ExecuteScalar());
            connection.Close();
            return flag;
        }

        public bool Insert()
        {

            bool flag = false;
            if (!IsUserExist(AdminEmail))
            {
                SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["cs"].ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("insert into [lokateapp_DB].[AdminUsers] values('" + CompanyName + "','" + CompanyAddress + "','"
                    + AdminName + "','" + AdminSurname + "','" + AdminEmail + "','" + AdminPhone + "','" + AdminPassword + "','" + '0' + "')", connection);
                flag = Convert.ToBoolean(command.ExecuteNonQuery());
                connection.Close();
                return flag;
            }
            return flag;
        }
           

    }
}