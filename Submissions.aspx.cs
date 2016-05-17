using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;

namespace _2SecondLean
{
    public partial class Submissions : System.Web.UI.Page
    {
        DateTime startDate = DateTime.Parse("01/01/2016");
        DateTime endDate = DateTime.Today.AddDays(1);

        protected void Page_Load(object sender, EventArgs e)
        {              
            if (! Page.IsPostBack)
            {
                List<string> departments = new List<string>();
                departments.Add("All");
                departments.AddRange(Models.Department.GetDepartments());
                Department_DropDownList.DataSource = departments;
            }

            Check_Dates();
            SetupGridview();
            DataBind();
        }

        protected void SetupGridview()
        {
            string department = Department_DropDownList.SelectedValue.ToString();

            if (department == "All")
            {
                department = "%";
            }

            string query = "SELECT [id], [time], [department], [name], [issue], [change], [benefit] FROM [Quality].[dbo].[two_second_lean] "
                            + "WHERE [department] like '" + department + "' "
                            + "AND time between '" + startDate.ToString("yyyy-MM-dd") + "' AND '" + endDate.ToString("yyyy-MM-dd") + "' "
                            + "ORDER BY id desc";

            SqlDataSource1.SelectCommand = query;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GridView1.SelectedRow != null)
            {
                GridViewRow gvr = GridView1.SelectedRow;
                string id = gvr.Cells[1].Text.ToString();

                Models.SessionHandler sh = new Models.SessionHandler();
                sh.SetId(id);
            }

            Response.Redirect("Details.aspx");
        }

        protected void Check_Dates()
        {
            string text = Start_Date_TextBox.Text.ToString().Trim();
            DateTime newDate;

            if (DateTime.TryParse(text, out newDate))
            {
                Start_Date_TextBox.Text = newDate.ToShortDateString();
                startDate = newDate;
            }
            else
            {
                startDate = DateTime.Parse("01/01/2016");
                Start_Date_TextBox.Text = startDate.ToShortDateString();
            }

            text = End_Date_TextBox.Text.ToString().Trim();

            if (DateTime.TryParse(text, out newDate))
            {
                End_Date_TextBox.Text = newDate.ToShortDateString();
                endDate = newDate;
            }
            else
            {
                endDate = DateTime.Today.AddDays(1);
                End_Date_TextBox.Text = endDate.ToShortDateString();
            }
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                e.Row.ToolTip = "Click to select row";
                e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.GridView1, "Select$" + e.Row.RowIndex);
            }
        }
    }
}