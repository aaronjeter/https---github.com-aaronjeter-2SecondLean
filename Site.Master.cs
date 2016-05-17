using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _2SecondLean
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Models.User.UserAuthenticated())
            {
                Admin_LinkButton.Visible = true;
            }
            else
            {
                Login_LinkButton.Visible = true;
            }
        }

        protected void Admin_LinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Submissions");
        }

        protected void Login_LinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login");
        }
    }
}