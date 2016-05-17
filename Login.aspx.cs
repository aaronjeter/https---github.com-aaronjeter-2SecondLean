using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Security;

using System.Data.SqlClient;

namespace _2SecondLean
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            bool authenticated = false;
            authenticated = Models.User.ValidateUser(Login1.UserName, Login1.Password); 
            if (authenticated)
            {
                Response.Redirect("Admin/Submissions.aspx");
            }
        }        
    }
}