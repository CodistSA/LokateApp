using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Lokate.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Email Required")]
        [DisplayName("Email ")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$",
                                    ErrorMessage = "Email Format is wrong")]
        [StringLength(50, ErrorMessage = "Less than 50 characters")]
        public string AdminEmail
        {
            get; set;
        }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password Required")]
        [DisplayName("Password")]
        [StringLength(30, ErrorMessage = ":Less than 30 characters")]
        public string AdminPassword
        {
            get; set;
        }
        public bool IsUserExist(string AdminEmail, string AdminPassword)
        {
            bool flag = false;
            SqlConnection connection = new SqlConnection(
    System.Configuration.ConfigurationManager.ConnectionStrings["cs"].ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("select count(*) from [lokateapp_DB].[AdminUsers] where Admin_Email = '" + AdminEmail + "' and Admin_Password = '" + AdminPassword + "'", connection);
            flag = Convert.ToBoolean(command.ExecuteScalar());
            connection.Close();
            return flag;
        }
    }
    
}
