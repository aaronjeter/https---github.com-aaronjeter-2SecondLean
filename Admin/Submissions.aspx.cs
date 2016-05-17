using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;

namespace _2SecondLean.Admin
{
    public partial class Submissions : System.Web.UI.Page
    {
        DateTime startDate = DateTime.Parse("01/01/2016");
        DateTime endDate = DateTime.Today.AddDays(1);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Models.User.UserAuthenticated())
            {
                Content_Panel.Visible = true;                
                LoadData();
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        protected void LoadData()
        {
            Check_Dates();
            string department = Department_DropDownList.SelectedValue.ToString();

            if (department == "All")
            {
                department = "%";
            }

            string query = "SELECT [id], [time], [department], [name], [issue], [change], [benefit] FROM [Quality].[dbo].[two_second_lean] "
                         + "WHERE [approved] like '" + department + "' "
                         + "AND time between '" + startDate.ToString("yyyy-MM-dd") + "' AND '" + endDate.ToString("yyyy-MM-dd") + "' "
                         + "ORDER BY id desc";

            SqlDataSource1.SelectCommand = query;
            DataBind();
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

        protected void Export_Button_Click(object sender, EventArgs e)
        {
            List<Models.Submission> submissions = Models.Submission.GetSubmissionList();

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("\"ID\", Time, Department, Name, Issue, Change, Benefit, Approved" + Environment.NewLine);

            foreach (Models.Submission sub in submissions)
            {
                //"Escape" user input in csv by surrounding fields with double quote marks (")
                sb.Append("\"" + sub.ID + "\",\"" + sub.Time + "\",\"" + sub.Department + "\",\"" + sub.Name + "\",\""
                                 + sub.Issue + "\",\"" + sub.Change + "\",\"" + sub.Benefit + "\",\"" + sub.Approved + "\"" + Environment.NewLine);                
            }

            Response.Clear();
            Response.ContentType = "text/csv";
            Response.AppendHeader("Content-Disposition", string.Format("attachment; filename=2SecondLean_{0}.csv", DateTime.Now));
            Response.Write(sb.ToString());
            Context.Response.End();
        }
    }
}