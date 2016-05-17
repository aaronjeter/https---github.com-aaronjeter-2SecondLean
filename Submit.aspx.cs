using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

using System.Data.SqlClient;

namespace _2SecondLean
{
    public partial class Submit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Submit_Button_Click(object sender, EventArgs e)
        {
            byte[] beforeImage = new byte[0];
            byte[] afterImage = new byte[0];

            string beforeName = "";
            string afterName = "";

            string department, name, issue, change, benefit;

            bool finished = true;

            #region Validate Form

            Error_Label.Visible = false;

            #region Before Fileupload
            try
            {
                if (Before_FileUpload.HasFile && ValidateImage(Before_FileUpload.FileName.ToString()))
                {
                    beforeImage = Before_FileUpload.FileBytes;
                    beforeName = Before_FileUpload.FileName.ToString();
                }
                else
                {
                    Error_Label.Text = "Please Select Before and After Images (gif, png, or jpg) to Upload";
                    Error_Label.Visible = true;
                    finished = false;
                }
            }
            catch (Exception ex)
            {
                Error_Label.Text = ex.Message;
                Error_Label.Visible = true;
                finished = false;
            }
            #endregion

            #region After Fileupload
            try
            {
                if (After_FileUpload.HasFile && ValidateImage(After_FileUpload.FileName.ToString()))
                {
                    afterImage = After_FileUpload.FileBytes;
                    afterName = After_FileUpload.FileName.ToString();
                }
                else
                {
                    Error_Label.Text = "Please Select Before and After Images (gif, png, or jpg) to Upload";
                    Error_Label.Visible = true;
                    finished = false;
                }
            }
            catch (Exception ex)
            {
                Error_Label.Text = ex.Message;
                Error_Label.Visible = true;
                finished = false;
            }
            #endregion

            department = Department.Text.ToString();
            name = Name.Text.ToString();
            issue = Issue.Text.ToString();
            change = Change.Text.ToString();
            benefit = Benefit.Text.ToString();

            if (name == "")
            {
                name = "anonymous";
            }

            if (issue == "")
            {
                finished = false;
            }

            if (change == "")
            {
                finished = false;
            }

            if (benefit == "")
            {
                finished = false;
            }

            #endregion

            if (finished)
            {
                #region Database Stuff

                SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                SqlCommand command = new SqlCommand();
                command.Connection = connection;

                command.CommandText = "Insert Into Quality.dbo.two_second_lean (department, time, name, issue, change, benefit, beforeImage, afterImage, beforeImageName, afterImageName, approved)"
                                    + " Values (@department, @time, @name, @issue, @change, @benefit, @beforeImage, @afterImage, @beforeImageName, @afterImageName, 0);"
                                    + " Select Scope_Identity()";
                command.Parameters.AddWithValue("@department", department);
                command.Parameters.AddWithValue("@time", DateTime.Now);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@issue", issue);
                command.Parameters.AddWithValue("@change", change);
                command.Parameters.AddWithValue("@benefit", benefit);

                command.Parameters.Add("@beforeImage", System.Data.SqlDbType.VarBinary, 0).Value = beforeImage;
                command.Parameters.Add("@afterImage", System.Data.SqlDbType.VarBinary, 0).Value = afterImage;

                command.Parameters.AddWithValue("@beforeImageName", beforeName);
                command.Parameters.AddWithValue("@afterImageName", afterName);

                connection.Open();
                var retval = command.ExecuteScalar();
                string id = retval.ToString();
                connection.Close();

                Models.SessionHandler sh = new Models.SessionHandler();
                sh.SetId(id);
                Response.Redirect("Details.aspx");
                #endregion
            }
        }

        public bool ValidateImage(string filename)
        {
            if (GetImageFormat(filename) == null)
            {
                return false;
            }

            return true;
        }

        public ImageFormat GetImageFormat(string filename)
        {
            string fileExtension = filename.Split('.')[1].ToLowerInvariant();
            switch(fileExtension)
            {
                case "png":
                    return ImageFormat.Png;
                case "gif":
                    return ImageFormat.Gif;
                case "jpg":
                    return ImageFormat.Jpeg;
                case "jpeg":
                    return ImageFormat.Jpeg;
                default:
                    return null;                    
            }
        }
    }
}