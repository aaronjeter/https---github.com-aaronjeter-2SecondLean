using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2SecondLean.Models
{
    public class SessionHandler
    {
        public void SetId(string id)
        {
            HttpContext.Current.Session["id"] = id;
        }

        public string GetId()
        {
            string id = "";
            if (HttpContext.Current.Session["id"] != null)
            {
                id = HttpContext.Current.Session["id"].ToString();
            }

            return id;
        }

        public void SetSubmission(Submission sub)
        {
            HttpContext.Current.Session["Submission"] = sub;
        }

        public Submission GetSubmission()
        {
            Submission sub = null;
            if (HttpContext.Current.Session["Submission"] != null)
            {
                sub = (Submission)HttpContext.Current.Session["Submission"];
            }
            return sub;
        }


        #region User Fields

        public string GetEmail()
        {
            string email = null;

            if(HttpContext.Current.Session["email"] != null)
            {
                email = HttpContext.Current.Session["email"].ToString();
            }

            return email;
        }

        public string GetName()
        {
            string name = null;

            if (HttpContext.Current.Session["name"] != null)
            {
                name = HttpContext.Current.Session["name"].ToString();
            }

            return name;
        }

        public string GetRole()
        {
            string role = null;

            if(HttpContext.Current.Session["role"] != null)
            {
                role = HttpContext.Current.Session["role"].ToString();
            }

            return role;
        }

        #endregion
    }
}