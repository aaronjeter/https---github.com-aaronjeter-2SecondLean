using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _2SecondLean
{
    public partial class SlideShow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Models.Submission sub = Models.Submission.GetRandomSubmission();

            imgBefore.Src = sub.GetBeforeImage();
            imgAfter.Src = sub.GetAfterImage();

            //ID.Text = sub.ID;
            Department.Text = sub.Department;
            Time.Text = sub.Time.ToString("MM/dd/yyyy");
            Name.Text = sub.Name;
            Issue.Text = sub.Issue;
            Change.Text = sub.Change;
            Benefit.Text = sub.Benefit;
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Response.Redirect("SlideShow.aspx");
        }
    }
}