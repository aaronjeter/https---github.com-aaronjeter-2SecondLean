using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace _2SecondLean
{
    public partial class Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
            if (Page.IsPostBack == false)
            {
                Models.SessionHandler sh = new Models.SessionHandler();
                string id = sh.GetId();

                if (id == "")
                {
                    id = "1";
                }

                Models.Submission sub = new Models.Submission(id);

                imgBefore.Src = sub.GetBeforeImage();
                imgAfter.Src = sub.GetAfterImage();

                //ID.Text = sub.ID;
                Department.Text = sub.Department;
                Time.Text = sub.Time.ToString("MM/dd/yyyy");
                Name.Text = sub.Name;
                Issue.Text = sub.Issue;
                Change.Text = sub.Change;
                Benefit.Text = sub.Benefit;

                sh.SetSubmission(sub);
            }            
        }

        /// <summary>
        /// Method to rotate BeforeImage 90 degrees
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Before_Rotate_Button_Click(object sender, EventArgs e)
        {
            Models.SessionHandler sh = new Models.SessionHandler();
            Models.Submission sub = sh.GetSubmission();

            if (sub != null)
            {
                sub.RotateBefore();
                Response.Redirect("Details.aspx");
            }            
        }

        /// <summary>
        /// Method to rotate AfterImage 90 degrees
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void After_Rotate_Button_Click(object sender, EventArgs e)
        {
            Models.SessionHandler sh = new Models.SessionHandler();
            Models.Submission sub = sh.GetSubmission();
            string id = sh.GetId();

            if (sub != null)
            {
                sub.RotateAfter();
                Response.Redirect("Details.aspx");
            }
        }
    }
}