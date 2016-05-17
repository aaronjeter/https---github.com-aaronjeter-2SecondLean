using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;

namespace _2SecondLean.Models
{
    public class Submission
    {
        public Submission ()
        {

        }

        public Submission (string id)
        {
            #region Database Stuff
            SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            SqlCommand command = new SqlCommand();
            command.Connection = connection;

            command.CommandText = "Select * FROM Quality.dbo.two_second_lean WHERE id = @id";
            command.Parameters.AddWithValue("@id", id);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                ID = reader["id"].ToString();
                Department = reader["department"].ToString();
                Time = DateTime.Parse(reader["time"].ToString());
                Name = reader["name"].ToString();
                Issue = reader["issue"].ToString();
                Change = reader["change"].ToString();
                Benefit = reader["benefit"].ToString();

                BeforeImage = (byte[])reader["beforeImage"];
                AfterImage = (byte[])reader["afterImage"];

                BeforeName = reader["beforeImageName"].ToString();
                AfterName = reader["afterImageName"].ToString();
                Approved = Convert.ToBoolean(reader["approved"]);
            }

            connection.Close();
            #endregion
        }

        public static List<Submission> GetSubmissionList()
        {
            List<Submission> submissions = new List<Submission>();

            SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            SqlCommand command = new SqlCommand();
            command.Connection = connection;

            command.CommandText = "SELECT [id],[time],[department],[name],[issue],[change],[benefit],[approved] FROM [Quality].[dbo].[two_second_lean] order by id";

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Submission sub = new Submission();

                sub.ID = reader["id"].ToString();
                sub.Time = reader.GetDateTime(1);
                sub.Department = reader["department"].ToString();
                sub.Name = reader["name"].ToString();
                sub.Issue = reader["issue"].ToString();
                sub.Change = reader["change"].ToString();
                sub.Benefit = reader["benefit"].ToString();
                sub.Approved = reader.GetBoolean(7);
                submissions.Add(sub);
            }

            return submissions;
        }

        public static Submission GetRandomSubmission()
        {
            DateTime startDate = DateTime.Today.AddDays(-14);
            DateTime endDate = DateTime.Today;

            string random = "1";

            //Run query to see how many submissions there are
            SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            SqlCommand command = new SqlCommand();
            command.Connection = connection;

            command.CommandText = "Select Top 1 id From Quality.dbo.two_second_lean WHERE (time between @startDate AND @endDate) AND approved = 1 ORDER BY NEWID()";
            command.Parameters.AddWithValue("@startDate", startDate);
            command.Parameters.AddWithValue("@endDate", endDate);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                random = reader["id"].ToString();
            }

            connection.Close();

            //Get random number

            //return

            return new Submission(random);
        }

        /// <summary>
        /// Method to Update all fields in database. This method probably won't be used much, in favor of more specilized methods
        /// This is because of the size of the images. There is no need to push that much data unless we actually changed an image
        /// </summary>
        public void UpdateDatabase()
        {
            SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            SqlCommand command = new SqlCommand();
            command.Connection = connection;

            command.CommandText = "UPDATE Quality.dbo.two_second_lean "
                                + "SET  department = @department, name = @name, issue = @issue, change = @change, benefit= @benefit, beforeImage = @beforeImage, afterImage = @afterImage, beforeImageName = @beforeImageName, afterImageName = @afterImageName "
                                + "WHERE id = @id";

            command.Parameters.AddWithValue("@id", ID);
            command.Parameters.AddWithValue("@department", Department);
            command.Parameters.AddWithValue("@name", Name);
            command.Parameters.AddWithValue("@issue", Issue);
            command.Parameters.AddWithValue("@change", Change);
            command.Parameters.AddWithValue("@benefit", Benefit);

            command.Parameters.Add("@beforeImage", System.Data.SqlDbType.VarBinary, 0).Value = BeforeImage;
            command.Parameters.Add("@afterImage", System.Data.SqlDbType.VarBinary, 0).Value = AfterImage;

            command.Parameters.AddWithValue("@beforeImageName", BeforeName);
            command.Parameters.AddWithValue("@afterImageName", AfterName);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void UpdateBeforeImage()
        {
            SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            SqlCommand command = new SqlCommand();
            command.Connection = connection;

            command.CommandText = "UPDATE Quality.dbo.two_second_lean "
                                + "SET beforeImage = @beforeImage "
                                + "WHERE id = @id";

            command.Parameters.AddWithValue("@id", ID);
            
            command.Parameters.Add("@beforeImage", System.Data.SqlDbType.VarBinary, 0).Value = BeforeImage;
            connection.Open();
            command.ExecuteNonQuery();
        }

        public void UpdateAfterImage()
        {
            SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            SqlCommand command = new SqlCommand();
            command.Connection = connection;

            command.CommandText = "UPDATE Quality.dbo.two_second_lean "
                                + "SET afterImage = @afterImage "
                                + "WHERE id = @id";

            command.Parameters.AddWithValue("@id", ID);
            
            command.Parameters.Add("@afterImage", System.Data.SqlDbType.VarBinary, 0).Value = AfterImage;
            connection.Open();
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Method to rotate BeforeImage 90 Degrees
        /// </summary>
        public void RotateBefore()
        {
            //Convert Byte array into image object
            ImageFormat imf = GetImageFormat(BeforeName);
            MemoryStream ms = new MemoryStream(BeforeImage);
            Image img = Image.FromStream(ms);

            //Perform Rotation
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);

            //Convert Back to Byte array
            MemoryStream ms2 = new MemoryStream(); //Apparently you can't save PNG files back to the stream they came from.
            img.Save(ms2, imf); //outputs image to memory stream ms2            

            //Save Changes
            BeforeImage = ms2.ToArray();
            UpdateBeforeImage();
        }

        public void RotateAfter()
        {
            //Convert Byte array into image object
            ImageFormat imf = GetImageFormat(AfterName);
            MemoryStream ms = new MemoryStream(AfterImage);
            Image img = Image.FromStream(ms);

            //Perform Rotation
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);

            //Convert Back to Byte array
            MemoryStream ms2 = new MemoryStream(); //Apparently you can't save PNG files back to the stream they came from.
            img.Save(ms2, imf); //outputs image to memory stream ms2            
            AfterImage = ms2.ToArray();

            //Save Changes            
            UpdateAfterImage();
        }

        /// <summary>
        /// Method to convert image byte array into base 64 string representation (for displaying in browser)
        /// </summary>
        /// <param name="imageName"></param>
        /// <param name="image"></param>
        /// <returns></returns>
        public string ConvertImage(string imageName, byte[] image)
        {
            string text = "";
            ImageFormat im = GetImageFormat(imageName);

            using (var ms = new System.IO.MemoryStream(image))
            {
                using (var img = System.Drawing.Image.FromStream(ms))
                {
                    Bitmap bitmap = new Bitmap(img);
                    System.IO.MemoryStream newStream = new MemoryStream(); //PNG files can't be saved back to the stream they came from.
                    bitmap.Save(newStream, im);
                    var base64Data = Convert.ToBase64String(newStream.ToArray());
                    text = "data:image/gif;base64," + base64Data;
                }
            }

            return text;
        }

        public ImageFormat GetImageFormat(string filename)
        {
            string fileExtension = filename.Split('.')[1].ToLowerInvariant();
            switch (fileExtension)
            {
                case "png":
                    return ImageFormat.Png;
                case "gif":
                    return ImageFormat.Gif;
                default:
                    return ImageFormat.Jpeg;
            }
        }

        public string GetBeforeImage()
        {
            return ConvertImage(BeforeName, BeforeImage);
        }

        public string GetAfterImage()
        {
            return ConvertImage(AfterName, AfterImage);
        }

        public void Approve()
        {
            SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            SqlCommand command = new SqlCommand();
            command.Connection = connection;

            command.CommandText = "UPDATE Quality.dbo.two_second_lean "
                                + "SET  approved = 1"
                                + "WHERE id = @id";
            command.Parameters.AddWithValue("@id", ID);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete()
        {
            SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            SqlCommand command = new SqlCommand();
            command.Connection = connection;

            command.CommandText = "DELETE FROM Quality.dbo.two_second_lean "
                                + "WHERE id = @id";
            command.Parameters.AddWithValue("@id", ID);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public string ID { get; set; }
        public string Department { get; set; }
        public DateTime Time { get; set; }
        public string Name { get; set; }
        public string Issue { get; set; }
        public string Change { get; set; }
        public string Benefit { get; set; }

        public byte[] BeforeImage { get; set; }
        public byte[] AfterImage { get; set; }

        public string BeforeName { get; set; }
        public string AfterName { get; set; }

        public bool Approved { get; set; }
    }
}